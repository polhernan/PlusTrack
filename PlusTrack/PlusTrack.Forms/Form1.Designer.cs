namespace PlusTrack.Forms
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.siticoneDragForm1 = new SiticoneNetFrameworkUI.SiticoneDragForm();
            this.SuspendLayout();
            // 
            // siticoneDragForm1
            // 
            this.siticoneDragForm1.AccessibleDescription = "A panel that allows dragging the parent form.";
            this.siticoneDragForm1.AccessibleName = "Drag Form Panel";
            this.siticoneDragForm1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.siticoneDragForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.siticoneDragForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.siticoneDragForm1.Enabled = false;
            this.siticoneDragForm1.Location = new System.Drawing.Point(0, 0);
            this.siticoneDragForm1.Name = "siticoneDragForm1";
            this.siticoneDragForm1.Size = new System.Drawing.Size(800, 456);
            this.siticoneDragForm1.TabIndex = 0;
            this.siticoneDragForm1.TabStop = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.siticoneDragForm1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private SiticoneNetFrameworkUI.SiticoneDragForm siticoneDragForm1;
    }
}

