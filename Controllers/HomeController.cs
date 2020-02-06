
using System;
using System.Web.Mvc;
using Zadanie2.Models;
using Zadanie2.DTOs;
using Zadanie2.Helpers;
using System.Collections.Generic;

namespace Zadanie2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult TablesList()
        {
            var tables = Seed.GetTables();

            return View(tables);
        }

        public ActionResult DishesList(int table, string method, string reddirect)
        {
            if (method == "AddOrder")
            {
                var dishes = Seed.GetDishes();
                var result = new DishesView(dishes, table, method, reddirect);
                return View(result);
            }
            else if (method == "ModifyOrder")
            {
                var order = SessionHelper.GetOrder(table);
                var result = new DishesView(order.Dishes, table, method, reddirect);
                return View(result);
            }

            else return Content("Błąd");
            
            
        }
 
        public ActionResult AddOrder(DishesView orderDetails)
        {
            orderDetails.Dishes.ForEach(d => d.CalcTotalPrice());
            orderDetails.AddToSession();
            return RedirectToAction("Table", new { id = orderDetails.TableId });
        }

        public ActionResult RemoveOrder(int table, string redirect)
        {
            SessionHelper.RemoveFromSession(table);

            return RedirectToAction(redirect, new { id = table });
        }

        public ActionResult ModifyOrder(DishesView orderDetails)
        {
            orderDetails.Dishes.ForEach(d => d.CalcTotalPrice());
            orderDetails.Modify();
            if (orderDetails.RedirectTo == "Table")
                return RedirectToAction("Table", new { id = orderDetails.TableId });
            else
                return RedirectToAction("GetAllOrders");
        }

        public ActionResult Table(int id)
        {
            var x = SessionHelper.GetOrder(id);

            return View("TableDetails", x);
        }

        public ActionResult SetTotal(string price, string quantity)
        {
            var p = Double.Parse(price);
            var q = Double.Parse(quantity);
            double x = Math.Round(p * q, 2);
            return Json(x);
        }

        public ActionResult GetAllOrders()
        {
            var result = SessionHelper.GetAll();
            return View("Orders", result);
        }

        public ActionResult Finalization(Order order)
        {
            var x = new Order(order.TotalPrice, order.TableId);
            return View("Finalization", x);
        }

        public ActionResult FinalizationFromAllOrders(double total, int id)
        {
            var x = new Order(total, id);
            return View("Finalization", x);
        }

        public ActionResult MultiOrder()
        {
            var tables = Seed.GetTables();
            var dishes = Seed.GetDishes();

            var x = new MultiView(tables, dishes);

            return View("MultiOrder", x);
        }

        public ActionResult AddMultiOrder(MultiView multiView)
        {
            foreach(var item in multiView.Dishes)
            {
                item.CalcTotalPrice();
            }

            for (int i=0; i< multiView.Tables.Count; i++)
            {
                if(multiView.Tables[i].IsChoosen)
                {
                    multiView.Dishes.Modify(i);
                }
            }

            return RedirectToAction("GetAllOrders");
        }
    }
}