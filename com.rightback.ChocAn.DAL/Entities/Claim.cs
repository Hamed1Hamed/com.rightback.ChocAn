using com.rightback.ChocAn.DAL.Entities;
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

        //date service actually provided to member by provider
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "DateTime of Claim")]
        public DateTime DateOfClaim { get; set; }

        //date provider recorded the service from its terminal
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Record DateTime of Claim")]
        public DateTime DateOfClaimRecorded { get; set; }

        //we can't rely on Service fee - it must be in claim too.
        //because service fee can change in time, historical reports should not change
        [Required]
        public decimal Fee { get; set; }

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
