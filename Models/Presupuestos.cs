namespace models;

public class Presupuestos
{
    int idPresupuesto;
    string nombreDestinatario;
    List<PresupuestosDetalle> detalle;

    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    public string NombreDestinatario { get => nombreDestinatario; set => nombreDestinatario = value; }
    public List<PresupuestosDetalle> Detalles { get => detalle; set => detalle = value; }

    //Constructor
    public Presupuestos(int idPresupuesto, string nombreDestinatario, List<PresupuestosDetalle> detalles)
    {
        IdPresupuesto=idPresupuesto;
        NombreDestinatario=nombreDestinatario;
        Detalles=detalles;
    }
}