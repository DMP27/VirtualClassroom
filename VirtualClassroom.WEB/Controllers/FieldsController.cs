using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vereyon.Web;
using VirtualClassroom.Common.Entities;
using VirtualClassroom.WEB.Data;

namespace VirtualClassroom.WEB.Controllers
{

    [Authorize(Roles = "Admin")]
    public class FieldsController : Controller
    {
        private readonly DataContext _context;
        private readonly IFlashMessage _flashMessage;
        public FieldsController(DataContext context, IFlashMessage flashMessage)
        {
            _context = context;
            _flashMessage = flashMessage;
        }

        // GET: Fields
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fields.
                Include(f => f.Districts).
                ToListAsync());
        }

        // GET: Fields/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Field = await _context.Fields
                 .Include(f => f.Districts )
                 .ThenInclude(d => d.Churches)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Field == null)
            {
                return NotFound();
            }

            return View(Field);
        }

        // GET: Fields/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Field Field)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    _context.Add(Field);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }//TODO duplicate validation isn't working
                catch (DbUpdateException dbUpdateException)
                {

                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }

            }
            return View(Field);
        }

        // GET: Fields/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Field = await _context.Fields.FindAsync(id);
            if (Field == null)
            {
                return NotFound();
            }
            return View(Field);
        }

        // POST: Fields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Field Field)
        {
            if (id != Field.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Field);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {

                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }

               // return RedirectToAction(nameof(Index));
            }
            return View(Field);
        }

        // GET: Fields/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Field = await _context.Fields
                

            
                .Include(f => f.Districts)//this is for delete in "cascade", if we delete a field, we provoke a delete in district and church
                .ThenInclude(d => d.Churches)//this is for delete in "cascade", if we delete a field, we provoke a delete in district and church
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Field == null)
            {
                return NotFound();
            }

            //_context.Fields.Remove(Field);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));



            try
            {
                _context.Fields.Remove(Field);
                await _context.SaveChangesAsync();
                _flashMessage.Confirmation("The category was deleted.");
            }
            catch
            {
                _flashMessage.Danger("The category can't be deleted because it has related records.");
            }

            return RedirectToAction(nameof(Index));
            //return View(Field);
        }


        /*
        // POST: Fields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Field = await _context.Fields.FindAsync(id);
            _context.Fields.Remove(Field);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        */





        public async Task<IActionResult> AddDistrict(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Field Field = await _context.Fields.FindAsync(id);
            if (Field == null)
            {
                return NotFound();
            }

            District model = new District { IdField = Field.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDistrict(District district)
        {
            if (ModelState.IsValid)
            {
                Field field = await _context.Fields
                    .Include(f => f.Districts)
                    .FirstOrDefaultAsync(f => f.Id == district.IdField);
                if (field == null)
                {
                    return NotFound();
                }

                try
                {
                    district.Id = 0;
                    field.Districts.Add(district);
                    _context.Update(field);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(Details)}/{field.Id}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(district);
        }




        public async Task<IActionResult> EditDistrict(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            District district = await _context.Districts.FindAsync(id);
            if (district == null)
            {
                return NotFound();
            }

            Field field = await _context.Fields.FirstOrDefaultAsync(f => f.Districts.FirstOrDefault(d => d.Id == district.Id) != null);
            district.IdField = field.Id;
            return View(district);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDistrict(District district)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(district);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(Details)}/{district.IdField}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(district);
        }

        public async Task<IActionResult> DetailsDistrict(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            District district = await _context.Districts
                .Include(d => d.Churches)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (district == null)
            {
                return NotFound();
            }

            Field field = await _context.Fields.FirstOrDefaultAsync(f => f.Districts.FirstOrDefault(d => d.Id == district.Id) != null);
            district.IdField = field.Id;
            return View(district);
        }





        public async Task<IActionResult> DeleteDistrict(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            District district = await _context.Districts
                .Include(d => d.Churches)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (district == null)
            {
                return NotFound();
            }

            Field field = await _context.Fields.FirstOrDefaultAsync(f => f.Districts.FirstOrDefault(d => d.Id == district.Id) != null);
            _context.Districts.Remove(district);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{field.Id}");
        }






        public async Task<IActionResult> AddChurch(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            District district = await _context.Districts.FindAsync(id);
            if (district == null)
            {
                return NotFound();
            }

            Church model = new Church { IdDistrict = district.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddChurch(Church church)
        {
            if (ModelState.IsValid)
            {
                District district = await _context.Districts
                    .Include(d => d.Churches)
                    .FirstOrDefaultAsync(c => c.Id == church.IdDistrict);
                if (district == null)
                {
                    return NotFound();
                }

                try
                {
                    church.Id = 0;
                    district.Churches.Add(church);
                    _context.Update(district);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(DetailsDistrict)}/{district.Id}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(church);
        }




        public async Task<IActionResult> EditChurch(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Church church = await _context.Churches.FindAsync(id);
            if (church == null)
            {
                return NotFound();
            }

            District district = await _context.Districts.FirstOrDefaultAsync(d => d.Churches.FirstOrDefault(c => c.Id == church.Id) != null);
            church.IdDistrict = district.Id;
            return View(church);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditChurch(Church church)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(church);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(DetailsDistrict)}/{church.IdDistrict}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(church);
        }






        public async Task<IActionResult> DeleteChurch(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Church church = await _context.Churches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (church == null)
            {
                return NotFound();
            }

            District district = await _context.Districts.FirstOrDefaultAsync(d => d.Churches.FirstOrDefault(c => c.Id == church.Id) != null);
            _context.Churches.Remove(church);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(DetailsDistrict)}/{district.Id}");
        }





        /*ask how can i do an index inside detailschurch if church isn't VirtualClassroom.web but in VirtualClassroom.common


        public async Task<IActionResult> DetailsChurch(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Church church = await _context.Churches
                .Include(c => c.Users)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (church == null)
            {
                return NotFound();
            }

            Field field = await _context.Fields.FirstOrDefaultAsync(f => f.Districts.FirstOrDefault(d => d.Id == district.Id) != null);
            district.IdField = field.Id;
            return View(district);
        }







        */







        private bool FieldExists(int id)
        {
            return _context.Fields.Any(e => e.Id == id);
        }


    }
}
