
namespace api_dicsys
{
    public class Producto
    {   

        public int? id_producto { get; set; }
        public string? nombre_producto { get; set; }
        public decimal? precio { get; set; }
        public int? stock { get; set; }
        public int? fk_categoria { get; set; }
        public string? categoria { get; set; }
        public string? fecha_alta { get; set; }

    }
}
