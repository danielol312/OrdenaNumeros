using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace OrdenaNumeros
{
    public class Logic
    {
        
        //Atributos propios del juego
        private int[,] matrizValores;
        private Button[,] matrizBotones; //creo que el botón se puede quitar por ser objeto
        private int posicionFila, posicionColumna;
        

        //propiedades asociadas a los atributos
               
        public Logic()
        {
            posicionFila = 0;
            posicionColumna = 0;

            matrizBotones = new Button[4, 4];
            matrizValores = new int[4, 4];


        }
        /// <summary>
        /// Inicializa la matriz de botones, con los botones del interfaz
        /// </summary>
        public void InicializaMatrizBotones(Button boton1, Button boton2, Button boton3, Button boton4, Button boton5, Button boton6, Button boton7, Button boton8, Button boton9, Button boton10, Button boton11, Button boton12, Button boton13, Button boton14, Button boton15, Button boton16)
        {
            matrizBotones[0, 0] = boton1;
            matrizBotones[0, 1] = boton2;
            matrizBotones[0, 2] = boton3;
            matrizBotones[0, 3] = boton4;

            matrizBotones[1, 0] = boton5;
            matrizBotones[1, 1] = boton6;
            matrizBotones[1, 2] = boton7;
            matrizBotones[1, 3] = boton8;

            matrizBotones[2, 0] = boton9;
            matrizBotones[2, 1] = boton10;
            matrizBotones[2, 2] = boton11;
            matrizBotones[2, 3] = boton12;

            matrizBotones[3, 0] = boton13;
            matrizBotones[3, 1] = boton14;
            matrizBotones[3, 2] = boton15;
            matrizBotones[3, 3] = boton16;
        }
        /// <summary>
        /// Inicializa la matriz de valores, asignando los numeros a organizar
        /// </summary>
        public void InicializaMatrizValores()
        {
            int valor = 0;

            //Inicialmente se asignan los números del 0 al 15 en toda la matriz
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrizValores[i, j] = valor;
                    valor++;
                }
            }
            //Luego, procedemos a cambiar los valores de posición de manera aleatoria

            Random aleatorio = new Random();
            int posicionHorizontal, posicionVertical, valorTemporal;

            //Aqui desordenamos la matriz, calculando posiciones horizontales y
            //verticales dentro de la matriz
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    valorTemporal = matrizValores[i, j];
                    posicionHorizontal = aleatorio.Next(4);
                    posicionVertical = aleatorio.Next(4);

                    matrizValores[i, j] = matrizValores[posicionHorizontal, posicionVertical];
                    matrizValores[posicionHorizontal, posicionVertical] = valorTemporal;
                }
            }
        }
        /// <summary>
        /// Asigna los valores de la matrizValores como etiquetas de los
        /// botones en la matrizBotones
        /// </summary>
        public void InicializaEtiquetaBotones()
        {
            //Recalculamos la matriz de valores
            InicializaMatrizValores();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //El botón que tenga el valor 0, se verá como vacío
                    //para que el usuario pueda "desplazar" el valor allí
                    if (matrizValores[i, j] == 0)
                        matrizBotones[i, j].Text = "";
                    else
                        matrizBotones[i, j].Text = matrizValores[i, j].ToString();
                }
            }
        }
        /// <summary>
        /// Evalua información asociada al botón presionado
        /// </summary>
        /// <param name="numeroBoton">Consecutivo del botón presionado</param>
        /// <param name="datoFila">Fila en la matriz a la que pertenece el botón</param>
        /// <param name="datoColumna">Columna en la matriz a la que pertenece el botón</param>
        public void EvaluaBotonPresionado(int numeroBoton, int datoFila, int datoColumna)
        {
            posicionFila = datoFila;
            posicionColumna = datoColumna;

            //Aqui evaluamos en la matrizValores, la posición correspondiente al botón presionado
            EvaluaPosicion();

            //Finalmente, se da la notificación si el valor se encuentra en la posición correcta
            NotificaPosicionCorrectaValor();
        }
        /// <summary>
        /// Evalua si la posición presionada está adjacente al espacio disponible para usar
        /// </summary>
        private void EvaluaPosicion()
        {
            int valorTemporal = 0;

            //Validamos el valor superior a donde presionamos si está el cero
            if (posicionFila > 0)
            {
                if (matrizValores[posicionFila - 1, posicionColumna] == 0)
                {
                    valorTemporal = matrizValores[posicionFila, posicionColumna];
                    matrizValores[posicionFila, posicionColumna] = 0;
                    matrizValores[posicionFila - 1, posicionColumna] = valorTemporal;
                }
            }

            //Validamos el valor inferior a donde presionamos si está el cero
            if (posicionFila < 3)
            {
                if (matrizValores[posicionFila + 1, posicionColumna] == 0)
                {
                    valorTemporal = matrizValores[posicionFila, posicionColumna];
                    matrizValores[posicionFila, posicionColumna] = 0;
                    matrizValores[posicionFila + 1, posicionColumna] = valorTemporal;
                }
            }

            //Validamos el valor izquierdo a donde presionamos si está el cero
            if (posicionColumna > 0)
            {
                if (matrizValores[posicionFila, posicionColumna - 1] == 0)
                {
                    valorTemporal = matrizValores[posicionFila, posicionColumna];
                    matrizValores[posicionFila, posicionColumna] = 0;
                    matrizValores[posicionFila, posicionColumna - 1] = valorTemporal;
                }
            }

            //Validamos el valor derecho a donde presionamos si está el cero
            if (posicionColumna < 3)
            {
                if (matrizValores[posicionFila, posicionColumna + 1] == 0)
                {
                    valorTemporal = matrizValores[posicionFila, posicionColumna];
                    matrizValores[posicionFila, posicionColumna] = 0;
                    matrizValores[posicionFila, posicionColumna + 1] = valorTemporal;
                }
            }

            //Finalmente actualizamos etiquetas de los botones
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (matrizValores[i, j] == 0)
                        matrizBotones[i, j].Text = "";
                    else
                        matrizBotones[i, j].Text = matrizValores[i, j].ToString();
                }
            }

            //Y valoramos la condición de victoria
            EvaluaCondicionVictoria();
        }
        /// <summary>
        /// Notifica que el número se encuentra en la posición correcta, cambiando el color de fondo del botón
        /// </summary>
        public void NotificaPosicionCorrectaValor()
        {

            int[,] valoresEsperados = new int[4, 4];
            int valor = 1;

            int totalFilas = valoresEsperados.GetLength(0);
            int totalColumnas = valoresEsperados.GetLength(1);

            //Aqui llenamos la matriz de los valores esperados
            for (int i = 0; i < totalFilas; i++)
                for (int j = 0; j < totalColumnas; j++)
                {
                    valoresEsperados[i, j] = valor;
                    valor++;
                }

            //Al finalizar el juego, en la posición 4,4 se encuentra el 0
            valoresEsperados[3, 3] = 0;

            //Ahora comparamos con los valores actuales para saber si están en la posición correcta
            for (int i = 0; i < totalFilas; i++)
                for (int j = 0; j < totalColumnas; j++)
                {
                    if (matrizValores[i, j] == valoresEsperados[i, j])
                        matrizBotones[i, j].BackColor = Color.LightGreen;
                    else
                        matrizBotones[i, j].BackColor = Color.LightGray;

                    //El botón que tiene el 0 no deberá cambiar de color
                    if (matrizValores[i, j] == 0)
                        matrizBotones[i, j].BackColor = Color.LightGray;
                }
        }
        /// <summary>
        /// Esta función valida si todos los números están organizados
        /// </summary>
        public void EvaluaCondicionVictoria()
        {
            //Partimos del supuesto que ya logramos la condición de victoria
            bool condicionVictoria = true;

            int valorBuscado = 0;

            //Aqui recorremos la matriz de valores buscando para cada posición si el valor está en orden
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //incrementamos el valor buscado
                    valorBuscado++;

                    //Si los valores son diferentes, entonces todavía necesitamos seguir jugando!!!
                    if (matrizValores[i, j] != valorBuscado)
                    {
                        // Validamos si estamos en la última casilla, el valor existente es 0,
                        // el valor buscado ya llegó a 16 y la condición de victoria sigue siendo true
                        if (matrizValores[i, j] == 0 && valorBuscado == 16 && condicionVictoria == true)
                            condicionVictoria = true;

                        // De lo contrario, es porque estamos en cualquier otra casilla y los valores
                        // Todavía no son iguales
                        else
                            condicionVictoria = false;
                    }
                }
            }


            //Si la condición de victoria se logró, mostramos el mensaje de Victoria y desactivamos los botones
            if (condicionVictoria == true)
            {
                MessageBox.Show("Todos los números organizados, Felicitaciones!", "Victoria Alcanzada!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                InactivaBotones();
            }
        }
        /// <summary>
        /// Esta función inactiva los botones para ser utilizados en el juego
        /// </summary>
        public void InactivaBotones()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    matrizBotones[i, j].Enabled = false;
        }
        /// <summary>
        /// Esta función activa los botones para ser utilizados en el juego
        /// </summary>
        public void ActivaBotones()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    matrizBotones[i, j].Enabled = true;
        }
        public void InicializaFondoBotones()
        {
            int totalFilas = matrizBotones.GetLength(0);
            int totalColumnas = matrizBotones.GetLength(1);

            //Asignamos a todos los botones gris claro como color de fondo
            for (int i = 0; i < totalFilas; i++)
                for (int j = 0; j < totalColumnas; j++)
                    matrizBotones[i, j].BackColor = Color.LightGray;
        }


    }

}

