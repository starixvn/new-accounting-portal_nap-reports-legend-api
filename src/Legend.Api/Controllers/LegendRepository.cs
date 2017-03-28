using Fanex.Caching;
using Fanex.NAP.Core.Configuration;
using Fanex.NAP.Core.Models;
using Fanex.NAP.Core.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legend.API.Controllers
{

    public interface LegendRepository
    {
        Task<List<MenuItem>> GetMenuItems();
    }

    public class LegendRepositoryImp : LegendRepository
    {
        private readonly ISiteService siteService;
        private readonly CacheService cacheService;

        public LegendRepositoryImp(ISiteService siteService, CacheService cacheService)
        {
            this.siteService = siteService;
            this.cacheService = cacheService;
        }

        public async Task<List<MenuItem>> GetMenuItems()
        {
            return await cacheService.GetOrSetAsync("MenuItems", () =>
            {
                return siteService.GetMenuItemBySiteId(NapSettings.Settings.SiteId, NapSettings.Settings.Environment).ToList();
            });
        }
    }
}
