using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.DAL.Entities;
using com.rightback.ChocAn.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace com.rightback.ChocAn.DAL
{

    public class Provider : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProviderID { get; set; }

        [Required]
        public string TerminalCode { get; set; }

        public ProviderType Type { get; set; }


        //Navigation 
        public virtual ICollection<Claim> Claims { get; set; }
    }
}
