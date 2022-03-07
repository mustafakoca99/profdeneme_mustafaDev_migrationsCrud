using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace profdeneme_mustafaDev_migrationsCrud.Models
{
    public class yazar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "yazar adı giriniz")]
        public string yazaradi { get; set; }

        [Required(ErrorMessage = "yazar yaşı giriniz")]
        public string yazaryasi { get; set; }
    }
}
