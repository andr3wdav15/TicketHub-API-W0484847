using System.ComponentModel.DataAnnotations;

namespace TicketHub_API_W0484847
{
    public class TicketPurchase
    {
        [Required(ErrorMessage = "ConcertId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "ConcertId must be greater than 0.")]
        public int ConcertId { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name must not exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "CreditCard is required.")]
        [StringLength(
            16,
            MinimumLength = 16,
            ErrorMessage = "CreditCard number must be 16 digits."
        )]
        public string CreditCard { get; set; } = string.Empty;

        [Required(ErrorMessage = "Expiration is required.")]
        [RegularExpression(
            @"^(0[1-9]|1[0-2])\/(2[0-9])$",
            ErrorMessage = "Expiration date must be in MM/YY format."
        )]
        public string Expiration { get; set; } = string.Empty;

        [Required(ErrorMessage = "SecurityCode is required.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "SecurityCode must be 3 digits.")]
        public string SecurityCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Province is required.")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "PostalCode is required.")]
        [RegularExpression(
            @"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$",
            ErrorMessage = "Invalid PostalCode format (A1A 1A1)."
        )]
        public string PostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; } = string.Empty;
    }
}
