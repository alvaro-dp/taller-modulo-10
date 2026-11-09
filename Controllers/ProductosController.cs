using Microsoft.AspNetCore.Mvc;
using TiendaApi.Modelos;
using TiendaApi.Services;

namespace TiendaApi.Controllers;

[ApiController]
[Route("api/productos")]
public class ProductosController : ControllerBase
{
    private readonly IProductoRepository _repositorio;

    public ProductosController(IProductoRepository repositorio)
    {
        _repositorio = repositorio;
    }

    [HttpGet]
    public IActionResult Listar() => Ok(_repositorio.ObtenerTodos());

    [HttpGet("{id:int}")]
    public IActionResult Obtener(int id)
    {
        var producto = _repositorio.ObtenerPorId(id);
        return producto is null ? NotFound() : Ok(producto);
    }

    // ⚠️ Recibe la entidad directamente: el cliente puede mandar cualquier cosa
    // (incluso el Id). Este es el problema que resolvemos en el módulo 10.
    [HttpPost]
    public IActionResult Crear(Producto producto)
    {
        _repositorio.Agregar(producto);
        return CreatedAtAction(nameof(Obtener), new { id = producto.Id }, producto);
    }
}
