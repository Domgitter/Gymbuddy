using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    [MetadataType(typeof(GymUserAnnotations))]
    public partial class GymUser
    {
        public int Age { get{
                var timespan = DateTime.Now - BirthDate;
                return (int)(timespan.TotalDays / 365.25);
            
                            } }

    }
    public class GymUserAnnotations
    {
        public string UserID { get; set; }

        [Display(Name ="First Name")]
        public string Fname { get; set; }
        [Display(Name = "Last Name")]
        public string Lname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public System.DateTime BirthDate { get; set; }
        [Display(Name = "Address")]
        public string UserAddress { get; set; }
        [Display(Name = "State")]
        public string UserState { get; set; }
        [DisplayFormat(DataFormatString ="{0:00000}", ApplyFormatInEditMode =true)]
        public int Zip { get; set; }
    }
}