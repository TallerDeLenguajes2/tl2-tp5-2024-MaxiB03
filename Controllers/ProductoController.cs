using Microsoft.AspNetCore.Mvc;
using models;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private readonly ProductosRepository productoRepository;

    public ProductoController()
    {
        productoRepository = new ProductosRepository();
    }

    [HttpGet("GetProductos")]
    public ActionResult<List<Producto>> GetProductos()
    {
        List<Producto> productos = productoRepository.ListarProductos();

        if(productos == null || !productos.Any())
        {
            return BadRequest("No se encontraron Productos");
        }
        return Ok(productos);
    }
}
