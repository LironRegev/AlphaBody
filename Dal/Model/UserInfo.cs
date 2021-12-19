using Dal.DataTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Model
{
    public class UserInfo
    {
        [Key]
        public int UserId { get; set; }
        public Goal Goal { get; set; }
        public ActivityLevel ActivityLevel { get; set; }
        public MealsNum MealsNum { get; set; }
        public double BMI { get; set; }
        public double BMR { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public int NeededCalories { get; set; }
        public User User { get; set; }
    }
}
