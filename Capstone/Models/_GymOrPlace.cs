using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    [MetadataType(typeof(GymOrPlaceAnnotations))]
    public partial class GymOrPlace
    {

    }
    public class GymOrPlaceAnnotations
    {
        
        public int GymID { get; set; }
        [Display(Name = "Gym Name")]
        public string GymName { get; set; }
        [Display(Name = "Address")]
        public string GymAddress { get; set; }
        [Display(Name = "State")]
        public string GymState { get; set; }
        [DisplayFormat(DataFormatString = "{0:00000}", ApplyFormatInEditMode = true)]
        public int Zip { get; set; }
    }
}