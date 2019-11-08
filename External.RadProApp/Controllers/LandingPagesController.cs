using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.Radio.Context;
using DAL.Radio.Model;

namespace External.RadProApp.Controllers
{
    public class LandingPagesController : Controller
    {
        private RadioDbContext db = new RadioDbContext();

        // GET: LandingPages
        public async Task<ActionResult> Index()
        {
            return View(await db.LandingPages.ToListAsync());
        }

        // GET: LandingPages/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LandingPage landingPage = await db.LandingPages.FindAsync(id);
            if (landingPage == null)
            {
                return HttpNotFound();
            }
            return View(landingPage);
        }

        // GET: LandingPages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LandingPages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LandingPageId,One,Two,Three,Four,Five,Six,Seven,Eight,Nine,Ten,Eleven,Tweleve,Thirteen,Fourteen,Fifteen,Seventeen,Eighteen,Nineteen,Twenty,TwentyOne,TwentyTwo,TwentyThree,TwentyFour,TwentyFive,TwentySIx,TwentySeven,TwentyEight,TwentyNine,Thirty,ThirtyOne,ThirtyTwo,ThirtyThree,ThirtyFour,ThirtyFive,ThirtySix,ThirtySeven,ThirtyEight,ThirtyNine,Fourty,FourtyOne,fourtyTwo,FourtyThree,FourtyFour")] LandingPage landingPage)
        {
            if (ModelState.IsValid)
            {
                db.LandingPages.Add(landingPage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(landingPage);
        }

        // GET: LandingPages/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LandingPage landingPage = await db.LandingPages.FindAsync(id);
            if (landingPage == null)
            {
                return HttpNotFound();
            }
            return View(landingPage);
        }

        // POST: LandingPages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LandingPageId,One,Two,Three,Four,Five,Six,Seven,Eight,Nine,Ten,Eleven,Tweleve,Thirteen,Fourteen,Fifteen,Seventeen,Eighteen,Nineteen,Twenty,TwentyOne,TwentyTwo,TwentyThree,TwentyFour,TwentyFive,TwentySIx,TwentySeven,TwentyEight,TwentyNine,Thirty,ThirtyOne,ThirtyTwo,ThirtyThree,ThirtyFour,ThirtyFive,ThirtySix,ThirtySeven,ThirtyEight,ThirtyNine,Fourty,FourtyOne,fourtyTwo,FourtyThree,FourtyFour")] LandingPage landingPage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(landingPage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(landingPage);
        }

        // GET: LandingPages/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LandingPage landingPage = await db.LandingPages.FindAsync(id);
            if (landingPage == null)
            {
                return HttpNotFound();
            }
            return View(landingPage);
        }

        // POST: LandingPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LandingPage landingPage = await db.LandingPages.FindAsync(id);
            db.LandingPages.Remove(landingPage);
            await db.SaveChangesAsync();
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
