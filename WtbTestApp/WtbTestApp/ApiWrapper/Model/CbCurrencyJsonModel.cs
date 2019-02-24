using Newtonsoft.Json;

namespace WtbTestApp.ApiWrapper.Model
{
    public class CbCurrencyJsonModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("num")]
        public string Num { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("nominal")]
        public decimal Nominal { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }

        public CbCurrencyJsonModel()
        {
            
        }

        public CbCurrencyJsonModel(CbCurrencyXmlModel xmlModel)
        {
            Id = xmlModel.Id;
            Num = xmlModel.Num;
            Code = xmlModel.Code;
            Nominal = xmlModel.Nominal;
            Name = xmlModel.Name;
            Value = xmlModel.Value;
        }
    }
}