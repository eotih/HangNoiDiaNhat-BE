using HangNoiDiaNhat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HangNoiDiaNhat.Controllers
{
    [RoutePrefix("API/Delivery")]
    public class DeliveryController : ApiController
    {
        HangNoiDiaNhatEntities db = new HangNoiDiaNhatEntities();
        //---------------------------- Service Zone ----------------------------//
        [Route("SelectAllService")]
        [HttpGet]
        public object SelectAllService()
        {
            var result = db.Services.ToList();
            return result;
        }
        [Route("GetServiceById")]
        [HttpGet]
        public object GetServiceById(int ServiceID)
        {
            var result = db.Services.Where(x => x.ServiceID == ServiceID).FirstOrDefault();
            return result;
        }

        [Route("AddOrEditService")]
        [HttpPost]
        public object AddOrEditService(Service1 Service1)
        {
            if (Service1.ServiceID == 0)
            {
                Service service = new Service
                {
                    Name = Service1.Name,
                    CreatedAt = DateTime.Now
                };
                db.Services.Add(service);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Services.Where(x => x.ServiceID == Service1.ServiceID).FirstOrDefault();
                if (obj.ServiceID > 0)
                {
                    obj.Name = Service1.Name;
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
        [Route("DeleteService")]
        [HttpDelete]
        public object DeleteService(int ServiceID)
        {
            var obj = db.Services.Where(x => x.ServiceID == ServiceID).FirstOrDefault();
            db.Services.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        //---------------------------- IdentityCard Zone ----------------------------//
        [Route("SelectAllIdentityCard")]
        [HttpGet]
        public object SelectAllIdentityCard()
        {
            var result = db.IdentityCards.ToList();
            return result;
        }
        [Route("GetIdentityCardById")]
        [HttpGet]
        public object GetIdentityCardById(int IdentityCardID)
        {
            var result = db.IdentityCards.Where(x => x.IdentityCardID == IdentityCardID).FirstOrDefault();
            return result;
        }

        [Route("AddOrEditIdentityCard")]
        [HttpPost]
        public object AddOrEditIdentityCard(IdentityCard1 IdentityCard1)
        {
            if (IdentityCard1.IdentityCardID == 0)
            {
                IdentityCard identity = new IdentityCard
                {
                    FrontFigure = IdentityCard1.FrontFigure,
                    BackSideFigure = IdentityCard1.BackSideFigure,
                    CreatedAt = DateTime.Now
                };
                db.IdentityCards.Add(identity);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.IdentityCards.Where(x => x.IdentityCardID == IdentityCard1.IdentityCardID).FirstOrDefault();
                if (obj.IdentityCardID > 0)
                {
                    obj.FrontFigure = IdentityCard1.FrontFigure;
                    obj.BackSideFigure = IdentityCard1.BackSideFigure;
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
        [Route("DeleteIdentityCard")]
        [HttpDelete]
        public object DeleteIdentityCard(int IdentityCardID)
        {
            var obj = db.IdentityCards.Where(x => x.IdentityCardID == IdentityCardID).FirstOrDefault();
            db.IdentityCards.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        //---------------------------- ShippingDepartment Zone ----------------------------//
        [Route("SelectAllShippingDepartment")]
        [HttpGet]
        public object SelectAllShippingDepartment()
        {
            var result = db.ShippingDepartments.ToList();
            return result;
        }
        [Route("GetShippingDepartmentById")]
        [HttpGet]
        public object GetShippingDepartmentById(int ShippingDepartmentID)
        {
            var result = db.ShippingDepartments.Where(x => x.ShippingDepartmentID == ShippingDepartmentID).FirstOrDefault();
            return result;
        }

        [Route("AddOrEditShippingDepartment")]
        [HttpPost]
        public object AddOrEditShippingDepartment(ShippingDepartment1 ShippingDepartment1)
        {
            if (ShippingDepartment1.ShippingDepartmentID == 0)
            {
                ShippingDepartment department = new ShippingDepartment
                {
                    FullName = ShippingDepartment1.FullName,
                    Phone = ShippingDepartment1.Phone,
                    Email = ShippingDepartment1.Email,
                    Address = ShippingDepartment1.Address,
                    CreatedAt = DateTime.Now
                };
                db.ShippingDepartments.Add(department);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.ShippingDepartments.Where(x => x.ShippingDepartmentID == ShippingDepartment1.ShippingDepartmentID).FirstOrDefault();
                if (obj.ShippingDepartmentID > 0)
                {
                    obj.FullName = ShippingDepartment1.FullName;
                    obj.Phone = ShippingDepartment1.Phone;
                    obj.Email = ShippingDepartment1.Email;
                    obj.Address = ShippingDepartment1.Address;
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
        [Route("DeleteShippingDepartment")]
        [HttpDelete]
        public object DeleteShippingDepartment(int ShippingDepartmentID)
        {
            var obj = db.ShippingDepartments.Where(x => x.ShippingDepartmentID == ShippingDepartmentID).FirstOrDefault();
            db.ShippingDepartments.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        //---------------------------- TrackingOrders Zone ----------------------------//
        [Route("SelectAllTrackingOrders")]
        [HttpGet]
        public object SelectAllTrackingOrders()
        {
            var result = (from trOrd in db.TrackingOrders
                          select new
                          {
                              trOrd.CoderOrder,
                              trOrd.ShippingCode,
                              trOrd.Details,
                              trOrd.ShippingFee,
                              trOrd.CreatedAt,
                              trOrd.UpdatedAt,
                              ToChuc = db.Organizations.Where(x=>x.OrganizationID == trOrd.OrganizationID).FirstOrDefault(),
                              KhachHang = db.Customers.Where(x=>x.CustomerID == trOrd.CustomerID).FirstOrDefault(),
                              Shipper = db.Shippers.Where(x=>x.ShipperID == trOrd.ShipperID).FirstOrDefault(),
                              HinhThucThanhToan = db.Payments.Where(x=>x.PaymentID == trOrd.PaymentID).FirstOrDefault(),
                              TrangThai = db.States.Where(x=>x.StateID == trOrd.StateID).FirstOrDefault(),
                              DichVu = db.Services.Where(x=>x.ServiceID == trOrd.ServiceID).FirstOrDefault(),
                              NhaVanChuyen = db.ShippingDepartments.Where(x=>x.ShippingDepartmentID == trOrd.ShippingDepartmentID).FirstOrDefault(),
                          }).ToList();
            return result;
        }
        [Route("GetTrackingOrdersById")]
        [HttpGet]
        public object GetTrackingOrdersById(int TrackingOrderID)
        {
            var getTrackingOrdersById = db.TrackingOrders.Where(x => x.TrackingOrderID == TrackingOrderID).ToList();
            var result = (from trOrd in getTrackingOrdersById
                          select new
                          {
                              trOrd.CoderOrder,
                              trOrd.ShippingCode,
                              trOrd.Details,
                              trOrd.ShippingFee,
                              trOrd.CreatedAt,
                              trOrd.UpdatedAt,
                              ToChuc = db.Organizations.Where(x => x.OrganizationID == trOrd.OrganizationID).FirstOrDefault(),
                              KhachHang = db.Customers.Where(x => x.CustomerID == trOrd.CustomerID).FirstOrDefault(),
                              Shipper = db.Shippers.Where(x => x.ShipperID == trOrd.ShipperID).FirstOrDefault(),
                              HinhThucThanhToan = db.Payments.Where(x => x.PaymentID == trOrd.PaymentID).FirstOrDefault(),
                              TrangThai = db.States.Where(x => x.StateID == trOrd.StateID).FirstOrDefault(),
                              DichVu = db.Services.Where(x => x.ServiceID == trOrd.ServiceID).FirstOrDefault(),
                              NhaVanChuyen = db.ShippingDepartments.Where(x => x.ShippingDepartmentID == trOrd.ShippingDepartmentID).FirstOrDefault(),
                          }).ToList();
            return result;
        }

        [Route("AddOrEditTrackingOrders")]
        [HttpPost]
        public object AddOrEditTrackingOrders(TrackingOrder1 TrackingOrder1)
        {
            if (TrackingOrder1.TrackingOrderID == 0)
            {
                TrackingOrder trOrd = new TrackingOrder
                {
                    OrganizationID = TrackingOrder1.OrganizationID,
                    CustomerID = TrackingOrder1.CustomerID,
                    ShipperID = TrackingOrder1.ShipperID,
                    PaymentID = TrackingOrder1.PaymentID,
                    StateID = TrackingOrder1.StateID,
                    ServiceID = TrackingOrder1.ServiceID,
                    ShippingDepartmentID = TrackingOrder1.ShippingDepartmentID,
                    CoderOrder = TrackingOrder1.CoderOrder,
                    ShippingCode = TrackingOrder1.ShippingCode,
                    Details = TrackingOrder1.Details,
                    ShippingFee = TrackingOrder1.ShippingFee,
                    CreatedAt = DateTime.Now
                };
                db.TrackingOrders.Add(trOrd);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.TrackingOrders.Where(x => x.TrackingOrderID == TrackingOrder1.TrackingOrderID).FirstOrDefault();
                if (obj.TrackingOrderID > 0)
                {
                    obj.OrganizationID = TrackingOrder1.OrganizationID;
                    obj.CustomerID = TrackingOrder1.CustomerID;
                    obj.ShipperID = TrackingOrder1.ShipperID;
                    obj.PaymentID = TrackingOrder1.PaymentID;
                    obj.StateID = TrackingOrder1.StateID;
                    obj.ServiceID = TrackingOrder1.ServiceID;
                    obj.ShippingDepartmentID = TrackingOrder1.ShippingDepartmentID;
                    obj.CoderOrder = TrackingOrder1.CoderOrder;
                    obj.ShippingCode = TrackingOrder1.ShippingCode;
                    obj.Details = TrackingOrder1.Details;
                    obj.ShippingFee = TrackingOrder1.ShippingFee;
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
        [Route("DeleteTrackingOrders")]
        [HttpDelete]
        public object DeleteTrackingOrders(int TrackingOrderID)
        {
            var obj = db.TrackingOrders.Where(x => x.TrackingOrderID == TrackingOrderID).FirstOrDefault();
            db.TrackingOrders.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        //---------------------------- Shipper Zone ----------------------------//
        [Route("SelectAllShipper")]
        [HttpGet]
        public object SelectAllShipper()
        {
            var result = (from shipper in db.Shippers
                          select new
                          {
                              shipper.ShipperID,
                              shipper.FullName,
                              shipper.Phone,
                              shipper.Email,
                              shipper.Password,
                              shipper.Address,
                              shipper.CreatedAt,
                              shipper.UpdatedAt,
                              CCCD = db.Shippers.Where(x=>x.ShipperID == shipper.ShipperID).ToList()
                          }).ToList();
            return result;
        }
        [Route("GetShipperById")]
        [HttpGet]
        public object GetShipperById(int ShipperID)
        {
            var getShipperById = db.Shippers.Where(x => x.ShipperID == ShipperID).ToList();
            var result = (from shipper in getShipperById
                          select new
                          {
                              shipper.ShipperID,
                              shipper.FullName,
                              shipper.Phone,
                              shipper.Email,
                              shipper.Password,
                              shipper.Address,
                              shipper.CreatedAt,
                              shipper.UpdatedAt,
                              CCCD = db.Shippers.Where(x => x.ShipperID == shipper.ShipperID).ToList()
                          }).ToList();
            return result;
        }

        [Route("AddOrEditShipper")]
        [HttpPost]
        public object AddOrEditShipper(Shipper1 Shipper1)
        {
            if (Shipper1.ShipperID == 0)
            {
                Shipper shipper = new Shipper
                {
                    FullName = Shipper1.FullName,
                    IdentityID = Shipper1.IdentityID,
                    Phone = Shipper1.Phone,
                    Email = Shipper1.Email,
                    Password = Shipper1.Password,
                    Address = Shipper1.Address,
                    CreatedAt = DateTime.Now
                };
                db.Shippers.Add(shipper);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Shippers.Where(x => x.ShipperID == Shipper1.ShipperID).FirstOrDefault();
                if (obj.ShipperID > 0)
                {
                    obj.FullName = Shipper1.FullName;
                    obj.IdentityID = Shipper1.IdentityID;
                    obj.Phone = Shipper1.Phone;
                    obj.Email = Shipper1.Email;
                    obj.Password = Shipper1.Password;
                    obj.Address = Shipper1.Address;
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
        [Route("DeletShipper")]
        [HttpDelete]
        public object DeletShipper(int ShipperID)
        {
            var obj = db.Shippers.Where(x => x.ShipperID == ShipperID).FirstOrDefault();
            db.Shippers.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
    }
}
