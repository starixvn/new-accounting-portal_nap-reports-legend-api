using Fanex.Data.Repository;
using Legend.API.Controllers;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Legend.API.DatabaseTests
{
    public class DynamicRepositoryTests
    {
        [Test]
        public async Task SP_Acc_FunctionLegendSel_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new GetLegendCriteria
            {
                MenuId = 584,
            };

            // Act
            var repository = new DynamicRepository();
            var legend = await repository.GetAsync<LegendObject>(criteria);

            // Assert
            Assert.That(legend.LegendId, Is.Not.Zero);
            Assert.That(legend.Legend, Is.Not.Null.And.Not.Empty);
            Assert.That(legend.MenuId, Is.EqualTo(584));
            Assert.That(legend.System, Is.EqualTo("ACC-NAP"));
        }
    }
}