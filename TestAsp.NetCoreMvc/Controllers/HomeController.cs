using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAsp.NetCoreMvc.Models;

namespace TestAsp.NetCoreMvc.Controllers {
    public class HomeController : Controller {
        public IActionResult About() {
            return View();
        }

        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //для работы с БД
        private MobileContext db;
        public HomeController(MobileContext context) {
            db = context;
        }
        public async Task<IActionResult> Index() {
            return View(await db.Phones.ToListAsync());
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Phone phone) {
            db.Phones.Add(phone);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //выводим товары
        //в этом методе получаем id объекта, который нужно выводить
        public async Task<IActionResult> Details(int? id) {
            if (id != null) {
                Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.Id == id);
                if (phone != null) {
                    return View(phone);
                }
            }
            return NotFound();
        }
        //редактируем товары
        public async Task<IActionResult> Edit(int? id) {
            if (id != null) {
                Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.Id == id);
                return View(phone);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Phone phone) {
            db.Phones.Update(phone);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //удаляем выбранный товар
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id) { 
            if (id != null) {
                Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.Id == id);
                return View(phone);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id) {
            Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.Id == id);
            if (id != null) {
                db.Phones.Remove(phone);
                await db.SaveChangesAsync();
                return View("Index");
            }
            return NotFound();
        }
        //public async Task<IActionResult> Delete(int? id) {
        //    //Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.Id == id);
        //    if (id != null) {
        //        //db.Phones.Remove(phone);
        //        //await db.SaveChangesAsync();
        //        //return View("Index");
        //        Phone phone = new Phone { Id = id.Value };
        //        db.Entry(phone).State = EntityState.Deleted;
        //        await db.SaveChangesAsync();
        //        return View("Index");
        //    }
        //    return NotFound();
        //}
    }
}
