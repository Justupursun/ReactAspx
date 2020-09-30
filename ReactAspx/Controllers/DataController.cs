using ReactAspx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReactAspx.Controllers
{
    public class DataController : Controller
    {
        public IList<ArtItem> artItems;

        // GET: Data

        // Get list of all art from db
        [HttpGet]
        public ActionResult GetArtList()
        {
            artItems = new List<ArtItem>();
            using (var db = new AppDbContext())
            {
                foreach (var f in db.ArtItems)
                {
                    artItems.Add(f);
                }
            }

            return Json(artItems, JsonRequestBehavior.AllowGet); // return ArtItems in JSONformat
        }

        [HttpGet]
        public string GetUserId()
        {
            int uid = -1;
            if (Session["UserId"] != null)
                uid = Convert.ToInt32(Session["UserId"].ToString());
            return uid.ToString();
        }

        // User submits order
        [HttpPost]
        public ActionResult PlaceOrder(IList<ArtItem> items, int id)
        {
            bool dbSuccess = false;
            try
            {
                using (var db = new AppDbContext())
                {
                    Order o = new Order();
                    o.StudentId = id;
                    o.OrderDate = DateTime.Now;

                    foreach (var f in items)
                    {
                        o.HireFrom = f.HireFrom;
                        o.HireTill = f.HireTill;
                    }

                    db.Orders.Add(o);
                    db.SaveChanges();

                    int orderId = o.Id;
                    decimal grandTotal = 0;
                   
                    foreach (var f in items)
                    {
                        OrderDetail orderDetail = new OrderDetail
                        {
                            OrderId = orderId,
                            ArtItemId = f.Id,
                            
 //                           Quantity = f.Quantity,
 //                           TotalPrice = f.Price  * f.Quantity,
                            TotalPrice = f.Price,
                        };
                        db.OrderDetails.Add(orderDetail);
                        grandTotal += orderDetail.TotalPrice;
                    }

                    o.TotalPaid = grandTotal;
                    o.Status = 1;
                    o.OrderDate = DateTime.Now;
                    db.SaveChanges();
                    dbSuccess = true;
                }
            }
            catch (Exception ex)
            {
                //log ex
                dbSuccess = false;
            }

            if (dbSuccess)
                return Json("success: true", JsonRequestBehavior.AllowGet);
            else
                return Json("success: false", JsonRequestBehavior.AllowGet);

        }
    }
}