﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal3
{
    public class clsBiblioteca
    {
        int id;
        string cancion;
        string url;
        string portada;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

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

        public string Portada
        {
            get
            {
                return portada;
            }

            set
            {
                portada = value;
            }
        }

       
    }
}
