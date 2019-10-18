using System;
using System.Collections.Generic;
using System.Text;

namespace Esame2
{
    public class macchina: veicolo

    {
      
        public string Modello { get; set; }

        public string Marca { get; set; }

      
        public int NumeroCavalli { get; set; } 

        public string IsDiesel { get; set; }  // TODO bool

        public DateTime DataImmatricolazione { get; set; }



    }
}
