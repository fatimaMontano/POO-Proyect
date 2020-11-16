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
    public partial class Inicio_Registro : Form
    {
        public Inicio_Registro()
        {
            InitializeComponent();          
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Creditos creditos = new Creditos();
            creditos.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir de la aplicacion?", "¿Seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InicioSesion inicio = new InicioSesion();         
            inicio.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.Show();
            this.Hide();
        }

        private void Inicio_Registro_Load(object sender, EventArgs e)
        {

        }
    }
}
