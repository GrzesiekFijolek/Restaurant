using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zadanie2.Models;

namespace Zadanie2.Helpers
{
    public static class Seed
    {
        internal static readonly string[] _tableNames = { "stolik nr 1", "stolik nr 2", "stolik nr 3", "stolik nr 4", "stolik nr 5", "stolik nr 6" };
        private static readonly string[] _dishNames = { "pizza", "kurczak", "sushi", "ryba", "burger", "sałatka", "sok", "stek" };
        private static readonly string[] _dishImages =
        {
            "../Content/Images/pizza.jpg",
            "../Content/Images/chicken.jpg",
            "../Content/Images/sushi.jpg",
            "../Content/Images/fish.jpg",
            "../Content/Images/burger.jpg",
            "../Content/Images/salad.jpg",
            "../Content/Images/juice.jpg",
            "../Content/Images/steak.jpg",
        };
        private static readonly double[] _dishPrices = { 9.99, 14.99, 12.90, 18.90, 16.50, 10.50, 2, 21.79 };

        public static List<Table> GetTables()
        {
            int i = 1;
            List<Table> tables = new List<Table>();
            foreach(var name in _tableNames)
            {
                var table = new Table(i, name);
                tables.Add(table);
                i++;
            }

            return tables;
        }

        public static List<Dish> GetDishes()
        {
            List<Dish> dishes = new List<Dish>();
            for(int i=0; i<_dishPrices.Length; i++)
            {
                dishes.Add(new Dish(_dishNames[i], _dishPrices[i], _dishImages[i]));
            }

            return dishes;
        }



    }

}