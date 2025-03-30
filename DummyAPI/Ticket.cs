namespace TicketingAPI
{
    public class Ticket
    {
        public int concertId { get; set; } = 0;
        public string email { get; set; } = String.Empty;
        public string name { get; set; } = String.Empty;
        public string phone { get; set; } = String.Empty;
        public int quantity { get; set; } = 0;
        public string creditCard { get; set; } = String.Empty;
        public string expiration { get; set; } = String.Empty;
        public string securityCode { get; set; } = String.Empty;
        public string address { get; set; } = String.Empty;
        public string city { get; set; } = String.Empty;
        public string province { get; set; } = String.Empty;
        public string postalCode { get; set; } = String.Empty;
        public string country { get; set; } = String.Empty;
    }
}
