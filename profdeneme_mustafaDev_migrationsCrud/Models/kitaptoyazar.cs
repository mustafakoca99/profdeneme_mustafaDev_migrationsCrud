using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace profdeneme_mustafaDev_migrationsCrud.Models
{
    public class kitaptoyazar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int kitapf_id { get; set; }

        [ForeignKey("kitapf_id")]
        public kitap kitaplar { get; set; }

        public int yazarf_id { get; set; }

        [ForeignKey("yazarf_id")]
        public yazar yazarlar { get; set; }
    }
}
