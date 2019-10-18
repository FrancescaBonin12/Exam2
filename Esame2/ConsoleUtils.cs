using System;
using System.Collections.Generic;
using System.Text;

namespace Esame2
{
    class ConsoleUtils
    {

        public static int LeggiNumeroInteroDaConsole(int minValue, int maxValue)
        {
            //Leggo il valore stringa da console
            string valoreString;
            int valoreIntero = 0;

            //Predisposizione al fallimento
            bool isInteger = false;
            bool isInRange = false;

            do
            {
                try
                {
                    //Eseguo la lettura del valore da console
                    Console.Write("- selezione: ");
                    valoreString = Console.ReadLine();

                    //Validazione e parsing del valore
                    valoreIntero = int.Parse(valoreString);
                    isInteger = true;

                    //Verifico se è nel range
                    if (valoreIntero >= minValue && valoreIntero <= maxValue)
                    {
                        //imposto il flag IsInRange
                        isInRange = true;
                    }
                    else
                    {
                        //Messaggio di errore
                        Console.WriteLine("Attenzione! Il valore immesso non è nel range indicato");

                        //Ripristino condizioni di predisposizione fallimento iniziali
                        valoreIntero = 0;
                        isInteger = false;
                        isInRange = false;
                    }
                }
                catch (Exception exc)
                {
                    //Messaggio di errore
                    Console.WriteLine("Attenzione! Il valore immesso NON è un numero!");

                    //Ripristino condizioni di predisposizione fallimento iniziali
                    valoreIntero = 0;
                    isInteger = false;
                    isInRange = false;
                }
            }
            while (isInteger == false || isInRange == false);

            //Ritorno il valore intero
            return valoreIntero;
        }


        public static void ConfermaUscita()
        {
            Console.Write("Premi un pulsante per uscire");
            Console.ReadKey();
        }


        /// <summary>
        /// Esegue la lettura di standard input (console)
        /// di un valore e tenta di eseguire la conversione
        /// nel tipo specificato come generico
        /// </summary>
        /// <typeparam name="TOutput">Tipo a cui convertire</typeparam>
        /// <returns>Ritorna il valore convertito</returns>
        public static TOutput ReadLine<TOutput>(Func<TOutput, bool> acceptanceCondition)
        {
            //Predisposizione valori            
            TOutput valoreConvertito = default(TOutput);
            bool isValidCast = false;
            bool isAccepted = false;

            while (!isValidCast || !isAccepted)
            {
                //Try perchè il cast potrebbe fallire
                try
                {
                    //Lettura da console
                    string valueFromConsole = Console.ReadLine();

                    //Tento il casting forzato
                    valoreConvertito = (TOutput)Convert
                        .ChangeType(valueFromConsole, typeof(TOutput));

                    //Il cast è andato bene
                    isValidCast = true;

                    //Verifico la condizione di accettazione
                    isAccepted = acceptanceCondition(valoreConvertito);

                    //La condizione è stata accetta o meno
                    if (!isAccepted)
                    {
                        //Mostro un messaggio utente con l'errore di parsing
                        Console.WriteLine( "Condizione non valida. Riprova: ");
                    }
                }
                catch (Exception exc)
                {
                    //Mostro un messaggio utente con l'errore di parsing
                    Console.WriteLine( "Selezione non valida. Riprova: ");

                    //Il cast non è valido
                    isValidCast = false;
                }
            }

            //Se arrivo qui, il casting ok, ed esco
            return valoreConvertito;
        }





    }
}
