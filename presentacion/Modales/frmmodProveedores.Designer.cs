namespace presentacion.Modales
{
    partial class frmmodProveedores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmmodProveedores));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.btnlimpiarbuscador = new Guna.UI2.WinForms.Guna2Button();
            this.listabuscar = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnbuscarlista = new Guna.UI2.WinForms.Guna2Button();
            this.txtbuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.tablaproveedor = new Guna.UI2.WinForms.Guna2DataGridView();
            this.idproveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaproveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.tablaproveedor);
            this.guna2Panel1.Controls.Add(this.btnlimpiarbuscador);
            this.guna2Panel1.Controls.Add(this.listabuscar);
            this.guna2Panel1.Controls.Add(this.label9);
            this.guna2Panel1.Controls.Add(this.btnbuscarlista);
            this.guna2Panel1.Controls.Add(this.txtbuscar);
            this.guna2Panel1.Controls.Add(this.label16);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(942, 562);
            this.guna2Panel1.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(106)))), ((int)(((byte)(127)))));
            this.label16.Location = new System.Drawing.Point(12, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(219, 29);
            this.label16.TabIndex = 48;
            this.label16.Text = "Lista de Proveedores";
            // 
            // btnlimpiarbuscador
            // 
            this.btnlimpiarbuscador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnlimpiarbuscador.Animated = true;
            this.btnlimpiarbuscador.BackColor = System.Drawing.Color.Transparent;
            this.btnlimpiarbuscador.BorderRadius = 10;
            this.btnlimpiarbuscador.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.btnlimpiarbuscador.CheckedState.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnlimpiarbuscador.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.btnlimpiarbuscador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiarbuscador.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnlimpiarbuscador.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnlimpiarbuscador.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnlimpiarbuscador.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnlimpiarbuscador.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnlimpiarbuscador.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(139)))), ((int)(((byte)(255)))));
            this.btnlimpiarbuscador.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.btnlimpiarbuscador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(122)))), ((int)(((byte)(141)))));
            this.btnlimpiarbuscador.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.btnlimpiarbuscador.HoverState.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnlimpiarbuscador.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.btnlimpiarbuscador.Image = global::presentacion.Properties.Resources.escoba;
            this.btnlimpiarbuscador.ImageSize = new System.Drawing.Size(30, 30);
            this.btnlimpiarbuscador.Location = new System.Drawing.Point(707, 67);
            this.btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            this.btnlimpiarbuscador.PressedColor = System.Drawing.Color.Transparent;
            this.btnlimpiarbuscador.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.btnlimpiarbuscador.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0);
            this.btnlimpiarbuscador.Size = new System.Drawing.Size(59, 48);
            this.btnlimpiarbuscador.TabIndex = 53;
            this.btnlimpiarbuscador.Click += new System.EventHandler(this.btnlimpiarbuscador_Click);
            // 
            // listabuscar
            // 
            this.listabuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listabuscar.BackColor = System.Drawing.Color.Transparent;
            this.listabuscar.BorderRadius = 10;
            this.listabuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listabuscar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listabuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listabuscar.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.listabuscar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.listabuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listabuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.listabuscar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(205)))), ((int)(((byte)(212)))));
            this.listabuscar.ItemHeight = 30;
            this.listabuscar.Location = new System.Drawing.Point(91, 64);
            this.listabuscar.Name = "listabuscar";
            this.listabuscar.Size = new System.Drawing.Size(265, 36);
            this.listabuscar.TabIndex = 49;
            this.listabuscar.Tag = "";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 28);
            this.label9.TabIndex = 52;
            this.label9.Text = "Buscar:";
            // 
            // btnbuscarlista
            // 
            this.btnbuscarlista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbuscarlista.Animated = true;
            this.btnbuscarlista.BackColor = System.Drawing.Color.Transparent;
            this.btnbuscarlista.BorderRadius = 10;
            this.btnbuscarlista.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.btnbuscarlista.CheckedState.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnbuscarlista.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.btnbuscarlista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarlista.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnbuscarlista.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnbuscarlista.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnbuscarlista.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnbuscarlista.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnbuscarlista.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(139)))), ((int)(((byte)(255)))));
            this.btnbuscarlista.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.btnbuscarlista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(122)))), ((int)(((byte)(141)))));
            this.btnbuscarlista.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.btnbuscarlista.HoverState.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnbuscarlista.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.btnbuscarlista.Image = global::presentacion.Properties.Resources.buscar;
            this.btnbuscarlista.ImageSize = new System.Drawing.Size(30, 30);
            this.btnbuscarlista.Location = new System.Drawing.Point(638, 64);
            this.btnbuscarlista.Name = "btnbuscarlista";
            this.btnbuscarlista.PressedColor = System.Drawing.Color.Transparent;
            this.btnbuscarlista.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.btnbuscarlista.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0);
            this.btnbuscarlista.Size = new System.Drawing.Size(59, 48);
            this.btnbuscarlista.TabIndex = 51;
            this.btnbuscarlista.Click += new System.EventHandler(this.btnbuscarlista_Click);
            // 
            // txtbuscar
            // 
            this.txtbuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbuscar.Animated = true;
            this.txtbuscar.BorderRadius = 10;
            this.txtbuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbuscar.DefaultText = "";
            this.txtbuscar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(227)))));
            this.txtbuscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.txtbuscar.DisabledState.ForeColor = System.Drawing.Color.DarkGray;
            this.txtbuscar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(188)))), ((int)(((byte)(198)))));
            this.txtbuscar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.txtbuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtbuscar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(205)))), ((int)(((byte)(212)))));
            this.txtbuscar.Location = new System.Drawing.Point(380, 64);
            this.txtbuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.PasswordChar = '\0';
            this.txtbuscar.PlaceholderText = "Buscar ...";
            this.txtbuscar.SelectedText = "";
            this.txtbuscar.Size = new System.Drawing.Size(229, 48);
            this.txtbuscar.TabIndex = 50;
            // 
            // tablaproveedor
            // 
            this.tablaproveedor.AllowUserToAddRows = false;
            this.tablaproveedor.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablaproveedor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaproveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaproveedor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tablaproveedor.ColumnHeadersHeight = 37;
            this.tablaproveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.tablaproveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idproveedor,
            this.documento,
            this.nombre,
            this.fecha});
            this.tablaproveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablaproveedor.DefaultCellStyle = dataGridViewCellStyle3;
            this.tablaproveedor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablaproveedor.Location = new System.Drawing.Point(17, 183);
            this.tablaproveedor.MultiSelect = false;
            this.tablaproveedor.Name = "tablaproveedor";
            this.tablaproveedor.ReadOnly = true;
            this.tablaproveedor.RowHeadersVisible = false;
            this.tablaproveedor.RowHeadersWidth = 51;
            this.tablaproveedor.RowTemplate.Height = 30;
            this.tablaproveedor.Size = new System.Drawing.Size(913, 367);
            this.tablaproveedor.TabIndex = 54;
            this.tablaproveedor.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.tablaproveedor.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablaproveedor.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.tablaproveedor.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.tablaproveedor.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.tablaproveedor.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.tablaproveedor.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablaproveedor.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.tablaproveedor.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tablaproveedor.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.tablaproveedor.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.tablaproveedor.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.tablaproveedor.ThemeStyle.HeaderStyle.Height = 37;
            this.tablaproveedor.ThemeStyle.ReadOnly = true;
            this.tablaproveedor.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.tablaproveedor.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tablaproveedor.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablaproveedor.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.tablaproveedor.ThemeStyle.RowsStyle.Height = 30;
            this.tablaproveedor.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablaproveedor.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.tablaproveedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaproveedor_CellDoubleClick);
            // 
            // idproveedor
            // 
            this.idproveedor.HeaderText = "id";
            this.idproveedor.MinimumWidth = 6;
            this.idproveedor.Name = "idproveedor";
            this.idproveedor.ReadOnly = true;
            this.idproveedor.Visible = false;
            // 
            // documento
            // 
            this.documento.HeaderText = "RUC";
            this.documento.MinimumWidth = 6;
            this.documento.Name = "documento";
            this.documento.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Razon Social";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha Registrada";
            this.fecha.MinimumWidth = 6;
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // frmmodProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 562);
            this.Controls.Add(this.guna2Panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmmodProveedores";
            this.Text = "Modal Proveedores";
            this.Load += new System.EventHandler(this.frmmodProveedores_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaproveedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label16;
        private Guna.UI2.WinForms.Guna2Button btnlimpiarbuscador;
        private Guna.UI2.WinForms.Guna2ComboBox listabuscar;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2Button btnbuscarlista;
        private Guna.UI2.WinForms.Guna2TextBox txtbuscar;
        private Guna.UI2.WinForms.Guna2DataGridView tablaproveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idproveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
    }
}