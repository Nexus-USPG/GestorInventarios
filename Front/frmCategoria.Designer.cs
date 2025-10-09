namespace GestorInventarios.Front
{
    partial class frmCategoria
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lstCategorias = new ListBox();
            btnCrear = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(35, 49);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(119, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre de categoría";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(176, 46);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 1;
            // 
            // lstCategorias
            // 
            lstCategorias.FormattingEnabled = true;
            lstCategorias.ItemHeight = 15;
            lstCategorias.Location = new Point(72, 193);
            lstCategorias.Name = "lstCategorias";
            lstCategorias.Size = new Size(295, 139);
            lstCategorias.TabIndex = 2;
            lstCategorias.SelectedIndexChanged += lstCategorias_SelectedIndexChanged;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(35, 104);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(68, 23);
            btnCrear.TabIndex = 3;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(134, 104);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(68, 23);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(225, 104);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(68, 23);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // Categoria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnCrear);
            Controls.Add(lstCategorias);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Name = "Categoria";
            Text = "Categoria";
            Load += Categoria_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private TextBox txtNombre;
        private ListBox lstCategorias;
        private Button btnCrear;
        private Button btnEditar;
        private Button btnEliminar;
    }
}