using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProyectoFinal.Models
{
    public class Mascota
    {
        public Mascota() {
            this.Cuentas = new HashSet<Cuenta>();
        }
        public Mascota(string nombre, string personalidad, string estadoDeSalud, int edad, int cantDuenios, double peso, bool vacunado, Refugio suRefugio, byte[] Imagen)
        {
            Nombre = nombre;
            Personalidad = personalidad;
            EstadoDeSalud = estadoDeSalud;
            Edad = edad;
            CantDuenios = cantDuenios;
            Peso = peso;
            Vacunado = vacunado;
            SuRefugio = suRefugio;
            this.Imagen = Imagen;
            this.Cuentas = new HashSet<Cuenta>();
        }

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
        public byte[] Imagen { get; set; }
        public int RefugioId { get; set; }
        public Refugio SuRefugio { get; set; }
        public ICollection<Cuenta> Cuentas { get; set; }
    }
}
