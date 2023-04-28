using System;
using System.ComponentModel.DataAnnotations;

namespace PersonaApp
{
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre debe tener como máximo 100 caracteres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El Apellido es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre debe tener como máximo 100 caracteres")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "La matrícula es obligatoria")]
        [RegularExpression(@"^[0-9a-zA-Z]{10}$", ErrorMessage = "La matrícula debe tener exactamente 10 caracteres y solo puede contener dígitos y letras")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime FechaDeNacimiento { get; set; }
        public decimal UbicacionLatitud { get; set; }
        public decimal UbicacionLongitud { get; set; }
        public decimal UbicacionAltitud { get; set; }
    }
}