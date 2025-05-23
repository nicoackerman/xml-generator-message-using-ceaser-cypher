using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using xml_generator_message_using_ceaser_cypher.Services;
using xml_generator_message_using_ceaser_cypher.Models;
using System.Xml.Linq;

namespace xml_generator_message_using_ceaser_cypher.Pages
{
    public class ListadoModel : PageModel
    {
        public List<Mensaje> MensajesEncriptados => ServicioEncriptacion.ListaDeMensajes;
        
        public void OnGet()
        {
        }
        public void onPostExportarTodos() 
        {
            string ruta = Path.Combine("wwwroot", "Exportaciones");
            Directory.CreateDirectory(ruta);

            foreach (var mensaje in MensajesEncriptados)
            {
                GuardarComoXML(mensaje, ruta);
            }
        }
        private static void GuardarComoXML(Mensaje mensaje, string ruta)
        {
            XElement xml = new XElement("MensajeSecreto",
                new XElement("Remitente", mensaje.Remitente),
                new XElement("Mensaje", mensaje.MensajeEncriptado),
                new XElement("Codigo", mensaje.CodigoRemitente),
                new XElement("Fecha", mensaje.FechaDeEnvio.ToString("yyyy-MM-dd"))
            );

            string archivo = Path.Combine(ruta, $"Mensaje_{mensaje.CodigoRemitente}.xml");
            xml.Save(archivo);
        }
    }
}
