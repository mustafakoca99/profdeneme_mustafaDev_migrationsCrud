using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace profdeneme_mustafaDev_migrationsCrud.Models
{
    public class kitap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "kitap adı giriniz")]
        public string kitapadi { get; set; }

        [Required(ErrorMessage = "kitap sayfası girilmeli")]
        public int kitapsayfasi { get; set; }

        [Required(ErrorMessage = "kitap turu giriniz")]
        public string kitapturu { get; set; }
    }
}
