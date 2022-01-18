using Bz.ClassFinder.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VesalBahar.Core.Interfaces;
using VesalBahar.Core.ViewModels.ArticleGroups;
using VesalBahran.Web.Areas.Admin.Controllers;

namespace VesalBahran.Web.Areas.Admin.Controllers
{
    [BzDescription("گروه مقاله")]
    public class ArticleGroupsController : BaseAdminController
    {
        //private readonly ShopContext _context;
        private readonly IArticleGroupService _articleGroupService;

        public ArticleGroupsController(IArticleGroupService articleGroupService)
        {
            _articleGroupService = articleGroupService;
        }

        [BzDescription("فهرست")]
        // GET: Admin/articleGroups
        public async Task<IActionResult> Index()
        {
            return View(await _articleGroupService.GetAllAsync());
        }

        [BzDescription("جزئیات")]
        // GET: Admin/articleGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleGroup = await _articleGroupService.FindAsync(id.Value);
            if (articleGroup == null)
            {
                return NotFound();
            }

            return View(articleGroup);
        }

        [BzDescription("افزودن")]
        // GET: Admin/articleGroups/Create
        public IActionResult Create()
        {
            return View("CreateOrEdit", new ArticleGroupCreateOrEditVm());
        }

        [BzDescription("افزودن")]
        // POST: Admin/articleGroups/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title")] ArticleGroupCreateOrEditVm articleGroup)
        {
            if (ModelState.IsValid)
            {
                await _articleGroupService.AddAsync(articleGroup);
                return RedirectToAction(nameof(Index));
            }
            return View("CreateOrEdit",articleGroup);
        }

        [BzDescription("ویرایش")]
        // GET: Admin/articleGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleGroup = await _articleGroupService.FindAsync(id.Value);
            if (articleGroup == null)
            {
                return NotFound();
            }
            return View("CreateOrEdit",articleGroup);
        }

        [BzDescription("ویرایش")]
        // POST: Admin/articleGroups/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,CreateDate,Id")] ArticleGroupCreateOrEditVm articleGroup)
        {
            if (id != articleGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _articleGroupService.EditAsync(articleGroup);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _articleGroupService.Exists(articleGroup.Id))
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
            return View("CreateOrEdit",articleGroup);
        }

        [BzDescription("حذف")]
        // GET: Admin/articleGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleGroup = await _articleGroupService.FindAsync(id.Value);
            if (articleGroup == null)
            {
                return NotFound();
            }

            return View(articleGroup);
        }

        [BzDescription("تایید حذف")]
        // POST: Admin/articleGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _articleGroupService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
