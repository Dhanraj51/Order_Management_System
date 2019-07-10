using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Order_Management_System.Controllers
{
    public class OrderController : ApiController
    {

        [HttpGet]
        public IEnumerable<tbl_Orders> LoadAlloders()
        {
            using (OrderDBEntities entities = new OrderDBEntities())
            {
                return entities.tbl_Orders.ToList();
            }
        }
        [HttpGet]
        public HttpResponseMessage Loadorderbtid(int id)
        {
            using (OrderDBEntities entities = new OrderDBEntities())
            {
                var entity = entities.tbl_Orders.FirstOrDefault(e => e.OrderID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Order with OrderID = " + id.ToString() + "Not found");
                }
            }
        }
        public HttpResponseMessage Post([FromBody]tbl_Orders tbl_Orders)
        {
            try
            {
                using (OrderDBEntities entities = new OrderDBEntities())
                {
                    entities.tbl_Orders.Add(tbl_Orders);
                    entities.SaveChanges();

                    var Message = Request.CreateResponse(HttpStatusCode.Created, tbl_Orders);
                    Message.Headers.Location = new Uri(Request.RequestUri + tbl_Orders.OrderID.ToString());
                    return Message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public void Delete(int id)
        {
            using (OrderDBEntities entities = new OrderDBEntities())
            {
                entities.tbl_Orders.Remove(entities.tbl_Orders.FirstOrDefault(e => e.OrderID == id));
                entities.SaveChanges();

            }
        }
        public HttpResponseMessage put(int id, [FromBody] tbl_Orders tbl_Orders)
        {
            try
            {

                using (OrderDBEntities entities = new OrderDBEntities())
                {
                    var entity = entities.tbl_Orders.FirstOrDefault(e => e.OrderID == id);
                    if (entity == null)
                    {

                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Order with id = " + id.ToString() + "Not found to update");
                    }
                    else
                    {
                        entity.Buyer_Name = tbl_Orders.Buyer_Name;
                        entity.Buyer_Mobileno = tbl_Orders.Buyer_Mobileno;
                        entity.OrderStatus = tbl_Orders.OrderStatus;
                        entity.ShippingAddress = tbl_Orders.ShippingAddress;
                        entity.Orderitems = tbl_Orders.Orderitems;
                        entity.OrderitemID = tbl_Orders.OrderitemID;
                        entity.Orderdate = tbl_Orders.Orderdate;
                        entity.Email = tbl_Orders.Email;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
