using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Order_Management_System.Models
{
    public class Productrepository
    {

        public IQueryable<tbl_Orders> GetAllProductDetails()
        {
            OrderDBEntities orderDBEntities = new OrderDBEntities();
            return orderDBEntities.tbl_Orders;

        }

        public IQueryable<tbl_Product> GetAllProductDetails(int id)
        {
            OrderDBEntities orderDBEntities = new OrderDBEntities();
            return orderDBEntities.tbl_Product.Where(c => c.OrderitemID == id).Select(e => e);
        }   
    }
}