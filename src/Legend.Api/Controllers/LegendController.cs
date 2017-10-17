namespace Legend.API.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using Fanex.Data.Repository;

    [AllowAnonymous]
    public class LegendController : ApiController
    {
        private readonly IDynamicRepository dynamicRepository;

        public LegendController(IDynamicRepository dynamicRepository)
        {
            this.dynamicRepository = dynamicRepository;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var criteria = new GetLegendCriteria
            {
                MenuId = id
            };

            var legend = await dynamicRepository.GetAsync<LegendObject>(criteria);
            var legendHtml = legend == null ? string.Empty : legend.Legend;

            return Json(legendHtml);
        }
    }
}