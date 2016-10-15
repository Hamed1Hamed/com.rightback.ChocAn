using com.rightback.ChocAn.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace com.rightback.ChocAn.DAL
{
    public class Member : Person
    {



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
