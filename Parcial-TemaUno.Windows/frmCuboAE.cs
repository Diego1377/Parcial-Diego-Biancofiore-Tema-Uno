using ArrayCubos.Entidades;
using ArrayObjetos.Entidades;
using System.Data;

namespace Parcial_TemaUno.Windows
{
    public partial class frmCuboAE : Form
    {
        public frmCuboAE()
        {
            InitializeComponent();
        }
        public Cubo cubo;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarDatosComboColorRelleno();
            CargarDatosComboTipodeBorde();
            if (cubo != null)
            {
                txt1.Text = cubo.GetLado().ToString();
                //txt2.Text = objeto.GetLado2().ToString();
                cboColores.SelectedItem = cubo.ColorRelleno;
                cboBordes.SelectedItem = cubo.TipoDeBorde;
            }
        }

        private void CargarDatosComboTipodeBorde()
        {
            var listaBordes = Enum.GetValues(typeof(TipodeBorde)).Cast<TipodeBorde>().ToList();
            cboBordes.DataSource = listaBordes;
            cboBordes.SelectedIndex = 0;
        }

        private void CargarDatosComboColorRelleno()
        {
            var listaColores = Enum.GetValues(typeof(ColorRelleno)).Cast<ColorRelleno>().ToList();
            cboColores.DataSource = listaColores;
            cboColores.SelectedIndex = 0;
        }

        internal Cubo GetCubo()
        {
            return cubo;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                if (cubo == null)
                {
                    cubo = new Cubo();
                }

                cubo.SetLado(int.Parse(txt1.Text));
                cubo.ColorRelleno = (ColorRelleno)cboColores.SelectedItem;
                cubo.TipoDeBorde = (TipodeBorde)cboBordes.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }

        private bool validarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (!int.TryParse(txt1.Text, out int arista))
            {
                valido = false;
                errorProvider1.SetError(txt1, "Nro. mal ingresado.");
            }
            else if (arista <= 0)
            {
                valido = false;
                errorProvider1.SetError(txt1, "Valor de la Arista menor o igual a cero.");
            }
           
            return valido;
        }
        public void SetCubo(Cubo? cubo)
        {
            this.cubo = cubo;
        }
    }
}
