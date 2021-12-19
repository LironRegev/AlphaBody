using BL.NeededCaloriesCalculators;
using Dal;
using Dal.DataTypes;
using Dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserDataManager
    {
        private User _user;

        public bool Register(string userName, string password, string FirstName, string LastName)
        {
            if (DBOperations.IsUserNameExist(userName))
            {
                return false;
            }

            _user = new User() { UserName = userName, Password = password, FirstName = FirstName, LastName = LastName, Role = Role.User };

            DBOperations.AddUser(_user);

            return true;
        }
        public bool Login(string userName, string password)
        {
            _user = DBOperations.GetUser(userName, password);

            return _user != null;
        }

        public bool CheckIfNewUser()
        {
            return _user.UserInfo == null;
        }


        public void SaveAndCompleteUserInfo(UserInfo userInfo)
        {
            var bmi = CalculateBMI(userInfo.Height, (int)userInfo.Weight);
            var bmr = CalculateBMR(userInfo.Gender, userInfo.Height, (int)userInfo.Weight, userInfo.Age);
            var ncc = NCCFactory.GetNCC(userInfo.Goal);
            var neededCalories = ncc.CalculateNeededCalories(userInfo.Age, userInfo.Gender, userInfo.Height, userInfo.Weight, userInfo.ActivityLevel);

            _user.UserInfo = userInfo;
            userInfo.UserId = _user.Id;
            userInfo.BMI =bmi;
            userInfo.BMR = bmr;
            userInfo.NeededCalories = neededCalories;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Body mass index (BMI) is a measure of body fat based on height and weight\nUnderweight = < 18.5\n Normal weight= 18.5–24.9\n Overweight = 25–29.9\nYour BMI is{bmi}");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"The Basal Metabolic Rate (BMR) Calculator estimates your basal metabolic rate—the amount of energy expended while at rest in a neutrally temperate environment, and in a post-absorptive state\n Your BMR is {bmr}");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Your needed calories in each day to get to your goal is {neededCalories}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            DBOperations.SaveUserInfo(_user.UserInfo);
        }


        public void SaveDislikedFoods(List<int> dislikedFoods)
        {
            if (_user.Dislikes != null)
            {
                DBOperations.DeleteUserDislikedFoods(_user.Dislikes);
            }
            var transformed = dislikedFoods.Select(foodId => new UserDislike() { FoodId = foodId, UserId = _user.Id }).ToList();
            _user.Dislikes = transformed;
            DBOperations.SaveUserDislikedFoods(transformed);
        }



        private double CalculateBMR(Gender gender, int height, int weight, int age)
        {
            if (gender == Gender.Male)
            {
                return 66.47 + (13.75 * weight) + (5.003 * height) - (6.755 * age);
            }
            else
            {
                return 655.1 + (9.563 * weight) + (1.85 * height) - (4.676 * age);
            }
        }

        private double CalculateBMI(double height, double weight)
        {
            double bmiHeight = height / 100;
            double bmi = weight / (bmiHeight * bmiHeight);
            return (int)bmi;
        }
        public List<UserMenuItem> GetUserMenu()
        {
            return _user.UserMenuItems;
        }
        public void SaveMenu(List<UserMenuItem> menu)
        {
            if (_user.UserMenuItems != null)
            {
                DBOperations.DeleteUserMenu(_user.UserMenuItems);
            }
            foreach (var item in menu)
            {
                item.UserId = _user.Id;
            }
            _user.UserMenuItems = DBOperations.SaveUserMenu(menu);
        }
        public UserInfo GetUserInfo()
        {
            return _user.UserInfo;
        }
        public List<int> GetUserDislike()
        {
            return _user.Dislikes.Select(D => D.FoodId).ToList();
        }
        public bool IsAdmin()
        {
            return _user.Role == Role.Admin;
        }

        
    }

    }
