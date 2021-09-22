namespace Entidades
{
    public class TicketDetalle
    {
        public int IdTicketDetalle { get; set; }
        public int IdTicket { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public double PreUnitario { get; set; }
    }
}
