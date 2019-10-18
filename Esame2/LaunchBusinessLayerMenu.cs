using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esame2
{
    public static class LaunchBusinessLayerMenu
    {

        public static void Summary()
        {
            //Menu
            Console.WriteLine("***********************");
            Console.WriteLine("* Business Layer Menu *");
            Console.WriteLine("***********************");
            Console.WriteLine("* 1 - Crea bici");

            //Recupero della selezione
            var selezione = ConsoleUtils.LeggiNumeroInteroDaConsole(1, 1);

            //Avvio della procedura
            switch (selezione)
            {
                //********************************************************
                case 1:
                    CreaBici();
                    break;

                //********************************************************
                default:
                    Console.WriteLine("Selezione non valida");
                    break;
            }
        }

        public static void CreaBici()
        {
            //Richiedo all'utente il tipo di provider dati
            //ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Provider storage(Json,Text,Sql):");
            //string storageTypeAsString = ConsoleUtils.ReadLine<string>(e => e == "Sql" || e == "Json" || e == "Text");
            //StorageType storageType = Enum.Parse<StorageType>(storageTypeAsString);

            //Richiediamo i dati da console
            Console.Write( "Modello:");
            string modello = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            Console.Write( "Marca:");
            string marca = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            Console.WriteLine( "numeroditelaio:");
            int numeroditelaio = ConsoleUtils.ReadLine<int>(a => a > 0);
            Console.WriteLine( "Inserisci 'yes' se è elettrica, altrimenti inserisci 'no':");
            string iselettrica = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
           

            IManager<bicicletta> biciManager;
            IManager<macchina> macchinaManager;

            StorageType storageType=0;
            //Switch sul tipo di storage
            switch (storageType)
            {
                case StorageType.Json:
                    biciManager = new JsonBiciManager();
                    macchinaManager = new JsonMacchinaManager();
                    break;
                default:
                    throw new NotSupportedException($"Il provider {storageType} non è supportato");
            }

    

            //Istanzio il business layer (che il cervello della 
            //nostra applicazione)
            MainBusinessLayer layer = new MainBusinessLayer(biciManager, macchinaManager);

            //Avvio la funzione di creazione
            string[] messaggiDiErrore = layer.CreaBiciSeNonEsiste(
               modello, marca,numeroditelaio, iselettrica);

            //Se non ho messaggi di errore, confermo
            if (messaggiDiErrore.Length == 0)
               Console.WriteLine( "Creazione eseguita con successo");
            else
            {
                //Messaggio di errore generale
                Console.WriteLine("Attenzione! Ci sono errori nella creazione!");

                //Scorriamo gli errori e li mostriamo all'utente
                foreach (var currentMessage in messaggiDiErrore)
                    Console.WriteLine( currentMessage);
            }

        }



        public static void CreaMacchina()
        {
            //Richiedo all'utente il tipo di provider dati
            //ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Provider storage(Json,Text,Sql):");
            //string storageTypeAsString = ConsoleUtils.ReadLine<string>(e => e == "Sql" || e == "Json" || e == "Text");
            //StorageType storageType = Enum.Parse<StorageType>(storageTypeAsString);

            //Richiediamo i dati da console
            Console.Write("Modello:");
            string modello = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            Console.Write("Marca:");
            string marca = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            Console.WriteLine("Numero di cavalli:");
            int numerodicavalli = ConsoleUtils.ReadLine<int>(a => a > 0);
            Console.WriteLine("è a diesel? Scrivi 'yes' oppure 'no'");
            string isdiesel = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            Console.WriteLine("Data di immatricolazione");
            string datadiimmatricolazione = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));


            IManager<bicicletta> biciManager;
            IManager<macchina> macchinaManager;


            //Switch sul tipo di storage
            StorageType storageType= 0;
            switch (storageType)
             {
                 case StorageType.Json:
                    biciManager = new JsonBiciManager();
                    macchinaManager = new JsonMacchinaManager();
                    break;
                 default:
                     throw new NotSupportedException($"Il provider {storageType} non è supportato");
             }

  

            //Istanzio il business layer (che il cervello della 
            //nostra applicazione)
            MainBusinessLayer layer = new MainBusinessLayer(biciManager, macchinaManager);

            //Avvio la funzione di creazione
            string[] messaggiDiErrore = layer.CreaMacchinaSeNonEsiste(
               modello, marca, numerodicavalli, isdiesel);

            //Se non ho messaggi di errore, confermo
            if (messaggiDiErrore.Length == 0)
                Console.WriteLine("Creazione eseguita con successo");
            else
            {
                //Messaggio di errore generale
                Console.WriteLine("Attenzione! Ci sono errori nella creazione!");

                //Scorriamo gli errori e li mostriamo all'utente
                foreach (var currentMessage in messaggiDiErrore)
                    Console.WriteLine(currentMessage);
            }

        }

        /*      public static void Stampalistabici()
               {


          //LEGGI

        //Leggiamo i libri dal disco => "R" di CRUD
       // Console.WriteLine("Lettura del database...");
            //libriInArchivio = manager.Carica();
            //Console.WriteLine($"Trovati {libriInArchivio.Count} libri in archivio");
            //foreach (var currentLibro in libriInArchivio)
                //Console.WriteLine($"Lettura: {currentLibro.Titolo} (ID:{currentLibro.Id})");
            //Console.WriteLine("");
               }

           */


        /*      public static void Stampalistamacchine()
                {

                }

            */


    }
}
