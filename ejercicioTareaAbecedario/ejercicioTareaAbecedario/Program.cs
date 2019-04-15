using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace AbecedarioTareas
{
    class Program
    {
        static readonly int limiteLetras = 26; //cantidad de letras en el abecedario    
        static readonly int valor_anscii_letra_A = 65;
        static void Main(string[] args)
        {
            Dictionary<char, string> abecedario = new Dictionary<char, string>();
            int x = 0;// indice para operar

            Task t1 = new Task(() => {
                while (x < limiteLetras) //mientras el indice es menor al limite de letras del abecedario
                {
                    if (isPar(x))
                    {
                        abecedario.Add((char)(x + valor_anscii_letra_A), "Tarea 1"); //al valor que contiene valor_anscii... le suma al indice ,que al castearlo a un car 
                                                                                     //obtengo la letra.
                        x++; // y sumo el valor de el indice
                    }
                }
            });

            Task t2 = new Task(() => {
                while (x < limiteLetras)
                {
                    if (!isPar(x)) //si el valor no es par 
                    {
                        abecedario.Add((char)(x + valor_anscii_letra_A), "Tarea 2"); //aca hace lo mismo que arriba exepto que esta vez graba la tarea 2
                        x++;
                    }
                }
            });

            Task t3 = new Task(() => {
                foreach (KeyValuePair<char, string> item in abecedario)
                {
                    Console.WriteLine("la letra : {0} fue grabada por la {1}", item.Key, item.Value);
                }

            });// cree una nueva tarea para imprimir los valores

            t1.Start();
            t2.Start();

            Task.WaitAny(new Task[] { t1, t2 }); // espera por las tareas que terminen su ejecucion

            t3.Start();
            t3.Wait();
            Console.ReadLine();

        }

        static bool isPar(int n)
        {
            return n % 2 == 0;
        }
    }
}
