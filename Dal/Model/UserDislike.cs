using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Model
{
    public class UserDislike
    {
        public int UserId { get; set; }
        public int FoodId { get; set; }
        public User User { get; set; }
        public Food Food { get; set; }
    }
}
