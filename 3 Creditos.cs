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
    public partial class Creditos : Form
    {
        public Creditos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inicio_Registro back = new Inicio_Registro();
            back.Show();
            this.Hide();
        }

        private void Creditos_Load(object sender, EventArgs e)
        {

        }
    }
}
