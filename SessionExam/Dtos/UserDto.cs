using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SessionExam.Dtos
{
    public class UserDto
    {
        [Required(ErrorMessage = "{0} boş geçilmez")]
        [StringLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olamaz")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Kullanıcı Kodu")]
        public string Username { get; set; }


        [Required(ErrorMessage = "{0} boş geçilmez")]
        [StringLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olamaz")]
        [DataType(DataType.Password)]
        [DisplayName("Kullanıcı Şifre")]
        public string Password { get; set; }


        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }

    }
}
