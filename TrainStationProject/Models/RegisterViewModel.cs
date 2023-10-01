using System.ComponentModel.DataAnnotations;

namespace TrainStationProject.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı adı giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi giriniz")]
        public string Password { get; set; }

    }
}

