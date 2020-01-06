using System.Linq;
using DesafioPV.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace DesafioPV.Controllers
{
    public class FornecedorController : Controller
        
    {
        private readonly NHibernate.ISession _session;

        public FornecedorController(NHibernate.ISession session)
        {
            _session = session;
        }

        // GET: Fornecedor
        public ActionResult Index()
        {
            var Fornecedores = _session.Query<Fornecedor>().ToList();
            return View(Fornecedores);

        }

        // GET: Fornecedor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Fornecedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Fornecedor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Fornecedor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Fornecedor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Fornecedor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}