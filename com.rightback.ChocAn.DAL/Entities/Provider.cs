using com.rightback.ChocAn.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.DAL
{
    public class Provider:Person
    {
      
            //9 digit provider login code
            [Required]
            public string Code { get; set; }

            [Required]
            public string TerminalCode { get; set; }

        public enum Type
            {
            internist,
            dietitian,
            exercise,
            specialist
        }

            //Navigation 
            public virtual ICollection<Claim> Claims { get; set; }
        }
    }
