using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ProyectoFinal.Context;
using ProyectoFinal.Models;
using System.Text.RegularExpressions;

namespace ProyectoFinal.BDhelper
{
    public class BDhelp
    {
        public static async Task<Refugio> CrearRefugio(String nom, String des, String dir, String hor, IFormFile ImageData, ProyectoFinalDatabaseContext _context)
        {
            Refugio result = null;

            if (nom != null && des != null && dir != null && hor != null)
            {
                if (!_context.Refugios.Any(refu => refu.Nombre == nom))
                {
                    var dataStream = new MemoryStream();
                    await ImageData.CopyToAsync(dataStream);
                    byte[] conv = dataStream.ToArray();
                    _context.Add(new Refugio(nom, des, dir, hor, conv));
                    await _context.SaveChangesAsync();
                    result = await _context.Refugios.FirstOrDefaultAsync(refu => refu.Nombre == nom);
                }
            }
            return result;
        }

        public static async Task<bool> CrearMascota(
            String idRefugio,
            String nom,
            String pers,
            String salud,
            int edad,
            int cantDue,
            int peso,
            bool vac,
            IFormFile ImageData,
            ProyectoFinalDatabaseContext _context
            )
        {

            Refugio refugio = await _context.Refugios.FirstOrDefaultAsync(refu => refu.Id == int.Parse(idRefugio));
            var dataStream = new MemoryStream();
            await ImageData.CopyToAsync(dataStream);
            byte[] conv = dataStream.ToArray();
            Mascota mascota = new Mascota(nom, pers, salud, edad, cantDue, peso, vac, refugio, conv);
            refugio.Mascotas.Add(mascota);
            _context.Update(refugio);
            _context.Add(mascota);
            await _context.SaveChangesAsync();
            return true;
        }
        public static async Task<bool> Crear(String usr, String pwd, String eml, ProyectoFinalDatabaseContext _context) {

            bool yaExiste = _context.Cuentas.Any(ct => ct.Nombre == usr);

                if (!yaExiste) {
                _context.Add(new Cuenta(usr, pwd, eml, false));
                await _context.SaveChangesAsync();
            }

            return !yaExiste;
        }

        public static async Task<Cuenta> Loguear(String usr, String pwd, ProyectoFinalDatabaseContext _context)
        {
            Cuenta cuenta;
            //var ordenes = await _db.OrdenCompras.Include(x => x.OrdenStatus).Include(x=>x.DetalleOrdenes).ThenInclude(x=>x.Producto).Where(a=>a.UserId==userId).ToListAsync();
            //public byte[] Imagen { get; set; }
            //<img src="data:image/png;base64,@Convert.ToBase64String(Producto.Imagen)" class="card-img-top" alt="...">
            //from carrito in _db.Carritos
            //join detalleCarrito in _db.DetalleCarritos
            //on carrito.Id equals detalleCarrito.Carrito_Id
            //select new { detalleCarrito.Id }
            //                  ).ToListAsync();
            /*
             */
            //location.href='@Url.Action("ClickTest", "Home")'
            cuenta = await _context.Cuentas.FirstOrDefaultAsync(ct => ct.Nombre == usr && ct.Password == pwd);
            
            return cuenta;
        }

        private String cuentaRegex(Cuenta cuenta) {

            Regexer rxCuentaNombre = new Regexer(cuenta.Nombre);

            rxCuentaNombre
                .eliminarEspaciosIniciales()
                .noTieneEspacios()
                .masDeNChar(4);

            return "";



        }
    }

    public class Regexer {

        private String texto;
        private String textoModificado;
        private bool huboFallo = false;
        private ArrayList comentarios = new ArrayList();

        public String getTexto()
        {
            return texto;
        }

        public String getTextoModificado()
        {
            return textoModificado;
        }
        public bool getHuboFallo() { 
            return huboFallo;
        }

        public ArrayList getComentarios()
        {
            return comentarios;
        }

        public Regexer(string texto)
        {
            this.texto = texto;
            this.textoModificado = texto;

        }

        public Regexer eliminarEspaciosIniciales() {

            textoModificado = textoModificado.Trim();

            return this;
        }

        public Regexer noTieneEspacios() {

            Regex rx = new Regex(@"^[^\s]+$");

            if (!rx.IsMatch(textoModificado) ) {
                huboFallo = true;
                comentarios.Add("El texto ingresado tiene espacios");


            }


            return this;
        }

        public Regexer masDeNChar(int cantChar)
        {
            //@"\b" + Regex.Escape(Replaces[i].word) + @"\b"
            Regex rx = new Regex(@".{" + cantChar + @",}");

            if (rx.IsMatch(textoModificado))
            {
                huboFallo |= true;
                comentarios.Add("El texto ingresado tiene menos de " + cantChar + " caracteres");


            }

            return this;
        }


    }
}
