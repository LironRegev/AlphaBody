using Dal.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Model
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FoodKind FoodKind { get; set; }
        public int Grams { get; set; }
        public int Calories { get; set; }
        public double ProteinGrams { get; set; }
        public double CarbsGrams { get; set; }
        public double FatGrams { get; set; }
        public double CholesterolMilligram { get; set; }
        public double Fibers { get; set; }
        public List <UserDislike> Dislikes { get; set; }

        public List <UserMenuItem> UserMenuItems { get; set; }
    }
}
