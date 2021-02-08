using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    [MetadataType(typeof(UserExerciseTypeAnnotations))]
    public partial class UserExerciseType
    {

    }
    public class UserExerciseTypeAnnotations
    {
        [Display(Name="Exercise")]
        public int UserExerciseTypeID { get; set; }
        [Display(Name = "User")]
        public string UserID { get; set; }
        [Display(Name = "Exercise")]
        public int ExerciseTypeID { get; set; }
        [Display(Name = "Gym")]
        public Nullable<int> GymID { get; set; }
        public int LevelID { get; set; }

    }
}