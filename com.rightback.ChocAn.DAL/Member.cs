using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace com.rightback.ChocAn.DAL
{
    class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string StreetAddres { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string Email { get; set; }
        
        public enum Status
        {
            Active,
            Suspended,
            ABC
        }


        //Navigation 
        public virtual ICollection<Claim> Claims { get; set; }
    }
}
