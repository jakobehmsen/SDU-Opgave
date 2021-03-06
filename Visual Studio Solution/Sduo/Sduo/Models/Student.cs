//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sduo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        [Display(Name = "CPR nr")]
        [Required]
        public string CprNr { get; set; }
        [Display(Name = "Navn")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Addresse")]
        [Required]
        public string Address { get; set; }
        [Display(Name = "Post nr")]
        [Required]
        public string PostalCode { get; set; }
        [Display(Name = "By")]
        [Required]
        public string City { get; set; }
        [Display(Name = "K�n")]
        public int Gender { get; set; }
        [Display(Name = "K�n")]
        [Required]
        public Gender GenderEnum
        {
            get { return (Gender)Gender; }
            set { Gender = (int)value;  }
        }
        [Display(Name = "Tlf nr")]
        [Required]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    
        public virtual ICollection<Course> Courses { get; set; }
    }
}
