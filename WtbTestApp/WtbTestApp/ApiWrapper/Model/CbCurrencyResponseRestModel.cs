using System;
using System.Xml.Serialization;

namespace WtbTestApp.ApiWrapper.Model
{
    [XmlRoot("ValCurs")]
    public class CbCurrencyResponseRestModel
    {
        [XmlIgnore]
        public DateTime Date { get; set; }

        [XmlAttribute("Date")]
        public string DateString {
            get => Date.ToString("dd.MM.yyyy");
            set => Date = DateTime.Parse(value);
        }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("Valute")]
        public CbCurrencyRestModel[] Items { get; set; }
    }
}