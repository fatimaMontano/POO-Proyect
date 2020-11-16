using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Promama_Fase1.Entity;

namespace Promama_Fase1
{
    
    public partial class Registro : Form
    {
        public List<ClUsuario> ususuario = new List<ClUsuario>();
        public Registro()
        {
            InitializeComponent();

            using (UnFuturoMejorEntities3 db = new UnFuturoMejorEntities3())
            {
                ususuario = (from d in db.Usuario
                            select new ClUsuario
                            {
                                Nombre = d.Nombre,
                                Apellido = d.Apellido,
                                Usuario = d.Usuario1,
                                Contra = d.Contraseña,
                                Telefono = d.Telefono,
                                Correo = d.Correo,
                                TpUsuario = d.TipoUsuario
                            }).ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InicioSesion Inicio = new InicioSesion();
            Inicio.Show();
            this.Hide();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            borrar();
            ClUsuario usuario = new ClUsuario();
            if (usuario.verificarUsuario(txtUsuario.Text,ususuario))
            {
                if(Validar() && ValidarCorreo(txtCorreo.Text) && ValidarTelefono(txtTelefono.Text))
                {
                    usuario.Nombre = txtNombre.Text;
                    usuario.Apellido = txtApellido.Text;
                    usuario.Usuario = txtUsuario.Text;
                    usuario.Telefono = txtTelefono.Text;
                    usuario.Correo = txtCorreo.Text;
                    usuario.Contra = txtContra.Text;
                    usuario.TpUsuario = "Usuario";

                    using (UnFuturoMejorEntities3 db = new UnFuturoMejorEntities3())
                    {
                        Usuario usu = new Usuario();
                        usu.Nombre = usuario.Nombre;
                        usu.Apellido = usuario.Apellido;
                        usu.Usuario1 = usuario.Usuario;
                        usu.Telefono = usuario.Telefono;
                        usu.Correo = usuario.Correo;
                        usu.Contraseña = usuario.Contra;
                        usu.TipoUsuario = usuario.TpUsuario;

                        db.Usuario.Add(usu);
                        db.SaveChanges();
                    }

                        MessageBox.Show("El usuario se creo con exito");
                }
                else
                {
                    MessageBox.Show("Error al ingresar Datos");
                }
            }
            else
            {
                MessageBox.Show("Error, el usuario ya existe");
                txtUsuario.Focus();
                txtUsuario.Text = "";
            }
        }

        private bool Validar()
        {
            bool Vali = true;
            if (txtNombre.Text == "")
            {
                Vali = false;
                errorProvider1.SetError(txtNombre, "Ingrese un Nombre");
            }
            if (txtApellido.Text == "")
            {
                Vali = false;
                errorProvider1.SetError(txtApellido, "Ingrese un Apellido");
            }
            if (txtContra.Text == "")
            {
                Vali = false;
                errorProvider1.SetError(txtContra, "Ingrese una contraseña");
            }
            if (txtUsuario.Text == "")
            {
                Vali = false;
                errorProvider1.SetError(txtUsuario, "Ingrese un Usuario");
            }
            if (txtTelefono.Text == "")
            {
                Vali = false;
                errorProvider1.SetError(txtTelefono, "Ingrese un numero de telefono");
            }
            if (txtCorreo.Text == "")
            {
                Vali = false;
                errorProvider1.SetError(txtCorreo, "Ingrese un Correo");
            }
            return Vali;
        }
        private bool ValidarCorreo(string Correo)
        {
            string correo = @"\A(\w+\.?\w*)\@(\w{2,}\.){1,}(\w{2,4})\Z"; 
            if (Regex.IsMatch(Correo, correo))
            {
                if (Regex.Replace(Correo, correo, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private bool ValidarTelefono(string Telefono)
        {
            string telefono = @"\A([0-9]{4})+(-){1}([0-9]{4})\Z";
            if (Regex.IsMatch(Telefono, telefono))
            {
                if (Regex.Replace(Telefono, telefono, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (ValidarTelefono(txtTelefono.Text))
            {
                errorProvider1.SetError(txtTelefono,"");
            }
            else
            {
                errorProvider1.SetError(txtTelefono, "El formato no es el correcto"+
                    "Ejm: 1234-5678");            
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (ValidarCorreo(txtCorreo.Text))
            {
                errorProvider1.SetError(txtCorreo, "");
            }
            else
            {
                errorProvider1.SetError(txtCorreo, "El formato no es el correcto");
            }
        }
        private void borrar()
        {
            errorProvider1.SetError(txtNombre, "");
            errorProvider1.SetError(txtApellido, "");
            errorProvider1.SetError(txtContra, "");
            errorProvider1.SetError(txtUsuario, "");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Inicio_Registro volver = new Inicio_Registro();

            volver.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void Registro_Load(object sender, EventArgs e)
        {

        }
    }
}
