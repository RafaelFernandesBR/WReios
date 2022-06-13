using System.Collections.Generic;

namespace RasReiios.DadosRastreio
{

    public class Root
    {
        public List<Objeto> objetos { get; set; }
        public int quantidade { get; set; }
        public string resultado { get; set; }
        public string versao { get; set; }
    }

}