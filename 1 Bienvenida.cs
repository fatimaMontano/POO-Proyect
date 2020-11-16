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
    public partial class Bienvenida : Form
    {
        public Bienvenida()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {        
            Inicio_Registro inicio = new Inicio_Registro();
            inicio.Show();
            timer1.Enabled = false;
            this.Hide();
        }

        private void Bienvenida_Load(object sender, EventArgs e)
        {

        }
    }
}
