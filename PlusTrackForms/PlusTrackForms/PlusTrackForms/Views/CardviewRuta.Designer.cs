namespace PlusTrackForms.Views
{
    partial class CardviewRuta
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
            this.label2 = new System.Windows.Forms.Label();
            this.lConductor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lCamio = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Conductor:";
            // 
            // lConductor
            // 
            this.lConductor.AutoSize = true;
            this.lConductor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lConductor.ForeColor = System.Drawing.Color.White;
            this.lConductor.Location = new System.Drawing.Point(3, 30);
            this.lConductor.Name = "lConductor";
            this.lConductor.Size = new System.Drawing.Size(21, 20);
            this.lConductor.TabIndex = 2;
            this.lConductor.Text = "A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Camio:";
            // 
            // lCamio
            // 
            this.lCamio.AutoSize = true;
            this.lCamio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCamio.ForeColor = System.Drawing.Color.White;
            this.lCamio.Location = new System.Drawing.Point(3, 81);
            this.lCamio.Name = "lCamio";
            this.lCamio.Size = new System.Drawing.Size(19, 20);
            this.lCamio.TabIndex = 4;
            this.lCamio.Text = "0";
            // 
            // CardviewRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.Controls.Add(this.lCamio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lConductor);
            this.Controls.Add(this.label2);
            this.Name = "CardviewRuta";
            this.Size = new System.Drawing.Size(223, 114);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lConductor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lCamio;
    }
}
