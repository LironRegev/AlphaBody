using BL;
using Dal.DataTypes;
using Dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaBodyFirst
{
    public class GetUserInput
    {
        public static List<int> GetDislikeFoods()
        {
            var dislikedFoodIds = new List<int>();
            var done = false;
            while (!done)
            {
                Console.WriteLine("This menu will help you to choose food items that you dont want to include in your DietMenu\n Enter 0 to finish, or select food kind:");
                ShowOutput.ShowFoodKinds();

                var selectedKind = int.Parse(Console.ReadLine());

                if (selectedKind == 0)
                {
                    done = true;
                }
                else
                {
                    var foods = FoodsManager.Instance.GetFoodOfKind(selectedKind);
                    Console.WriteLine();
                    Console.WriteLine($"Enter 0 to go back, or select food:");
                    for (int i = 0; i < foods.Count; i++)
                    {
                        var food = foods[i];
                        Console.WriteLine($"{i + 1}. {food.Name}");
                    }

                    var selectedFoodIndex = int.Parse(Console.ReadLine());
                    if (selectedFoodIndex != 0)
                    {
                        var selectedFood = foods[selectedFoodIndex - 1];
                        dislikedFoodIds.Add(selectedFood.Id);
                    }


                }
            }
            return dislikedFoodIds;
        }
        public static UserInfo GetUserInfoInput()
        {
            Console.WriteLine("What Is Your Age?");
            var age = int.Parse(Console.ReadLine());
            Console.WriteLine("What Is Your Height?");
            var height = int.Parse(Console.ReadLine());
            Console.WriteLine("What Is Your Weight?");
            var weight = int.Parse(Console.ReadLine());
            Console.WriteLine("What Is Your Gender?");
            Console.WriteLine("1.Male \n2.Female");
            int userGender = int.Parse(Console.ReadLine());
            var gender = (Gender)userGender;
            Console.WriteLine("How Active Are You?");
            Console.WriteLine("1.SuperLight(No Exercise) \n2.Light(1-2 Exercises Per Week) \n3.Medium(3-4 Exercises Per Week) \n4.Heavy(5-6 Exercises Per Week) \n5.SuperHeavy(4-6 Exercises Per Week Twice A Day)");
            int userActivity = int.Parse(Console.ReadLine());
            var activityLevel = (ActivityLevel)userActivity;
            Console.WriteLine("What Is Your Goal?");
            Console.WriteLine("1.WeightLose \n2.WeightGain \n3.BodyFatLose \n4.MuscleGain");
            int userGoal = int.Parse(Console.ReadLine());
            var goal = (Goal)userGoal;
            Console.WriteLine("How Many Meals Do You Eat Per Day?");
            int usermeals= int.Parse(Console.ReadLine());
            var mealsNum = (MealsNum)usermeals;

            return new UserInfo() { Age = age, Height= height, Weight = weight, Gender = gender, Goal = goal,ActivityLevel = activityLevel,MealsNum=mealsNum};
        }
        public static Food GetNewFood()
        {
            Console.WriteLine("Please select the food kind of the new food");
            ShowOutput.ShowFoodKinds();
            var selectedKind = int.Parse(Console.ReadLine());
            var foodkind = (FoodKind)selectedKind;
            Console.WriteLine("What is the food name?");
            var foodname = Console.ReadLine();
            Console.WriteLine("Please enter all food values according to 100 grams");
            Console.WriteLine("What is the food Calories?");
            var calories = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the food protein?");
            var protein = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the food carbs?");
            var carbs = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the food fat?");
            var fat = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the food Cholesterol?");
            var chol = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the food fibers?");
            var fibers = int.Parse(Console.ReadLine());

            return new Food() { Calories = calories, ProteinGrams = protein, CarbsGrams = carbs, FatGrams = fat, CholesterolMilligram = chol, Fibers = fibers, Grams = 100, FoodKind = foodkind, Name = foodname };
        }
    }
}
