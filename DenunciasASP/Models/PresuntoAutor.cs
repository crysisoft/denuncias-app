using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenunciasASP.Models
{
    public class PresuntoAutor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombre")]
        public string NombreAutor { get; set; }
        
        [Required]
        [MaxLength(50)]
        [Display(Name = "Alias")]
        public string Alias { get; set; }
        
        [Required]
        [MaxLength(50)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Color Piel")]
        public int ColorPielId { get; set; }

        [ForeignKey("ColorPielId")]
        public Color ColorPiel { get; set; }

        [Required]
        [Display(Name = "Color Cabello")]
        public int ColorCabelloId { get; set; }

        [ForeignKey("ColorCabelloId")]
        public Color ColorCabello { get; set; }

        [Required]
        [Display(Name = "Estatura")]
        public float EstaturaAprox { get; set; }

        [Required]
        [Display(Name = "Contextura")]
        public int ContexturaId { get; set; }

        [ForeignKey("ContexturaId")]
        public Contextura Contextura { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Tatuajes")]
        public string Tatuajes { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Cicatrices")]
        public string Cicatrices { get; set; }

        [Required]
        [Display(Name = "Sexo")]
        public int SexoId { get; set; }

        [ForeignKey("SexoId")]
        public Sexo Sexo { get; set; }

        [Required]
        [Display(Name = "Denuncia")]
        public int DenunciaId { get; set; }

        [ForeignKey("DenunciaId")]
        public Denuncia denuncia { get; set; }

    }
}