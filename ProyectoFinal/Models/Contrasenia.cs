using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public class Contrasenia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String Salt { get; set; }
        public String hash { get; set; }

        
    }
}
