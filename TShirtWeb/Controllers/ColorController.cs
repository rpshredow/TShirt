using Microsoft.AspNetCore.Mvc;
using TShirt.Models;
using TShirtWeb.DataAccess;

namespace TShirtWeb.Controllers
{
    public class ColorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ColorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Color> objColorList = _db.Colors;
            return View(objColorList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Color obj)
        {
            if (ModelState.IsValid)
            {
                _db.Colors.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Color Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            { 
                return NotFound();
            }
            //var colorFromDb = _db.Colors.Find(id);
            var colorFromDbFirst = _db.Colors.FirstOrDefault(x => x.Id == id);
            //var colorFromDbSingle = _db.Colors.SingleOrDefault(x => x.Id == id);

            if (colorFromDbFirst == null)
            {
                return NotFound();
            }

            return View(colorFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Color obj)
        {
            if (ModelState.IsValid)
            {
                _db.Colors.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Color Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var colorFromDb = _db.Colors.Find(id);
            var colorFromDbFirst = _db.Colors.FirstOrDefault(x => x.Id == id);
            //var colorFromDbSingle = _db.Colors.SingleOrDefault(x => x.Id == id);

            if (colorFromDbFirst == null)
            {
                return NotFound();
            }

            return View(colorFromDbFirst);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Colors.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Colors.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Color Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
