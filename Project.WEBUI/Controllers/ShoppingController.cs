using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Project.WEBUI.VMClasses;
using Project.WEBUI.Models.ShoppingTools;
using Project.ENTITIES.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Project.COMMON.Tools;

namespace Project.WEBUI.Controllers
{
    public class ShoppingController : Controller
    {
        OrderRepository _orderRep;
        OrderDetailRepository _detailRep;
        ProductRepository _prodRep;
        CategoryRepository _catRep;

        public ShoppingController()
        {
            _orderRep = new OrderRepository();
            _detailRep = new OrderDetailRepository();
            _prodRep = new ProductRepository();
            _catRep = new CategoryRepository();
        }

        //Pagination
        public ActionResult ShoppingList(int? page, int? categoryID)
        {
            PaginationVM pavm = new PaginationVM
            {
                PagedProducts = categoryID == null ? _prodRep.GetActives().ToPagedList(page ?? 1, 9) : _prodRep.Where(x => x.CategoryID == categoryID).ToPagedList(page ?? 1, 9),
                Categories = _catRep.GetActives()
            };

            if (categoryID != null) TempData["catID"] = categoryID;

            return View(pavm);
        }

        //Sepete ekleme
        public ActionResult AddToCart(int id)
        {
            Cart cart = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;

            Product productToAdd = _prodRep.Find(id);

            CartItem cartItem = new CartItem
            {
                ID = productToAdd.ID,
                Name = productToAdd.ProductName,
                Price = productToAdd.UnitPrice,
                ImagePath = productToAdd.ImagePath
            };

            cart.AddToCart(cartItem);

            //Sepetimde kaç ürün var sepete gitmeden badge olarak görmek için
            Session["count"] = cart.ProductCount();
            Session["scart"] = cart;
            return RedirectToAction("ShoppingList");
        }

        //Sepet sayfası
        public ActionResult CartPage()
        {
            if (Session["scart"] != null)
            {
                CartPageVM cpvm = new CartPageVM();
                Cart cart = Session["scart"] as Cart;
                cpvm.Cart = cart;
                return View(cpvm);
            }

            TempData["cartEmpty"] = "Sepetinizde ürün bulunmamaktadır...";
            return RedirectToAction("ShoppingList");
        }

        public ActionResult DeleteFromCart(int id)
        {
            if (Session["scart"] != null)
            {
                Cart cart = Session["scart"] as Cart;
                cart.RemoveFromCart(id);
                Session["count"] = cart.ProductCount();
                if (cart.Sepetim.Count == 0)
                {
                    Session.Remove("scart");
                    TempData["cartEmpty"] = "Sepetinizde ürün bulunmamaktadır...";
                    return RedirectToAction("ShoppingList");
                }
                return RedirectToAction("CartPage");
            }
            return RedirectToAction("ShoppingList");
        }

        public ActionResult ConfirmOrder()
        {
            AppUser currentUser;
            if (Session["member"] != null)
            {
                currentUser = Session["member"] as AppUser;
            }
            else
            {
                TempData["guest"] = "Siparişi onaylamak için üye olmalısınız.";
                return RedirectToAction("RegisterNow", "Register");
            }
            return View();
        }

        //https://localhost:44344/api/Payment/ReceivePayment
        [HttpPost]
        public ActionResult ConfirmOrder(OrderVM ovm)
        {
            bool result;
            Cart cart = Session["scart"] as Cart;

            ovm.Order.TotalPrice = ovm.PaymentDTO.ShoppingPrice = cart.TotalPrice;

            #region APISection

            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44344/api/");

                Task<HttpResponseMessage> postTask = client.PostAsJsonAsync("Payment/ReceivePayment", ovm.PaymentDTO);

                HttpResponseMessage sonuc;

                try
                {
                    sonuc = postTask.Result;
                }

                catch (Exception)
                {
                    TempData["connectionDeny"] = "Banka bağlantıyı reddetti";
                    return RedirectToAction("ShoppingList");
                }

                if (sonuc.IsSuccessStatusCode) result = true;
                else result = false;

                if (result)
                {
                    if (Session["member"] != null)
                    {
                        AppUser user = Session["member"] as AppUser;
                        ovm.Order.AppUserID = user.ID;
                        ovm.Order.Username = user.UserName;
                    }
                    else
                    {
                        ovm.Order.AppUserID = null;
                        ovm.Order.Username = TempData["anonim"].ToString();
                    }

                    _orderRep.Add(ovm.Order);

                    foreach (CartItem item in cart.Sepetim)
                    {
                        OrderDetail od = new OrderDetail();
                        od.OrderID = ovm.Order.ID;
                        od.ProductID = item.ID;
                        od.UnitPrice = item.Price;
                        od.TotalPrice = item.SubTotal;
                        od.Quantity = item.Amount;
                        _detailRep.Add(od);

                        //Stok düşme
                        Product decreaseStock = _prodRep.Find(item.ID);
                        decreaseStock.UnitsInStock -= item.Amount;
                        _prodRep.Update(decreaseStock);
                    }

                    TempData["payment"] = "Siparişiniz bize ulaşmıştır.. Teşekkür ederiz";
                    MailService.Send(ovm.Order.Email, body: $"Siparişiniz başarıyla alındı. Siparişiniz toplam tutarı: {ovm.Order.TotalPrice}");
                    Session["scart"] = null;
                    Session["count"] = null;
                    return RedirectToAction("ShoppingList");
                }

                else
                {
                    TempData["paymentIssue"] = "Ödeme ile ilgili bir sorun oluştu. Lütfen bankanız ile iletişime geçiniz.";
                    return RedirectToAction("ShoppingList");
                }
            }


            #endregion
        }

    }
}