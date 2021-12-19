using BL;
using Dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaBodyFirst
{
    public class ShowOutput
    {
        public static void RegisterOrLogin()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1.Login");
            Console.WriteLine("2.Register");
        }
        public static void ShowAdminOptions()
        {
            Console.WriteLine("Please Choose One Of The Below");
            Console.WriteLine("0.Exit");
            Console.WriteLine("1.Add new food");
            Console.WriteLine("2.Delete food");
        }
        public static void ShowUserOptions()
        {
            Console.WriteLine("Please Choose One Of The Below");
            Console.WriteLine("0.Exit");
            Console.WriteLine("1.Update user info");
            Console.WriteLine("2.Update dislikes");
            Console.WriteLine("3.See menu");
            Console.WriteLine("4.Create new menu");
        }
        public static void ShowMenu(List<UserMenuItem> userMenu)
        {
            var groupItems = userMenu.GroupBy(gp => gp.MealTime);
            foreach (var group in groupItems)
            {
                var mealTime = group.Key;
                var foods = group.ToList();
                Console.WriteLine(mealTime);
                foreach (var menuItem in foods)
                {
                    Console.WriteLine($"\t{menuItem.Food.Name} {menuItem.Grams}" );
                }
            }
        }
        public static void ShowFoodKinds()
        {
            var kinds = FoodsManager.Instance.GetFoodKinds();
            foreach (var kind in kinds)
            {
                Console.WriteLine($"{kind.Id}. {kind.KindName}");
            }
        }
        public static void ShowAllFoods(List<Food> allfoods)
        {
            foreach (var food in allfoods)
            {
                Console.WriteLine($"{food.Id}. {food.Name}");
            }
        }
        
    }
}
