using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sduo.Models
{
    public enum Gender
    {
        [Display(Name = "Mand")]
        Male = 0,

        [Display(Name = "Kvinde")]
        Female = 1,
    }
}