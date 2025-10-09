using System;
using System.Linq;
using System.Windows.Forms;
using GestorInventarios.Models;
using GestorInventarios.Services;
using System.Drawing;

namespace GestorInventarios.Front
{
    public partial class frmProductos : Form
    {
        private int? productoIdEnEdicion = null;

        public frmProductos()
        {
            InitializeComponent();
            CargarCategoriasAComboBox();
            ConfigurarDGV();
            RefrescarListaProductos();
            EstablecerModoCreacion();
        }

        private void CargarCategoriasAComboBox()
        {
            var categorias = CategoriaService.ObtenerCategorias();
            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "Id";
            if (categorias != null && categorias.Any())
            {
                cmbCategoria.SelectedIndex = -1;
            }
        }

        private void RefrescarListaProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = ProductoService.ObtenerProductos();
            if (dgvProductos.Columns.Contains("CantidadInicial"))
            {
                dgvProductos.Columns["CantidadInicial"].Visible = false;
            }
        }

        private void ConfigurarDGV()
        {
            dgvProductos.AutoGenerateColumns = true;

            if (!dgvProductos.Columns.Contains("btnEditar"))
            {
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.HeaderText = "Editar";
                btnEditar.Text = "Editar";
                btnEditar.Name = "btnEditar";
                btnEditar.UseColumnTextForButtonValue = true;
                dgvProductos.Columns.Add(btnEditar);
            }

            if (!dgvProductos.Columns.Contains("btnEliminar"))
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.HeaderText = "Eliminar";
                btnEliminar.Text = "Eliminar";
                btnEliminar.Name = "btnEliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                dgvProductos.Columns.Add(btnEliminar);
            }

            dgvProductos.CellContentClick += dgvProductos_CellContentClick;
        }

        private void EstablecerModoCreacion()
        {
            productoIdEnEdicion = null;
            btnCrear.Text = "Crear Producto";
            txtNombre.Clear();
            txtPrecio.Clear();
            txtCantidadInicial.Clear();
            cmbCategoria.SelectedIndex = -1;
            txtCantidadInicial.Enabled = true;
            this.Text = "Gestión de Productos - Creación";
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !(dgvProductos.Columns[e.ColumnIndex] is DataGridViewButtonColumn))
                return;

            Producto productoSeleccionado = dgvProductos.Rows[e.RowIndex].DataBoundItem as Producto;
            if (productoSeleccionado == null) return;

            string nombreColumna = dgvProductos.Columns[e.ColumnIndex].Name;

            try
            {
                if (nombreColumna == "btnEliminar")
                {
                    if (MessageBox.Show($"¿Desea eliminar '{productoSeleccionado.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ProductoService.EliminarProducto(productoSeleccionado.Id);
                        RefrescarListaProductos();
                        MessageBox.Show("Producto eliminado.", "Éxito");
                        EstablecerModoCreacion();
                    }
                }
                else if (nombreColumna == "btnEditar")
                {
                    txtNombre.Text = productoSeleccionado.Nombre;
                    txtPrecio.Text = productoSeleccionado.PrecioUnitario.ToString();
                    txtCantidadInicial.Text = productoSeleccionado.CantidadInicial.ToString();

                    productoIdEnEdicion = productoSeleccionado.Id;
                    btnCrear.Text = "Guardar Cambios";
                    txtCantidadInicial.Enabled = false;

                    if (productoSeleccionado.Categoria != null)
                    {
                        cmbCategoria.SelectedValue = productoSeleccionado.Categoria.Id;
                    }
                    this.Text = "Gestión de Productos - Editando: " + productoSeleccionado.Nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategoria.SelectedItem == null) throw new Exception("Debe seleccionar una categoría.");
                if (!decimal.TryParse(txtPrecio.Text, out decimal precio)) throw new Exception("Precio no válido.");

                Categoria categoriaSeleccionada = cmbCategoria.SelectedItem as Categoria;

                if (productoIdEnEdicion.HasValue)
                {
                    ProductoService.ActualizarProducto(
                        productoIdEnEdicion.Value,
                        txtNombre.Text,
                        categoriaSeleccionada,
                        precio
                    );
                    MessageBox.Show("Producto actualizado con éxito.", "Éxito");
                }
                else
                {
                    if (!int.TryParse(txtCantidadInicial.Text, out int cantidad)) throw new Exception("Cantidad inicial no válida.");

                    ProductoService.CrearProducto(
                        txtNombre.Text,
                        categoriaSeleccionada,
                        precio,
                        cantidad
                    );
                    MessageBox.Show("Producto creado con éxito.", "Éxito");
                }

                RefrescarListaProductos();
                EstablecerModoCreacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Gestión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}