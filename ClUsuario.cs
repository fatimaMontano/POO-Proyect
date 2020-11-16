using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promama_Fase1
{
    public class ClUsuario
    {
        string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        string contra;
        public string Contra
        {
            get { return contra; }
            set { contra = value; }
        }

        string apellido;
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        string telefono;
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        string correo;
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        string tpusuario;
        public string TpUsuario
        {
            get { return tpusuario; }
            set { tpusuario = value; }
        }

        public bool verificarUsuario(string usuario, List<ClUsuario> list)
        {
            bool veri = true;
            ClUsuario verificar = new ClUsuario();
            for (int i = 0; i < list.Count; i++)
            {
                verificar = list[i];
                if (verificar.Usuario == usuario)
                    veri = false;
            }
            return veri;
        }
        public bool verificarUsuario(string usuario,string contra, List<ClUsuario> list,out ClUsuario usu)
        {
            bool veri = false;
            usu = null;
            ClUsuario verificar = new ClUsuario();
            for (int i = 0; i < list.Count; i++)
            {
                verificar = list[i];
                if (verificar.Usuario == usuario && verificar.Contra == contra)
                {
                    veri = true;
                    usu = verificar;
                }
                    
            }
            return veri;
        }
    }
    
}
