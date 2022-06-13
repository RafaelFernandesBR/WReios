using System;
using System.Collections.Generic;

namespace RasReiios.DadosRastreio
{

    public class Objeto
    {
        public string codObjeto { get; set; }
        public DateTime dtPrevista { get; set; }
        public List<Evento> eventos { get; set; }
        public string modalidade { get; set; }
        public TipoPostal tipoPostal { get; set; }
        public bool habilitaAutoDeclaracao { get; set; }
        public bool permiteEncargoImportacao { get; set; }
        public bool habilitaPercorridaCarteiro { get; set; }
        public bool bloqueioObjeto { get; set; }
        public bool possuiLocker { get; set; }
        public bool habilitaLocker { get; set; }
        public bool habilitaCrowdshipping { get; set; }
    }

}