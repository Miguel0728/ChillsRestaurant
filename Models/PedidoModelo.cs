namespace ChillsRestaurant.Models
{
    public class PedidoModelo
    {
        public int IdPedido { get; set; }

        public MenuItem Producto { get; set; }

        public int Cantidad { get; set; }

        public decimal _Monto;

        public decimal Monto
        {
            get
            {
                _Monto = (Producto.Price * Cantidad);
                return _Monto;
            }
            set
            {
                _Monto = value;
            }
        }
        public decimal Total { get; set; }
    }
}
