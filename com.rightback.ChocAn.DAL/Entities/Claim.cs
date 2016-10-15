using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace com.rightback.ChocAn.DAL
{
    public class Claim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClaimID { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "DateTime of Claim")]
        public DateTime DateOfClaim { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }


        public string Comments { get; set; }

        //Navigation 
        [Required]
        public virtual Provider Provider { get; set; }
        [Required]
        public virtual Member Member { get; set; }
        [Required]
        public virtual Service Service { get; set; }

    }
}
