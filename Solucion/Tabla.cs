using System;

namespace Solucion
{
    public class Tabla
    {

        private double ancho;
        private double largo;
        private double precioBase;
        public Tabla(double ancho, double largo, double precioBase)
        {
            if (ancho < largo) { // hay que darles vuelta
                this.ancho = largo;
                this.largo = ancho;
            } else {
                this.ancho = ancho;
                this.largo = largo;
            }
            this.precioBase = precioBase;
        }

        public bool mayor (Tabla otra) {
            if (this.ancho > otra.ancho) { // ancho mío es más grande
                return true;
            }
            if (this.ancho < otra.ancho) { // la otra es más ancha
                return false;
            }
            if (this.largo > otra.largo) { // yo soy más larga
                return true;
            }
            return false; // la otra es más larga
        }

        public bool MeSirve(double ancho, double largo) {
            if (this.ancho >= ancho && this.largo >= largo) {
                return true;
            }
            return false;
        }

        public double GetLargo(){
            return this.largo;
        }  
        public double GetAncho(){
            return this.ancho;
        }  
        public double GetPrecioBase(){
            return this.precioBase;
        }  

        public double GetPrecio() {
            double precio = this.largo * this.ancho * this.precioBase;
            return precio;
        }
    }
}
