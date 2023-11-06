using Microsoft.AspNetCore.Mvc;
using KnowledgeHubPortal.Models.DataAccess;
using KnowledgeHubPortal.Models.Domain;

namespace KnowledgeHubPortal.Controllers
{
    
    public class ArticlesController : Controller
    {
        CategoryRepository cRepo = new CategoryRepository();
        KHPDbContext db = new KHPDbContext();

        public IActionResult Index() // list-display the data
        {

            return View(db.Articles.ToList());
        }

        [HttpGet]
        public IActionResult Submit()
        {
            // return view with category list
            var categories = cRepo.GetAll();
            ViewBag.Categories=categories;
            return View();
        }

        [HttpPost]
        public IActionResult Submit(Article article)
        {
            // server side validation

            article.DateSubmitted= DateTime.Now;
            // article.Author = User.Identity.Name;
            article.Author = "Unknown";

            //if (!ModelState.IsValid)
            //{
            //    var categories = cRepo.GetAll();
            //    ViewBag.Categories = categories;
            //    return View();
            //}
            db.Articles.Add(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
