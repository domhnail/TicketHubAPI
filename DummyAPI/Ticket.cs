using System.ComponentModel.DataAnnotations;

namespace TicketingAPI
{
    public class Ticket
    {
        [Required]
        public int ConcertId { get; set; } = 0;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; } = 0;

        [Required]
        [CreditCard]
        public string CreditCard { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^(0[1-9]|1[0-2])\\/\\d{2}$", ErrorMessage = "Expiration must be MM/YY.")]
        public string Expiration { get; set; } = string.Empty;

        [Required]
        [StringLength(4, MinimumLength = 3, ErrorMessage = "Security code must be 3 or 4 digits.")]
        public string SecurityCode { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string Province { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^[A-Za-z0-9 ]{3,10}$", ErrorMessage = "Invalid postal code format.")]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        public string Country { get; set; } = string.Empty;
    }
}
