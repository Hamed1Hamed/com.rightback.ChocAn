using com.rightback.ChocAn.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static com.rightback.ChocAn.DAL.Entities.USState;

namespace com.rightback.ChocAn.DAL
{

    public class Provider : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProviderID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string StreetAddres { get; set; }
        [Required]
        public string City { get; set; }

        [Required]
        public State State { get; set; }

        [Required]
        public string Zip { get; set; }
        [Required]
        public string Email { get; set; }
        //9 digit provider login code
        [Required]
        public string Code { get; set; }

        [Required]
        public string TerminalCode { get; set; }

        public ProviderType Type { get; set; }

        public enum ProviderType
        {
            internist=0,
            dietitian=1,
            exercise=2,
            specialist=3
        }

        //Navigation 
        public virtual ICollection<Claim> Claims { get; set; }
    }
}
