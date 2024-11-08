using System;
using Solucion;

namespace Solucion
{
    public class Ferreteria
    {
        Almacen almacen;
        double anchoInicial;
        double largoInicial;
        double precioBase;
        public Ferreteria(double anchoInicial, double largoInicial, double precioBase)
        {
            this.almacen = new Almacen(500);
            this.anchoInicial = anchoInicial;
            this.largoInicial = largoInicial;
            this.precioBase = precioBase;
        }

        
        public double ProcesarSolicitud(double anchoSolicitado, double largoSolicitado)
        {
            if (anchoInicial < anchoSolicitado || largoInicial < largoSolicitado) {
                return -1;
            }
            int posicion = almacen.IndiceTabla(anchoSolicitado, largoSolicitado);
            Tabla tabla;
            if (posicion != -1) {
                tabla = almacen.SacarTabla(posicion);
            } else{
                tabla = new Tabla(anchoInicial, largoInicial, precioBase);
            }
            // Sí puedo partir la tabla
            
            return 0;
        }
    }
}