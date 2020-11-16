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
    public partial class EstadoSol : Form
    {
        public ClUsuario usu = new ClUsuario();
        public EstadoSol()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UsuarioFrom volver = new UsuarioFrom();
            volver.usu = usu;
            volver.Show();
            this.Hide();
        }

        List<Soli> listsoliPen = new List<Soli>();
        List<Soli> listsoliRes = new List<Soli>();

        private void EstadoSol_Load(object sender, EventArgs e)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            using (UnFuturoMejorEntities3 db = new UnFuturoMejorEntities3())
            {
                listsoliPen = (from d in db.Solicitud.Where(d => d.Estado == "Pendiente" && d.Usuario == usu.Usuario)
                               select new Soli
                               {
                                   Titulo = d.Titulo,
                                   Lugar = d.Lugar,
                                   Descripcion = d.Descripcion,
                                   Fecha = d.Fecha.ToString(),
                                   Estado = d.Estado,
                                   Respuesta = d.Respuesta,                                
                                   Imagen = d.Imagen
                               }).ToList();

                listsoliRes = (from d in db.Solicitud.Where(d => d.Estado == "Contestada" && d.Usuario == usu.Usuario)
                               select new Soli
                               {
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

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {

            int indice = dataGridView2.CurrentRow.Index;
            Soli solicitud = new Soli();
            solicitud = listsoliRes[indice];
            VerSoliUsu versoli = new VerSoliUsu();
            versoli.solici = solicitud;
            versoli.usu = usu;
            versoli.Show();
            this.Hide();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int indice = dataGridView1.CurrentRow.Index;
            Soli solicitud = new Soli();
            solicitud = listsoliPen[indice];
            solicitud.Respuesta = "Aun esta pendiente la solicitud y no se tiene respuesta";
            VerSoliUsu versoli = new VerSoliUsu();
            versoli.solici = solicitud;
            versoli.usu = usu;
            versoli.Show();
            this.Hide();
        }

    }
}
