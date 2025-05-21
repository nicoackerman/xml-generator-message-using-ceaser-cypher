namespace xml_generator_message_using_ceaser_cypher.Models;
public class Mensaje 
{
    public string Remitente { get; set; } = string.Empty;
    public string MensajeEncriptado { get; set; } = string.Empty;
    public string CodigoRemitente { get; set; } = string.Empty;
    public DateTime FechaDeEnvio { get; set; } = DateTime.Now;
    public int Key { get; set; } = 0;
}