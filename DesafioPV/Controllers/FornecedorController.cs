using System.Collections.Generic;
using System.Linq;
using DesafioPV.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpPost]
        public ActionResult Index(string searchString)
        {

            var Fornecedores = _session.Query<Fornecedor>().Where(x => x.Nome.Contains(searchString) || 
                                                                  x.CpfCnpj.Contains(searchString) || 
                                                                  x.DtHoraCadastro.ToString().Contains(searchString)).ToList();

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
            ViewBag.IdEmpresa = 0;
            ViewBag.ListaTelefones = new List<TelefoneFornecedor>();

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

                dynamic listaTel = JsonConvert.DeserializeObject(form["tableTelefoneContent"]);

                if (TryValidateModel(fornecedor))
                {
                    _session.Save(fornecedor);

                    if (listaTel != null)
                    {

                        foreach (var item in listaTel)
                        {
                            _session.Save(new TelefoneFornecedor { Telefone = item.Telefone, Fornecedor = fornecedor });
                        }

                    }



                    return RedirectToAction(nameof(Index));
                }

                ViewBag.IdEmpresa = idEmpresa;
                ViewBag.ListaTelefones = fornecedor.ListaTelefoneFornecedor;
                var ListaEmpresa = _session.Query<Empresa>().ToList();
                ViewBag.ListaEmpresa = ListaEmpresa;

                return View(fornecedor);
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