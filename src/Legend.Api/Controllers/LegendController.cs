namespace Legend.API.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;

    [AllowAnonymous]
    public class LegendController : ApiController
    {
        private readonly LegendService legendService;

        public LegendController(LegendService legendService)
        {
            this.legendService = legendService;
        }

        [HttpGet]
        public IHttpActionResult Index()
        {
            return Json("Legend API");
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string menuName)
        {
            var content = await legendService.GetLegend(menuName);
            return Json(content);
        }
    }
}