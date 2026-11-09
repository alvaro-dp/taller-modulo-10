namespace TiendaApi.Modelos;

// ⚠️ Modelo "anémico" A PROPÓSITO: todo es público y modificable.
// Nada impide un precio negativo, stock -3 o la categoría "monitr".
// En el módulo 10 lo reemplazamos por Dominio/Producto.cs.
public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public string Categoria { get; set; } = "";
}
