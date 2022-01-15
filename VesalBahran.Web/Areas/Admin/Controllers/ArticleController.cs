using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VesalBahran.Web.Areas.Admin.Controllers
{
    [Route("Article")]
    public class ArticleController : BaseAdminController
    {
        private readonly IProductService _productService;
        private readonly IProductGroupService _productGroupService;
        public ProductsController(IProductService productService, IProductGroupService productGroupService)
        {
            _productService = productService;
            _productGroupService = productGroupService;
        }

        [Route("ShowArticle")]
        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAllAsync());
        }
        [BzDescription("")]
        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.FindAsync(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [BzDescription("")]
        // GET: Admin/Products/Create
        public async Task<IActionResult> Create()
        {
            await LoadDropDownList();
            return View("CreateOrEdit", new ProductCreateOrEditVm());
        }
        [BzDescription("")]
        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateOrEditVm product)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _productService.AddAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _productService.Exists(product.Id))
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
            await LoadDropDownList(product);
            return View("CreateOrEdit", product);
        }

        private async Task LoadDropDownList(ProductCreateOrEditVm product = null)
        {
            if (product == null)
                ViewBag.Groups = new SelectList(await _productGroupService.GetAllAsync(), "Id", "Title");
            else
                ViewBag.Groups = new SelectList(await _productGroupService.GetAllAsync(), "Id", "Title", product.GroupId);
        }

        [BzDescription("")]
        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.FindAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            await LoadDropDownList(product);
            return View("CreateOrEdit", product);
        }
        [BzDescription("")]
        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductCreateOrEditVm product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productService.EditAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _productService.Exists(product.Id))
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
            await LoadDropDownList(product);
            return View("CreateOrEdit", product);
        }
        [BzDescription("")]
        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.FindAsync(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [BzDescription("")]
        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
