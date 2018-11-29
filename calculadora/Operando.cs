using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculadora {
    class Operando {

        /** Atributos **/
        private string numero;
        private bool esPositivo;

        /**
         Constructor de clase que recibe un número en String
             */
        public Operando(string numero) {
            this.numero = numero;
            this.esPositivo = true;
        }

        /**
         Constructor de clase vacío
             */
        public Operando() {
            this.numero = "";
            this.esPositivo = true;
        }

        /**
         Añade un número al operando
             */
        public void AddNumero(string numero) {
            this.numero += numero;
        }

        /**
         Guarda y cambia el operando
             */
        public void SetOperando(string numero) {
            this.numero = numero;
        }

        /**
         Devuelve un string con el operando guardado
             */
        public string GetOperandoString() {
            return this.numero;
        }

        /**
         Devuelve un double con el operando guardado
             */
        public double GetOperandoDouble() {
            return double.Parse(this.numero);
        }

        /**
         Devuelve true si el Operando esta vacio, en caso contrario devuelve false
             */
        public bool EstaVacio() {
            return this.numero.Length == 0;
        }

        /**
         Elimina el último número del operando
             */
        public void EliminarUltimoNumero() {
            string aux = "";

            /* Para eliminar un número se recorre todo el string excepto la última posicion */
            for(int i = 0; i < this.numero.Length - 1; i++) {
                aux += this.numero[i];
            }

            this.numero = aux;
        }

        public void CambiarSigno() {
            string aux = "";
            int comienzo;

            /* Si es el número no es positivo tendremos que eliminar el signo negativo, por lo que 
             * el recorrido empezará en la posición 1 en vez del 0, y si es positivo guardamos en aux
             * el signo negativo y el comienzo es en 0 */
            if (!esPositivo) {
                comienzo = 1;
                esPositivo = true;
            } else {
                aux = "-";
                comienzo = 0;
                esPositivo = false;
            }

            for (int i = comienzo; i < this.numero.Length; i++) {
                aux += this.numero[i];
            }

            this.numero = aux;
        }

        /**
         Reinicia el operando, es decir elimina todo dentro
             */
        public void ReiniciarOperando() {
            this.numero = "";
            this.esPositivo = true;
        }
    }
}
