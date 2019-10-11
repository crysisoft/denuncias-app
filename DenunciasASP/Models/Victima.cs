using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenunciasASP.Models
{
    public class Victima
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        
        [Required]
        [MaxLength(50)]
        [Display(Name = "Identificación")]
        public string Identificacion { get; set; }

        [Required]
        [Display(Name = "Sexo")]
        public int SexoId { get; set; }

        [ForeignKey("SexoId")]
        public Sexo Sexo { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        [Required]
        [Display(Name = "Denuncia")]
        public int DenunciaId { get; set; }

        [ForeignKey("DenunciaId")]
        public Denuncia denuncia { get; set; }

    }
}