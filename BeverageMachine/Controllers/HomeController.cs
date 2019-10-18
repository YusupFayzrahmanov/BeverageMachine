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
                Coins = _db.Coins.ToList(),
                Buyer = GetBuyer(HttpContext)
            };
            return View(_vm);
        }

        public ActionResult AddCoin(int Id)
        {
            try
            {
                var _coin = _db.Coins.Find(Id);
                if (_coin == null)
                    return HttpNotFound();
                var _buyer = GetBuyer(HttpContext);
                _buyer.Amount += _coin.Value;
                _buyerCache.Update(_buyer);
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

                    var _buyer = GetBuyer(HttpContext);
                    if(_drink.Cost < _buyer.Amount)
                    {
                        ViewBag.Error = "Напиток дороже внесенной суммы!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _buyer.Drinks.Add(_drink);
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

        public ActionResult GetChange()
        {
            var _buyer = GetBuyer(HttpContext);
            var _coins = _db.Coins.ToList();
            var _selectCoins = _coins.Where(x => x.Count > 0 && x.Value <= _buyer.Amount);
            _selectCoins.OrderByDescending(x => x.Value);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private Buyer GetBuyer(HttpContextBase httpContext)
        {
            var _cookieRequest = httpContext.Request.Cookies["buyerId"].Value;
            if (_cookieRequest != null)
            {
                var _buyer = _buyerCache.GetBuyer(_cookieRequest);
                if (_buyer != null)
                {
                    return _buyer;
                }
                else
                {
                    return SetCookies(httpContext);
                }
            }
            else
            {
                return SetCookies(httpContext);
            }

        }

        private Buyer SetCookies(HttpContextBase httpContext)
        {
            var _guidId = Guid.NewGuid().ToString();
            var _buyer = new Buyer() { Id = _guidId, Amount = 0 };
            _buyerCache.Add(_buyer);
            httpContext.Response.Cookies["buyerId"].Value = _guidId;
            httpContext.Response.Cookies["buyerId"].Expires = DateTime.Now.AddMinutes(20);
            return _buyer;
        }
    }
}