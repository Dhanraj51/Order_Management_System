using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Order_Management_System.Models
{
    public partial class ProductdetailsModel
    {

        public tbl_Orders Create (tbl_Orders product)
        {
            return new tbl_Orders()
            {
                OrderitemID = product.OrderitemID,
                Ordersdetails = product.Ordersdetails.Select(p => Create(p)),

               //Productname = product.Productname,
                //height = product.height,
                //Image = product.Image,
                //Barcode = product.Barcode,
                //SKU = product.SKU,
                //AvailableQuantity = product.AvailableQuantity   
            };
        }
        public ProductdetailsModel Create(OrderDBEntities orderDBEntities)
        {
            return new ProductdetailsModel()
            {
                
            };
        }
    }
}