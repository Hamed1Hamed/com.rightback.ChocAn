using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace com.rightback.ChocAn.DAL
{
    class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Fee { get; set; }


        //Navigation 
        public virtual ICollection<Claim> ClaimsHasThisService { get; set; }
    }
}
