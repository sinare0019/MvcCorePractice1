using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcCorePractice1.Models
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("نام کاربری")]
        public string UserName {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("کلمه عبور")]
        public string Password { get; set; }
        [Required]
        [DisplayName("ایمیل")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("تکرار کلمه عبور")]
        public string RePassword { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("شماره موبایل")]
        public string Mobile { get; set; }
    }
}
