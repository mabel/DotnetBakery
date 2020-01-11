using System;
using System.ComponentModel.DataAnnotations;

namespace Baloon_AB.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Initial Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime InitDate { get; set; }
    }
}
