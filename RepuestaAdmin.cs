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
    public partial class RepuestaAdmin : Form
    {
        public Solici solici = new Solici();
        public ClUsuario usu = new ClUsuario();
        public RepuestaAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (UnFuturoMejorEntities3 db = new UnFuturoMejorEntities3())
            {
                Solicitud edit = db.Solicitud.Where(d => d.IdSoli == solici.IdSoli).First();
                edit.Respuesta = txtRespuesta.Text;
                edit.Estado = "Contestada";
                db.Entry(edit).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                MessageBox.Show("La respuesta se guardo con exito");
            }
        }

        private void RepuestaAdmin_Load(object sender, EventArgs e)
        {
            if(solici.Estado == "Contestada")
            {
                btnGuardar.Enabled = false;
                txtRespuesta.ReadOnly = true;
            }
            txtTitulo.Text = solici.Titulo;
            txtDescripcion.Text = solici.Descripcion;
            txtFecha.Text = solici.Fecha;
            txtLugar.Text = solici.Lugar;
            txtRespuesta.Text = solici.Respuesta;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(solici.Imagen);
            pictureBox3.Image = Image.FromStream(ms);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            ClUsuario usuario = new ClUsuario();
            using(UnFuturoMejorEntities3 db = new UnFuturoMejorEntities3())
            {
                usuario = (from d in db.Usuario
                           where (d.Usuario1 == solici.Usuario)
                           select new ClUsuario
                           {
                               Usuario = d.Usuario1,
                               Nombre = d.Nombre,
                               Apellido=d.Apellido,
                               Telefono=d.Telefono,
                               Correo=d.Correo
                           }).First();
                                
            }
            richTextBox1.Text = " Usuario: " + usuario.Usuario + "\n Nombre del Usuario: " +usuario.Nombre+" " + usuario.Apellido +
               "\n Telefono: " +usuario.Telefono+ "\n Correo: " +usuario.Correo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SolicitudAd back = new SolicitudAd();
            back.usu = usu;
            back.Show();
            this.Hide();
        }
    }
}
