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
        [Route("SelectAllContact")]
        [HttpGet]
        public object SelectAllContact()
        {
            var result = db.Contacts.ToList();
            return result;
        }
        [Route("GetContactById")]
        [HttpGet]
        public object GetContactById(int ContactID)
        {
            var result = db.Contacts.Where(x => x.ContactID == ContactID).FirstOrDefault();
            return result;
        }

        [Route("AddOrEditContact")]
        [HttpPost]
        public object AddOrEditContact(Contact1 Contact1)
        {
            if (Contact1.ContactID == 0)
            {
                Contact Contact = new Contact
                {
                    FullName = Contact1.FullName,
                    Phone = Contact1.Phone,
                    Email = Contact1.Email,
                    Address = Contact1.Address,
                    Subtitle = Contact1.Subtitle,
                    Details = Contact1.Details,
                    CreatedAt = DateTime.Now
                };
                db.Contacts.Add(Contact);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Contacts.Where(x => x.ContactID == Contact1.ContactID).FirstOrDefault();
                if (obj.ContactID > 0)
                {
                    obj.FullName = Contact1.FullName;
                    obj.Phone = Contact1.Phone;
                    obj.Email = Contact1.Email;
                    obj.Address = Contact1.Address;
                    obj.Details = Contact1.Details;
                    obj.Subtitle = Contact1.Subtitle;
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
        [Route("DeleteContact")]
        [HttpDelete]
        public object DeleteContact(int ContactID)
        {
            var obj = db.Contacts.Where(x => x.ContactID == ContactID).FirstOrDefault();
            db.Contacts.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Deleted",
                Message = "Delete Successfuly"
            };
        }

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
        public object GetCustomerById(int CustomerID)
        {
            var result = db.Customers.Where(x => x.CustomerID == CustomerID).FirstOrDefault();
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
        public object DeleteCustomer(int CustomerID)
        {
            var obj = db.Customers.Where(x => x.CustomerID == CustomerID).FirstOrDefault();
            db.Customers.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Deleted",
                Message = "Delete Successfuly"
            };
        }
        //---------------------------- Image Zone ----------------------------//
        [Route("SelectAllImage")]
        [HttpGet]
        public object SelectAllImage()
        {
            var result = db.Images.ToList();
            return result;
        }
        [Route("GetImageByProductId")]
        [HttpGet]
        public object GetImageByProductId(int ProductID)
        {
            var result = db.Images.Where(x => x.ProductID == ProductID).FirstOrDefault();
            return result;
        }

        [Route("AddOrEditProductImage")]
        [HttpPost]
        public object AddOrEditProductImage(Image1 img1)
        {
            if (img1.ImageID == 0)
            {
                Image img = new Image
                {
                    ProductID = img1.ProductID,
                    Image1 = img1.Image2,
                    CreatedAt = DateTime.Now
                };
                db.Images.Add(img);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Images.Where(x => x.ImageID == img1.ImageID).FirstOrDefault();
                if (obj.ImageID > 0)
                {
                    obj.ProductID = img1.ProductID;
                    obj.Image1 = img1.Image2;
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
        [Route("DeleteImage")]
        [HttpDelete]
        public object DeleteImage(int img)
        {
            var obj = db.Images.Where(x => x.ImageID == img).FirstOrDefault();
            db.Images.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Deleted",
                Message = "Delete Successfuly"
            };
        }
        //---------------------------- Product Zone ----------------------------//
        [Route("SelectAllProduct")]
        [HttpGet]
        public object SelectAllProduct()
        {
            var result = (from prd in db.Products
                          select new
                          {
                              prd.Name,
                              prd.Slug,
                              prd.Details,
                              prd.Quantity,
                              prd.Price,
                              prd.Discount,
                              prd.ImportPrice,
                              prd.Sold,
                              prd.Thumbnail,
                              prd.CreatedAt,
                              prd.UpdatedAt,
                              TheLoai = db.Categories.Where(x=>x.CategoryID == prd.CategoryID).FirstOrDefault(),
                              NhanVien = db.Accounts.Where(x=>x.AccountID == prd.AccountID).FirstOrDefault(),
                              ChucNang = db.ProductDetails.Where(x=>x.ProductDetailID == prd.ProductDetailID).ToList(),
                              ThuongHieu = db.Brands.Where(x=>x.BrandID == prd.BrandID).FirstOrDefault(),
                              HinhAnh = db.Images.Where(x=>x.ImageID == prd.ImageID).ToList(),
                          }).ToList();
            return result;
        }
        [Route("GetProductById")]
        [HttpGet]
        public object GetProductById(int ProductID)
        {
            var getProductById = db.Products.Where(x => x.ProductID == ProductID).ToList();
            var result = (from prd in getProductById
                          select new
                          {
                              prd.Name,
                              prd.Slug,
                              prd.Details,
                              prd.Quantity,
                              prd.Price,
                              prd.Discount,
                              prd.ImportPrice,
                              prd.Sold,
                              prd.Thumbnail,
                              prd.CreatedAt,
                              prd.UpdatedAt,
                              TheLoai = db.Categories.Where(x => x.CategoryID == prd.CategoryID).FirstOrDefault(),
                              NhanVien = db.Accounts.Where(x => x.AccountID == prd.AccountID).FirstOrDefault(),
                              ChucNang = db.ProductDetails.Where(x => x.ProductDetailID == prd.ProductDetailID).ToList(),
                              ThuongHieu = db.Brands.Where(x => x.BrandID == prd.BrandID).FirstOrDefault(),
                              HinhAnh = db.Images.Where(x => x.ImageID == prd.ImageID).ToList(),
                          }).ToList();
            return result;
        }

        [Route("AddOrEditProduct")]
        [HttpPost]
        public object AddOrEditProduct(Product1 Product1)
        {
            if (Product1.ProductID == 0)
            {
                Product prd = new Product
                {
                    CategoryID = Product1.ProductID,
                    AccountID = Product1.AccountID,
                    ProductDetailID = Product1.ProductDetailID,
                    BrandID = Product1.BrandID,
                    ImageID = Product1.ImageID,
                    Slug = Utilities.ReplaceSpecialChars(Product1.Name),
                    Thumbnail = Product1.Thumbnail,
                    Details = Product1.Details,
                    Name = Product1.Name,
                    Quantity = Product1.Quantity,
                    Price = Product1.Price,
                    Discount = Product1.Discount,
                    ImportPrice = Product1.ImportPrice,
                    Sold = Product1.Sold,
                    CreatedAt = DateTime.Now
                };
                db.Products.Add(prd);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Products.Where(x => x.ProductID == Product1.ProductID).FirstOrDefault();
                if (obj.ProductID > 0)
                {
                    obj.CategoryID = Product1.ProductID;
                    obj.AccountID = Product1.AccountID;
                    obj.ProductDetailID = Product1.ProductDetailID;
                    obj.BrandID = Product1.BrandID;
                    obj.ImageID = Product1.ImageID;
                    obj.Slug = Utilities.ReplaceSpecialChars(Product1.Name);
                    obj.Thumbnail = Product1.Thumbnail;
                    obj.Details = Product1.Details;
                    obj.Name = Product1.Name;
                    obj.Quantity = Product1.Quantity;
                    obj.Price = Product1.Price;
                    obj.Discount = Product1.Discount;
                    obj.ImportPrice = Product1.ImportPrice;
                    obj.Sold = Product1.Sold;
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
        [Route("DeleteProduct")]
        [HttpDelete]
        public object DeleteProduct(int ProductID)
        {
            var obj = db.Products.Where(x => x.ProductID == ProductID).FirstOrDefault();
            db.Products.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Deleted",
                Message = "Delete Successfuly"
            };
        }
        //---------------------------- ProductDetail Zone ----------------------------//
        [Route("SelectAllProductDetail")]
        [HttpGet]
        public object SelectAllProductDetail()
        {
            var result = db.ProductDetails.ToList();
            return result;
        }
        [Route("GetProductDetailByID")]
        [HttpGet]
        public object GetProductDetailByID(int ProductDetailID)
        {
            var result = db.ProductDetails.Where(x => x.ProductDetailID == ProductDetailID).FirstOrDefault();
            return result;
        }

        [Route("AddOrEditProductDetail")]
        [HttpPost]
        public object AddOrEditProductDetail (ProductDetail1 ProductDetail1)
        {
            if (ProductDetail1.ProductDetailID == 0)
            {
                ProductDetail productDetail = new ProductDetail
                {
                    ProductID = ProductDetail1.ProductID,
                    UtilityID = ProductDetail1.UtilityID,
                    CreatedAt = DateTime.Now
                };
                db.ProductDetails.Add(productDetail);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.ProductDetails.Where(x => x.ProductDetailID == ProductDetail1.ProductDetailID).FirstOrDefault();
                if (obj.ProductDetailID > 0)
                {
                    obj.ProductID = ProductDetail1.ProductID;
                    obj.UtilityID = ProductDetail1.UtilityID;
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
        [Route("DeleteProductDetail")]
        [HttpDelete]
        public object DeleteProductDetail(int ImageID)
        {
            var obj = db.Images.Where(x => x.ImageID == ImageID).FirstOrDefault();
            db.Images.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Deleted",
                Message = "Delete Successfuly"
            };
        }
        //---------------------------- Orders Zone ----------------------------//
        [Route("SelectAllOrders")]
        [HttpGet]
        public object SelectAllOrders()
        {
            var result = (from ord in db.Orders
                          select new
                          {
                              ord.Details,
                              ord.Quantity,
                              ord.TotalPrice,
                              ord.CreatedAt,
                              ord.UpdatedAt,
                              ChiTietDonHang = db.OrderDetails.Where(x=>x.OrderDetailID == ord.OrderDetailID).ToList(),
                              NhanVien = db.Accounts.Where(x=>x.AccountID == ord.AccountID).FirstOrDefault(),
                              TrangThai = db.States.Where(x=>x.StateID == ord.StateID).FirstOrDefault(),
                              HinhThucThanhToan = db.Payments.Where(x=>x.PaymentID == ord.PaymentID).FirstOrDefault(),
                              TinhTrangDonHang = db.TrackingOrders.Where(x=>x.TrackingOrderID == ord.TrackingOrderID).FirstOrDefault(),
                          }).ToList();
            return result;
        }
        [Route("GetOrdersById")]
        [HttpGet]
        public object GetOrdersById(int OrderID)
        {
            var getOrdersById = db.Orders.Where(x => x.OrderID == OrderID).ToList();
            var result = (from ord in getOrdersById
                          select new
                          {
                              ord.Details,
                              ord.Quantity,
                              ord.TotalPrice,
                              ord.CreatedAt,
                              ord.UpdatedAt,
                              ChiTietDonHang = db.OrderDetails.Where(x => x.OrderDetailID == ord.OrderDetailID).ToList(),
                              NhanVien = db.Accounts.Where(x => x.AccountID == ord.AccountID).FirstOrDefault(),
                              TrangThai = db.States.Where(x => x.StateID == ord.StateID).FirstOrDefault(),
                              HinhThucThanhToan = db.Payments.Where(x => x.PaymentID == ord.PaymentID).FirstOrDefault(),
                              TinhTrangDonHang = db.TrackingOrders.Where(x => x.TrackingOrderID == ord.TrackingOrderID).FirstOrDefault(),
                          }).ToList();
            return result;
        }

        [Route("AddOrEditOrder")]
        [HttpPost]
        public object AddOrEditOrder(Order1 Order1)
        {
            if (Order1.OrderID == 0)
            {
                Order ord = new Order
                {
                    OrderDetailID = Order1.OrderDetailID,
                    AccountID = Order1.AccountID,
                    StateID = Order1.StateID,
                    PaymentID = Order1.PaymentID,
                    TrackingOrderID = Order1.TrackingOrderID,
                    Details = Order1.Details,
                    Quantity = Order1.Quantity,
                    TotalPrice = Order1.TotalPrice,
                    CreatedAt = DateTime.Now
                };
                db.Orders.Add(ord);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Orders.Where(x => x.OrderID == Order1.OrderID).FirstOrDefault();
                if (obj.OrderID > 0)
                {
                    obj.OrderDetailID = Order1.OrderDetailID;
                    obj.AccountID = Order1.AccountID;
                    obj.StateID = Order1.StateID;
                    obj.PaymentID = Order1.PaymentID;
                    obj.TrackingOrderID = Order1.TrackingOrderID;
                    obj.Details = Order1.Details;
                    obj.Quantity = Order1.Quantity;
                    obj.TotalPrice = Order1.TotalPrice;
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
        [Route("DeleteOrder")]
        [HttpDelete]
        public object DeleteOrder(int OrderID)
        {
            var obj = db.Orders.Where(x => x.OrderID == OrderID).FirstOrDefault();
            db.Orders.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Deleted",
                Message = "Delete Successfuly"
            };
        }
        //---------------------------- OrderDetails Zone ----------------------------//
        [Route("SelectAllOrderDetails")]
        [HttpGet]
        public object SelectAllOrderDetails()
        {
            var result = (from ord in db.OrderDetails
                          select new
                          {
                              ord.Details,
                              ord.Quantity,
                              ord.CreatedAt,
                              ord.UpdatedAt,
                              ord.OrderID,
                              SanPham = db.Products.Where(x => x.ProductID == ord.ProductID).FirstOrDefault(),
                              KhachHang = db.Customers.Where(x => x.CustomerID == ord.CustomerID).FirstOrDefault(),
                              TrangThai = db.States.Where(x => x.StateID == ord.StateID).FirstOrDefault(),
                          }).ToList();
            return result;
        }
        [Route("GetOrderDetailById")]
        [HttpGet]
        public object GetOrderDetailById(int OrderDetailID)
        {
            var getOrderDetailById = db.OrderDetails.Where(x => x.OrderDetailID == OrderDetailID).ToList();
            var result = (from ord in getOrderDetailById
                          select new
                          {
                              ord.Details,
                              ord.Quantity,
                              ord.CreatedAt,
                              ord.UpdatedAt,
                              ord.OrderID,
                              SanPham = db.Products.Where(x => x.ProductID == ord.ProductID).FirstOrDefault(),
                              KhachHang = db.Customers.Where(x => x.CustomerID == ord.CustomerID).FirstOrDefault(),
                              TrangThai = db.States.Where(x => x.StateID == ord.StateID).FirstOrDefault(),
                          }).ToList();
            return result;
        }

        [Route("AddOrEditOrderDetails")]
        [HttpPost]
        public object AddOrEditOrderDetails(OrderDetail1 OrderDetail1)
        {
            if (OrderDetail1.OrderDetailID == 0)
            {
                OrderDetail ord = new OrderDetail
                {
                    OrderID = OrderDetail1.OrderID,
                    ProductID = OrderDetail1.ProductID,
                    CustomerID = OrderDetail1.CustomerID,
                    StateID = OrderDetail1.StateID,
                    Details = OrderDetail1.Details,
                    Quantity = OrderDetail1.Quantity,
                    CreatedAt = DateTime.Now
                };
                db.OrderDetails.Add(ord);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.OrderDetails.Where(x => x.OrderDetailID == OrderDetail1.OrderDetailID).FirstOrDefault();
                if (obj.OrderDetailID > 0)
                {
                    obj.OrderID = OrderDetail1.OrderID;
                    obj.ProductID = OrderDetail1.ProductID;
                    obj.CustomerID = OrderDetail1.CustomerID;
                    obj.StateID = OrderDetail1.StateID;
                    obj.Details = OrderDetail1.Details;
                    obj.Quantity = OrderDetail1.Quantity;
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
        [Route("DeleteOrderDetail")]
        [HttpDelete]
        public object DeleteOrderDetail(int OrderDetailID)
        {
            var obj = db.OrderDetails.Where(x => x.OrderDetailID == OrderDetailID).FirstOrDefault();
            db.OrderDetails.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Deleted",
                Message = "Delete Successfuly"
            };
        }
    }
}
