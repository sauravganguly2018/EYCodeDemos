using System.Data;
using KnowledgeHubPortal.Models.DataAccess;
using KnowledgeHubPortal.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace KnowledgeHubPortal.Controllers
{
    public class CategoriesController : Controller
    {
        CategoryRepository repo=new CategoryRepository();

        //.../Categories/Index
        public IActionResult Index(string term)
        {
            List<Category> categories = null;
            if(term.IsNullOrEmpty())
            {
                categories = repo.GetAll();
            }
            else
            {
                categories = repo.GetByName(term);
            }
            
            return View(categories);

            // return list of categories
        }
        //../Categories/Create
        [HttpGet]
        public IActionResult Create()
        {
            // return a view for collecting category info
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category c)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            // save
            // Category c= new Category{CategoryName="categoryname" CategoryDescription="categorydescription"}

            repo.Create(c);
            string msg = $"Category {c.CategoryName} successfully created.";
            TempData["Message"] = msg;
            // ViewData["Message"] = msg;
            // ViewBag.Message = msg;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // return a view for editing category info
            // get the category by id
            var categoryToEdit = repo.GetById(id);
            return View(categoryToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            // validation - client side - server side
            if (!ModelState.IsValid)
            {
                // return view to collect valid data
                return View();
            }
            // save
            // Category c= new Category{CategoryName="categoryname" CategoryDescription="categorydescription"}

            repo.Update(category);
            string msg = $"Category {category.CategoryName} successfully updated.";
            TempData["Message"] = msg;
            return RedirectToAction("Index");
        }
    }
}
