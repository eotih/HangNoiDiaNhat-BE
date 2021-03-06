using HangNoiDiaNhat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HangNoiDiaNhat.Controllers
{
    [RoutePrefix("API/Organization")]
    public class OrganizationController : ApiController
    {
        HangNoiDiaNhatEntities db = new HangNoiDiaNhatEntities();
        //---------------------------- Customer Zone ----------------------------//
        [Route("SelectAllOrganization")]
        [HttpGet]
        public object SelectAllOrganization()
        {
            var result = db.Organizations.ToList();
            return result;
        }
        [Route("GetOrganizationById")]
        [HttpGet]
        public object GetOrganizationById(int OrganizationID)
        {
            var result = db.Organizations.Where(x => x.OrganizationID == OrganizationID).FirstOrDefault();
            return result;
        }

        [Route("AddOrEditOrganization")]
        [HttpPost]
        public object AddOrEditOrganization(Organization1 Organization1)
        {
            if (Organization1.OrganizationID == 0)
            {
                Organization organization = new Organization
                {
                    FullName = Organization1.FullName,
                    Phone = Organization1.Phone,
                    Email = Organization1.Email,
                    Address = Organization1.Address,
                    CreatedAt = DateTime.Now
                };
                db.Organizations.Add(organization);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Organizations.Where(x => x.OrganizationID == Organization1.OrganizationID).FirstOrDefault();
                if (obj.OrganizationID > 0)
                {
                    obj.FullName = Organization1.FullName;
                    obj.Phone = Organization1.Phone;
                    obj.Email = Organization1.Email;
                    obj.Address = Organization1.Address;
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
        [Route("DeleteOrganization")]
        [HttpDelete]
        public object DeleteOrganization(int OrganizationID)
        {
            var obj = db.Organizations.Where(x => x.OrganizationID == OrganizationID).FirstOrDefault();
            db.Organizations.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Deleted",
                Message = "Delete Successfuly"
            };
        }
        //---------------------------- Banner Zone ----------------------------//
        [Route("SelectAllBanner")]
        [HttpGet]
        public object SelectAllBanner()
        {
            var result = db.Banners.ToList();
            return result;
        }
        [Route("GetBannerById")]
        [HttpGet]
        public object GetBannerById(int BannerID)
        {
            var result = db.Banners.Where(x => x.BannerID == BannerID).FirstOrDefault();
            return result;
        }

        [Route("AddOrEditBanner")]
        [HttpPost]
        public object AddOrEditBanner(Banner1 Banner1)
        {
            if (Banner1.BannerID == 0)
            {
                Banner banner = new Banner
                {
                    Name = Banner1.Name,
                    Image = Banner1.Image,
                    CreatedAt = DateTime.Now
                };
                db.Banners.Add(banner);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Banners.Where(x => x.BannerID == Banner1.BannerID).FirstOrDefault();
                if (obj.BannerID > 0)
                {
                    obj.Name = Banner1.Name;
                    obj.Image = Banner1.Image;
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
        [Route("DeleteBanner")]
        [HttpDelete]
        public object DeleteBanner(int BannerID)
        {
            var obj = db.Banners.Where(x => x.BannerID == BannerID).FirstOrDefault();
            db.Banners.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Deleted",
                Message = "Delete Successfuly"
            };
        }

        //---------------------------- Banner Zone ----------------------------//
        [Route("Login")]
        [HttpPost]
        public Response Login(Login lg)
        {
            if (ModelState.IsValid)
            {
                var f_password = Utilities.GetMD5(lg.Password);
                var user = db.Accounts.Where(s => s.Email.Equals(lg.Email) && s.Password.Equals(f_password)).FirstOrDefault();
                if (user != null)
                {
                    return new Response() { Status = "Success", Message = Utilities.GenerateToken(user.AccountID, Convert.ToInt32(user.RoleID)) };
                }
            }
            else
            {
                return new Response { Status = "Fail", Message = "Login Fail" };
            }
            return new Response { Status = "Sai", Message = "Sai" };
        }
        [Route("SelectAllAccount")]
        [HttpGet]
        public object SelectAllAccount()
        {
            var result = db.Accounts.ToList();
            return result;
        }
        [Route("GetAccountById")]
        [HttpGet]
        public object GetAccountById(int AccountID)
        {
            var result = db.Accounts.Where(x => x.AccountID == AccountID).FirstOrDefault();
           
            return result;
        }

        [Route("AddOrEditAccount")]
        [HttpPost]
        public object AddOrEditAccount(Account1 Account1)
        {
            if (Account1.AccountID == 0)
            {
                Account acc = new Account
                {
                    RoleID = Account1.RoleID,
                    FullName = Account1.FullName,
                    Phone = Account1.Phone,
                    Email = Account1.Email,
                    Image = Account1.Image,
                    Password = Utilities.GetMD5(Account1.Password),
                    Address = Account1.Address,
                    CreatedAt = DateTime.Now
                };
                db.Accounts.Add(acc);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Accounts.Where(x => x.AccountID == Account1.AccountID).FirstOrDefault();
                if (obj.AccountID > 0)
                {
                    obj.RoleID = Account1.RoleID;
                    obj.FullName = Account1.FullName;
                    obj.Phone = Account1.Phone;
                    obj.Email = Account1.Email;
                    obj.Image = Account1.Image;
                    //obj.Password = Utilities.GetMD5(Account1.Password);
                    obj.Address = Account1.Address;
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
        [Route("ChangePassword")]
        [HttpPost]
        public object ChangePassword(Account1 Account1)
        {
            var obj = db.Accounts.Where(x => x.AccountID == Account1.AccountID).FirstOrDefault();
            if (obj.AccountID > 0)
            {
                obj.Password = Utilities.GetMD5(Account1.Password);
                obj.UpdatedAt = DateTime.Now;
                db.SaveChanges();
                return new Response
                {
                    Status = "Updated",
                    Message = "Updated Successfully"
                };

            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };
        }
        [Route("DeleteAccount")]
        [HttpDelete]
        public object DeleteAccount(int AccountID)
        {
            var obj = db.Accounts.Where(x => x.AccountID == AccountID).FirstOrDefault();
            db.Accounts.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Deleted",
                Message = "Delete Successfuly"
            };
        }
    }
}
