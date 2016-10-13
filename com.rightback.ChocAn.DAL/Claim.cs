using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace com.rightback.ChocAn.DAL
{
    class Claim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int claimID { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "DateTime of Claim")]
        public DateTime DateOfClaim { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }


        //Navigation 
        public virtual Provider Provider { get; set; }
        public virtual Provider Member { get; set; }
        public virtual Provider Service { get; set; }

    }
}
