using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculadora {
    class Operando {

        /** Atributos **/
        private string numero;

        /**
         Constructor de clase que recibe un número en String
             */
        public Operando(string numero) {
            this.numero = numero;
        }

        /**
         Constructor de clase vacío
             */
        public Operando() {
            this.numero = "";
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

            for(int i = 0; i < this.numero.Length - 1; i++) {
                aux += this.numero[i];
            }

            this.numero = aux;
        }
    }
}
