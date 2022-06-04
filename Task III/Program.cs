using System;
using System.Threading.Tasks;
using System.Threading;

namespace Task_III
{
    class Program
    {
        static void Main(string[] args)
        {
            RealizarOtrasTareas();

            Console.ReadLine();
        }

        static void EjecutarTarea()
        {


            for (int i = 0; i < 3; i++)
            {
                var Mithreath = Thread.CurrentThread.ManagedThreadId;

                Thread.Sleep(1000);

                Console.WriteLine("Esta vuelta del bucle corresponde al THreath: " + Mithreath + "...");
            }

            
        }

        static void RealizarOtrasTareas()
        {

          var tarea1 =  Task.Run(() =>
            {

                EjecutarTarea();


            });
            //hzce que esta tarea primero termine para empezar las otras
            tarea1.Wait();
            var tarea2 = Task.Run(() =>
            {

                EjecutarTarea2();


            });
            //La tarea 3 no comenzara hasta que termine las anteriores gracias al metodo waitall
            //Task.WaitAll(tarea1, tarea2);
            //Waut any sirve para que cuando cualquiera de las dos termine esta empueze
           // Task.WaitAny(tarea1, tarea2);
            var tarea3 = Task.Run(() =>
            {

                EjecutarTarea3();


            });

            
        }

        static void EjecutarTarea2()
        {


            for (int i = 0; i < 3; i++)
            {
                var Mithreath = Thread.CurrentThread.ManagedThreadId;

                Thread.Sleep(500);

                Console.WriteLine("Esta vuelta del bucle corresponde al THreath: " + Mithreath + " Corresponde a la tarea 2---");
            }
        }
        static void EjecutarTarea3()
        {


            for (int i = 0; i < 3; i++)
            {
                var Mithreath = Thread.CurrentThread.ManagedThreadId;

                Thread.Sleep(500);

                Console.WriteLine("Esta vuelta del bucle corresponde al THreath: " + Mithreath + "Correspobde a la tarea 3...-----");
            }
        }

    }
}
