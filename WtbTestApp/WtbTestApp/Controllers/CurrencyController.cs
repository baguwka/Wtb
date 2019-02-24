using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using WtbTestApp.ApiWrapper;
using WtbTestApp.ApiWrapper.Model;
using WtbTestApp.RestProvider;

namespace WtbTestApp.Controllers
{
    public class CurrencyController : ApiController
    {
        private readonly ICbApiWrapper _ApiWrapper;

        //todo ioc
        public CurrencyController()
        {
            _ApiWrapper = new DefaultCbApiWrapper(new CbRestProvider());
        }

        [HttpGet]
        [Route("api/GetCurrency")]
        public async Task<JsonResult<CbCurrencyJsonResponseModel>> GetCurrency()
        {
            var currencies = await _ApiWrapper.GetDailyCurrencies();
            return Json(currencies);
        }
    }
}
