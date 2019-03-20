using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAO;

namespace VentaPolizas.Controllers
{
    public class PolizasController : Controller
    {
        private polizasEntities db = new polizasEntities();

        // GET: Polizas
        public ActionResult Index()
        {
            return View(new BLPolizas().Consultar());
        }

        // GET: Polizas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Polizas polizas = new BLPolizas().ConsultarByIdPoliza(Convert.ToInt64(id));
            if (polizas == null)
            {
                return HttpNotFound();
            }
            return View(polizas);
        }

        // GET: Polizas/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombres,Apellidos,TipoDocumento,NumeroDocumento,Email,Celular,Direccion,TipoVehiculo,PlacaVehiculo,FechaCompra")] Polizas polizas)
        {
            if (ModelState.IsValid)
            {
                if (new BLPolizas().InsertarPoliza(polizas))
                {
                    return RedirectToAction("Index");
                }

                //Error al insertar
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(polizas);
        }

        // GET: Polizas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Polizas polizas = new BLPolizas().ConsultarByIdPoliza(Convert.ToInt64(id));
            if (polizas == null)
            {
                return HttpNotFound();
            }
            return View(polizas);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombres,Apellidos,TipoDocumento,NumeroDocumento,Email,Celular,Direccion,TipoVehiculo,PlacaVehiculo,FechaCompra")] Polizas polizas)
        {
            if (ModelState.IsValid)
            {
                if (new BLPolizas().EditarPoliza(polizas))
                {
                    return RedirectToAction("Index");
                }

                //Error al actualizar
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(polizas);
        }

        // GET: Polizas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Polizas polizas = new BLPolizas().ConsultarByIdPoliza(Convert.ToInt64(id));
            if (polizas == null)
            {
                return HttpNotFound();
            }
            return View(polizas);
        }

        // POST: Polizas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Polizas polizas = new BLPolizas().ConsultarByIdPoliza(Convert.ToInt64(id));

            if (new BLPolizas().EliminarPoliza(polizas))
            {

            }

            return RedirectToAction("Index");
        }


    }
}
