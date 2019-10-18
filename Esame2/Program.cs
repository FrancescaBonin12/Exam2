using System;

namespace Esame2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Visualizzo menu e richiedo selezione
            Console.WriteLine("*******************************");
            Console.WriteLine("* MENU                        *");
            Console.WriteLine("*******************************");
            Console.WriteLine("* 1 - Esegui Menù Biciclette");
            Console.WriteLine("* 2 - Esegui Menù Macchine");
           
            var selezione = ConsoleUtils.LeggiNumeroInteroDaConsole(1, 2);

            //Selezione dell'opzione
            switch (selezione)
            {
                case 1:
                    LaunchBusinessLayerMenu.CreaBici();
                    break;
                case 2:
                    LaunchBusinessLayerMenu.CreaMacchina();
                    break;
                default:
                    Console.WriteLine("Opzione non valida!");
                    break;
            }

            //Richiedo conferma di uscita
            ConsoleUtils.ConfermaUscita();
        }
    }
}
