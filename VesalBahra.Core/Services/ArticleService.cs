using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VesalBahar.Core.Interfaces;
using VesalBahar.Core.Statics;
using VesalBahar.Core.Utilities.Extensions;
using VesalBahar.Core.ViewModels;
using VesalBahar.Core.ViewModels.Articles;
using VesalBahar.Data;
using VesalBahar.Domine.Entities.Articles;
using VesalBahar.Statics;
using X.PagedList;

namespace VesalBahar.Core.Services
{
    public class ArticleService: IArticleService
    {
        private readonly VesaleBaharContext _context;
        private readonly ILoggerService<ArticleService> _logger;

        public ArticleService(VesaleBaharContext context, ILoggerService<ArticleService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public ArticleDetailVm GetArticleDetail(int articeId)   
        {
            var model = _context.Articles.Include(c => c.Group).Single(c => c.Id == articeId);
            return model.ToDetailViewModel();
        }
        public IPagedList<ArticleDetailVm> GetArticlesByGroupId(int articeId, int page = 1)
        {
            if (page <= 0) page = 1;
            return _context.Articles
                .Where(c => c.Id == articeId)   
                .Select(c => c.ToDetailViewModel())
                .ToPagedList(page, Values.PageSize);
        }

        public async Task<ArticleCreateOrEditVm> FindAsync(int id)
        {
            var model = await _context.Articles
                .SingleOrDefaultAsync(f => f.Id == id);
            return model.ToCreateOrEditViewModel();
        }

        public async Task<bool> AddAsync(ArticleCreateOrEditVm vm)
        {
            try
            {
                string articleImageTitle = null;
                if (vm.ImageFile != null)
                {
                    articleImageTitle = DateTime.Now.ToString("yyyyMMddHHmmss_") + vm.ImageFile.FileName;
                    var thumbSize = new ThumbSize(100, 100);
                    vm.ImageFile.AddImageToServer(articleImageTitle, PathTools.ArticleImageServerPath, thumbSize);
                }
                await _context.Articles.AddAsync(new Article
                {
                    Id = vm.Id,
                    Title = vm.Title,
                    HeadTitle = vm.HeadTitle,
                    Description = vm.Description,
                    CreateDate = DateTime.Now,
                    ImageTitle = articleImageTitle
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }

        public async Task<bool> EditAsync(ArticleCreateOrEditVm vm)
        {
            try
            {
                var article = await _context.Articles.FindAsync(vm.Id);

                if (vm.ImageFile != null)
                {
                    var articleImageTitle = DateTime.Now.ToString("MM-dd-yyyy_") + vm.ImageFile.FileName;
                    var thumbSize = new ThumbSize(100, 100);
                    vm.ImageFile.AddImageToServer(articleImageTitle, PathTools.ArticleImageServerPath, thumbSize, vm.ImageTitle);
                    article.ImageTitle = articleImageTitle;
                }


                article.Title = vm.Title;
                article.Description = vm.Description;
                article.ModifyDate = DateTime.Now;
                _context.Articles.Update(article);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var article = await _context.Articles.FindAsync(id);
                article.ImageTitle.DeleteImage(PathTools.ArticleImageServerPath);
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ArticleIndexVm>> GetAllAsync()
        {
            return await _context.Articles
                .Include(c => c.Group)
                .OrderByDescending(c => c.Id)
                .ToIndexViewModel()
                .ToListAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Articles.AnyAsync(p => p.Id == id);
        }
    }
}
