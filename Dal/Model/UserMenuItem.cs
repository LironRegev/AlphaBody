using Dal.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Model
{
    public class UserMenuItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FoodId { get; set; }
        public MealTime MealTime { get; set; }
        public int Grams { get; set; }
        public User User { get; set; }
        public Food Food{ get; set; }   
    }
}
