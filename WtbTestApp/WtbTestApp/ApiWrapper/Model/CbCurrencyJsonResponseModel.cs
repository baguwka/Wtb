using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace WtbTestApp.ApiWrapper.Model
{
    public class CbCurrencyJsonResponseModel
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("currencies")]
        public ICollection<CbCurrencyJsonModel> Items { get; set; }

        public CbCurrencyJsonResponseModel()
        {
            
        }

        public CbCurrencyJsonResponseModel(CbCurrencyXmlResponseModel model)
        {
            Name = model.Name;
            Date = model.Date;
            if (model.Items != null)
            {
                Items = model.Items
                    .Select(i => i.ToJsonModel())
                    .ToList();
            }
        }
    }
}