using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesalBahar.Core.Interfaces;
using VesalBahar.Core.ViewModels.ArticleGroups;
using VesalBahar.Data;
using VesalBahar.Domine.Entities.Articles;

namespace Shop.Core.Services
{
    public class ArticleGroupService : IArticleGroupService
    {
        private readonly VesaleBaharContext _context;

        public ArticleGroupService(VesaleBaharContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(ArticleGroupCreateOrEditVm vm)
        {
            try
            {                
                _context.ArticleGroups.Add(new ArticleGroup 
                {
                 Id = vm.Id,
                 CreateDate = DateTime.Now,
                 Title = vm.Title                    
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var articleGroup = await _context.ArticleGroups.FindAsync(id);
                _context.ArticleGroups.Remove(articleGroup);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> EditAsync(ArticleGroupCreateOrEditVm vm)
        {
            try
            {
                var articleGroup = await _context.ArticleGroups.FindAsync(vm.Id);
                articleGroup.Title = vm.Title;
                articleGroup.ModifyDate = DateTime.Now;
                _context.ArticleGroups.Update(articleGroup);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.ArticleGroups.AnyAsync(e => e.Id == id);
        }

        public async Task<ArticleGroupCreateOrEditVm> FindAsync(int id)
        {
            var model = await _context.ArticleGroups                
                .FirstOrDefaultAsync(m => m.Id == id);
            return model.ToCreateOrEditViewModel();
        }

        public async Task<List<ArticleGroupIndexVm>> GetAllAsync()
        {
            return await _context.ArticleGroups.ToIndexViewModel().ToListAsync();
            //var result=  await _context.ArticleGroups.ToListAsync();
            //var vm= result.ToIndexViewModel().ToList();
            //return vm;
        }
    }
}
