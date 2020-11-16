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
    public partial class RegistroAd : Form
    {
        public ClUsuario usu = new ClUsuario();
        public RegistroAd()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            using (UnFuturoMejorEntities3 db = new UnFuturoMejorEntities3())
            {
                Usuarios = (from d in db.Usuario
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
        public List<ClUsuario> Usuarios = new List<ClUsuario>();
        private void button1_Click(object sender, EventArgs e)
        {
            borrar();
            ClUsuario usuario = new ClUsuario();
            if (usuario.verificarUsuario(txtUsuario.Text, Usuarios))
            {
                if (Validar() && ValidarCorreo(txtCorreo.Text) && ValidarTelefono(txtTelefono.Text))
                {
                    usuario.Nombre = txtNombre.Text;
                    usuario.Apellido = txtApellido.Text;
                    usuario.Usuario = txtUsuario.Text;
                    usuario.Telefono = txtTelefono.Text;
                    usuario.Correo = txtCorreo.Text;
                    usuario.Contra = txtContra.Text;
                    usuario.TpUsuario = comboBox1.Text;

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

                    MessageBox.Show("El usuario se ha creado con exito");
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
                errorProvider1.SetError(txtContra, "Ingrese un Apellido");
            }
            if (txtUsuario.Text == "")
            {
                Vali = false;
                errorProvider1.SetError(txtUsuario, "Ingrese un Apellido");
            }
            if (txtTelefono.Text == "")
            {
                Vali = false;
                errorProvider1.SetError(txtTelefono, "Ingrese un Apellido");
            }
            if (txtCorreo.Text == "")
            {
                Vali = false;
                errorProvider1.SetError(txtCorreo, "Ingrese un Apellido");
            }
            if (comboBox1.Text == "")
            {
                Vali = false;
                errorProvider1.SetError(comboBox1, "Ingrese un Apellido");
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
        private void borrar()
        {
            errorProvider1.SetError(txtNombre, "");
            errorProvider1.SetError(txtApellido, "");
            errorProvider1.SetError(txtContra, "");
            errorProvider1.SetError(txtUsuario, "");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Administrador back = new Administrador();
            back.Show();
            back.usu = usu;
            this.Hide();
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (ValidarTelefono(txtTelefono.Text))
            {
                errorProvider1.SetError(txtTelefono, "");
            }
            else
            {
                errorProvider1.SetError(txtTelefono, "El formato no es el correcto" +
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

        private void RegistroAd_Load(object sender, EventArgs e)
        {

        }
    }
}
