using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal3
{
    class clsMyLista
    {
        string cancion;
        string url;

        public string Cancion
        {
            get
            {
                return cancion;
            }

            set
            {
                cancion = value;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }
    }
}
