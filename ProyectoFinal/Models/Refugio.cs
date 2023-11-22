
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Collections;

namespace ProyectoFinal.Models
{
    public class Refugio
    {
        public Refugio() {
            this.Mascotas = new HashSet<Mascota>();
            this.Cuentas = new HashSet<Cuenta>();
        }
        public Refugio(String Nombre, String Descripcion, String direcion, String Horario, Byte[] Imagen) {
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.direccion = direcion;
            this.Horario = Horario;
            this.Imagen = Imagen;
            this.Cuentas = new HashSet<Cuenta>();
            this.Mascotas = new HashSet<Mascota>();

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Nombre {get; set;}
        public String Descripcion { get; set; }
        public String direccion { get; set; }
        public String Horario { get; set; }
        public byte[] Imagen { get; set; }
        public ICollection<Mascota> Mascotas { get; set; }

        public ICollection<Cuenta> Cuentas { get; set;}
    }
}
