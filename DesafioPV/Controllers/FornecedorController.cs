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

        public ActionResult Details(int id)
        {
            
            var fornecedor = _session.Get<Fornecedor>(id);

            return View(fornecedor);
        }

        // GET: Fornecedor/Create
        public ActionResult Create()
        {

            var ListaEmpresa = _session.Query<Empresa>().ToList();
            ViewBag.ListaEmpresa = ListaEmpresa;

            return View();
        }

        // POST: Fornecedor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection form, Fornecedor fornecedor)
        {
            try
            {
                int idEmpresa = int.Parse(form["Empresa"].ToString());
                fornecedor.Empresa = _session.Get<Empresa>(idEmpresa);
                fornecedor.DtHoraCadastro = System.DateTime.Now;
                _session.Save(fornecedor);

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

        public ActionResult Delete(int id)
        {
            var empresa = _session.Get<Fornecedor>(id);
            return View(empresa);
        }

        [HttpPost]
        public ActionResult Delete(int id, Fornecedor fornecedor)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(fornecedor);
                    transaction.Commit();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}