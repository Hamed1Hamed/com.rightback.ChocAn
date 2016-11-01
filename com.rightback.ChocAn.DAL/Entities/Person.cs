using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static com.rightback.ChocAn.DAL.Entities.USState;

namespace com.rightback.ChocAn.DAL.Entities
{
    public abstract class Person
    {
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
        //9 digit provider login code
        [Required]

        public string Code { get; set; }
    }
}
