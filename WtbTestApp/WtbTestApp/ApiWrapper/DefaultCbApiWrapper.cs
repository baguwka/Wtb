using System;
using System.Threading.Tasks;
using WtbTestApp.ApiWrapper.Model;
using WtbTestApp.RestProvider;
using WtbTestApp.Utils;

namespace WtbTestApp.ApiWrapper
{
    public class DefaultCbApiWrapper : ICbApiWrapper
    {
        private readonly IRestProvider _RestProvider;

        public DefaultCbApiWrapper(IRestProvider restProvider)
        {
            _RestProvider = restProvider ?? throw new ArgumentNullException(nameof(restProvider));
        }

        public async Task<CbCurrencyJsonResponseModel> GetDailyCurrencies()
        {
            var response = await _RestProvider.GetAsync("XML_daily.asp");
            if (response.IsSuccess)
            {
                var xmlModel = XmlSerializerUtils.Deserialize<CbCurrencyXmlResponseModel>(response.Content);
                var jsonModel = xmlModel.ToJsonModel();
                return jsonModel;
            }
            else
            {
                return null;
            }
        }
    }
}