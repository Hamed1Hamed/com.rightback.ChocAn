using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.rightback.ChocAn.DAL
{
    public class Batch
    {
        //this table will keep track of each week report batch
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BatchID { get; set; }

        [Required]
        public int Year { get; set; }
        // in 365 day format
        [Required]
        public int DayOfYear { get; set; }

    }
}