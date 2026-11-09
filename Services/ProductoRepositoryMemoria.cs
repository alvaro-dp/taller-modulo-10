using TiendaApi.Modelos;

namespace TiendaApi.Services;

public interface IProductoRepository
{
    IReadOnlyList<Producto> ObtenerTodos();
    Producto? ObtenerPorId(int id);
    void Agregar(Producto producto);
}

// Guarda los productos en una lista en memoria (se pierden al reiniciar).
// Es Singleton: una sola lista para toda la app. En el módulo 12 la cambiamos por EF Core.
public class ProductoRepositoryMemoria : IProductoRepository
{
    private readonly List<Producto> _productos =
    [
        new() { Id = 1, Nombre = "Mouse", Precio = 15m, Stock = 22, Categoria = "Perifericos" },
        new() { Id = 2, Nombre = "Teclado", Precio = 45m, Stock = 5, Categoria = "Perifericos" },
        new() { Id = 3, Nombre = "Monitor 24", Precio = 200m, Stock = 3, Categoria = "Monitores" },
        new() { Id = 4, Nombre = "SSD 1TB", Precio = 80m, Stock = 8, Categoria = "Almacenamiento" },
    ];
    private int _siguienteId = 5;

    public IReadOnlyList<Producto> ObtenerTodos() => _productos;

    public Producto? ObtenerPorId(int id) => _productos.FirstOrDefault(p => p.Id == id);

    public void Agregar(Producto producto)
    {
        producto.Id = _siguienteId++;
        _productos.Add(producto);
    }
}
