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
    public partial class SolicitudAd : Form
    {
        public ClUsuario usu = new ClUsuario();
        public List<ClUsuario> Usuarios = new List<ClUsuario>();
        public SolicitudAd()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Administrador volver = new Administrador();
            volver.Usuarios = Usuarios;
            volver.usu = usu;
            volver.Show();
            this.Hide();
        }
        List<Solici> listsoliPen = new List<Solici>();
        List<Solici> listsoliRes = new List<Solici>();

        private void SolicitudAd_Load(object sender, EventArgs e)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            using (UnFuturoMejorEntities3 db = new UnFuturoMejorEntities3())
            {
                listsoliPen = (from d in db.Solicitud.Where(d => d.Estado == "Pendiente")
                               select new Solici
                               {
                                   IdSoli = d.IdSoli,
                                   Usuario= d.Usuario,
                                   Titulo = d.Titulo,
                                   Lugar = d.Lugar,
                                   Descripcion = d.Descripcion,
                                   Fecha = d.Fecha.ToString(),
                                   Estado = d.Estado,
                                   Respuesta = d.Respuesta,
                                   Imagen = d.Imagen
                               }).ToList();

                listsoliRes = (from d in db.Solicitud.Where(d => d.Estado == "Contestada")
                               select new Solici
                               {
                                   IdSoli = d.IdSoli,
                                   Usuario = d.Usuario,
                                   Titulo = d.Titulo,
                                   Lugar = d.Lugar,
                                   Descripcion = d.Descripcion,
                                   Fecha = d.Fecha.ToString(),
                                   Estado = d.Estado,
                                   Respuesta = d.Respuesta,
                                   Imagen = d.Imagen
                               }).ToList();
            }

            dataGridView1.DataSource = listsoliPen;
            dataGridView2.DataSource = listsoliRes;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int indice = dataGridView1.CurrentRow.Index;
            Solici solicitud = new Solici();
            solicitud = listsoliPen[indice];
            RepuestaAdmin versoli = new RepuestaAdmin();
            versoli.solici = solicitud;
            versoli.usu = usu;
            versoli.Show();
            this.Hide();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            int indice = dataGridView2.CurrentRow.Index;
            Solici solicitud = new Solici();
            solicitud = listsoliRes[indice];
            RepuestaAdmin versoli = new RepuestaAdmin();
            versoli.solici = solicitud;
            versoli.usu = usu;
            versoli.Show();
            this.Hide();
        }
    }
}
