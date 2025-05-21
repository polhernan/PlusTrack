namespace PlusTrackForms.Views
{
    partial class FormCrearCamio
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
            this.tbMatricula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bCrear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCapacitat = new System.Windows.Forms.TextBox();
            this.bTancar = new System.Windows.Forms.Button();
            this.dtpUltimaITV = new System.Windows.Forms.DateTimePicker();
            this.dtpSeguentITV = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // tbMatricula
            // 
            this.tbMatricula.Location = new System.Drawing.Point(95, 21);
            this.tbMatricula.Name = "tbMatricula";
            this.tbMatricula.Size = new System.Drawing.Size(100, 20);
            this.tbMatricula.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Matricula:";
            // 
            // bCrear
            // 
            this.bCrear.Location = new System.Drawing.Point(111, 168);
            this.bCrear.Name = "bCrear";
            this.bCrear.Size = new System.Drawing.Size(75, 23);
            this.bCrear.TabIndex = 2;
            this.bCrear.Text = "Crear";
            this.bCrear.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Última ITV:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Següent ITV:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Capacitat:";
            // 
            // tbCapacitat
            // 
            this.tbCapacitat.Location = new System.Drawing.Point(95, 131);
            this.tbCapacitat.Name = "tbCapacitat";
            this.tbCapacitat.Size = new System.Drawing.Size(100, 20);
            this.tbCapacitat.TabIndex = 10;
            // 
            // bTancar
            // 
            this.bTancar.Location = new System.Drawing.Point(25, 168);
            this.bTancar.Name = "bTancar";
            this.bTancar.Size = new System.Drawing.Size(75, 23);
            this.bTancar.TabIndex = 11;
            this.bTancar.Text = "Tancar";
            this.bTancar.UseVisualStyleBackColor = true;
            // 
            // dtpUltimaITV
            // 
            this.dtpUltimaITV.Location = new System.Drawing.Point(95, 57);
            this.dtpUltimaITV.Name = "dtpUltimaITV";
            this.dtpUltimaITV.ShowCheckBox = true;
            this.dtpUltimaITV.Size = new System.Drawing.Size(100, 20);
            this.dtpUltimaITV.TabIndex = 12;
            // 
            // dtpSeguentITV
            // 
            this.dtpSeguentITV.Location = new System.Drawing.Point(95, 94);
            this.dtpSeguentITV.Name = "dtpSeguentITV";
            this.dtpSeguentITV.ShowCheckBox = true;
            this.dtpSeguentITV.Size = new System.Drawing.Size(100, 20);
            this.dtpSeguentITV.TabIndex = 13;
            // 
            // FormCrearCamio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 216);
            this.Controls.Add(this.dtpSeguentITV);
            this.Controls.Add(this.dtpUltimaITV);
            this.Controls.Add(this.bTancar);
            this.Controls.Add(this.tbCapacitat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bCrear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMatricula);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCrearCamio";
            this.Text = "FormCrearCamio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tbMatricula;
        public System.Windows.Forms.TextBox tbCapacitat;
        public System.Windows.Forms.Button bCrear;
        public System.Windows.Forms.Button bTancar;
        public System.Windows.Forms.DateTimePicker dtpUltimaITV;
        public System.Windows.Forms.DateTimePicker dtpSeguentITV;
    }
}