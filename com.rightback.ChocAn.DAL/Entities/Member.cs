using com.rightback.ChocAn.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using static com.rightback.ChocAn.DAL.Entities.USState;

namespace com.rightback.ChocAn.DAL
{

    public class Member : BaseEntity
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
        public State State { get; set; }
        
        [Required]
        public string Zip { get; set; }
        [Required]
        public string Email { get; set; }

        //9 digit member code
        [Required]
        public string Code { get; set; }

        [Required]
        public MemberStatus Status { get; set; }

        public enum MemberStatus
        {
            Active = 1,
            Suspended = 2,
            Deleted = 3
        }

        //Navigation 
        public virtual ICollection<Claim> Claims { get; set; }

        public string getStatusAsString()
        {

            switch (this.Status)
            {
                case MemberStatus.Active:
                    return "Active";
                case MemberStatus.Suspended:
                    return "Suspended";
                case MemberStatus.Deleted:
                    return "Deleted";   
            }

            return String.Empty;
        }
    }
}
