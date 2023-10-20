
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Collections;

namespace ProyectoFinal.Models
{
    public class Refugio
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Nombre {get; set;}
        public String Descripcion { get; set; }
        public String direccion { get; set; }
        public String Horario { get; set; }
        public List<Mascota>? Mascotas { get; set; }


    }
}
