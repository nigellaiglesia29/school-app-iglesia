using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolApp.Validation;

namespace SchoolApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        
        [Display(Name = "Student No.")]
        [Required(ErrorMessage = "Please enter the student number.")]
        // Format: four digits, dash, four digits
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Use the format 2026-0001.")]
        public string? StudentNo { get; set; }
        
        // Name: custom label and error messages
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please enter the student's name. - Nigella")]
        [StringLength(100, ErrorMessage = "The name can't be longer than 100 characters.")]
        public string? Name { get; set; }

        // Email: custom label and error messages
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email, like ana@example.com.")]
        public string? Email { get; set; }

        
        [Display(Name = "Confirm Email")]
        [Required(ErrorMessage = "Please type the email again.")]
        [NotMapped]
        [Compare("Email", ErrorMessage = "Emails do not match.")]
        public string? ConfirmEmail { get; set; }


        // Phone: custom label and error message
        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string? Phone { get; set; }

        // Age: custom range message
        [Range(16, 60, ErrorMessage = "Age must be from 16 to 60.")]
        public int? Age { get; set; }


        [Display(Name = "Birth Date")]
        // Shows a date picker without the time
        [DataType(DataType.Date)]
        // Our custom rule from Validation/NotFutureDateAttribute.cs
        [NotFutureDate(ErrorMessage = "Birth date can't be in the future.")]
        public DateTime? BirthDate { get; set; }
    }
}
