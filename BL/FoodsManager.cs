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
    public class FoodsManager
    {
        private static FoodsManager _instance;
        public static FoodsManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FoodsManager();
                }
                return _instance;
            }
        }
        public List<(int Id, string KindName)> GetFoodKinds()
        {
            
            return new List<(int Id, string KindName)>
            {
                (1, "Baked"),
                (2, "Bread"),
                (3, "Dairy"),
                (4, "Egg"),
                (5, "Fish"),
                (6, " Fruit"),
                (7, "Grain"),
                (8, "Legumes"),
                (9, "Meat"),
                (10, "Nuts"),
                (11, "Oil"),
                (12, "Salads"),
                (13, "Snack"),
                (14, " Vegetable"),
            };
        }

        public List<Food> GetFoodOfKind(int selectedKind)
        {
            var enumValue = (FoodKind)(selectedKind - 1);
            return DBOperations.GetAllFoodsOfKind(enumValue);
        }
        public List<Food> GetAllFoods()
        {
            return DBOperations.GetAllFoods();
        }
        public void SaveNewFood(Food newfood)
        {
            DBOperations.SaveNewFood(newfood);
        }

        public void DeleteFood(Food selectedfoodtodelete)
        {
            DBOperations.DeleteFood(selectedfoodtodelete);
        }
    }
}
