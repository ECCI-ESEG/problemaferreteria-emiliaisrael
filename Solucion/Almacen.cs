using System;
using Solucion;

namespace Solucion
{
    public class Almacen
    {
        List<Tabla> tablas;
        int capacidadMaxima;
        public Almacen(int capacidadMaxima)
        {
            this.capacidadMaxima = capacidadMaxima;
            this.tablas = new List<Tabla>(capacidadMaxima);
        }

        public bool AgregarTabla(Tabla t) {
            if (this.capacidadMaxima < tablas.Count + 1) {
                return false;
            }
            int posTabla = 0;
            for (int i = 0; i < tablas.Count; ++i) {
                if (tablas[i].mayor(t)) {
                    posTabla = i;
                    break;
                }
            }
            tablas.Insert(posTabla, t);
            return true;
        }

        public Tabla SacarTabla(int i) {
            Tabla elemento = new Tabla(tablas[i].GetAncho(), tablas[i].GetLargo(), tablas[i].GetPrecioBase());
            tablas.Remove(tablas[i]);
            return elemento;
        }

        public int IndiceTabla(double ancho, double largo) {
            for (int i  = 0; i < tablas.Count; ++i) {
                if (tablas[i].MeSirve(ancho, largo)) {
                    return i;
                }
            }  
            return -1;
        }

    }
}
