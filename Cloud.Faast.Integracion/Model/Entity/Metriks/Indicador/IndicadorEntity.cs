using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Model.Entity.Metriks.Indicador
{
    public class IndicadorEntity
    {
        public string? co_tipo { get; set; }
        public int id_rut { get; set; }
        public string? rut { get; set; }
        public decimal mt_cartera_vigente { get; set; }
        public decimal mt_cartera_pagada { get; set; }
        public decimal mt_cartera_morosa { get; set; }
        public decimal mt_riesgo_otorgado { get; set; }
        public decimal mt_concentracion { get; set; }
        public decimal mt_cta_cobrar { get; set; }
        public decimal mt_excedente { get; set; }
        public decimal prom_plazo_pago { get; set; }
        public decimal prom_plazo_mora { get; set; }
        public decimal prom_tasa { get; set; }
        public decimal mt_concentracion_max { get; set; }
        public DateTime fe_concentracion_max { get; set; }
        public DateTime fe_creacion { get; set; }

    }
}
