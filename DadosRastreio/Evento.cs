using System;

namespace RasReiios.DadosRastreio
{

    public class Evento
    {
        public string codigo { get; set; }
        public string descricao { get; set; }
        public DateTime dtHrCriado { get; set; }
        public string tipo { get; set; }
        public Unidade unidade { get; set; }
        public string urlIcone { get; set; }
        public UnidadeDestino unidadeDestino { get; set; }
    }

}