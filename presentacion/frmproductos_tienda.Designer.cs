namespace presentacion
{
    partial class frmproductos_tienda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnexportarexcel = new Guna.UI2.WinForms.Guna2Button();
            this.tablaproductostienda = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnseleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idproducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrecategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtallaropa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombretalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idmarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombremarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.temporada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioventa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecharegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtid = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtindice = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblfecha = new System.Windows.Forms.Label();
            this.btnlimpiarbuscador = new Guna.UI2.WinForms.Guna2Button();
            this.listabuscar = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnbuscarlista = new Guna.UI2.WinForms.Guna2Button();
            this.txtbuscar = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tablaproductostienda)).BeginInit();
            this.SuspendLayout();
            // 
            // btnexportarexcel
            // 
            this.btnexportarexcel.Animated = true;
            this.btnexportarexcel.BackColor = System.Drawing.Color.Transparent;
            this.btnexportarexcel.BorderRadius = 10;
            this.btnexportarexcel.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.btnexportarexcel.CheckedState.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnexportarexcel.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.btnexportarexcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexportarexcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnexportarexcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnexportarexcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnexportarexcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnexportarexcel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(250)))), ((int)(((byte)(223)))));
            this.btnexportarexcel.FocusedColor = System.Drawing.Color.Transparent;
            this.btnexportarexcel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexportarexcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(221)))), ((int)(((byte)(55)))));
            this.btnexportarexcel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(250)))), ((int)(((byte)(223)))));
            this.btnexportarexcel.HoverState.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnexportarexcel.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(221)))), ((int)(((byte)(55)))));
            this.btnexportarexcel.Image = global::presentacion.Properties.Resources.sobresalir;
            this.btnexportarexcel.ImageSize = new System.Drawing.Size(30, 30);
            this.btnexportarexcel.Location = new System.Drawing.Point(838, 83);
            this.btnexportarexcel.Name = "btnexportarexcel";
            this.btnexportarexcel.PressedColor = System.Drawing.Color.Transparent;
            this.btnexportarexcel.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.btnexportarexcel.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0);
            this.btnexportarexcel.Size = new System.Drawing.Size(159, 55);
            this.btnexportarexcel.TabIndex = 77;
            this.btnexportarexcel.Text = "  EXCEL";
            this.btnexportarexcel.Click += new System.EventHandler(this.btnexportarexcel_Click);
            // 
            // tablaproductostienda
            // 
            this.tablaproductostienda.AllowUserToAddRows = false;
            this.tablaproductostienda.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablaproductostienda.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.tablaproductostienda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaproductostienda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaproductostienda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.tablaproductostienda.ColumnHeadersHeight = 30;
            this.tablaproductostienda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnseleccionar,
            this.idproducto,
            this.codigo,
            this.nombre,
            this.descripcion,
            this.idcategoria,
            this.nombrecategoria,
            this.idtallaropa,
            this.nombretalla,
            this.idmarca,
            this.nombremarca,
            this.stock,
            this.colores,
            this.temporada,
            this.precioventa,
            this.descuento,
            this.total,
            this.fecharegistro});
            this.tablaproductostienda.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablaproductostienda.DefaultCellStyle = dataGridViewCellStyle6;
            this.tablaproductostienda.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablaproductostienda.Location = new System.Drawing.Point(14, 161);
            this.tablaproductostienda.MultiSelect = false;
            this.tablaproductostienda.Name = "tablaproductostienda";
            this.tablaproductostienda.ReadOnly = true;
            this.tablaproductostienda.RowHeadersVisible = false;
            this.tablaproductostienda.RowHeadersWidth = 51;
            this.tablaproductostienda.RowTemplate.Height = 30;
            this.tablaproductostienda.Size = new System.Drawing.Size(1452, 500);
            this.tablaproductostienda.TabIndex = 76;
            this.tablaproductostienda.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.tablaproductostienda.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablaproductostienda.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.tablaproductostienda.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.tablaproductostienda.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.tablaproductostienda.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.tablaproductostienda.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablaproductostienda.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.tablaproductostienda.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tablaproductostienda.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.tablaproductostienda.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.tablaproductostienda.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tablaproductostienda.ThemeStyle.HeaderStyle.Height = 30;
            this.tablaproductostienda.ThemeStyle.ReadOnly = true;
            this.tablaproductostienda.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.tablaproductostienda.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tablaproductostienda.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablaproductostienda.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.tablaproductostienda.ThemeStyle.RowsStyle.Height = 30;
            this.tablaproductostienda.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablaproductostienda.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.tablaproductostienda.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.tablaproductostienda_CellFormatting);
            this.tablaproductostienda.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.tablaproductostienda_CellPainting);
            // 
            // btnseleccionar
            // 
            this.btnseleccionar.FillWeight = 60.96258F;
            this.btnseleccionar.HeaderText = "Seleccionar";
            this.btnseleccionar.MinimumWidth = 6;
            this.btnseleccionar.Name = "btnseleccionar";
            this.btnseleccionar.ReadOnly = true;
            this.btnseleccionar.Width = 104;
            // 
            // idproducto
            // 
            this.idproducto.FillWeight = 60.96258F;
            this.idproducto.HeaderText = "idproducto";
            this.idproducto.MinimumWidth = 6;
            this.idproducto.Name = "idproducto";
            this.idproducto.ReadOnly = true;
            this.idproducto.Visible = false;
            this.idproducto.Width = 122;
            // 
            // codigo
            // 
            this.codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codigo.FillWeight = 60.96258F;
            this.codigo.HeaderText = "Codigo";
            this.codigo.MinimumWidth = 6;
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Width = 92;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nombre.HeaderText = "Nombre Producto";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 176;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.descripcion.FillWeight = 60.96258F;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.MinimumWidth = 6;
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 129;
            // 
            // idcategoria
            // 
            this.idcategoria.HeaderText = "idcategoria";
            this.idcategoria.MinimumWidth = 6;
            this.idcategoria.Name = "idcategoria";
            this.idcategoria.ReadOnly = true;
            this.idcategoria.Visible = false;
            this.idcategoria.Width = 123;
            // 
            // nombrecategoria
            // 
            this.nombrecategoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nombrecategoria.FillWeight = 60.96258F;
            this.nombrecategoria.HeaderText = "Categoria";
            this.nombrecategoria.MinimumWidth = 6;
            this.nombrecategoria.Name = "nombrecategoria";
            this.nombrecategoria.ReadOnly = true;
            this.nombrecategoria.Width = 112;
            // 
            // idtallaropa
            // 
            this.idtallaropa.FillWeight = 60.96258F;
            this.idtallaropa.HeaderText = "idtallaropa";
            this.idtallaropa.MinimumWidth = 6;
            this.idtallaropa.Name = "idtallaropa";
            this.idtallaropa.ReadOnly = true;
            this.idtallaropa.Visible = false;
            this.idtallaropa.Width = 118;
            // 
            // nombretalla
            // 
            this.nombretalla.FillWeight = 60.96258F;
            this.nombretalla.HeaderText = "Talla";
            this.nombretalla.MinimumWidth = 6;
            this.nombretalla.Name = "nombretalla";
            this.nombretalla.ReadOnly = true;
            this.nombretalla.Width = 71;
            // 
            // idmarca
            // 
            this.idmarca.FillWeight = 60.96258F;
            this.idmarca.HeaderText = "idmarca";
            this.idmarca.MinimumWidth = 6;
            this.idmarca.Name = "idmarca";
            this.idmarca.ReadOnly = true;
            this.idmarca.Visible = false;
            this.idmarca.Width = 98;
            // 
            // nombremarca
            // 
            this.nombremarca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nombremarca.FillWeight = 60.96258F;
            this.nombremarca.HeaderText = "Marca";
            this.nombremarca.MinimumWidth = 6;
            this.nombremarca.Name = "nombremarca";
            this.nombremarca.ReadOnly = true;
            this.nombremarca.Width = 83;
            // 
            // stock
            // 
            this.stock.FillWeight = 60.96258F;
            this.stock.HeaderText = "Stock";
            this.stock.MinimumWidth = 6;
            this.stock.Name = "stock";
            this.stock.ReadOnly = true;
            this.stock.Width = 81;
            // 
            // colores
            // 
            this.colores.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colores.FillWeight = 60.96258F;
            this.colores.HeaderText = "Color";
            this.colores.MinimumWidth = 6;
            this.colores.Name = "colores";
            this.colores.ReadOnly = true;
            this.colores.Width = 79;
            // 
            // temporada
            // 
            this.temporada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.temporada.FillWeight = 60.96258F;
            this.temporada.HeaderText = "Temporada";
            this.temporada.MinimumWidth = 6;
            this.temporada.Name = "temporada";
            this.temporada.ReadOnly = true;
            this.temporada.Width = 123;
            // 
            // precioventa
            // 
            this.precioventa.FillWeight = 60.96258F;
            this.precioventa.HeaderText = "Precio";
            this.precioventa.MinimumWidth = 6;
            this.precioventa.Name = "precioventa";
            this.precioventa.ReadOnly = true;
            this.precioventa.Width = 86;
            // 
            // descuento
            // 
            this.descuento.FillWeight = 60.96258F;
            this.descuento.HeaderText = "Descuento";
            this.descuento.MinimumWidth = 6;
            this.descuento.Name = "descuento";
            this.descuento.ReadOnly = true;
            this.descuento.Width = 120;
            // 
            // total
            // 
            this.total.FillWeight = 60.96258F;
            this.total.HeaderText = "Total";
            this.total.MinimumWidth = 6;
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 74;
            // 
            // fecharegistro
            // 
            this.fecharegistro.FillWeight = 60.96258F;
            this.fecharegistro.HeaderText = "Fecha Registrada";
            this.fecharegistro.MinimumWidth = 6;
            this.fecharegistro.Name = "fecharegistro";
            this.fecharegistro.ReadOnly = true;
            this.fecharegistro.Width = 173;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(172)))), ((int)(((byte)(184)))));
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 24);
            this.label2.TabIndex = 75;
            this.label2.Text = "productos que tienes en stock";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(106)))), ((int)(((byte)(127)))));
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 29);
            this.label1.TabIndex = 74;
            this.label1.Text = "Productos en tienda";
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
            this.txtid.Location = new System.Drawing.Point(328, 15);
            this.txtid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtid.Name = "txtid";
            this.txtid.PasswordChar = '\0';
            this.txtid.PlaceholderText = "";
            this.txtid.SelectedText = "";
            this.txtid.Size = new System.Drawing.Size(30, 29);
            this.txtid.TabIndex = 73;
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
            this.txtindice.Location = new System.Drawing.Point(279, 15);
            this.txtindice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtindice.Name = "txtindice";
            this.txtindice.PasswordChar = '\0';
            this.txtindice.PlaceholderText = "";
            this.txtindice.SelectedText = "";
            this.txtindice.Size = new System.Drawing.Size(41, 29);
            this.txtindice.TabIndex = 72;
            this.txtindice.Visible = false;
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Location = new System.Drawing.Point(382, 18);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(40, 16);
            this.lblfecha.TabIndex = 71;
            this.lblfecha.Text = "fecha";
            this.lblfecha.Visible = false;
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
            this.btnlimpiarbuscador.Location = new System.Drawing.Point(1407, 18);
            this.btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            this.btnlimpiarbuscador.PressedColor = System.Drawing.Color.Transparent;
            this.btnlimpiarbuscador.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.btnlimpiarbuscador.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0);
            this.btnlimpiarbuscador.Size = new System.Drawing.Size(59, 48);
            this.btnlimpiarbuscador.TabIndex = 70;
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
            this.listabuscar.Location = new System.Drawing.Point(791, 15);
            this.listabuscar.Name = "listabuscar";
            this.listabuscar.Size = new System.Drawing.Size(265, 36);
            this.listabuscar.TabIndex = 66;
            this.listabuscar.Tag = "";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(712, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 28);
            this.label9.TabIndex = 69;
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
            this.btnbuscarlista.Location = new System.Drawing.Point(1338, 15);
            this.btnbuscarlista.Name = "btnbuscarlista";
            this.btnbuscarlista.PressedColor = System.Drawing.Color.Transparent;
            this.btnbuscarlista.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.btnbuscarlista.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0);
            this.btnbuscarlista.Size = new System.Drawing.Size(59, 48);
            this.btnbuscarlista.TabIndex = 68;
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
            this.txtbuscar.Location = new System.Drawing.Point(1080, 15);
            this.txtbuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.PasswordChar = '\0';
            this.txtbuscar.PlaceholderText = "Buscar ...";
            this.txtbuscar.SelectedText = "";
            this.txtbuscar.Size = new System.Drawing.Size(229, 48);
            this.txtbuscar.TabIndex = 67;
            // 
            // frmproductos_tienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1479, 676);
            this.Controls.Add(this.btnexportarexcel);
            this.Controls.Add(this.tablaproductostienda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.txtindice);
            this.Controls.Add(this.lblfecha);
            this.Controls.Add(this.btnlimpiarbuscador);
            this.Controls.Add(this.listabuscar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnbuscarlista);
            this.Controls.Add(this.txtbuscar);
            this.Name = "frmproductos_tienda";
            this.Text = "frmproductos_tienda";
            this.Load += new System.EventHandler(this.frmproductos_tienda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaproductostienda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnexportarexcel;
        private Guna.UI2.WinForms.Guna2DataGridView tablaproductostienda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtid;
        private Guna.UI2.WinForms.Guna2TextBox txtindice;
        private System.Windows.Forms.Label lblfecha;
        private Guna.UI2.WinForms.Guna2Button btnlimpiarbuscador;
        private Guna.UI2.WinForms.Guna2ComboBox listabuscar;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2Button btnbuscarlista;
        private Guna.UI2.WinForms.Guna2TextBox txtbuscar;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idproducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtallaropa;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombretalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombremarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colores;
        private System.Windows.Forms.DataGridViewTextBoxColumn temporada;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioventa;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecharegistro;
    }
}