//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lab_03.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public partial class customer
    {
        public int ID { get; set; }
        [Required]
        public string fname { get; set; }

        [Required]
        public string lname { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9._%+-]+\.[A-Za-z]{2,4}")]
        [Required]
        public string email { get; set; }

        [Required]
        public Nullable<decimal> phoneNumber { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        [Required]
        public string passwork { get; set; }
        public string LoginErrorMessage { get; set; }
    }
}
