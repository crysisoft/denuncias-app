using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenunciasASP.Models
{
    public class Denuncia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Localidad")]
        public int LocalidadId { get; set; }

        [ForeignKey("LocalidadId")]
        public Localidad Localidad { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Agreción")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaHoraOcurrido { get; set; }

        [Required]
        [Display(Name = "Tipo Delito")]
        public int TipoDelitoId { get; set; }

        [ForeignKey("TipoDelitoId")]
        public DelitoTipo TipoDelito { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        public Estado Estado { get; set; }

        [Required]
        [Display(Name = "Lugar Afectado")]
        public int LugarAfectadoId { get; set; }

        [ForeignKey("LugarAfectadoId")]
        public LugarAfectado LugarAfectado { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "Sintesis")]
        [DataType(DataType.MultilineText)]
        public string Sintesis { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "Dirección")]
        [DataType(DataType.MultilineText)]
        public string Direccion { get; set; }       
        

        [Required]
        [Display(Name = "Masculino")]
        public int CuantosMasculino { get; set; }

        [Required]
        [Display(Name = "Femenino")]
        public int CuantosFemenino { get; set; } 
        
        [Required]
        [Display(Name = "Desconocidos")]
        public int CuantosDesconocidos { get; set; }

        public ICollection<Victima> Victimas { get; set; }
        public ICollection<ObjetoAfectado> objetoAfectados { get; set; }
        public ICollection<ObjetoUtilizado> objetoUtilizados { get; set; }
        public ICollection<PresuntoAutor> presuntoAutors { get; set; }
    }
}