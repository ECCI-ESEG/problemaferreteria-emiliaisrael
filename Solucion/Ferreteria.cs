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
            if (anchoInicial > largoInicial) {
                this.anchoInicial = largoInicial;
                this.largoInicial = anchoInicial;
            } else {
                this.anchoInicial = anchoInicial;
                this.largoInicial = largoInicial;
            }
            this.precioBase = precioBase;
        }

        
        public double ProcesarSolicitud(double anchoSolicitado, double largoSolicitado)
        {
            if (anchoSolicitado > largoSolicitado) {
                double temp = largoSolicitado;
                largoSolicitado = anchoSolicitado;
                anchoSolicitado = temp;
            }
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
            double ancho_actual = tabla.GetAncho();
            double largo_actual = tabla.GetLargo();
            double largo_restante = largo_actual - anchoSolicitado;
            double ancho_restante = ancho_actual - largoSolicitado;
            Tabla restante = new Tabla(ancho_actual, largo_restante, this.precioBase);
            Tabla residuo = new Tabla(anchoSolicitado, ancho_restante, this.precioBase);
            Tabla cliente = new Tabla(anchoSolicitado, largoSolicitado, this.precioBase);
            if (restante.mayor(residuo)){ 
                almacen.AgregarTabla(restante);
                almacen.AgregarTabla(residuo);
            } else {
                almacen.AgregarTabla(residuo);
                almacen.AgregarTabla(restante);
            }
            return cliente.GetPrecio();
        }
    }
}