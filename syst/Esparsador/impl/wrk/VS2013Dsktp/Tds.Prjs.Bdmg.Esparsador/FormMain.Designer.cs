namespace Tds.Prjs.Bdmg.Esparsador
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BinCountControl = new System.Windows.Forms.NumericUpDown();
            this.NumericFieldsControl = new System.Windows.Forms.TextBox();
            this.FilenameControl = new System.Windows.Forms.TextBox();
            this.ProcessButton = new System.Windows.Forms.Button();
            this.SeparatorControl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OutputStartIndexControl = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BinCountControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputStartIndexControl)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Caminho do arquivo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(473, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Índice dos campos numéricos a serem discretizados (indíce começa em 0, separe-os " +
    "com vírgulas)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Quantidade de bins";
            // 
            // BinCountControl
            // 
            this.BinCountControl.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Tds.Prjs.Bdmg.Esparsador.Properties.Settings.Default, "BinCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.BinCountControl.Location = new System.Drawing.Point(15, 103);
            this.BinCountControl.Name = "BinCountControl";
            this.BinCountControl.Size = new System.Drawing.Size(96, 20);
            this.BinCountControl.TabIndex = 9;
            this.BinCountControl.Value = global::Tds.Prjs.Bdmg.Esparsador.Properties.Settings.Default.BinCount;
            // 
            // NumericFieldsControl
            // 
            this.NumericFieldsControl.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Tds.Prjs.Bdmg.Esparsador.Properties.Settings.Default, "NumericFields", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NumericFieldsControl.Location = new System.Drawing.Point(12, 64);
            this.NumericFieldsControl.Name = "NumericFieldsControl";
            this.NumericFieldsControl.Size = new System.Drawing.Size(473, 20);
            this.NumericFieldsControl.TabIndex = 8;
            this.NumericFieldsControl.Text = global::Tds.Prjs.Bdmg.Esparsador.Properties.Settings.Default.NumericFields;
            // 
            // FilenameControl
            // 
            this.FilenameControl.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Tds.Prjs.Bdmg.Esparsador.Properties.Settings.Default, "Filename", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FilenameControl.Location = new System.Drawing.Point(12, 25);
            this.FilenameControl.Name = "FilenameControl";
            this.FilenameControl.Size = new System.Drawing.Size(473, 20);
            this.FilenameControl.TabIndex = 1;
            this.FilenameControl.Text = global::Tds.Prjs.Bdmg.Esparsador.Properties.Settings.Default.Filename;
            // 
            // ProcessButton
            // 
            this.ProcessButton.Location = new System.Drawing.Point(491, 25);
            this.ProcessButton.Name = "ProcessButton";
            this.ProcessButton.Size = new System.Drawing.Size(77, 97);
            this.ProcessButton.TabIndex = 10;
            this.ProcessButton.Text = "Processar";
            this.ProcessButton.UseVisualStyleBackColor = true;
            this.ProcessButton.Click += new System.EventHandler(this.ProcessButton_Click);
            // 
            // SeparatorControl
            // 
            this.SeparatorControl.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Tds.Prjs.Bdmg.Esparsador.Properties.Settings.Default, "Separator", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SeparatorControl.Location = new System.Drawing.Point(114, 102);
            this.SeparatorControl.Name = "SeparatorControl";
            this.SeparatorControl.Size = new System.Drawing.Size(96, 20);
            this.SeparatorControl.TabIndex = 11;
            this.SeparatorControl.Text = global::Tds.Prjs.Bdmg.Esparsador.Properties.Settings.Default.Separator;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Separador";
            // 
            // OutputStartIndexControl
            // 
            this.OutputStartIndexControl.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Tds.Prjs.Bdmg.Esparsador.Properties.Settings.Default, "OutputIndex", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.OutputStartIndexControl.Location = new System.Drawing.Point(219, 103);
            this.OutputStartIndexControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.OutputStartIndexControl.Name = "OutputStartIndexControl";
            this.OutputStartIndexControl.Size = new System.Drawing.Size(96, 20);
            this.OutputStartIndexControl.TabIndex = 13;
            this.OutputStartIndexControl.Value = global::Tds.Prjs.Bdmg.Esparsador.Properties.Settings.Default.OutputIndex;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(243, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Índici do primeiro campo de saída (-1 para ignorar)";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 139);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OutputStartIndexControl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SeparatorControl);
            this.Controls.Add(this.ProcessButton);
            this.Controls.Add(this.BinCountControl);
            this.Controls.Add(this.NumericFieldsControl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FilenameControl);
            this.Name = "FormMain";
            this.Text = "Esparsador de Dados";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.BinCountControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputStartIndexControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FilenameControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NumericFieldsControl;
        private System.Windows.Forms.NumericUpDown BinCountControl;
        private System.Windows.Forms.Button ProcessButton;
        private System.Windows.Forms.TextBox SeparatorControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown OutputStartIndexControl;
        private System.Windows.Forms.Label label5;
    }
}

