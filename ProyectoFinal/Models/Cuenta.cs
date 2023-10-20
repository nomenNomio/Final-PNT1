using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public class Cuenta
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public Boolean Admin { get; set; }
        public List<Refugio>? Refugios { get; set; }
        public List<Mascota>? Mascotas { get; set; }



    }
}
