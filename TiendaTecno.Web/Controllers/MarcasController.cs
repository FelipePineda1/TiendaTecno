using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiendaTecno.Web.Data;
using TiendaTecno.Web.Models;
using TiendaTecno.Web.Models.ViewModels;

namespace TiendaTecno.Web.Controllers
{
    public class MarcasController : Controller
    {
        private readonly DataContext _context;

        public MarcasController(DataContext context)
        {
            _context = context;
        }

        // GET: Marcas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Marcas.ToListAsync());
        }

        // GET: Marcas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _context.Marcas
                .FirstOrDefaultAsync(m => m.MarcaID == id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

       

        // GET: Marcas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marcas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MarcaViewModel view)
        {
            if (ModelState.IsValid)
            {

                var path = string.Empty;

                if (view.LogoFile != null && view.LogoFile.Length > 0)
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Marcas", view.LogoFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.LogoFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Marcas/{view.LogoFile.FileName}";
                }

                var marca = this.ToMarca(view, path);

                _context.Add(marca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        private Marca ToMarca(MarcaViewModel view, string path)
        {
            return new Marca
            {
                MarcaID = view.MarcaID,
                Nombre = view.Nombre,
                UrlLogo = path
            };
        }

        // GET: Marcas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }
            var view = this.ToMarcaViewModel(marca);
            return View(view);

        }

        private MarcaViewModel ToMarcaViewModel(Marca marca)
        {
            return new MarcaViewModel
            {
                MarcaID = marca.MarcaID,
                Nombre = marca.Nombre,
                UrlLogo = marca.UrlLogo
            };
        }

        // POST: Marcas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MarcaViewModel view)
        {
            if (id != view.MarcaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var path = view.UrlLogo;

                    if (view.LogoFile != null && view.LogoFile.Length > 0)
                    {
                        path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Marcas", view.LogoFile.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.LogoFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Marcas/{view.LogoFile.FileName}";

                        _context.Update(view);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaExists(view.MarcaID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        // GET: Marcas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _context.Marcas
                .FirstOrDefaultAsync(m => m.MarcaID == id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // POST: Marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaExists(int id)
        {
            return _context.Marcas.Any(e => e.MarcaID == id);
        }
    }
}
