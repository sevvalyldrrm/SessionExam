using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SessionExam.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} boş geçilmez")]
        [StringLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olamaz")]
        [DisplayName("Ad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} boş geçilmez")]
        [StringLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olamaz")]
        [DisplayName("Soyad")]
        public string Surname { get; set; }

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

    }
}
