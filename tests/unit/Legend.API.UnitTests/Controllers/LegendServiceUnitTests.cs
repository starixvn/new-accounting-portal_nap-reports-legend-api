using Fanex.Caching;
using Fanex.Data.Repository;
using Fanex.NAP.Core.Models;
using Fanex.NAP.Core.Service.Interface;
using Legend.API.Controllers;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Legend.API.UnitTests.Controllers
{
    public class LegendServiceUnitTests
    {
        private const int ValidMenuId = 1;

        [Test]
        public async Task GetLegend_InvalidMenuName_ReturnsEmpty()
        {
            // Arrange
            var legendService = CreateLegendService();

            // Act
            var legend = await legendService.GetLegend("Invalid Menu Name");

            // Assert
            Assert.That(legend, Is.Empty);
        }

        [Test]
        public async Task GetLegend_ValidMenuName_ReturnsNonEmptyLegend()
        {
            // Arrange
            var legendService = CreateLegendService();

            // Act
            var legend = await legendService.GetLegend("Valid Menu Name");

            // Assert
            Assert.That(legend, Is.Not.Empty);
        }

        private LegendService CreateLegendService()
        {
            var siteService = CreateSiteService();
            var cacheService = new CacheServiceImpl();
            var repository = CreateRepository();

            return new LegendServiceImp(siteService, cacheService, repository);
        }

        private ISiteService CreateSiteService()
        {
            var menuItem = new MenuItem
            {
                Id = ValidMenuId,
                Name = "Valid Menu Name"
            };
            var menuItems = new List<MenuItem>
            {
                menuItem
            };
            var siteService = Substitute.For<ISiteService>();
            siteService.GetMenuItemBySiteId(Arg.Any<int>(), Arg.Any<string>())
                .Returns(menuItems);

            return siteService;
        }

        private IDynamicRepository CreateRepository()
        {
            var legend = new LegendDTO
            {
                MenuId = ValidMenuId,
                Legend = "Any Legend",
                System = "Any System"
            };

            var repository = Substitute.For<IDynamicRepository>();
            repository.GetAsync<LegendDTO>(Arg.Is<GetLegendCriteria>(x => x.MenuId == ValidMenuId))
                        .Returns(legend);

            return repository;
        }
    }
}
