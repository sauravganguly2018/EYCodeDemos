using System.Data;
using MahaKumbh.Models.DataAccess;
using MahaKumbh.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MahaKumbh.Controllers
{
    public class QuestionsController : Controller
    {
        MahaKumbhDbContext db = new MahaKumbhDbContext();

        //.../Questions/Index
        public IActionResult Index(string term)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            TempData["UserName"] = UserName;
            List<Question> questions = null;
            if (term.IsNullOrEmpty())
            {
                questions = db.Questions.ToList();
            }
            else
            {
                var ques = from que in db.Questions
                           where que.Title.Contains(term)
                           select que;
                questions = ques.ToList();
            }

            return View(questions);
        }
        //../questions/Create
        [HttpGet]
        public IActionResult Create()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            TempData["UserName"] = UserName;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Question que)
        {
            que.Author = HttpContext.Session.GetString("UserName");
            que.DateSubmitted = DateTime.Now;
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            db.Questions.Add(que);
            db.SaveChanges();
            string msg = $"Question {que.Title} successfully created.";
            TempData["Message"] = msg;
            TempData["Alert"] = "Success";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            TempData["UserName"] = UserName;
            var QuestionToEdit = db.Questions.Find(id);
            return View(QuestionToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Question question)
        {
            question.Author = HttpContext.Session.GetString("UserName");
            question.DateSubmitted = DateTime.Now;
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            db.Entry(question).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            string msg = $"Question {question.Title} successfully updated.";
            TempData["Message"] = msg;
            TempData["Alert"] = "Success";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var quesToRemove=db.Questions.Find(id);
            db.Questions.Remove(quesToRemove);
            db.SaveChanges();
            string msg = $"Question {quesToRemove.Title} successfully deleted.";
            TempData["Message"] = msg;
            TempData["Alert"] = "Danger";
            return RedirectToAction("Index");
        }
    }
}
