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
    public partial class IniciandoSesion : Form
    {
        public ClUsuario usu = new ClUsuario();
        public IniciandoSesion()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }
        public List<ClUsuario> Usuarios = new List<ClUsuario>();
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (usu.TpUsuario == "Admin")
            {
                Administrador inicio = new Administrador();
                inicio.usu = usu;
                inicio.Show();
                this.Hide();
            }
            if (usu.TpUsuario == "Usuario")
            {
                UsuarioFrom inicio = new UsuarioFrom();
                inicio.usu = usu;
                inicio.Show();
                this.Hide();
            }
            timer1.Enabled = false;
        }

        private void IniciandoSesion_Load(object sender, EventArgs e)
        {

        }
    }
}
