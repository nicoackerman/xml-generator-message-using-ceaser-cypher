using xml_generator_message_using_ceaser_cypher.Models;
namespace xml_generator_message_using_ceaser_cypher.Services;

public static class ServicioEncriptacion
{
    public static List<Mensaje> ListaDeMensajes { get; } = [];
    public static void Agregar(Mensaje mensaje)
    {
        ListaDeMensajes.Add(mensaje);
    }
    public static void Limpiar()
    {
        ListaDeMensajes.Clear();
    }
}
