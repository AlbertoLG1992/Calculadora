using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calculadora{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window{

        /* Variables */
        string  resultado = "",
                operacion = "",
                operacionCompleta = "";
        Operando    operando1,
                    operando2;

        public MainWindow() {
            InitializeComponent();
            this.operando1 = new Operando();
            this.operando2 = new Operando();
        }

        /** 
         Métodos al pulsar el botón 1 
            */
        private void BtnUno_Click(object sender, RoutedEventArgs e) {
            this.RellenarNumero("1");
        }

        /** 
         Métodos al pulsar el botón 2 
            */
        private void BtnDos_Click(object sender, RoutedEventArgs e) {
            this.RellenarNumero("2");
        }

        /** 
         Métodos al pulsar el botón 3 
            */
        private void BtnTres_Click(object sender, RoutedEventArgs e) {
            this.RellenarNumero("3");
        }

        /** 
         Métodos al pulsar el botón 4 
            */
        private void BtnCuatro_Click(object sender, RoutedEventArgs e) {
            this.RellenarNumero("4");
        }

        /** 
         Métodos al pulsar el botón 5 
            */
        private void BtnCinco_Click(object sender, RoutedEventArgs e) {
            this.RellenarNumero("5");
        }

        /** 
         Métodos al pulsar el botón 6 
            */
        private void BtnSeis_Click(object sender, RoutedEventArgs e) {
            this.RellenarNumero("6");
        }

        /**
         Métodos al pulsar el botón 7 
            */
        private void BtnSiete_Click(object sender, RoutedEventArgs e) {
            this.RellenarNumero("7");
        }

        /** 
         Métodos al pulsar el botón 8 
            */
        private void BtnOcho_Click(object sender, RoutedEventArgs e) {
            this.RellenarNumero("8");
        }

        /** 
         Métodos al pulsar el botón 9 
            */
        private void BtnNueve_Click(object sender, RoutedEventArgs e) {
            this.RellenarNumero("9");
        }

        /** 
         Métodos al pulsar el botón 0 
            */
        private void BtnCero_Click(object sender, RoutedEventArgs e) {
            this.RellenarNumero("0");
        }

        /**
         Método para cambiar el simbolo del operando que estamos rellenando
             */
        private void BtnCambiarSigno_Click(object sender, RoutedEventArgs e) {
            if(this.operacion.Length == 0) {
                this.operando1.CambiarSigno();
                this.PintarNumero(this.operando1.GetOperandoString());
            } else {
                this.operando2.CambiarSigno();
                this.PintarNumero(this.operando2.GetOperandoString());
            }
        }

        /** 
         Método al pulsar para eliminar un número del perando
            */
        private void BtnMenorIgual_Click(object sender, RoutedEventArgs e) {
            if (operacion.Length == 0) { //OPERANDO1
                this.operando1.EliminarUltimoNumero();
                this.PintarNumero(this.operando1.GetOperandoString());
            } else { //OPERANDO2
                this.operando2.EliminarUltimoNumero();
                this.PintarNumero(this.operando2.GetOperandoString());
            }
        }

        /**
         Método que ocurre al pulsar C, pone la calculadora todo a 0;
             */
        private void BtnC_Click(object sender, RoutedEventArgs e) {
            this.operando1.ReiniciarOperando();
            this.operando2.ReiniciarOperando();
            this.operacion = "";
            this.operacionCompleta = "";
            this.PintarOperacionCompleta();
            this.PintarNumero("");
        }

        /**
         Método que ocurre al pulsar CE, pone a 0 el operador en el que esté
             */
        private void BtnCE_Click(object sender, RoutedEventArgs e) {
            if(operacion.Length == 0) {
                this.operando1.ReiniciarOperando();
            } else {
                this.operando2.ReiniciarOperando();
            }
            this.PintarNumero("0");
        }

        /** 
         Método para signar la suma como operación 
            */
        private void BtnSumar_Click(object sender, RoutedEventArgs e) {
            this.RellenarOperacion("+");
        }

        /** 
         Método para signar la resta como operación 
            */
        private void BtnRestar_Click(object sender, RoutedEventArgs e) {
            this.RellenarOperacion("-");
        }

        /** 
         Método para signar la multiplicación como operación 
            */
        private void BtnMultiplicar_Click(object sender, RoutedEventArgs e) {
            this.RellenarOperacion("*");
        }

        /** 
         Método para signar la división como operación 
            */
        private void BtnDividir_Click(object sender, RoutedEventArgs e) {
            this.RellenarOperacion("/");
        }

        /**
         Método que se ejecuta al pulsar igual, lo que hace mostrar el resultado en 
         pantalla
             */
        private void BtnIgual_Click(object sender, RoutedEventArgs e) {
            /* Se comprueba que los dos operando estan rellenos, no es necesario
             * comprobar la operación pues ya se ha comprobado anteriormente */
            if(!this.operando2.EstaVacio() && !this.operando2.EstaVacio()) {

                switch (this.operacion) {
                    case "+": {
                            this.resultado = (this.operando1.GetOperandoDouble() + this.operando2.GetOperandoDouble()).ToString();
                            break;
                        }
                    case "-": {
                            this.resultado = (this.operando1.GetOperandoDouble() - this.operando2.GetOperandoDouble()).ToString();
                            break;
                        }
                    case "*": {
                            this.resultado = (this.operando1.GetOperandoDouble() * this.operando2.GetOperandoDouble()).ToString();
                            break;
                        }
                    case "/": {
                            this.resultado = (this.operando1.GetOperandoDouble() / this.operando2.GetOperandoDouble()).ToString();
                            break;
                        }
                }
                this.operacionCompleta += this.operando2.GetOperandoString() + " = ";
                this.PintarOperacionCompleta();
                this.PintarNumero(this.resultado);

                /* Se reinician los operandos y el signo para poder seguir haciendo operaciones
                 * tras pulsar igual*/
                this.operando1.ReiniciarOperando();
                this.operando2.ReiniciarOperando();
                this.operacion = "";
            }
        }

        /**
         Recibe un entero y lo agrega a operando1 u operando2, además lo envia para
         pintar en pantalla
             */
        private void RellenarNumero(string num) {
            /* Si la operación aun no ha sido decidida se sigue rellenando
             * el primer operando, en caso contrario estamos seguros de que es
             * el segundo operando */
            if (operacion.Length == 0) {
                this.operando1.AddNumero(num);
                this.PintarNumero(this.operando1.GetOperandoString());

                /* Se elimina la operacion completa para borrarlo de la pantalla
                 * cuando se inserta de nuevo el operando 1*/
                this.operacionCompleta = "";
                this.PintarOperacionCompleta();
            } else {
                this.operando2.AddNumero(num);
                this.PintarNumero(this.operando2.GetOperandoString());
            }
        }

        /**
         Recibe un String con el simbolo de la operación y lo agrega como 
         simbolo de la operación
             */
        private void RellenarOperacion(string operacion) {
            /* La condición para que se grabe correctamente es que el operando 2 no se
             * haya empezado a rellenar, para no poder cambiar el simbolo de la operación
             * mientras que ya se ha empezado a rellenar el segundo número */
            if(this.operando2.EstaVacio()) {
                this.operacion = operacion;
                /* Se agrega a operacion completa el primer operando y el operador, para mostrarlo
                 * por pantalla */
                this.operacionCompleta = this.operando1.GetOperandoString() + " " + this.operacion + " ";
                this.PintarOperacionCompleta();
            }
        }

        /**
         Recibe un String y lo pinta en el textBox 
            */
        private void PintarNumero(string num) {
            txbPantalla.Text = num;
        }

        /**
         Pinta el string operacionCompleta en la pantalla
             */
        private void PintarOperacionCompleta() {
            txbOperacion.Text = this.operacionCompleta;
        }
    }
}
