using Estagram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estagram.Controllers
{
    public class PostController : Controller
    {
        public DbModel db = new DbModel();

        public ActionResult Newsfeed()
        {
            return View();
        }

        public ActionResult Content()
        {
            return View();
        }

        public ActionResult CreateNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostAdd(string name, string opinion)
        {
            Post pt = new Post();
            pt.picture = name;
            pt.description = opinion;

            db.Posts.Add(pt);
            if(db.SaveChanges() > 0)
            {
                return Content("PostAdd 1");
            } else
            {
                return Content("PostAdd 0");
            }
        }

        [HttpPost]
        public ActionResult CommentAdd(int post_id, string username, string comment)
        {
            Comment cm = new Comment();
            cm.post_id = post_id;
            cm.username = username;
            cm.comment1 = comment;

            db.Comments.Add(cm);
            if(db.SaveChanges() > 0)
            {
                return Content("1");
            } else
            {
                return Content("0");
            }
        }

        [HttpPost]
        public ActionResult LikeUpdate(int post_id, int count_like)
        {
            // Look this method later
            List<Like> lk = db.Likes.SqlQuery("SELECT * FROM LIKES WHERE post_id=" + post_id).ToList();

            if (lk.Count > 0)
            {
                lk[0].likes = count_like;
                if (db.SaveChanges() > 0)
                {
                    return Content("1 update");
                }
                else
                {
                    return Content("0 update");
                }
            }
            else
            {
                Like lik = new Like();
                lik.post_id = post_id;
                lik.likes = 1;
                db.Likes.Add(lik);
                if (db.SaveChanges() > 0)
                {
                    return Content("1 post");
                }
                else
                {
                    return Content("0 post");
                }
            }
        }

        [HttpPost]
        public ActionResult CommentDelete (int comment_id)
        {
            Comment comment = db.Comments.Find(comment_id);
            db.Comments.Remove(comment);
            if (db.SaveChanges() > 0)
            {
                return Content("1");
            } else
            {
                return Content("0");
            }
        }

        [HttpPost]
        public ActionResult PostDelete(int postID, int likeID)
        {
            Post post = db.Posts.Find(postID);
            Like like = db.Likes.Find(likeID);
            List<Comment> comment = db.Comments.SqlQuery("SELECT * FROM Comments WHERE post_id=" + postID).ToList();

            for (var i = 0; i < comment.Count; i++)
            {
                db.Comments.Remove(comment[i]);

            }
            db.Likes.Remove(like);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToRoute("~/Post/Newsfeed");
        }
    }
}
