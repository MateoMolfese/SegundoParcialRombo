using SegundoParcialRombo.Datos;
using SegundoParcialRombo.Entidades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace SegundoParcialRombo.Windows
{
    public partial class frmRomboAE : Form
    {
        private Rombo? rombo;
        private readonly RepositorioRombos? _repo;
        public frmRomboAE(RepositorioRombos? repo)
        {
            InitializeComponent();
            _repo = repo;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (rombo != null)
            {
                txtDiagonalMayor.Text = rombo.DiagonalMayor.ToString();
                txtDiagonalMenor.Text = rombo.DiagonalMenor.ToString();
                switch (rombo.TipoBorde)
                {
                    case Contorno.Solido:
                        rbtSolido.Checked = true;
                        break;
                    case Contorno.Punteado:
                        rbtPunteado.Checked = true;
                        break;
                    case Contorno.Rayado:
                        rbtRayado.Checked = true;
                        break;
                    case Contorno.Doble:
                        rbtDoble.Checked = true;
                        break;
                }
            }
        }
        public Rombo? GetRombo()
        {
            return rombo;
        }

        public void SetRombo(Rombo rombo)
        {
            this.rombo = rombo;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (!int.TryParse(txtDiagonalMayor.Text, out int dM) ||
                dM <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtDiagonalMayor, "Diagonal Mayor mal ingresado");
            }
            if (!int.TryParse(txtDiagonalMenor.Text, out int dm) ||
                dm <= 0 || dm >= dM)
            {
                valido = false;
                errorProvider1.SetError(txtDiagonalMenor, "Diagonal Menor mal ingresado");
            }
            if (_repo!.Existe(dM, dm))
            {
                valido = false;
                errorProvider1.SetError(txtDiagonalMayor, "¡¡¡Rombo existente!!!");
            }
            return valido;

        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (rombo is null)
                {
                    rombo = new Rombo();
                }
                rombo.DiagonalMayor = int.Parse(txtDiagonalMayor.Text);
                rombo.DiagonalMenor = int.Parse(txtDiagonalMenor.Text);
                if (rbtSolido.Checked)
                    rombo.TipoBorde = Contorno.Solido;
                else if (rbtPunteado.Checked)
                    rombo.TipoBorde = Contorno.Punteado;
                else if (rbtRayado.Checked)
                    rombo.TipoBorde = Contorno.Rayado;
                else
                    rombo.TipoBorde = Contorno.Doble;
                DialogResult = DialogResult.OK;
            }

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }
    }
}
