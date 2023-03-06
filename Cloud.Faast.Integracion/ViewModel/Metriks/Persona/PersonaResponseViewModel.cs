﻿namespace Cloud.Faast.Integracion.ViewModel.Metriks.Persona
{
    public class PersonaResponseViewModel
    {
        public int Id { get; set; }
        public string? RazonSocial { get; set; }
        public bool Cliente { get; set; }
        public bool Deudor { get; set; }
        public string? RutEjecutivo { get; set; }
        public string? EstadoCliente { get; set; }
        public string? EstadoDeudor { get; set; }
    }
}
