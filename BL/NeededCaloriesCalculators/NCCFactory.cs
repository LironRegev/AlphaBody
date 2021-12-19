using Dal.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.NeededCaloriesCalculators
{
    public static class NCCFactory
    {
        public static INeededCaloriesCalculator GetNCC(Goal goal)
        {
            switch (goal)
            {
                case Goal.WeightLose:
                    return new WeightLoseNCC();
                case Goal.WeightGain:
                    return new WeightGainNCC();
                case Goal.BodyFatLose:
                    return new BodyFatLoseNCC();
                case Goal.MuscleGain:
                    return new MuscleGainNCC();
                default:
                    return null;
            }
        }
    }
}
