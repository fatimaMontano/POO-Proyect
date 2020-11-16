using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Promama_Fase1
{
    public partial class UsuarioFrom : Form
    {
        public ClUsuario usu=new ClUsuario();
        public UsuarioFrom()
        {
            InitializeComponent();
            
        }
        public List<ClUsuario> Usuarios = new List<ClUsuario>();
        private void lbUsu_Click(object sender, EventArgs e)
        {

        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            lbUsu.Text = usu.Usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SolicitudFrom solicitud = new SolicitudFrom();
            solicitud.usu = usu;
            solicitud.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Inicio_Registro volver = new Inicio_Registro();
            volver.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EstadoSol EstadoSol = new EstadoSol();
            EstadoSol.usu = usu;
            EstadoSol.Show();
            this.Hide();
        }
    }
}
