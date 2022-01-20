using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VesalBahar.Core.Interfaces;

namespace Shop.WebUI.Controllers
{
    public class ArticleGroupsController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IArticleGroupService _articleGroupService;
        public ArticleGroupsController(IArticleService articleService, IArticleGroupService articleGroupService)
        {
            _articleService = articleService;
            _articleGroupService = articleGroupService;
        }

        [Route("cat/{id}/{title}")]
        public async Task<IActionResult> Index(int id, string title, int page)
        {
            return View(Tuple.Create(
                await _articleGroupService.FindAsync(id),
                _articleService.GetArticlesByGroupId(id, page)
                ));
        }
        public IActionResult LoadArticleDetail(int id)
        {
            return PartialView("_LoadArticleDetail", _articleService.GetArticleDetail(id));
        }
    }
}
