using Fanex.Caching;
using Fanex.Data.Repository;
using Fanex.NAP.Core.Configuration;
using Fanex.NAP.Core.Models;
using Fanex.NAP.Core.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legend.API.Controllers
{

    public interface LegendService
    {
        Task<string> GetLegend(string menuName);
    }

    public class LegendServiceImp : LegendService
    {
        private readonly IDynamicRepository dynamicRepository;

        private readonly ISiteService siteService;

        private readonly CacheService cacheService;

        public LegendServiceImp(ISiteService siteService, CacheService cacheService, IDynamicRepository dynamicRepository)
        {
            this.siteService = siteService;
            this.cacheService = cacheService;
            this.dynamicRepository = dynamicRepository;
        }

        public async Task<string> GetLegend(string menuName)
        {
            var menuId = await GetMenuId(menuName);
            if (menuId == 0)
            {
                return string.Empty;
            }

            var criteria = new GetLegendCriteria
            {
                MenuId = menuId
            };

            var legend = await dynamicRepository.GetAsync<LegendDTO>(criteria);
            return legend == null ? string.Empty : legend.Legend;
        }

        private async Task<int> GetMenuId(string menuName)
        {
            var menuItems = await GetMenuItems();
            var menuItem = menuItems.Where(m => m.Name == menuName).FirstOrDefault();
            return menuItem == null ? 0 : menuItem.Id;
        }

        private async Task<List<MenuItem>> GetMenuItems()
        {
            return await cacheService.GetOrSetAsync("MenuItems", () =>
            {
                return siteService.GetMenuItemBySiteId(NapSettings.Settings.SiteId, NapSettings.Settings.Environment).ToList();
            });
        }
    }
}
