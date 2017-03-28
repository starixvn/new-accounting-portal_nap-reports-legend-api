using Fanex.Data.Repository;

namespace Legend.API.Controllers
{
    public class GetLegendCriteria : CriteriaBase
    {
        public int MenuId { get; set; }

        public string System => "ACC-NAP";

        public override string GetSettingKey()
        {
            return "LegendManagement_SelReportLegend";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
