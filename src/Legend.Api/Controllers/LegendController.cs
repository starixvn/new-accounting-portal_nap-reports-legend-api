namespace Legend.API.Controllers
{
    using Fanex.Data.Repository;
    using System.Threading.Tasks;
    using System.Web.Http;

    [AllowAnonymous]
    public class LegendController : ApiController
    {
        private readonly IDynamicRepository dynamicRepository;

        public LegendController(IDynamicRepository dynamicRepository)
        {
            this.dynamicRepository = dynamicRepository;
        }

        [HttpGet]
        public IHttpActionResult Index()
        {
            return Json("Legend API");
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var criteria = new GetLegendCriteria
            {
                MenuId = id
            };

            var legend = await dynamicRepository.GetAsync<LegendDTO>(criteria);
            var legendHtml = legend == null ? string.Empty : legend.Legend;

            return Json(legendHtml);
        }
    }
}