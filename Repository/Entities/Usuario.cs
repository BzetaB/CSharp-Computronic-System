namespace Repository.Entities
{
    public class Usuario
    {
        //MAPEO DE TABLAS DE LA BD
        public int ID_USER { get; set; }
        public string? NOM_USER { get; set; }
        public string? EMAIL_USER { get; set; }
        public string? CLAVE_USER { get; set; }

        public Boolean ESTADO_USER { get; set; }
        public DateTime FECHA_CMA { get; set; }
    }
}
