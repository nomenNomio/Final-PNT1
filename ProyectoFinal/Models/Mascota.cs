using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProyectoFinal.Models
{
    public class Mascota
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Personalidad { get; set; }
        public String EstadoDeSalud { get; set; }
        public int Edad { get; set;  }
        public int CantDuenios { get; set; }
        public double Peso { get; set; }
        public Boolean Vacunado { get; set; }
        public Refugio SuRefugio { get; set; }
    }
}
