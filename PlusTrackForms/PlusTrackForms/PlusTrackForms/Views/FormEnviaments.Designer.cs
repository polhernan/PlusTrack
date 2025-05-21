namespace PlusTrackForms.Views
{
    partial class FormEnviaments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEnviaments));
            this.tbFiltre = new System.Windows.Forms.TextBox();
            this.cbFiltre = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bBuscar = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.bEnviaments = new System.Windows.Forms.Button();
            this.bEmpleats = new System.Windows.Forms.Button();
            this.bCamions = new System.Windows.Forms.Button();
            this.bRutes = new System.Windows.Forms.Button();
            this.bPaquets = new System.Windows.Forms.Button();
            this.bUbicacions = new System.Windows.Forms.Button();
            this.flpComandes = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvPackages = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackages)).BeginInit();
            this.SuspendLayout();
            // 
            // tbFiltre
            // 
            this.tbFiltre.Location = new System.Drawing.Point(228, 75);
            this.tbFiltre.Name = "tbFiltre";
            this.tbFiltre.Size = new System.Drawing.Size(223, 20);
            this.tbFiltre.TabIndex = 41;
            this.tbFiltre.TextChanged += new System.EventHandler(this.tbFiltre_TextChanged);
            // 
            // cbFiltre
            // 
            this.cbFiltre.FormattingEnabled = true;
            this.cbFiltre.Location = new System.Drawing.Point(284, 35);
            this.cbFiltre.Name = "cbFiltre";
            this.cbFiltre.Size = new System.Drawing.Size(167, 21);
            this.cbFiltre.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Filtrar per:";
            // 
            // bBuscar
            // 
            this.bBuscar.BackColor = System.Drawing.Color.RoyalBlue;
            this.bBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.bBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBuscar.ForeColor = System.Drawing.Color.White;
            this.bBuscar.Location = new System.Drawing.Point(470, 60);
            this.bBuscar.Name = "bBuscar";
            this.bBuscar.Size = new System.Drawing.Size(95, 35);
            this.bBuscar.TabIndex = 38;
            this.bBuscar.Text = "Buscar";
            this.bBuscar.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.flowLayoutPanel1.Controls.Add(this.bEnviaments);
            this.flowLayoutPanel1.Controls.Add(this.bEmpleats);
            this.flowLayoutPanel1.Controls.Add(this.bCamions);
            this.flowLayoutPanel1.Controls.Add(this.bRutes);
            this.flowLayoutPanel1.Controls.Add(this.bPaquets);
            this.flowLayoutPanel1.Controls.Add(this.bUbicacions);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(210, 521);
            this.flowLayoutPanel1.TabIndex = 37;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // bEnviaments
            // 
            this.bEnviaments.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.bEnviaments.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bEnviaments.FlatAppearance.BorderSize = 0;
            this.bEnviaments.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.bEnviaments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.bEnviaments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bEnviaments.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEnviaments.ForeColor = System.Drawing.Color.White;
            this.bEnviaments.Image = ((System.Drawing.Image)(resources.GetObject("bEnviaments.Image")));
            this.bEnviaments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEnviaments.Location = new System.Drawing.Point(0, 15);
            this.bEnviaments.Margin = new System.Windows.Forms.Padding(0, 15, 15, 15);
            this.bEnviaments.Name = "bEnviaments";
            this.bEnviaments.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.bEnviaments.Size = new System.Drawing.Size(210, 52);
            this.bEnviaments.TabIndex = 17;
            this.bEnviaments.Text = "          Enviaments";
            this.bEnviaments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEnviaments.UseVisualStyleBackColor = false;
            // 
            // bEmpleats
            // 
            this.bEmpleats.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bEmpleats.FlatAppearance.BorderSize = 0;
            this.bEmpleats.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.bEmpleats.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.bEmpleats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bEmpleats.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEmpleats.ForeColor = System.Drawing.Color.White;
            this.bEmpleats.Image = ((System.Drawing.Image)(resources.GetObject("bEmpleats.Image")));
            this.bEmpleats.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEmpleats.Location = new System.Drawing.Point(0, 97);
            this.bEmpleats.Margin = new System.Windows.Forms.Padding(0, 15, 15, 15);
            this.bEmpleats.Name = "bEmpleats";
            this.bEmpleats.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.bEmpleats.Size = new System.Drawing.Size(210, 52);
            this.bEmpleats.TabIndex = 18;
            this.bEmpleats.Text = "          Empleats";
            this.bEmpleats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEmpleats.UseVisualStyleBackColor = true;
            // 
            // bCamions
            // 
            this.bCamions.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bCamions.FlatAppearance.BorderSize = 0;
            this.bCamions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.bCamions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.bCamions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCamions.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCamions.ForeColor = System.Drawing.Color.White;
            this.bCamions.Image = ((System.Drawing.Image)(resources.GetObject("bCamions.Image")));
            this.bCamions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCamions.Location = new System.Drawing.Point(0, 179);
            this.bCamions.Margin = new System.Windows.Forms.Padding(0, 15, 15, 15);
            this.bCamions.Name = "bCamions";
            this.bCamions.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.bCamions.Size = new System.Drawing.Size(210, 52);
            this.bCamions.TabIndex = 19;
            this.bCamions.Text = "          Camions";
            this.bCamions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCamions.UseVisualStyleBackColor = true;
            // 
            // bRutes
            // 
            this.bRutes.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bRutes.FlatAppearance.BorderSize = 0;
            this.bRutes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.bRutes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.bRutes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRutes.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRutes.ForeColor = System.Drawing.Color.White;
            this.bRutes.Image = ((System.Drawing.Image)(resources.GetObject("bRutes.Image")));
            this.bRutes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bRutes.Location = new System.Drawing.Point(0, 261);
            this.bRutes.Margin = new System.Windows.Forms.Padding(0, 15, 15, 15);
            this.bRutes.Name = "bRutes";
            this.bRutes.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.bRutes.Size = new System.Drawing.Size(210, 52);
            this.bRutes.TabIndex = 20;
            this.bRutes.Text = "          Rutes";
            this.bRutes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bRutes.UseVisualStyleBackColor = true;
            // 
            // bPaquets
            // 
            this.bPaquets.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bPaquets.FlatAppearance.BorderSize = 0;
            this.bPaquets.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.bPaquets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.bPaquets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPaquets.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPaquets.ForeColor = System.Drawing.Color.White;
            this.bPaquets.Image = ((System.Drawing.Image)(resources.GetObject("bPaquets.Image")));
            this.bPaquets.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bPaquets.Location = new System.Drawing.Point(0, 343);
            this.bPaquets.Margin = new System.Windows.Forms.Padding(0, 15, 15, 15);
            this.bPaquets.Name = "bPaquets";
            this.bPaquets.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.bPaquets.Size = new System.Drawing.Size(210, 52);
            this.bPaquets.TabIndex = 21;
            this.bPaquets.Text = "          Paquets";
            this.bPaquets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bPaquets.UseVisualStyleBackColor = true;
            // 
            // bUbicacions
            // 
            this.bUbicacions.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bUbicacions.FlatAppearance.BorderSize = 0;
            this.bUbicacions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.bUbicacions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.bUbicacions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bUbicacions.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bUbicacions.ForeColor = System.Drawing.Color.White;
            this.bUbicacions.Image = ((System.Drawing.Image)(resources.GetObject("bUbicacions.Image")));
            this.bUbicacions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bUbicacions.Location = new System.Drawing.Point(0, 425);
            this.bUbicacions.Margin = new System.Windows.Forms.Padding(0, 15, 15, 15);
            this.bUbicacions.Name = "bUbicacions";
            this.bUbicacions.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.bUbicacions.Size = new System.Drawing.Size(210, 52);
            this.bUbicacions.TabIndex = 22;
            this.bUbicacions.Text = "          Ubicacions";
            this.bUbicacions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bUbicacions.UseVisualStyleBackColor = true;
            // 
            // flpComandes
            // 
            this.flpComandes.Location = new System.Drawing.Point(228, 131);
            this.flpComandes.Name = "flpComandes";
            this.flpComandes.Size = new System.Drawing.Size(310, 378);
            this.flpComandes.TabIndex = 42;
            // 
            // dgvPackages
            // 
            this.dgvPackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPackages.Location = new System.Drawing.Point(587, 60);
            this.dgvPackages.Name = "dgvPackages";
            this.dgvPackages.Size = new System.Drawing.Size(324, 446);
            this.dgvPackages.TabIndex = 44;
            // 
            // FormEnviaments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 521);
            this.Controls.Add(this.dgvPackages);
            this.Controls.Add(this.flpComandes);
            this.Controls.Add(this.tbFiltre);
            this.Controls.Add(this.cbFiltre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bBuscar);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEnviaments";
            this.Text = "FormEnviament";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbFiltre;
        public System.Windows.Forms.ComboBox cbFiltre;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button bBuscar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.Button bEnviaments;
        public System.Windows.Forms.Button bEmpleats;
        public System.Windows.Forms.Button bCamions;
        public System.Windows.Forms.Button bRutes;
        public System.Windows.Forms.Button bPaquets;
        public System.Windows.Forms.Button bUbicacions;
        public System.Windows.Forms.FlowLayoutPanel flpComandes;
        public System.Windows.Forms.DataGridView dgvPackages;
    }
}