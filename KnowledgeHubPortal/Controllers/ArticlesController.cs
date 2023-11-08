using Microsoft.AspNetCore.Mvc;
using KnowledgeHubPortal.Models.DataAccess;
using KnowledgeHubPortal.Models.Domain;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace KnowledgeHubPortal.Controllers
{
    public class ArticlesController : Controller
    {
        CategoryRepository cRepo = new CategoryRepository();
        KHPDbContext db = new KHPDbContext();

        public IActionResult Index(int CategoryID) // list-display the data
        {
            if (CategoryID == 0)
            {
                var approvedArticles = from a in db.Articles.Include(a => a.Category)
                                       where a.IsApproved == true
                                       select a;
                var categories = cRepo.GetAll();
                ViewBag.Categories = categories;
                return View(approvedArticles.ToList());
            }
            else
            {
                var approvedArticles = from a in db.Articles.Include(a => a.Category)
                                       where a.IsApproved == true && a.CategoryID == CategoryID
                                       select a;
                var categories = cRepo.GetAll();
                ViewBag.Categories = categories;
                return View(approvedArticles.ToList());
            }
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
            article.IsApproved = false;

            //if (!ModelState.IsValid)
            //{
            //    var categories = cRepo.GetAll();
            //    ViewBag.Categories = categories;
            //    return View();
            //}
            db.Articles.Add(article);
            db.SaveChanges();
            TempData["Message"] = $"Article {article.Title} is submitted successfully";
            return RedirectToAction("Submit");
        }

        public IActionResult Review()
        {
            // fetch all new unapproved articles and return to view
            var unapprovedArticles = from a in db.Articles.Include(a=>a.Category)
                                     where a.IsApproved == false
                                     select a;
            return View(unapprovedArticles);
        }
        public IActionResult Approve(List<int> articleid)
        {
            var allArticles = db.Articles;
            foreach(var item in allArticles)
            {
                foreach(var id in articleid)
                {
                    if (item.ArticleID == id)
                    {
                        item.IsApproved= true;
                        
                    }
                }
            }

            db.SaveChanges();
            return RedirectToAction("Review");
        }
        public IActionResult Reject(List<int> articleid)
        {
            var allArticles = db.Articles;
            foreach (var item in allArticles)
            {
                foreach (var id in articleid)
                {
                    if (item.ArticleID == id)
                    {
                        db.Articles.Remove(item);

                    }
                }
            }

            db.SaveChanges();
            return RedirectToAction("Review");

        }
    }
}
