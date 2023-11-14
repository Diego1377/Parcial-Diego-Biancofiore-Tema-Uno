using ArrayObjetos.Datos;
using ArrayObjetos.Entidades;
using System;

namespace Parcial_TemaUno.Windows
{
    public partial class frmPrincipal : Form
    {
        private RepositorioDeCubos repo;
        private List<Cubo> lista;
        int intValor;
        private Cubo cubo;

        public frmPrincipal()
        {
            InitializeComponent();
            repo = new RepositorioDeCubos();
            ActualizarCantidadRegistros();

        }

        private void ActualizarCantidadRegistros()
        {
            if (intValor > 0)
            {
                txtCantidad.Text = repo.GetCantidad(intValor).ToString();
            }
            else
            {
                txtCantidad.Text = repo.GetCantidad().ToString();
            }
        }
        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            lista = repo.GetLista();
            MostrarDatosEnGrilla();
            ActualizarCantidadRegistros();
            intValor = 0;
            tsbFiltro.BackColor = SystemColors.Control;
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmCuboAE frm = new frmCuboAE() { Text = "Agregar Objeto." };
            DialogResult dr = frm.ShowDialog();
            if (dr != DialogResult.OK)
            {
                return;
            }
            Cubo cubo = frm.GetCubo();
            if (!repo.Existe(cubo))
            {
               
                repo.Agregar(cubo);
                txtCantidad.Text = repo.GetCantidad().ToString();
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, cubo);
                AgregarFila(r);

                MessageBox.Show("Registro agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
             else
            {
                MessageBox.Show("Registro existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }
        private void SetearFila(DataGridViewRow r, Cubo cubo)
        {
            r.Cells[Column1.Index].Value = cubo.GetLado();
            r.Cells[Column2.Index].Value = cubo.ColorRelleno;
            r.Cells[Column3.Index].Value = cubo.TipoDeBorde;
            r.Cells[Column4.Index].Value = cubo.GetArea();
            r.Cells[Column5.Index].Value = cubo.GetVolumen();
            r.Tag = cubo;
        }
        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("¿Desea borrar el Cubo?", "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            var filaSeleccionada = dgvDatos.SelectedRows[0];
            Cubo cubo = filaSeleccionada.Tag as Cubo;
            repo.Borrar(cubo);
            txtCantidad.Text = repo.GetCantidad().ToString();
            QuitarFila(filaSeleccionada);
        }

        private void QuitarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Remove(r);
            MessageBox.Show("Registro borrado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var filaSeleccionada = dgvDatos.SelectedRows[0];

            Cubo cubo = (Cubo)filaSeleccionada.Tag;
            int aristaAnterior = cubo.GetLado();
            frmCuboAE frm = new frmCuboAE() { Text = "Editar Cubo" };
            frm.SetCubo(cubo);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            cubo = frm.GetCubo();
            repo.Editar(aristaAnterior, cubo);
            SetearFila(filaSeleccionada, cubo);
            MessageBox.Show("Registro editado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsbFiltro_Click(object sender, EventArgs e)
        {
            var stringValor = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el valor a filtrar",
                "Filtrar por mayor o igual",
                "0", 400, 400);
            if (!int.TryParse(stringValor, out intValor))
            {
                return;
            }
            if (intValor <= 0)
            {
                return;
            }
            lista = repo.Filtrar(intValor);
            tsbFiltro.BackColor = Color.BlueViolet;
            MostrarDatosEnGrilla();
            ActualizarCantidadRegistros();
            MessageBox.Show("Filtro aplicado!");
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if (repo.GetCantidad() > 0)
            {
                lista = repo.GetLista();
                MostrarDatosEnGrilla();
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var cubo in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, cubo);
                AgregarFila(r);
            }
        }

        private void ascendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista = repo.OrdenarAsc();
            MostrarDatosEnGrilla();
            ActualizarCantidadRegistros();
        }

        private void descendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista = repo.OrdenarDesc();
            MostrarDatosEnGrilla();
            ActualizarCantidadRegistros();
        }
    }
}