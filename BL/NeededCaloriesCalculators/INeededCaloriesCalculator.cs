using Dal.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.NeededCaloriesCalculators
{
    public interface INeededCaloriesCalculator
    {
        int CalculateNeededCalories(int age, Gender gender, int height, double weight, ActivityLevel activityLevel);
    }
}
