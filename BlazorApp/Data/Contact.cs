using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BlazorApp.Data
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }

        // First name
        [Required(ErrorMessage = "Last name is required and cannot be empty.")]
        [StringLength(250, ErrorMessage = "First name cannot exceed 250 characters.")]
        public string? FirstName { get; set; }


        //last name
        [Required(ErrorMessage = "Last name is required and cannot be empty.")]
        [StringLength(250, ErrorMessage = "Last name cannot exceed 250 characters.")]
        public string? LastName { get; set; }

        
        // Phone Number
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 digits.")]
        public string? PhoneNumber { get; set; }

        
        public DateTime? BirthDate { get; set; }


    }
}
