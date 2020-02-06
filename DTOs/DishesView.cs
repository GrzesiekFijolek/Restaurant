using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zadanie2.Models;

namespace Zadanie2.DTOs
{
    public class DishesView
    {
        public List<Dish> Dishes { get; set; }
        public int TableId { get; set; }
        public string NextMethod { get; set; } //nazwa metody akcji w formularzu
        public string RedirectTo { get; set; } //nazwa metody powrotu

        public DishesView(List<Dish> dishes, int tableId, string method, string redirect)
        {
            Dishes = dishes;
            TableId = tableId;
            NextMethod = method;
            RedirectTo = redirect;

            foreach(var item in dishes)
            {
                item.CalcTotalPrice();
            }
        }

        public DishesView() { }
    }
}