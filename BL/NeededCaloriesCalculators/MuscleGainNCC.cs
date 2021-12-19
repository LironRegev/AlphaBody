using Dal;
using Dal.DataTypes;
using Dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL.NeededCaloriesCalculators
{
    public class MuscleGainNCC : INeededCaloriesCalculator
    {
        List<GoalDefinition> goalDefinitions;
        Dictionary<ActivityLevel, int> activityCalories;
        public MuscleGainNCC()
        {
            goalDefinitions = DBOperations.GetGoalDefinitionsByGoal(Goal.MuscleGain);
            activityCalories = new Dictionary<ActivityLevel, int>()
            {
                {ActivityLevel.SuperLight, 250 },
                {ActivityLevel.Light, 300 },
                {ActivityLevel.Medium, 400 },
                {ActivityLevel.Heavy, 500 },
                {ActivityLevel.SuperHeavy, 700 },
            };
        }
        private int GetHeightCalaulation(Gender gender, int height)
        {
            if (gender == Gender.Male)
            {
                if (height >= 140 && height <= 149)
                {
                    return 50;
                }
                else if (height >= 150 && height <= 159)
                {
                    return 125;
                }
                else if (height >= 160 && height <= 169)
                {
                    return 200;
                }
                else if (height >= 170 && height <= 179)
                {
                    return 275;
                }
                else if (height >= 180 && height <= 189)
                {
                    return 350;
                }
                else if (height >= 190 && height <= 200)
                {
                    return 425;
                }
                else
                {
                    return 500;
                }

            }
            if (gender == Gender.Female)
            {
                if (height >= 140 && height <= 149)
                {
                    return 50;
                }
                else if (height >= 150 && height <= 159)
                {
                    return 100;
                }
                else if (height >= 160 && height <= 169)
                {
                    return 150;
                }
                else if (height >= 170 && height <= 179)
                {
                    return 200;
                }
                else if (height >= 180 && height <= 189)
                {
                    return 250;
                }
                else if (height >= 190 && height <= 200)
                {
                    return 300;
                }
                else
                {
                    return 350;
                }

            }

            return 0;
        }
        public int CalculateNeededCalories(int age, Gender gender, int height, double weight, ActivityLevel activityLevel)
        {
            var definition = goalDefinitions.FirstOrDefault(gd => gd.MinAge <= age && gd.MaxAge >= age && gd.Gender == gender);

            var activitycalculation = activityCalories[activityLevel];

            var heightcalaulation = GetHeightCalaulation(gender, height);

            return definition.Calories + activitycalculation + heightcalaulation;
        }
    }
}
