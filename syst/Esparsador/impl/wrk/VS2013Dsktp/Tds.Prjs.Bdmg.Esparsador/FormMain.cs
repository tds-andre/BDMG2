using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tds.Prjs.Bdmg.Esparsador.Properties;

namespace Tds.Prjs.Bdmg.Esparsador
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const char csep = '\t';
            const String ssep = "\t";
            StreamReader reader = new StreamReader("C:/_/Projetos/BDMG/syst/Sinais/data/repo/input.csv");
            var header = reader.ReadLine();
            var headers = header.Split(csep).ToList();
            var firstrun = true;
            List<List<String>> lines = new List<List<String>>();
            while (!reader.EndOfStream) {
                var line = reader.ReadLine();
                var fields = line.Split(csep).ToList();
                lines.Add(fields);                
            }
            reader.Close();
            
            var sample = lines[0];
            List<int> indexes = new List<int>();
            for(int i = 0; i < sample.Count; i++){
                Decimal dummy;                
                if (!Decimal.TryParse(sample[i], out dummy)) {
                    indexes.Add(i);
                }
            }

            List<List<String>> dimensions = new List<List<String>>();
            foreach (var index in indexes) {
                dimensions.Add(lines.Select(line => line[index]).Distinct().ToList());
            }

            StreamWriter writer = new StreamWriter("C:/_/Projetos/BDMG/syst/Sinais/data/repo/input.sparsed.csv");
            writer.Write(header);
            foreach (var index in indexes){
                var ix = indexes.IndexOf(index);
                foreach (var dim in dimensions[ix]) {
                    writer.Write(ssep + headers[index] + " - " + dim);
                }
            }
            writer.WriteLine();

            foreach (var line in lines) {
                writer.Write(String.Join(ssep, line));
                foreach (var index in indexes)
                {
                    var ix = indexes.IndexOf(index);
                    var val = line[index];
                    foreach (var dim in dimensions[ix])
                    {
                        if (dim == val) {
                            writer.Write(ssep + "1");
                        }
                        else{
                            writer.Write(ssep + "0");
                        }                        
                    }
                }
                writer.WriteLine();
            }
            writer.Close();


        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Filename = FilenameControl.Text;
            Settings.Default.Save();
        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            //init
            int outputIndex = OutputStartIndexControl.Value;
            string filename = FilenameControl.Text;
            int binCount = (int)BinCountControl.Value;
            char csep;
            if (SeparatorControl.Text == "\\t")
            {
                csep = '\t';
            }
            else
            {
                csep = SeparatorControl.Text[0];
            }
            List<int> NumericFields = null;
            if (NumericFieldsControl.Text.Length > 0)
            {
                NumericFields = NumericFieldsControl.Text.Split(',').Select(el => int.Parse(el.Trim())).ToList();
            }

            //read
            StreamReader reader = new StreamReader(filename);
            var header = reader.ReadLine();
            var headers = header.Split(csep).ToList();
            List<List<String>> lines = new List<List<String>>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var fields = line.Split(csep).ToList();
                lines.Add(fields);
            }
            reader.Close();

            //identify categories
            var sample = lines[0];
            List<int> indexes = new List<int>();
            for (int i = 0; i < sample.Count; i++)
            {
                Decimal dummy;
                if (!Decimal.TryParse(sample[i], out dummy))
                {
                    indexes.Add(i);
                }
            }
            indexes.RemoveAll(el => NumericFields.Contains(el));

            //get categories
            List<List<String>> dimensions = new List<List<String>>();
            foreach (var index in indexes)
            {
                dimensions.Add(lines.Select(line => line[index]).Distinct().ToList());
            }

            //get maxes
            List<decimal> maxes = new List<decimal>();
            foreach (var index in NumericFields)
            {

                maxes.Add(lines.Select(el => el[index]).Where(el => el != "").Select(el => Decimal.Parse(el)).Max());
            }

            //get mins
            List<decimal> mins = new List<decimal>();
            foreach (var index in NumericFields)
            {
                mins.Add(lines.Select(el => el[index]).Where(el => el != "").Select(el => Decimal.Parse(el)).Min());
            }

            //set step
            List<decimal> steps = new List<decimal>();
            for (int i = 0; i < NumericFields.Count; i++)
            {
                steps.Add((maxes[i] - mins[i]) / binCount);
            }

            //write input header            
            StreamWriter writer = new StreamWriter(Path.ChangeExtension(filename, " - input.sparsed.tsv"));
            for (int j = 0; j < headers.Count; j++)
            {
                if (j >= outputIndex) {
                    break;
                }
                var val = headers[j];
                if (indexes.Contains(j))
                {
                    int jx = indexes.IndexOf(j);
                    foreach (var dim in dimensions[jx])
                    {
                        var s = val + " - " + dim + csep;
                        Console.WriteLine(s);
                        writer.Write(s);
                    }
                }
                else if (NumericFields.Contains(j))
                {
                    for (var i = 0; i < binCount; i++)
                    {
                        var s = val + " - " + i.ToString() + csep;
                        Console.WriteLine(s);
                        writer.Write(s);
                    }
                    String ss = val + " - " + "Não Definido" + csep;
                    Console.WriteLine(ss);
                    writer.Write(ss);
                }
                else
                {
                    String ss = val + csep;
                    Console.WriteLine(ss);
                    writer.Write(ss);
                }
                
            }
            writer.WriteLine();

            //write input content
            for (int i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                for (int j = 0; j < line.Count; j++)
                {
                    if (j >= outputIndex)                    
                        break;
                    
                    var val = line[j];

                    //for categories
                    if (indexes.Contains(j))
                    {
                        var jx = indexes.IndexOf(j);
                        foreach (var dim in dimensions[jx])
                        {
                            if (dim == val)
                            {
                                writer.Write("1" + csep);
                            }
                            else
                            {
                                writer.Write("0" + csep);
                            }
                        }
                    }

                    //for discretized
                    else if (NumericFields.Contains(j))
                    {
                        var jx = NumericFields.IndexOf(j);
                        int bin;
                        if (val == "")
                        {
                            bin = binCount;
                        }
                        else
                        {
                            var nval = Decimal.Parse(val);
                            bin = (int)Decimal.Truncate(((nval - mins[jx] - steps[jx] / 10000000) / steps[jx]));
                        }
                        for (int k = 0; k < binCount - 1; k++)
                        {
                            if (k == bin)
                            {
                                writer.Write("1" + csep);
                            }
                            else
                            {
                                writer.Write("0" + csep);
                            }
                        }
                        if (bin == binCount)
                            writer.Write("1" + csep);
                        else
                            writer.Write("0" + csep);
                    }
                    else
                        writer.Write(val + csep);
                }
                writer.WriteLine();
            }
            writer.Close();

            //write output header
            if (outputIndex > -1)
            {
                writer = new StreamWriter(Path.ChangeExtension(filename, " - output.sparsed.tsv"));
                for (int j = outputIndex; j < headers.Count; j++)
                {

                }
            }
        }
      
    }
}
