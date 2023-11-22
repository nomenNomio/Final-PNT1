using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public class Cuenta
    {
        public Cuenta() {
            this.Refugios = new HashSet<Refugio>();
            this.Mascotas = new HashSet<Mascota>();
        }
        public Cuenta(String Nombre, String Password, String Email, Boolean Admin) { 
            this.Nombre = Nombre;
            this.Password = Password;
            this.Email = Email;
            this.Admin = Admin;
            this.Refugios = new HashSet<Refugio>();
            this.Mascotas = new HashSet<Mascota>();
        }
        public Cuenta(String Nombre, String Password, String Email)
        {
            this.Nombre = Nombre;
            this.Password = Password;
            this.Email = Email;
            this.Refugios = new HashSet<Refugio>();
            this.Mascotas = new HashSet<Mascota>();
        }

        public Cuenta(Cuenta cuenta, Boolean Admin)
        {
            this.Id = cuenta.Id;
            this.Nombre = cuenta.Nombre;
            this.Password = cuenta.Password;
            this.Email = cuenta.Email;
            this.Admin = Admin;
            this.Refugios = new HashSet<Refugio>();
            this.Mascotas = new HashSet<Mascota>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public Boolean Admin { get; set; }
        public ICollection<Refugio> Refugios { get; set; }
        public ICollection<Mascota> Mascotas { get; set; }



    }
}
