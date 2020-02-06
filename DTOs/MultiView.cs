using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zadanie2.Models;

namespace Zadanie2.DTOs
{
    public class MultiView
    {
        public List<Table> Tables { get; set; }
        public List<Dish> Dishes { get; set; }

        public MultiView(List<Table> tables, List<Dish> dishes)
        {
            Tables = tables;
            Dishes = dishes;
        }

        public MultiView()
        {

        }
    }
}