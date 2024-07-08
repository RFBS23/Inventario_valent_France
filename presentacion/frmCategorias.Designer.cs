namespace presentacion
{
    partial class frmCategorias
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
            this.panelcategorias = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnombrecategoria = new Guna.UI2.WinForms.Guna2TextBox();
            this.tablacategorias = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnseleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idcategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrecategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorestado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecharegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnlimpiarbuscador = new Guna.UI2.WinForms.Guna2Button();
            this.listabuscar = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnbuscarlista = new Guna.UI2.WinForms.Guna2Button();
            this.txtbuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            this.btnLimpiar = new Guna.UI2.WinForms.Guna2Button();
            this.btnAgregar = new Guna.UI2.WinForms.Guna2Button();
            this.cbestado = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblfecha = new System.Windows.Forms.Label();
            this.txtid = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtindice = new Guna.UI2.WinForms.Guna2TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panelcategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablacategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // panelcategorias
            // 
            this.panelcategorias.BackColor = System.Drawing.SystemColors.Control;
            this.panelcategorias.Controls.Add(this.label10);
            this.panelcategorias.Controls.Add(this.label2);
            this.panelcategorias.Controls.Add(this.txtnombrecategoria);
            this.panelcategorias.Controls.Add(this.tablacategorias);
            this.panelcategorias.Controls.Add(this.btnlimpiarbuscador);
            this.panelcategorias.Controls.Add(this.listabuscar);
            this.panelcategorias.Controls.Add(this.label9);
            this.panelcategorias.Controls.Add(this.btnbuscarlista);
            this.panelcategorias.Controls.Add(this.txtbuscar);
            this.panelcategorias.Controls.Add(this.btnEliminar);
            this.panelcategorias.Controls.Add(this.btnLimpiar);
            this.panelcategorias.Controls.Add(this.btnAgregar);
            this.panelcategorias.Controls.Add(this.cbestado);
            this.panelcategorias.Controls.Add(this.label6);
            this.panelcategorias.Controls.Add(this.lblfecha);
            this.panelcategorias.Controls.Add(this.txtid);
            this.panelcategorias.Controls.Add(this.txtindice);
            this.panelcategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelcategorias.Location = new System.Drawing.Point(0, 0);
            this.panelcategorias.Name = "panelcategorias";
            this.panelcategorias.Size = new System.Drawing.Size(1479, 676);
            this.panelcategorias.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 20);
            this.label2.TabIndex = 50;
            this.label2.Text = "Nombre de Categoria";
            // 
            // txtnombrecategoria
            // 
            this.txtnombrecategoria.Animated = true;
            this.txtnombrecategoria.BorderRadius = 10;
            this.txtnombrecategoria.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtnombrecategoria.DefaultText = "";
            this.txtnombrecategoria.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(227)))));
            this.txtnombrecategoria.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.txtnombrecategoria.DisabledState.ForeColor = System.Drawing.Color.DarkGray;
            this.txtnombrecategoria.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(188)))), ((int)(((byte)(198)))));
            this.txtnombrecategoria.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.txtnombrecategoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtnombrecategoria.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(205)))), ((int)(((byte)(212)))));
            this.txtnombrecategoria.Location = new System.Drawing.Point(30, 143);
            this.txtnombrecategoria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtnombrecategoria.Name = "txtnombrecategoria";
            this.txtnombrecategoria.PasswordChar = '\0';
            this.txtnombrecategoria.PlaceholderText = "Categoria";
            this.txtnombrecategoria.SelectedText = "";
            this.txtnombrecategoria.Size = new System.Drawing.Size(339, 48);
            this.txtnombrecategoria.TabIndex = 49;
            // 
            // tablacategorias
            // 
            this.tablacategorias.AllowUserToAddRows = false;
            this.tablacategorias.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablacategorias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tablacategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablacategorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tablacategorias.ColumnHeadersHeight = 37;
            this.tablacategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.tablacategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnseleccionar,
            this.idcategoria,
            this.nombrecategoria,
            this.valorestado,
            this.estado,
            this.fecharegistro});
            this.tablacategorias.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablacategorias.DefaultCellStyle = dataGridViewCellStyle3;
            this.tablacategorias.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablacategorias.Location = new System.Drawing.Point(12, 297);
            this.tablacategorias.MultiSelect = false;
            this.tablacategorias.Name = "tablacategorias";
            this.tablacategorias.ReadOnly = true;
            this.tablacategorias.RowHeadersVisible = false;
            this.tablacategorias.RowHeadersWidth = 51;
            this.tablacategorias.RowTemplate.Height = 30;
            this.tablacategorias.Size = new System.Drawing.Size(1455, 367);
            this.tablacategorias.TabIndex = 48;
            this.tablacategorias.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.tablacategorias.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablacategorias.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.tablacategorias.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.tablacategorias.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.tablacategorias.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.tablacategorias.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablacategorias.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.tablacategorias.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tablacategorias.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.tablacategorias.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.tablacategorias.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.tablacategorias.ThemeStyle.HeaderStyle.Height = 37;
            this.tablacategorias.ThemeStyle.ReadOnly = true;
            this.tablacategorias.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.tablacategorias.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tablacategorias.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablacategorias.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.tablacategorias.ThemeStyle.RowsStyle.Height = 30;
            this.tablacategorias.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablacategorias.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.tablacategorias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablacategorias_CellContentClick);
            this.tablacategorias.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.tablacategorias_CellPainting);
            // 
            // btnseleccionar
            // 
            this.btnseleccionar.HeaderText = "Seleccionar";
            this.btnseleccionar.MinimumWidth = 6;
            this.btnseleccionar.Name = "btnseleccionar";
            this.btnseleccionar.ReadOnly = true;
            // 
            // idcategoria
            // 
            this.idcategoria.HeaderText = "idcategoria";
            this.idcategoria.MinimumWidth = 6;
            this.idcategoria.Name = "idcategoria";
            this.idcategoria.ReadOnly = true;
            this.idcategoria.Visible = false;
            // 
            // nombrecategoria
            // 
            this.nombrecategoria.HeaderText = "Nombre de categoria";
            this.nombrecategoria.MinimumWidth = 6;
            this.nombrecategoria.Name = "nombrecategoria";
            this.nombrecategoria.ReadOnly = true;
            // 
            // valorestado
            // 
            this.valorestado.HeaderText = "ValorEstado";
            this.valorestado.MinimumWidth = 6;
            this.valorestado.Name = "valorestado";
            this.valorestado.ReadOnly = true;
            this.valorestado.Visible = false;
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.MinimumWidth = 6;
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            // 
            // fecharegistro
            // 
            this.fecharegistro.HeaderText = "Fecha Registrada";
            this.fecharegistro.MinimumWidth = 6;
            this.fecharegistro.Name = "fecharegistro";
            this.fecharegistro.ReadOnly = true;
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
            this.btnlimpiarbuscador.Location = new System.Drawing.Point(1408, 22);
            this.btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            this.btnlimpiarbuscador.PressedColor = System.Drawing.Color.Transparent;
            this.btnlimpiarbuscador.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.btnlimpiarbuscador.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0);
            this.btnlimpiarbuscador.Size = new System.Drawing.Size(59, 48);
            this.btnlimpiarbuscador.TabIndex = 47;
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
            this.listabuscar.Location = new System.Drawing.Point(792, 19);
            this.listabuscar.Name = "listabuscar";
            this.listabuscar.Size = new System.Drawing.Size(265, 36);
            this.listabuscar.TabIndex = 43;
            this.listabuscar.Tag = "";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(713, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 28);
            this.label9.TabIndex = 46;
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
            this.btnbuscarlista.Location = new System.Drawing.Point(1339, 19);
            this.btnbuscarlista.Name = "btnbuscarlista";
            this.btnbuscarlista.PressedColor = System.Drawing.Color.Transparent;
            this.btnbuscarlista.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.btnbuscarlista.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0);
            this.btnbuscarlista.Size = new System.Drawing.Size(59, 48);
            this.btnbuscarlista.TabIndex = 45;
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
            this.txtbuscar.Location = new System.Drawing.Point(1081, 19);
            this.txtbuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.PasswordChar = '\0';
            this.txtbuscar.PlaceholderText = "Buscar ...";
            this.txtbuscar.SelectedText = "";
            this.txtbuscar.Size = new System.Drawing.Size(229, 48);
            this.txtbuscar.TabIndex = 44;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Animated = true;
            this.btnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.BorderRadius = 10;
            this.btnEliminar.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.btnEliminar.CheckedState.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEliminar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEliminar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEliminar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEliminar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(62)))), ((int)(((byte)(29)))));
            this.btnEliminar.FocusedColor = System.Drawing.Color.Transparent;
            this.btnEliminar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.btnEliminar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(56)))), ((int)(((byte)(26)))));
            this.btnEliminar.HoverState.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.btnEliminar.Image = global::presentacion.Properties.Resources.compartimiento;
            this.btnEliminar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnEliminar.ImageSize = new System.Drawing.Size(30, 30);
            this.btnEliminar.Location = new System.Drawing.Point(1302, 143);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.PressedColor = System.Drawing.Color.Transparent;
            this.btnEliminar.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.btnEliminar.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0);
            this.btnEliminar.Size = new System.Drawing.Size(165, 48);
            this.btnEliminar.TabIndex = 42;
            this.btnEliminar.Text = "    Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Animated = true;
            this.btnLimpiar.BackColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.BorderRadius = 10;
            this.btnLimpiar.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.btnLimpiar.CheckedState.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLimpiar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLimpiar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLimpiar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLimpiar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.btnLimpiar.FocusedColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btnLimpiar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(97)))), ((int)(((byte)(230)))));
            this.btnLimpiar.HoverState.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(248)))));
            this.btnLimpiar.Image = global::presentacion.Properties.Resources.escoba;
            this.btnLimpiar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLimpiar.ImageSize = new System.Drawing.Size(30, 30);
            this.btnLimpiar.Location = new System.Drawing.Point(1083, 143);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.PressedColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.btnLimpiar.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0);
            this.btnLimpiar.Size = new System.Drawing.Size(188, 48);
            this.btnLimpiar.TabIndex = 41;
            this.btnLimpiar.Text = "    Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Animated = true;
            this.btnAgregar.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregar.BorderRadius = 10;
            this.btnAgregar.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.btnAgregar.CheckedState.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAgregar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAgregar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAgregar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAgregar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.btnAgregar.FocusedColor = System.Drawing.Color.Transparent;
            this.btnAgregar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.btnAgregar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(97)))), ((int)(((byte)(230)))));
            this.btnAgregar.HoverState.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.btnAgregar.Image = global::presentacion.Properties.Resources.agregar_usuario;
            this.btnAgregar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAgregar.ImageSize = new System.Drawing.Size(30, 30);
            this.btnAgregar.Location = new System.Drawing.Point(883, 143);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.PressedColor = System.Drawing.Color.Transparent;
            this.btnAgregar.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.btnAgregar.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0);
            this.btnAgregar.Size = new System.Drawing.Size(165, 48);
            this.btnAgregar.TabIndex = 40;
            this.btnAgregar.Text = "    Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cbestado
            // 
            this.cbestado.BackColor = System.Drawing.Color.Transparent;
            this.cbestado.BorderRadius = 10;
            this.cbestado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbestado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbestado.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.cbestado.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.cbestado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbestado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbestado.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(205)))), ((int)(((byte)(212)))));
            this.cbestado.ItemHeight = 30;
            this.cbestado.Location = new System.Drawing.Point(512, 143);
            this.cbestado.Name = "cbestado";
            this.cbestado.Size = new System.Drawing.Size(265, 36);
            this.cbestado.TabIndex = 39;
            this.cbestado.Tag = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(508, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 38;
            this.label6.Text = "Estado";
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Location = new System.Drawing.Point(398, 22);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(40, 16);
            this.lblfecha.TabIndex = 35;
            this.lblfecha.Text = "fecha";
            this.lblfecha.Visible = false;
            // 
            // txtid
            // 
            this.txtid.BorderRadius = 10;
            this.txtid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtid.DefaultText = "0";
            this.txtid.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtid.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtid.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtid.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtid.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtid.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtid.Location = new System.Drawing.Point(339, 22);
            this.txtid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtid.Name = "txtid";
            this.txtid.PasswordChar = '\0';
            this.txtid.PlaceholderText = "";
            this.txtid.SelectedText = "";
            this.txtid.Size = new System.Drawing.Size(30, 29);
            this.txtid.TabIndex = 34;
            this.txtid.Visible = false;
            // 
            // txtindice
            // 
            this.txtindice.BorderRadius = 8;
            this.txtindice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtindice.DefaultText = "-1";
            this.txtindice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtindice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtindice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtindice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtindice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtindice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtindice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtindice.Location = new System.Drawing.Point(290, 22);
            this.txtindice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtindice.Name = "txtindice";
            this.txtindice.PasswordChar = '\0';
            this.txtindice.PlaceholderText = "";
            this.txtindice.SelectedText = "";
            this.txtindice.Size = new System.Drawing.Size(41, 29);
            this.txtindice.TabIndex = 33;
            this.txtindice.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(106)))), ((int)(((byte)(127)))));
            this.label10.Location = new System.Drawing.Point(12, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(229, 29);
            this.label10.TabIndex = 51;
            this.label10.Text = "Agrega tus categorias";
            // 
            // frmCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1479, 676);
            this.Controls.Add(this.panelcategorias);
            this.Name = "frmCategorias";
            this.Text = "frmCategorias";
            this.Load += new System.EventHandler(this.frmCategorias_Load);
            this.panelcategorias.ResumeLayout(false);
            this.panelcategorias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablacategorias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelcategorias;
        private System.Windows.Forms.Label lblfecha;
        private Guna.UI2.WinForms.Guna2TextBox txtid;
        private Guna.UI2.WinForms.Guna2TextBox txtindice;
        private Guna.UI2.WinForms.Guna2Button btnEliminar;
        private Guna.UI2.WinForms.Guna2Button btnLimpiar;
        private Guna.UI2.WinForms.Guna2Button btnAgregar;
        private Guna.UI2.WinForms.Guna2ComboBox cbestado;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button btnlimpiarbuscador;
        private Guna.UI2.WinForms.Guna2ComboBox listabuscar;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2Button btnbuscarlista;
        private Guna.UI2.WinForms.Guna2TextBox txtbuscar;
        private Guna.UI2.WinForms.Guna2DataGridView tablacategorias;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorestado;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecharegistro;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtnombrecategoria;
        private System.Windows.Forms.Label label10;
    }
}