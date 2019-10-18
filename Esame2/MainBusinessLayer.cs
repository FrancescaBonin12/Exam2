using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Esame2
{

    /// <summary>
    /// Classe che contiene il flusso funzionale di Galaxy
    /// </summary>
    public class MainBusinessLayer
    {
       
       
            private IManager<bicicletta> _BiciManager;
            private IManager<macchina> _AutoManager;

            public MainBusinessLayer(IManager<bicicletta> biciMan, IManager<macchina> autoMan)
            {
                _BiciManager = biciMan;
                _AutoManager = autoMan;
            }

        public string[] CreaBiciSeNonEsiste(
       string modello, string marca, int numeroditelaio,
       string iselettrica)
        {
            //1) Validazione degli input
            if (string.IsNullOrEmpty(modello))
                throw new ArgumentNullException(nameof(modello));
            if (string.IsNullOrEmpty(marca))
                throw new ArgumentNullException(nameof(marca));
            if (numeroditelaio <= 0)
                throw new ArgumentNullException(nameof(numeroditelaio));
            if (string.IsNullOrEmpty(iselettrica))
                throw new ArgumentNullException(nameof(iselettrica));

            //Predisposizione messaggi di uscita
            IList<string> messaggi = new List<string>();


            //3)  Verifico che il prezzo sia > 1
            if (numeroditelaio <= 0)
            {
                //Aggiungo il messaggio di errore, ed esco
                messaggi.Add($"Il numero di telaio deve essere maggiore di 0");
                return messaggi.ToArray();
            }

            /*
            //4) Verifico che il codice non sia già usato
            Libro libroConStessoCodice = GetLibroByCodice(codice);
            if (libroConStessoCodice != null)
            {
                //Aggiungo il messaggio di errore, ed esco
                messaggi.Add($"Esiste già un libro con il " +
                    $"codice '{codice}' (ha l'id {libroConStessoCodice.Id})");
                return messaggi.ToArray();
            }

    */

            //7) Creo l'oggetto con tutti i dati
            bicicletta nuovabici = new bicicletta
            {
                Modello = modello,
                Marca = marca,
                Numeroditelaio = numeroditelaio,
                IsElettrica = iselettrica,
            };

            //Aggiungo il libro
            _BiciManager.Crea(nuovabici);

            //8) Ritorno in uscita le validazioni (vuote se non ho errori)
            return messaggi.ToArray();
        }




        public string[] CreaMacchinaSeNonEsiste(
      string modello, string marca, int numerodicavalli,
      string  isdiesel)
        {
            //1) Validazione degli input
            if (string.IsNullOrEmpty(modello))
                throw new ArgumentNullException(nameof(modello));
            if (string.IsNullOrEmpty(marca))
                throw new ArgumentNullException(nameof(marca));
            if (numerodicavalli <= 100)
                throw new ArgumentNullException(nameof(numerodicavalli));
            if (string.IsNullOrEmpty(isdiesel))
                throw new ArgumentNullException(nameof(isdiesel));

            //Predisposizione messaggi di uscita
            IList<string> messaggi = new List<string>();


            //3)  Verifico che il prezzo sia > 1
            if (numerodicavalli <= 0)
            {
                //Aggiungo il messaggio di errore, ed esco
                messaggi.Add($"Il numero di cavalli deve essere maggiore di 100");
                return messaggi.ToArray();
            }

            /*
            //4) Verifico che il codice non sia già usato
            Libro libroConStessoCodice = GetLibroByCodice(codice);
            if (libroConStessoCodice != null)
            {
                //Aggiungo il messaggio di errore, ed esco
                messaggi.Add($"Esiste già un libro con il " +
                    $"codice '{codice}' (ha l'id {libroConStessoCodice.Id})");
                return messaggi.ToArray();
            }

    */

            //7) Creo l'oggetto con tutti i dati
            macchina nuovamacchina = new macchina
            {
                Modello = modello,
                Marca = marca,
                NumeroCavalli = numerodicavalli,
                IsDiesel = isdiesel,
            };

            //Aggiungo il libro
            _AutoManager.Crea(nuovamacchina);

            //8) Ritorno in uscita le validazioni (vuote se non ho errori)
            return messaggi.ToArray();
        }












        ~MainBusinessLayer()
            {
            _BiciManager = null;
            _AutoManager = null;
            }
        }
}
