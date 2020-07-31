using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiendaTecno.Web.Data;
using TiendaTecno.Web.Data.Entities;
using TiendaTecno.Web.Models;

namespace TiendaTecno.Web.Controllers
{
    public class ProductosController : Controller
    {
        private readonly DataContext _context;

        public ProductosController(DataContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index(string currentFilter, string search,int? pageNumber)
                                            
        {

            ViewData["CurrentFilter"] = search;
            if (search != null)
            {
                pageNumber = 1;
            }
            else
            {
                search = currentFilter;
            }

            var productos = from s in _context.Productos
                           select s;


            if (!String.IsNullOrEmpty(search))
            {
                productos = productos.Where(s => s.NombreProducto.Contains(search)
                                       || s.Marca.Nombre.Contains(search)
                                       || s.Descripcion.Contains(search));
            }


            int pageSize = 9;
            return View(await PaginatedList<Producto>.CreateAsync(productos, pageNumber ?? 1, pageSize));
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Marca)
                .FirstOrDefaultAsync(m => m.ProductoID == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaID"] = new SelectList(_context.Categorias, "CategoriaID", "NombreCategoria");
            ViewData["MarcaID"] = new SelectList(_context.Marcas, "MarcaID", "Nombre");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductoViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (view.FileImage != null && view.FileImage.Length > 0)
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Productos", view.FileImage.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.FileImage.CopyToAsync(stream);
                    }

                    path = $"~/images/Productos/{view.FileImage.FileName}";
                }

                var producto = this.ToProducto(view, path);

                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaID"] = new SelectList(_context.Categorias, "CategoriaID", "NombreCategoria", view.CategoriaID);
            ViewData["MarcaID"] = new SelectList(_context.Marcas, "MarcaID", "Nombre", view.MarcaID);
            return View(view);
        }

        private Producto ToProducto(ProductoViewModel view, string path)
        {
            return new Producto
            {
                ProductoID = view.ProductoID,
                UrlImage = path,
                NombreProducto = view.NombreProducto,
                MarcaID = view.MarcaID,
                Marca = view.Marca,
                CategoriaID = view.CategoriaID,
                Categoria = view.Categoria,
                Descripcion = view.Descripcion,
                Precio = view.Precio,
                Disponible = view.Disponible
            };
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            var view = this.ToProductoViewModel(producto)
;
            ViewData["CategoriaID"] = new SelectList(_context.Categorias, "CategoriaID", "NombreCategoria", view.CategoriaID);
            ViewData["MarcaID"] = new SelectList(_context.Marcas, "MarcaID", "Nombre", view.MarcaID);
            return View(view);
        }

        private ProductoViewModel ToProductoViewModel(Producto producto)
        {
            return new ProductoViewModel
            {
                ProductoID = producto.ProductoID,
                UrlImage = producto.UrlImage,
                NombreProducto = producto.NombreProducto,
                MarcaID = producto.MarcaID,
                Marca = producto.Marca,
                CategoriaID = producto.CategoriaID,
                Categoria = producto.Categoria,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Disponible = producto.Disponible


            };
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductoViewModel view)
        {
            if (id != view.ProductoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var path = view.UrlImage;

                    if (view.FileImage != null && view.FileImage.Length > 0)
                    {
                        path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Productos", view.FileImage.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.FileImage.CopyToAsync(stream);
                        }

                        path = $"~/images/Productos/{view.FileImage.FileName}";

                        _context.Update(view);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(view.ProductoID))
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
            
            ViewData["CategoriaID"] = new SelectList(_context.Categorias, "CategoriaID", "NombreCategoria", view.CategoriaID);
            ViewData["MarcaID"] = new SelectList(_context.Marcas, "MarcaID", "Nombre", view.MarcaID);
            return View(view);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Marca)
                .FirstOrDefaultAsync(m => m.ProductoID == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.ProductoID == id);
        }
    }
}
