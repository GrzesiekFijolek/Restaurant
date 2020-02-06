using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zadanie2.Helpers;

namespace Zadanie2.Models
{
    public class Table
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string IsOccupied { get; set; }
        public bool IsChoosen { get; set; }

        public Table(int id, string name)
        {
            Name = name;
            Id = id;
            IsOccupied = SessionHelper.GetTableInfo(name) ? "wolny" : "zajęty";
            IsChoosen = false;
        }

        public Table()
        {
            IsChoosen = false;
        }
    }   
}