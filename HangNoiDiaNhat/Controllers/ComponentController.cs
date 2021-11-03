using HangNoiDiaNhat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HangNoiDiaNhat.Controllers
{
    [RoutePrefix("API/Component")]
    public class ComponentController : ApiController
    {
        HangNoiDiaNhatEntities db = new HangNoiDiaNhatEntities();
        //---------------------------- State Zone ----------------------------//
        [Route("SelectAllState")]
        [HttpGet]
        public object SelectAllState()
        {
            var result = db.States.ToList();
            return result;
        }
        [Route("GetStateById")]
        [HttpGet]
        public object GetStateById(int StateID)
        {
            var result = db.States.Where(x => x.StateID == StateID).FirstOrDefault();
            return result;
        }

        [Route("AddOrEditState")]
        [HttpPost]
        public object AddOrEditState(State1 state1)
        {
            if (state1.StateID == 0)
            {
                State state = new State
                {
                    Name = state1.Name,
                    CreatedAt = DateTime.Now
                };
                db.States.Add(state);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.States.Where(x => x.StateID == state1.StateID).FirstOrDefault();
                if (obj.StateID > 0)
                {
                    obj.Name = state1.Name;
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
        [Route("DeleteState")]
        [HttpDelete]
        public object DeleteState(int StateID)
        {
            var obj = db.States.Where(x => x.StateID == StateID).FirstOrDefault();
            db.States.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Deleted",
                Message = "Delete Successfuly"
            };
        }
        //---------------------------- Payment Zone ----------------------------//
        [Route("SelectAllPayment")]
        [HttpGet]
        public object SelectAllPayment()
        {
            var result = db.Payments.ToList();
            return result;
        }
        [Route("GetPaymentById")]
        [HttpGet]
        public object GetPaymentById(int PaymentID)
        {
            var result = db.Payments.Where(x => x.PaymentID == PaymentID).FirstOrDefault();
            return result;
        }

        [Route("AddOrEditPayment")]
        [HttpPost]
        public object AddOrEditPayment(Payment1 payment1)
        {
            if (payment1.PaymentID == 0)
            {
                Payment payment = new Payment
                {
                    Name = payment1.Name,
                    CreatedAt = DateTime.Now
                };
                db.Payments.Add(payment);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Payments.Where(x => x.PaymentID == payment1.PaymentID).FirstOrDefault();
                if (obj.PaymentID > 0)
                {
                    obj.Name = payment1.Name;
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
        [Route("DeletePayment")]
        [HttpDelete]
        public object DeletePayment(int PaymentID)
        {
            var obj = db.Payments.Where(x => x.PaymentID == PaymentID).FirstOrDefault();
            db.Payments.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Deleted",
                Message = "Delete Successfuly"
            };
        }
        //---------------------------- Roles Zone ----------------------------//
        [Route("SelectAllRole")]
        [HttpGet]
        public object SelectAllRole()
        {
            var result = db.Roles.ToList();
            return result;
        }
        [Route("GetRoleById")]
        [HttpGet]
        public object GetRoleById(int RoleID)
        {
            var result = db.Roles.Where(x => x.RoleID == RoleID).FirstOrDefault();
            return result;
        }

        [Route("AddOrEditRole")]
        [HttpPost]
        public object AddOrEditRole(Role1 role1)
        {
            if (role1.RoleID == 0)
            {
                Role role = new Role
                {
                    RoleName = role1.RoleName,
                    CreatedAt = DateTime.Now
                };
                db.Roles.Add(role);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Roles.Where(x => x.RoleID == role1.RoleID).FirstOrDefault();
                if (obj.RoleID > 0)
                {
                    obj.RoleName = role1.RoleName;
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
        [Route("DeleteRole")]
        [HttpDelete]
        public object DeleteRole(int RoleID)
        {
            var obj = db.Roles.Where(x => x.RoleID == RoleID).FirstOrDefault();
            db.Roles.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Deleted",
                Message = "Delete Successfuly"
            };
        }
        //---------------------------- Category Zone ----------------------------//
        [Route("SelectAllCategory")]
        [HttpGet]
        public object SelectAllCategory()
        {
            var result = db.Categories.ToList();
            return result;
        }
        [Route("GetCategoryById")]
        [HttpGet]
        public object GetCategoryById(int CategoryID)
        {
            var result = db.Categories.Where(x => x.CategoryID == CategoryID).FirstOrDefault();
            return result;
        }

        [Route("AddOrEditCategory")]
        [HttpPost]
        public object AddOrEditCategory(Category1 cate)
        {
            if (cate.CategoryID == 0)
            {
                Category category = new Category
                {
                    Name = cate.Name,
                    Slug = Utilities.ReplaceSpecialChars(cate.Name),
                    Thumbnail = cate.Thumbnail,
                    CreatedAt = DateTime.Now
                };
                db.Categories.Add(category);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Categories.Where(x => x.CategoryID == cate.CategoryID).FirstOrDefault();
                if (obj.CategoryID > 0)
                {
                    obj.Name = cate.Name;
                    obj.Slug = Utilities.ReplaceSpecialChars(cate.Name);
                    obj.Thumbnail = cate.Thumbnail;
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
        [Route("DeleteCategory")]
        [HttpDelete]
        public object DeleteCategory(int CategoryID)
        {
            var obj = db.Categories.Where(x => x.CategoryID == CategoryID).FirstOrDefault();
            db.Categories.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Deleted",
                Message = "Delete Successfuly"
            };
        }
        //---------------------------- Brand Zone ----------------------------//
        [Route("SelectAllBrand")]
        [HttpGet]
        public object SelectAllBrand()
        {
            var result = db.Brands.ToList();
            return result;
        }
        [Route("GetBrandById")]
        [HttpGet]
        public object GetBrandById(int BrandID)
        {
            var result = db.Brands.Where(x => x.BrandID == BrandID).FirstOrDefault();
            return result;
        }

        [Route("AddOrEditBrand")]
        [HttpPost]
        public object AddOrEditBrand(Brand1 brand1)
        {
            if (brand1.BrandID == 0)
            {
                Brand brand = new Brand
                {
                    Name = brand1.Name,
                    Slug = Utilities.ReplaceSpecialChars(brand1.Name),
                    Thumbnail = brand1.Thumbnail,
                    CreatedAt = DateTime.Now
                };
                db.Brands.Add(brand);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Brands.Where(x => x.BrandID == brand1.BrandID).FirstOrDefault();
                if (obj.BrandID > 0)
                {
                    obj.Name = brand1.Name;
                    obj.Slug = Utilities.ReplaceSpecialChars(brand1.Name);
                    obj.Thumbnail = brand1.Thumbnail;
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
        [Route("DeleteBrand")]
        [HttpDelete]
        public object DeleteBrand(int BrandID)
        {
            var obj = db.Brands.Where(x => x.BrandID == BrandID).FirstOrDefault();
            db.Brands.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Deleted",
                Message = "Delete Successfuly"
            };
        }
        
        //---------------------------- Util Zone ----------------------------//
        [Route("SelectAllUtil")]
        [HttpGet]
        public object SelectAllUtil()
        {
            var result = db.Utilities.ToList();
            return result;
        }
        [Route("GetUtilById")]
        [HttpGet]
        public object GetUtilById(int UtilityID)
        {
            var result = db.Utilities.Where(x => x.UtilityID == UtilityID).FirstOrDefault();
            return result;
        }

        [Route("AddOrEditUtil")]
        [HttpPost]
        public object AddOrEditUtil(Util Util)
        {
            if (Util.UtilityID == 0)
            {
                Utility utility = new Utility
                {
                    Name = Util.Name,
                    Slug = Utilities.ReplaceSpecialChars(Util.Name),
                    CreatedAt = DateTime.Now
                };
                db.Utilities.Add(utility);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Utilities.Where(x => x.UtilityID == Util.UtilityID).FirstOrDefault();
                if (obj.UtilityID > 0)
                {
                    obj.Name = Util.Name;
                    obj.Slug = Utilities.ReplaceSpecialChars(Util.Name);
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
        [Route("DeleteUtil")]
        [HttpDelete]
        public object DeleteUtil(int UtilityID)
        {
            var obj = db.Utilities.Where(x => x.UtilityID == UtilityID).FirstOrDefault();
            db.Utilities.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Deleted",
                Message = "Delete Successfuly"
            };
        }
        
    }
}
