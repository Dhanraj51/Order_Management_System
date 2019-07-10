using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;


namespace Order_Management_System.Controllers
{
    public class EmailController : ApiController
    {
        public HttpResponseMessage Post(int id, [FromBody] tbl_Orders tbl_Orders)
        {
            try
            {
                using (OrderDBEntities entities = new OrderDBEntities())
                {
                    var entity = entities.tbl_Orders.FirstOrDefault(e => e.OrderID == id);
                    if (tbl_Orders.Email == "Placed")
                    {
                        MailMessage mm = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                        entity.Email = tbl_Orders.Email;
                        //tbl_Orders.Subject = "Order Plased..";
                        //tbl_Orders.Body = "Your Order Have been plased...";

                        SmtpServer.Port = 25;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("myemailaddress@gmail.com", "38jduw@@1#");
                        SmtpServer.EnableSsl = false;
                        SmtpServer.Send(mm);
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadGateway);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadGateway);
            }

        }
    }
}
