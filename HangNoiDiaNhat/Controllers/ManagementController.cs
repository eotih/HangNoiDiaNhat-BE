using HangNoiDiaNhat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HangNoiDiaNhat.Controllers
{
    [RoutePrefix("API/Management")]
    public class ManagementController : ApiController
    {
        HangNoiDiaNhatEntities db = new HangNoiDiaNhatEntities();
        //---------------------------- Customer Zone ----------------------------//
        [Route("SelectAllCustomer")]
        [HttpGet]
        public object SelectAllCustomer()
        {
            var result = db.Customers.ToList();
            return result;
        }
        [Route("GetCustomerById")]
        [HttpGet]
        public object GetCustomerById(Customer1 Customer1)
        {
            var result = db.Customers.Where(x => x.CustomerID == Customer1.CustomerID).FirstOrDefault();
            return result;
        }

        [Route("AddOrEditCustomer")]
        [HttpPost]
        public object AddOrEditCustomer(Customer1 Customer1)
        {
            if (Customer1.CustomerID == 0)
            {
                Customer Customer = new Customer
                {
                    FullName = Customer1.FullName,
                    Phone = Customer1.Phone,
                    Email = Customer1.Email,
                    Address = Customer1.Address,
                    Password = Customer1.Password,
                    CreatedAt = DateTime.Now
                };
                db.Customers.Add(Customer);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Customers.Where(x => x.CustomerID == Customer1.CustomerID).FirstOrDefault();
                if (obj.CustomerID > 0)
                {
                    obj.FullName = Customer1.FullName;
                    obj.Phone = Customer1.Phone;
                    obj.Email = Customer1.Email;
                    obj.Address = Customer1.Address;
                    obj.Password = Customer1.Password;
                    obj.UpdatedAt = DateTime.Now;
                    db.SaveChanges();
                    return new Response
                    {
                        Status = "Updated",
                        Message = "Updated Successfully"
                    };
                }
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };
        }
        [Route("DeleteCustomer")]
        [HttpDelete]
        public object DeleteCustomer(Customer1 Customer1)
        {
            var obj = db.Customers.Where(x => x.CustomerID == Customer1.CustomerID).FirstOrDefault();
            db.Customers.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
    }
}
