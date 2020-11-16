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
    
    public partial class SolicitudFrom : Form
    {
        public ClUsuario usu = new ClUsuario();
        public SolicitudFrom()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UsuarioFrom volver = new UsuarioFrom();
            volver.usu = usu;
            volver.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            try 
            {
                this.openFileDialog1.ShowDialog();
                if (this.openFileDialog1.FileName.Equals("") == false)
                {
                    pictureBox3.Load(this.openFileDialog1.FileName);
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error no se pudo cargar la imagen: " + ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            borrar();
            if (vali())
            {
                try
                {
                    using (UnFuturoMejorEntities3 db = new UnFuturoMejorEntities3())
                    {
                        Solicitud sol = new Solicitud();
                        sol.Titulo = txtTitulo.Text;
                        sol.Lugar = txtLugar.Text;
                        sol.Descripcion = txtDescripcion.Text;
                        sol.Usuario = usu.Usuario;
                        sol.Fecha = DateTime.Now;
                        sol.Estado = "Pendiente";
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        pictureBox3.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        sol.Imagen = ms.ToArray();

                        db.Solicitud.Add(sol);
                        db.SaveChanges();
                        MessageBox.Show("La solicitud se ingreso con exito");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al ingresar la solicitud: " + ex.ToString());
                }
            }
        }

        private bool vali()
        {
            bool val = true;
            if (txtLugar.Text == "")
            {
                val = false;
                errorProvider1.SetError(txtLugar, "Ingrese una dirección");
            }
            if (txtTitulo.Text == "")
            {
                val = false;
                errorProvider1.SetError(txtTitulo, "Ingrese un titulo del problema");
            }
        
            if (txtDescripcion.Text == "")
            {
                val = false;
                errorProvider1.SetError(txtDescripcion, "Debe ingresar una descripcion del problema");
            }
            return val;
            
        }

        private void borrar()
        {
            errorProvider1.SetError(txtDescripcion, "");
            errorProvider1.SetError(txtTitulo, "");
            errorProvider1.SetError(txtLugar, "");
        }

        private void SolicitudFrom_Load(object sender, EventArgs e)
        {

        }
    }
}
