using Bz.ClassFinder.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VesalBahar.Core.Interfaces;
using VesalBahar.Core.ViewModels.Articles;
using VesalBahar.Domine.Entities.Articles;

namespace VesalBahran.Web.Areas.Admin.Controllers
{
    [Route("Article")]
    public class ArticleController : BaseAdminController
    {
        private readonly IArticleService _articleService;
        private readonly IArticleGroupService _articleGroupService;
        public ArticleController(IArticleService articleService, IArticleGroupService articleGroupService)
        {
            _articleService = articleService;
            _articleGroupService = articleGroupService;
        }

        [Route("ShowArticle")]
        // GET: Admin/articles
        public async Task<IActionResult> Index()
        {
            return View(await _articleService.GetAllAsync());
        }

        [BzDescription("جزئیات")]
        // GET: Admin/articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _articleService.FindAsync(id.Value);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        [BzDescription("افزودن")]
        // GET: Admin/articles/Create
        public async Task<IActionResult> Create()
        {
            await LoadDropDownList();
            return View("CreateOrEdit", new ArticleCreateOrEditVm());
        }

        [BzDescription("افزودن")]
        // POST: Admin/articles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticleCreateOrEditVm article)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _articleService.AddAsync(article);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _articleService.Exists(article.Id))
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
            await LoadDropDownList(article);
            return View("CreateOrEdit", article);
        }

        private async Task LoadDropDownList(ArticleCreateOrEditVm article = null)
        {
            if (article == null)
                ViewBag.Groups = new SelectList(await _articleGroupService.GetAllAsync(), "Id", "Title");
            else
                ViewBag.Groups = new SelectList(await _articleGroupService.GetAllAsync(), "Id", "Title", article.GroupId);
        }

        [BzDescription("ویرایش")]
        // GET: Admin/articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _articleService.FindAsync(id.Value);
            if (article == null)
            {
                return NotFound();
            }
            await LoadDropDownList(article);
            return View("CreateOrEdit", article);
        }

        [BzDescription("ویرایش")]
        // POST: Admin/articles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArticleCreateOrEditVm article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _articleService.EditAsync(article);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _articleService.Exists(article.Id))
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
            await LoadDropDownList(article);
            return View("CreateOrEdit", article);
        }

        [BzDescription("حذف")]
        // GET: Admin/articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _articleService.FindAsync(id.Value);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        [BzDescription("حذف")]
        // POST: Admin/articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _articleService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
