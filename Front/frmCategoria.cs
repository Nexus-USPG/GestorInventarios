using System;
using System.Linq;
using System.Windows.Forms;
using GestorInventarios.Categorias;

namespace GestorInventarios.Front
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            RefrescarLista();
        }

        private void Categoria_Load(object sender, EventArgs e)
        {
            RefrescarLista();
        }

        
        private void RefrescarLista()
        {
            lstCategorias.DataSource = null;
            lstCategorias.DataSource = Categoria.ObtenerCategorias();
            lstCategorias.DisplayMember = "Nombre"; 
            lstCategorias.ValueMember = "Id";     
        }

       
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    return;

                Categoria.CrearCategoria(txtNombre.Text);
                RefrescarLista();
                txtNombre.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lstCategorias.SelectedItem is Categoria cat)
            {
                try
                {
                    Categoria.EditarCategoria(cat.Id, txtNombre.Text);
                    RefrescarLista();
                    txtNombre.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

  
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstCategorias.SelectedItem is Categoria cat)
            {
                var confirm = MessageBox.Show($"¿Deseas eliminar la categoría '{cat.Nombre}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        Categoria.EliminarCategoria(cat.Id);
                        RefrescarLista();
                        txtNombre.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

       
        private void lstCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCategorias.SelectedItem is Categoria cat)
            {
                txtNombre.Text = cat.Nombre;
            }
        }
    }
}
