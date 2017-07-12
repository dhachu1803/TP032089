using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaerskContainerWebApp.Models;

namespace MaerskContainerWebApp.Controllers
{
    public class ShipmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Shipments
        public ActionResult Index()
        {
            var shipment = db.Shipment.Include(s => s.Cargo).Include(s => s.Customer);
            return View(shipment.ToList());
        }

        // GET: Shipments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipment.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // GET: Shipments/Create
        public ActionResult Create()
        {
            ViewBag.CargoId = new SelectList(db.Cargo, "Id", "Id");
            ViewBag.CustomerId = new SelectList(db.Customer, "id", "CustomerName");
            ViewBag.status = GetAllStatus();
            ViewBag.Source = new SelectList(db.Warehouse, "Name", "Name");
            ViewBag.Destination = new SelectList(db.Warehouse, "Name", "Name");
            return View();
        }

        // POST: Shipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,CustomerId,CargoId,Source,Destination,ShippingDate,ArrivalDate,status")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                db.Shipment.Add(shipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CargoId = new SelectList(db.Cargo, "Id", "Id", shipment.CargoId);
            ViewBag.CustomerId = new SelectList(db.Customer, "id", "CustomerName", shipment.CustomerId);
            ViewBag.status = GetAllStatus();
            ViewBag.Source = new SelectList(db.Warehouse, "Name", "Name");
            ViewBag.Destination = new SelectList(db.Warehouse, "Name", "Name");

            return View(shipment);
        }

        // GET: Shipments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipment.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CargoId = new SelectList(db.Cargo, "Id", "Id", shipment.CargoId);
            ViewBag.CustomerId = new SelectList(db.Customer, "id", "CustomerName", shipment.CustomerId);
            ViewBag.status = GetAllStatus();
            ViewBag.Source = new SelectList(db.Warehouse, "Name", "Name");
            ViewBag.Destination = new SelectList(db.Warehouse, "Name", "Name");

            return View(shipment);
        }

        private List<SelectListItem> GetAllStatus()
        {
            List<SelectListItem> StatusList = new List<SelectListItem>();

            StatusList.Add(new SelectListItem { Text = "Pending", Value = "Pending" });
            StatusList.Add(new SelectListItem { Text = "Delivery", Value = "Delivery" });
            StatusList.Add(new SelectListItem { Text = "Cancelled", Value = "Cancelled" });
            StatusList.Add(new SelectListItem { Text = "Completed", Value = "Completed" });

            return StatusList;
        }

        // POST: Shipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CustomerId,CargoId,Source,Destination,ShippingDate,ArrivalDate,status")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CargoId = new SelectList(db.Cargo, "Id", "Id", shipment.CargoId);
            ViewBag.CustomerId = new SelectList(db.Customer, "id", "CustomerName", shipment.CustomerId);
            ViewBag.status = GetAllStatus();
            ViewBag.Source = new SelectList(db.Warehouse, "Name", "Name");
            ViewBag.Destination = new SelectList(db.Warehouse, "Name", "Name");

            return View(shipment);
        }

        // GET: Shipments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipment.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // POST: Shipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shipment shipment = db.Shipment.Find(id);
            db.Shipment.Remove(shipment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
