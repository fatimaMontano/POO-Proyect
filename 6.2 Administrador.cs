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

    public partial class Administrador : Form
    {
        public ClUsuario usu = new ClUsuario();
        public Administrador()
        {
            InitializeComponent();
            
            
        }
        public List<ClUsuario> Usuarios = new List<ClUsuario>();
        private void button1_Click(object sender, EventArgs e)
        {
            RegistroAd registro = new RegistroAd();
            registro.Usuarios = Usuarios;
            registro.usu = usu;
            registro.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inicio_Registro volver = new Inicio_Registro();
            volver.Show();
            this.Hide();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Administrador_Load(object sender, EventArgs e)
        {
            admin.Text = usu.Usuario;
            if (admin.Text != "Admin")
            {
                button1.Enabled = false;
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SolicitudAd AdminSol = new SolicitudAd();
            AdminSol.Usuarios = Usuarios;
            AdminSol.usu = usu;
            AdminSol.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
