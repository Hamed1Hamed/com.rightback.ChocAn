using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static com.rightback.ChocAn.DAL.Entities.USState;

namespace com.rightback.ChocAn.DAL
{

    public class Member : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { get; set; }


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
