using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Promama_Fase1.Entity;
namespace Promama_Fase1
{
    public partial class VerSoliUsu : Form
    {
        public Soli solici = new Soli();
        public ClUsuario usu = new ClUsuario();
        public VerSoliUsu()
        {
            InitializeComponent();
        }

        private void VerSoliUsu_Load(object sender, EventArgs e)
        {
            txtDescrip.Text = solici.Descripcion;
            txtTitulo.Text = solici.Titulo;
            txtLugar.Text = solici.Lugar;
            txtFecha.Text = solici.Fecha;
            txtRespuesta.Text = solici.Respuesta;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(solici.Imagen);
            pictureBox1.Image = Image.FromStream(ms);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EstadoSol back = new EstadoSol();
            back.usu = usu;
            back.Show();
            this.Hide();
        }
    }
}
