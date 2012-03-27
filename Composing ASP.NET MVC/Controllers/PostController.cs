using System;
using System.Linq;
using System.Web.Mvc;
using Blog.BusinessLogic;
using Composing_ASP.NET_MVC.Models;
using PostEntity=Blog.BusinessLogic.Models.Post;

namespace Composing_ASP.NET_MVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            if (postService == null)
            {
                throw new ArgumentNullException("postService");
            }

            this.postService = postService;
        }

        //
        // GET: /Post/

        public ActionResult Index()
        {
            // This can be achieved more simply and consistently across an application using AutoMapper
            var posts = postService.GetPosts().Select(p => new Post
            {
                Id = p.Id,
                Title = p.Title,
                Summary = p.Summary,
                Body = p.Body,
                PublicationDate = p.PublicationDate
            });

            return View(posts);
        }

        //
        // GET: /Post/Details/5

        public ActionResult Details(int id)
        {
            var postEntity = postService.GetPostById(id);

            // This can be achieved more simply and consistently across an application using AutoMapper
            return View(new Post
            {
                Id = postEntity.Id,
                Title = postEntity.Title,
                Summary = postEntity.Summary,
                Body = postEntity.Body,
                PublicationDate = postEntity.PublicationDate
            });
        }

        //
        // GET: /Post/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Post/Create

        [HttpPost]
        public ActionResult Create(Post postViewModel)
        {
            try
            {
                // This can be achieved more simply and consistently across an application using AutoMapper
                var post = new PostEntity
                               {
                                   Title = postViewModel.Title,
                                   Summary = postViewModel.Summary,
                                   Body = postViewModel.Body,
                                   PublicationDate = postViewModel.PublicationDate
                               };
                postService.PublishPost(post);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Post/Edit/5
 
        public ActionResult Edit(int id)
        {
            var postEntity = postService.GetPostById(id);
            return View(new Post
            {
                Id = postEntity.Id,
                Title = postEntity.Title,
                Summary = postEntity.Summary,
                Body = postEntity.Body,
                PublicationDate = postEntity.PublicationDate
            });
        }

        //
        // POST: /Post/Edit/5

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            try
            {
                var postEntity = postService.GetPostById(post.Id);

                // This can be achieved more simply and consistently across an application using AutoMapper
                postEntity.Title = post.Title;
                postEntity.Summary = post.Summary;
                postEntity.Body = post.Body;
                post.PublicationDate = post.PublicationDate;

                postService.PublishPost(postEntity);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Post/Delete/5

        [HttpPost]
        public ActionResult Delete(int id)
        {
            postService.DeletePost(id);
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RatePost(int id, int rating)
        {
            postService.RatePost(id, rating);

            // Return the new Rating using JSON
            var post = postService.GetPostById(id);
            return Json(post.Rating);
        }
    }
}
