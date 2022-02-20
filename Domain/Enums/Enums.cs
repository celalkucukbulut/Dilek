using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum Gender
    {
        [Display(Name = "Kadın Giyim")]
        Female = 4,
        [Display(Name = "Erkek Giyim")]
        Male = 5,
        [Display(Name = "Diğer")]
        Other = 6
    }
}
