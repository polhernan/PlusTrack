namespace PlusTrackForms.Views
{
    partial class CardviewEnviaments
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lId = new System.Windows.Forms.Label();
            this.lRepartidor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lCamio = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bBuscar
            // 
            this.bBuscar.BackColor = System.Drawing.Color.RoyalBlue;
            this.bBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.bBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBuscar.ForeColor = System.Drawing.Color.White;
            this.bBuscar.Location = new System.Drawing.Point(6, 101);
            this.bBuscar.Name = "bBuscar";
            this.bBuscar.Size = new System.Drawing.Size(95, 35);
            this.bBuscar.TabIndex = 39;
            this.bBuscar.Text = "Detalls";
            this.bBuscar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "ID ruta:";
            //this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lId
            // 
            this.lId.AutoSize = true;
            this.lId.Location = new System.Drawing.Point(82, 9);
            this.lId.Name = "lId";
            this.lId.Size = new System.Drawing.Size(33, 13);
            this.lId.TabIndex = 41;
            this.lId.Text = "AA00";
            // 
            // lRepartidor
            // 
            this.lRepartidor.AutoSize = true;
            this.lRepartidor.Location = new System.Drawing.Point(82, 37);
            this.lRepartidor.Name = "lRepartidor";
            this.lRepartidor.Size = new System.Drawing.Size(28, 13);
            this.lRepartidor.TabIndex = 43;
            this.lRepartidor.Text = "AAA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Repartidor:";
            // 
            // lCamio
            // 
            this.lCamio.AutoSize = true;
            this.lCamio.Location = new System.Drawing.Point(82, 68);
            this.lCamio.Name = "lCamio";
            this.lCamio.Size = new System.Drawing.Size(33, 13);
            this.lCamio.TabIndex = 45;
            this.lCamio.Text = "AA00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Camio:";
            // 
            // CardviewEnviaments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lCamio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lRepartidor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bBuscar);
            this.Name = "CardviewEnviaments";
            this.Size = new System.Drawing.Size(309, 169);
            this.Load += new System.EventHandler(this.CardviewEnviaments_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button bBuscar;
        protected System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lId;
        public System.Windows.Forms.Label lRepartidor;
        protected System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lCamio;
        protected System.Windows.Forms.Label label5;
    }
}
