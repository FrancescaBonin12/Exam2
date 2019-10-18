using System;
using System.Collections.Generic;
using System.Text;

namespace Esame2
{
    public class JsonMacchinaManager : JsonManagerBase<macchina>
    {
    protected override void RemapNuoviValoriSuEntityInLista(
            macchina entitySorgente, macchina entityDestinazione)
        {
            entityDestinazione.Modello = entitySorgente.Modello;
            entityDestinazione.Marca = entitySorgente.Marca;
            entityDestinazione.NumeroCavalli = entitySorgente.NumeroCavalli;
            entityDestinazione.IsDiesel = entitySorgente.IsDiesel;
            entityDestinazione.DataImmatricolazione = entitySorgente.DataImmatricolazione;

        }

    }
}
