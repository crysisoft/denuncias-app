using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenunciasASP.Models
{
    public class ObjetoAfectado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Objeto Afectado")]
        public string NombreAfectado { get; set; }      

        [Required]
        [Display(Name = "Cantidad")]
        public int CantidadAfectado { get; set; }

        [Required]
        [Display(Name = "Denuncia")]
        public int DenunciaId { get; set; }

        [ForeignKey("DenunciaId")]
        public Denuncia denuncia { get; set; }

    }
}