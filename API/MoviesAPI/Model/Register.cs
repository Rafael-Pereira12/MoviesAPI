using BeeEngineering.Learning.MoviesApp.Data.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Model
{
    public class Register 
    {
        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }

        //[EmailAddress]
        //[Required(ErrorMessage = "Email is required")]
        //public string EmailAddress { get; set;}

        [Required(ErrorMessage = "Password is required")]

        public string? Password { get; set; }
    }
}
