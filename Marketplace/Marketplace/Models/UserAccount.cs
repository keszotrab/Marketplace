using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Marketplace.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Userame { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        //Regular expression do dodania
        //chociaż jest srednio potrzebne bo i tak da sie to obejsc
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Confirm your password")]
        //[DataType(DataType.Password)]
        [HiddenInput]
        public string? Rank { get; set; }


    }
}
