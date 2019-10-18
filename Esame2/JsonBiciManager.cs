using System;
using System.Collections.Generic;
using System.Text;

namespace Esame2
{
    public class JsonBiciManager : JsonManagerBase<bicicletta>
    {

        protected override void RemapNuoviValoriSuEntityInLista(
                   bicicletta entitySorgente, bicicletta entityDestinazione)
        {
            entityDestinazione.Modello = entitySorgente.Modello;
            entityDestinazione.Marca = entitySorgente.Marca;
            entityDestinazione.Numeroditelaio = entitySorgente.Numeroditelaio;
            entityDestinazione.IsElettrica = entitySorgente.IsElettrica;
        }


    }
}
