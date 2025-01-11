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

    [HttpPost("crearProducto")]
    public ActionResult crearProducto([FromBody] Producto nuevoProducto)
    {
        productoRepository.CrearProducto(nuevoProducto);
        return Ok("Producto creado correctamente.");
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

    [HttpPut("/api/Producto/{idProducto}")]
    public ActionResult ModificarProducto(int idProducto, [FromQuery] string Descripcion)
    {
        Producto producto = productoRepository.ObtenerDetallePorId(idProducto);
        if (producto == null)
        {
            return NotFound("Producto no encontrado.");
        }

        producto.Descripcion = Descripcion;
        productoRepository.ModificarProducto(producto.IdProducto, producto);

        return Ok("Descripcion modificada con exito");
    }
}
