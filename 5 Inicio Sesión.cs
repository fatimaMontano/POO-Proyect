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
    public partial class InicioSesion : Form
    {
        public List<ClUsuario> Usuarios = new List<ClUsuario>();
        public InicioSesion()
        {
            InitializeComponent();   
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            ClUsuario usuario = new ClUsuario();           
            if (usuario.verificarUsuario(txtUsuario.Text,txtContra.Text,Usuarios,out usuario))
            {
                IniciandoSesion inicio = new IniciandoSesion();
                inicio.usu = usuario;
                inicio.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta", "Error al iniciar sesion", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inicio_Registro volver = new Inicio_Registro();
            volver.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtContra.PasswordChar == '*')
            {
                txtContra.PasswordChar = '\0';
            }
            else
            {
                txtContra.PasswordChar = '*';
            }
        }

        private void InicioSesion_Load(object sender, EventArgs e)
        {

            using (UnFuturoMejorEntities3 db = new UnFuturoMejorEntities3())
            {
                Usuarios = (from d in db.Usuario
                            select new ClUsuario
                            {                               
                                Nombre = d.Nombre,
                                Apellido = d.Apellido,
                                Usuario = d.Usuario1,
                                Contra= d.Contraseña,
                                Telefono =d.Telefono,
                                Correo = d.Correo,
                                TpUsuario = d.TipoUsuario
                            }).ToList(); 
            }
        }
    }
}
