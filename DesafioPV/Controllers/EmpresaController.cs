using DesafioPV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NHibernate;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DesafioPV.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly ISession _session;

        public EmpresaController(ISession session)
        {
            _session = session;
        }

        public IActionResult Index()
        {
            var Empresas = _session.Query<Empresa>().ToList();
            return View(Empresas);
        }

        public ActionResult Create()
        {

            ViewBag.ListaUf = GetListaUF();

            return View();
        }

        public List<string> GetListaUF()
        {
            var ListaUf = new List<string>
            {
                "AC",
                "AL",
                "AM",
                "AP",
                "BA",
                "CE",
                "DF",
                "ES",
                "GO",
                "MA",
                "MG",
                "MS",
                "MT",
                "PA",
                "PB",
                "PE",
                "PI",
                "PR",
                "RJ",
                "RN",
                "RO",
                "RR",
                "RS",
                "SC",
                "SE",
                "SP",
                "TO"
            };

            return ListaUf;
        }



        [HttpPost]
        public ActionResult Create(Empresa empresa)
        {
            try
            {

                if (TryValidateModel(empresa)) { 

                    _session.Save(empresa);

                    return RedirectToAction(nameof(Index));
                }
                
                ViewBag.ListaUf = GetListaUF();
                return View();

                
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(_session.Get<Empresa>(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Empresa empresaAlterada)
        {
            try
            {
                var empresa = _session.Get<Empresa>(id);

                empresa.Cnpj = empresaAlterada.Cnpj;
                empresa.NomeFantasia = empresaAlterada.NomeFantasia;
                empresa.UF = empresaAlterada.UF;

                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(empresa);
                    transaction.Commit();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var empresa = _session.Get<Empresa>(id);
            return View(empresa);
        }

        [HttpPost]
        public ActionResult Delete(int id, Empresa empresa)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(empresa);
                    transaction.Commit();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var empresa = _session.Get<Empresa>(id);
            return View(empresa);

        }

    }
}
