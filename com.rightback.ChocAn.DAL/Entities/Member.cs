using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.DAL.Entities;
using com.rightback.ChocAn.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace com.rightback.ChocAn.DAL
{

    public class Member : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { get; set; }


        public MemberStatus Status { get; set; }

     

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
