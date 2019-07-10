using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Collections;


namespace Order_Management_System.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        public IEnumerable<tbl_Product> LoadAllProduct()
        {
            using (OrderDBEntities entities = new OrderDBEntities())
            {
                return entities.tbl_Product.ToList();
            }
        }
        [HttpGet]
        public HttpResponseMessage LoadProductid(int id)
        {
            using (OrderDBEntities entities = new OrderDBEntities())
            {
                var entity = entities.tbl_Product.FirstOrDefault(e => e.OrderitemID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Orderitem with OrderotemID = " + id.ToString() + "Not found");
                }
            }
        }

        public HttpResponseMessage Post([FromBody]tbl_Product tbl_Product)
        {
            try
            {
                using (OrderDBEntities entities = new OrderDBEntities())
                {
                    entities.tbl_Product.Add(tbl_Product);
                    entities.SaveChanges();

                    var Message = Request.CreateResponse(HttpStatusCode.Created, tbl_Product);
                    Message.Headers.Location = new Uri(Request.RequestUri + tbl_Product.OrderitemID.ToString());
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
                entities.tbl_Product.Remove(entities.tbl_Product.FirstOrDefault(e => e.OrderitemID == id));
                entities.SaveChanges();

            }
        }
        public HttpResponseMessage put(int id, [FromBody] tbl_Product tbl_Product)
        {
            try
            {

                using (OrderDBEntities entities = new OrderDBEntities())
                {
                    var entity = entities.tbl_Product.FirstOrDefault(e => e.OrderitemID == id);
                    if (entity == null)
                    {

                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product with id = " + id.ToString() + "Not found to update");
                    }
                    else
                    {
                        entity.Productname = tbl_Product.Productname;
                        entity.Productdetails = tbl_Product.Productdetails;
                        entity.height = tbl_Product.height;
                        entity.Image = tbl_Product.Image;
                        entity.Weight = tbl_Product.Weight;
                        entity.SKU = tbl_Product.SKU;
                        entity.Barcode = tbl_Product.Barcode;
                        entity.AvailableQuantity = tbl_Product.AvailableQuantity;
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
