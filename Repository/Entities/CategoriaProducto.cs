namespace Repository.Entities
{
    public class CategoriaProducto
    {
        //MAPEO DE TABLAS DE LA BD
        public int ID_CATEGORIA { get; set; }
        public string? NOMBRE { get; set; }
        public Usuario? ID_USER { get; set; }
        public DateTime FECHA_CMA { get; set; }
    }
}
