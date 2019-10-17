using BeverageMachine.Models;
using BeverageMachine.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BeverageMachine.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        DatabaseContext _db = new DatabaseContext();

        /// <summary>
        /// 
        /// </summary>
        BuyerCache _buyerCache;

        public HomeController()
        {
            _buyerCache = new BuyerCache();
        }

        /// <summary>
        /// Глав. страница - автомат по продажи напитков
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var _vm = new HomeViewModel()
            {
                Drinks = _db.Drinks.ToList(),
                Coins = _db.Coins.ToList()
            };
            var _cookieRequest = HttpContext.Request.Cookies["buyerId"].Value;
            if(_cookieRequest != null)
            {
                var _buyer = _buyerCache.GetBuyer(_cookieRequest);
                if(_buyer != null)
                {
                    _vm.BuyerAmount = _buyer.Amount;
                }
                else
                {
                    SetCookies(HttpContext, 0);
                }
            }
            else
            {
                SetCookies(HttpContext, 0);
            }
            
            return View(_vm);
        }

        public ActionResult AddCoin(int Id)
        {
            try
            {
                var _coin = _db.Coins.Find(Id);
                if (_coin == null)
                    return HttpNotFound();
                var _cookieRequest = HttpContext.Request.Cookies["buyerId"].Value;
                if(_cookieRequest != null)
                {
                    var _buyer = _buyerCache.GetBuyer(_cookieRequest);
                    if(_buyer != null)
                    {
                        _buyer.Amount += _coin.Value;
                        _buyerCache.Update(_buyer);
                    }
                    else
                    {
                        SetCookies(HttpContext, _coin.Value);
                    }
                }
                else
                {
                    SetCookies(HttpContext, _coin.Value);
                }
                _coin.Count++;
                _db.SaveChanges();

            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return RedirectToAction("Index");
        }

        public ActionResult GetDrink(int id)
        {
            try
            {
                decimal _buyerAmount = 0;
                var _drink = _db.Drinks.Find(id);
                if (_drink == null)
                    return HttpNotFound();
                if (_drink.Count == 0)
                {
                    ViewBag.Error = "Ошибка. Напиток закончился.";
                    return RedirectToAction("Index");
                }
                else
                {
                    
                    var _cookieRequest = HttpContext.Request.Cookies["buyerId"].Value;
                    if (_cookieRequest != null)
                    {
                        var _buyer = _buyerCache.GetBuyer(_cookieRequest);
                        if (_buyer != null)
                        {
                            _buyerAmount = _buyer.Amount;
                        }
                        else
                        {
                            SetCookies(HttpContext, 0);
                        }
                    }
                    else
                    {
                        SetCookies(HttpContext, 0);
                    }
                    if(_drink.Cost < _buyerAmount)
                    {
                        ViewBag.Error = "Напиток дороже внесенной суммы!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _drink.Count--;
                        _db.SaveChanges();
                    }
                }


            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return RedirectToAction("Index");
        }

        //public JsonResult GetChange()
        //{

        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void SetCookies(HttpContextBase httpContext, decimal coin)
        {
            var _guidId = Guid.NewGuid().ToString();
            decimal _amount = 0;
            _amount += coin;
            _buyerCache.Add(new Buyer() { Id = _guidId, Amount = _amount });
            httpContext.Response.Cookies["buyerId"].Value = _guidId;
            httpContext.Response.Cookies["buyerId"].Expires = DateTime.Now.AddMinutes(20);
        }
    }
}