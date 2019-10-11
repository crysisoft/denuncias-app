using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenunciasASP.Models
{
    public class Localidad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Localidad")]
        public string NombreLocalidad { get; set; }
        [Required]
        [MaxLength(30)]
        public string Municipio { get; set; }
        [Required]
        [Display(Name = "No Distrito")]
        public int NoDistrito { get; set; } 
    }
}