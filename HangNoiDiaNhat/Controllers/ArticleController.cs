using HangNoiDiaNhat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HangNoiDiaNhat.Controllers
{
    [RoutePrefix("API/Article")]
    public class ArticleController : ApiController
    {
        HangNoiDiaNhatEntities db = new HangNoiDiaNhatEntities();
        //---------------------------- Field Zone ----------------------------//
        [Route("SelectAllField")]
        [HttpGet]
        public object SelectAllField()
        {
            var result = db.Fields.ToList();
            return result;
        }
        [Route("GetFieldById")]
        [HttpGet]
        public object GetFieldById(int FieldID)
        {
            var result = db.Fields.Where(x => x.FieldID == FieldID).FirstOrDefault();
            return result;
        }

        [Route("AddOrEditField")]
        [HttpPost]
        public object AddOrEditField(Field1 Field1)
        {
            if (Field1.FieldID == 0)
            {
                Field field = new Field
                {
                    Name = Field1.Name,
                    Slug = Utilities.ReplaceSpecialChars(Field1.Name),
                    Thumbnail = Field1.Thumbnail,
                    CreatedAt = DateTime.Now
                };
                db.Fields.Add(field);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Fields.Where(x => x.FieldID == Field1.FieldID).FirstOrDefault();
                if (obj.FieldID > 0)
                {
                    obj.Name = Field1.Name;
                    obj.Slug = Utilities.ReplaceSpecialChars(Field1.Name);
                    obj.Thumbnail = Field1.Thumbnail;
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
        [Route("DeleteField")]
        [HttpDelete]
        public object DeleteField(int FieldID)
        {
            var obj = db.Fields.Where(x => x.FieldID == FieldID).FirstOrDefault();
            db.Fields.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Deleted",
                Message = "Delete Successfuly"
            };
        }
        //---------------------------- Field Zone ----------------------------//
        [Route("SelectAllPost")]
        [HttpGet]
        public object SelectAllPost()
        {
            var result = (from Posts in db.Posts
                          select new
                          {
                              Posts.PostID,
                              Posts.Title,
                              Posts.Slug,
                              Posts.Details,
                              Posts.Thumbnail,
                              Posts.CreatedAt,
                              Posts.UpdatedAt,
                              LinhVuc = db.Fields.Where(x => x.FieldID == Posts.FieldID).FirstOrDefault(),
                              TrangThai = db.States.Where(x => x.StateID == Posts.StateID).FirstOrDefault(),
                          }).ToList();
            return result;
        }
        [Route("GetPostBySlug")]
        [HttpGet]
        public object GetPostBySlug(string Slug)
        {
            var getPostBySlug = db.Posts.Where(x => x.Slug == Slug).ToList();
            var result = (from Posts in getPostBySlug
                          select new
                          {
                              Posts.PostID,
                              Posts.Title,
                              Posts.Slug,
                              Posts.Details,
                              Posts.Thumbnail,
                              Posts.CreatedAt,
                              Posts.UpdatedAt,
                              LinhVuc = db.Fields.Where(x => x.FieldID == Posts.FieldID).FirstOrDefault(),
                              TrangThai = db.States.Where(x => x.StateID == Posts.StateID).FirstOrDefault(),
                          }).ToList();
            return result;
        }

        [Route("AddOrEditPost")]
        [HttpPost]
        public object AddOrEditPost(Post1 Post1)
        {
            if (Post1.PostID == 0)
            {
                Post post = new Post
                {
                    FieldID = Post1.FieldID,
                    StateID = Post1.StateID,
                    Title = Post1.Title,
                    Details = Post1.Details,
                    Thumbnail = Post1.Thumbnail,
                    Slug = Utilities.ReplaceSpecialChars(Post1.Title),
                    CreatedAt = DateTime.Now
                };
                db.Posts.Add(post);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Posts.Where(x => x.PostID == Post1.PostID).FirstOrDefault();
                if (obj.FieldID > 0)
                {
                    obj.FieldID = Post1.FieldID;
                    obj.StateID = Post1.StateID;
                    obj.Title = Post1.Title;
                    obj.Details = Post1.Details;
                    obj.Thumbnail = Post1.Thumbnail;
                    obj.Slug = Utilities.ReplaceSpecialChars(Post1.Title);
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
        [Route("DeletePost")]
        [HttpDelete]
        public object DeletePost(int PostID)
        {
            var obj = db.Posts.Where(x => x.PostID == PostID).FirstOrDefault();
            db.Posts.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Deleted",
                Message = "Delete Successfuly"
            };
        }
    }
}
