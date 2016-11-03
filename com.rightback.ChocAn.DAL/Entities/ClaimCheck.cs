using com.rightback.ChocAn.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace com.rightback.ChocAn.DAL
{
    /*
     * For verification purposes, the provider has a form on which to enter current date and time,
     * the date service was provided, member name and number service code, and fee to be paid.
     * At the end of the week, the provider totals the fees to verify the amount to be paid to
     * that provider by ChocAn for that week.
     * */
    public class ClaimCheck
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClaimCheckID { get; set; }

        [Required]
        public string MemberName { get; set; }

        [Required]
        public string MemberNumber { get; set; }

        [Required]
        public string ServiceCode { get; set; }

        //date service actually provided to member by provider
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "DateTime of Claim")]
        public DateTime DateOfServiceProvided { get; set; }

        //date provider recorded the service from its terminal
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Record DateTime of ClaimCheck")]
        public DateTime DateOfClaimCheck { get; set; }

        [Required]
        public decimal Fee { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }

        //Navigation 
        [Required]
        public virtual Provider Provider { get; set; }


    }
}
