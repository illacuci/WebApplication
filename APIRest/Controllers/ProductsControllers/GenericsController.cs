using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OredersAPI.Presentation.Controllers.ProductsControllers
{
    public class GenericsController : Controller
    {
        // GET: GenericsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GenericsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GenericsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenericsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenericsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GenericsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenericsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GenericsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
