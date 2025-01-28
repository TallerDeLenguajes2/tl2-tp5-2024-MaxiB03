using Microsoft.AspNetCore.Mvc;
using models;

[ApiController]
[Route("[controller]")]
public class PresupuestosController : ControllerBase
{
    private readonly PresupuestosRepository presupuestosRepository;

    public PresupuestosController()
    {
        presupuestosRepository = new PresupuestosRepository();
    }

    //Permite crear un Presupuesto
    [HttpPost("/api/CrearPresupuesto")]
    public ActionResult CrearPresupuesto([FromBody] Presupuestos nuevoPresupuesto)
    {
        presupuestosRepository.CrearPresupuesto(nuevoPresupuesto);
        // nuevoPresupuesto.Detalles = presupuestosRepository.ObtenerDetallePresupuesto(nuevoPresupuesto.IdPresupuesto);

        return Ok("Presupuesto creado correctamente.");
    }

    //Permite agregar un Producto existente y una cantidad al presupuesto.
    [HttpPost("/api/Presupuesto/{id}/ProductoDetalle")]
    public ActionResult AgregarDetalleAlPresupuesto(int id, int idProducto, int cantidad)
    {
        try
        {
            presupuestosRepository.AgregarDetalleAlPresupuesto(id, idProducto, cantidad);
            return Ok("Detalle agregado correctamente.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"ERROR {ex.Message}");
        }
    }

    [HttpGet("/api/GetPresupuesto")]
    public ActionResult<List<Presupuestos>> GetPresupuestos()
    {
        List<Presupuestos> presupuestos = presupuestosRepository.ListarPresupuestos();

        if(presupuestos == null || !presupuestos.Any())
        {
            return BadRequest("No se encontraron Productos");
        }
        return Ok(presupuestos);
    }

    [HttpDelete("/api/EliminarPresupuesto/{idPresupuesto}")]
    public ActionResult EliminarPresupuesto(int idPresupuesto)
    {
        try
        {
            presupuestosRepository.EliminarPresupuesto(idPresupuesto);
            return Ok($"Presupuesto con ID {idPresupuesto} eliminado correctamente.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al eliminar el presupuesto: {ex.Message}");
        }
    }
}
