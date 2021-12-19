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
    class Program
    {
        static void Main(string[] args)
        {
            
            var udm = new UserDataManager();
            

            var option = 0;
            while (option!=1 && option!=2)
            {
                ShowOutput.RegisterOrLogin();
                option = int.Parse(Console.ReadLine());
            }
            if (option == 1)
            {
                var success = false;
                while (!success)
                {
                    Console.WriteLine("Please Enter User Name");
                    var username = Console.ReadLine();
                    Console.WriteLine("Please Enter Password");
                    var pass = Console.ReadLine();
                    success = udm.Login(username, pass);
                }
                if (udm.IsAdmin())
                {
                    AdminFlow();
                }
                else
                {
                    RegularUserFlow(udm);
                }

            }
            else
            {
                var success = false;
                while (!success)
                {
                    Console.WriteLine("Please enter your first name");
                    var firstname = Console.ReadLine();
                    Console.WriteLine("Please enter your last name");
                    var lastname = Console.ReadLine();
                    Console.WriteLine("Please Enter User Name");
                    var username = Console.ReadLine();
                    Console.WriteLine("Please Enter Password");
                    var pass = Console.ReadLine();
                    success = udm.Register(username, pass,firstname,lastname);
                    if (!success)
                    {
                        Console.WriteLine("This user name already exists please choose different username");
                    }
                }
                RegularUserFlow(udm);
            }
            
        }

        private static void RegularUserFlow(UserDataManager udm)
        {
            var isNew = udm.CheckIfNewUser();
            if (isNew)
            {
                var userinputinfo = GetUserInput.GetUserInfoInput();
                udm.SaveAndCompleteUserInfo(userinputinfo);
                var dislikedFoodIds = GetUserInput.GetDislikeFoods();
                udm.SaveDislikedFoods(dislikedFoodIds);
                var menu = MenuBuilder.BuildMenu(userinputinfo.NeededCalories, FoodsManager.Instance.GetAllFoods(), dislikedFoodIds, userinputinfo.MealsNum);
                udm.SaveMenu(menu);
                ShowOutput.ShowMenu(menu);
            }

            var keepRunning = true;
            while (keepRunning)
            {
                ShowOutput.ShowUserOptions();
                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 0:
                        keepRunning = false;
                        break;
                    case 1:
                        var userinputinfo = GetUserInput.GetUserInfoInput();
                        udm.SaveAndCompleteUserInfo(userinputinfo);
                        break;
                    case 2:
                        var dislikedFoodIds = GetUserInput.GetDislikeFoods();
                        udm.SaveDislikedFoods(dislikedFoodIds);
                        break;
                    case 3:
                        var userMenu = udm.GetUserMenu();
                        ShowOutput.ShowMenu(userMenu);
                        break;
                    case 4:
                        var userInfo = udm.GetUserInfo();
                        var userDislikes = udm.GetUserDislike();
                        var menu = MenuBuilder.BuildMenu(userInfo.NeededCalories, FoodsManager.Instance.GetAllFoods(), userDislikes, userInfo.MealsNum);
                        udm.SaveMenu(menu);

                        ShowOutput.ShowMenu(menu);

                        break;
                    
                    default:
                        break;
                }
            }
        }
        private static void AdminFlow()
        {
            
            var keepRunning = true;
            while (keepRunning)
            {
                ShowOutput.ShowAdminOptions();
                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 0:
                        keepRunning = false;
                        break;
                    case 1:
                        var newfood = GetUserInput.GetNewFood();
                        FoodsManager.Instance.SaveNewFood(newfood);
                        break;
                    case 2:
                        var allfoods = FoodsManager.Instance.GetAllFoods();
                        ShowOutput.ShowAllFoods(allfoods);
                        var foodid = int.Parse(Console.ReadLine());
                        var selectedfoodtodelete = allfoods.FirstOrDefault(af => foodid == af.Id);
                        FoodsManager.Instance.DeleteFood(selectedfoodtodelete);
                        break;
                  
                    default:
                        break;
                }
            }
        }


    }
}
