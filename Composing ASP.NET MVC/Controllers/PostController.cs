using System;
using System.Web.Mvc;
using Blog.BusinessLogic;

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
            return View();
        }

        //
        // GET: /Post/Details/5

        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
            return View();
        }

        //
        // POST: /Post/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Post/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Post/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
