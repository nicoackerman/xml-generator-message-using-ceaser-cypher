using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using xml_generator_message_using_ceaser_cypher.Services;
using xml_generator_message_using_ceaser_cypher.Models;

namespace xml_generator_message_using_ceaser_cypher.Pages
{
    public class EncriptadorModel : PageModel
    {
        [BindProperty]
        public string Remitente { get; set; } = string.Empty;
        [BindProperty]
        public string MensajeOriginal { get; set; } = string.Empty;
        public string MensajeEncriptado { get; set; } = string.Empty;
        [BindProperty]
        public string CodigoRemitente { get; set; } = string.Empty;
        [BindProperty]
        public int Key { get; set; } = 0;
        public void OnGet()
        {
        }
        public string EncriptarMensaje(string sms = "", int key = 0)
        {
            char[] smsNormalizado = sms.ToCharArray();
            string smsEncriptado = sms;
            List<char> colaEncriptacion = new List<char>();
            List<char> dict = new List<char> {
                'a', 'b', 'c', 'd', 'e', 'f', 'g',
                'b', 'c', 'a', 'b', 'c', 'a', 'b', 'c',
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
                'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            };

            // no se ejecuta si sms es cadena vacia
            foreach (var c in smsNormalizado)
            {
                smsEncriptado = string.Empty;

                if (dict.Contains(c))
                {
                    int i = key + dict.IndexOf(c) % dict.Count;
                    colaEncriptacion.Add(dict[i]);
                }
                else
                {
                    colaEncriptacion.Add(c);
                }

                smsEncriptado = string.Concat(colaEncriptacion);
            }
            return smsEncriptado;
            
        }
        public void OnPost()
        {
            MensajeEncriptado = EncriptarMensaje("Hola Nicolas" , 2);

            Mensaje nuevoMensaje = new Mensaje();
            nuevoMensaje.Remitente = Remitente;
            nuevoMensaje.MensajeEncriptado = MensajeEncriptado;
            nuevoMensaje.CodigoRemitente = CodigoRemitente;
            nuevoMensaje.Key = Key;
            
            ServicioEncriptacion.Agregar(nuevoMensaje);
        }
    }
}
