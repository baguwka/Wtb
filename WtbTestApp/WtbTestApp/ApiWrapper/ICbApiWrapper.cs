using System.Threading.Tasks;
using WtbTestApp.ApiWrapper.Model;

namespace WtbTestApp.ApiWrapper
{
    public interface ICbApiWrapper
    {
        Task<CbCurrencyJsonResponseModel> GetDailyCurrencies();
    }
}