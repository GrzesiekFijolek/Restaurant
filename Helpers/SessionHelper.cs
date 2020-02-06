using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zadanie2.DTOs;
using Zadanie2.Models;

namespace Zadanie2.Helpers
{
    public static class SessionHelper
    {
        public static bool GetTableInfo(string name)
        {
            var x = HttpContext.Current.Session[name] == null ? true : false;
            return x;
        }

        public static Order GetOrder(int tableId)
        {
            var x = (Order)HttpContext.Current.Session[Seed._tableNames[tableId - 1]];

            if (x == null) x = new Order(tableId);
            return x;
        }

        public static void AddToSession(this DishesView dishes)
        {
            var tableId = Seed._tableNames[dishes.TableId - 1];
            var order = new Order(dishes.Dishes, dishes.TableId);
            HttpContext.Current.Session[tableId] = order;
        }

        public static void RemoveFromSession(int table)
        {
            var tableId = Seed._tableNames[table- 1];
            HttpContext.Current.Session.Remove(tableId);

        }

        public static void Modify(this DishesView dishes)
        {
            var tableId = Seed._tableNames[dishes.TableId - 1];
            var order = new Order(dishes.Dishes, dishes.TableId);
            HttpContext.Current.Session[tableId] = order;
        }

        public static void Modify(this List<Dish> dishes, int Id)
        {
            var tableId = Seed._tableNames[Id];
            var currentOrder = (Order)HttpContext.Current.Session[tableId];
            var order = new Order(dishes, Id+1);

            order.Add(currentOrder);
            HttpContext.Current.Session[tableId] = order;
        }

        public static List<Order>GetAll()
        {
            var all = new List<Order>();
            for(int i = 0; i < Seed._tableNames.Length; i++)
            {
                var order = (Order)HttpContext.Current.Session[Seed._tableNames[i]];
                if (order != null)
                    all.Add(order);
            }

            return all;
        }

    }
}