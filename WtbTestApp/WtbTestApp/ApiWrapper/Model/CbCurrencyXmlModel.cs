using System.Globalization;
using System.Xml.Serialization;

namespace WtbTestApp.ApiWrapper.Model
{
    [XmlRoot("Valute")]
    public class CbCurrencyXmlModel
    {
        [XmlAttribute("ID")]
        public string Id { get; set; }

        /// <summary>
        /// ISO4217 num
        /// </summary>
        [XmlElement("NumCode")]
        public string Num { get; set; }

        /// <summary>
        /// ISO4217 code
        /// </summary>
        [XmlElement("CharCode")]
        public string Code { get; set; }

        [XmlElement("Nominal")]
        public decimal Nominal { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlIgnore]
        public decimal Value { get; set; }

        [XmlElement("Value")]
        public string ValueFormatted
        {
            get
            {
                var formatted = Value.ToString(CultureInfo.InvariantCulture);
                return formatted.Replace(CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator, ",");
            }
            set
            {
                var formatted = value.Replace(",", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
                Value = decimal.Parse(formatted, NumberStyles.Any, CultureInfo.InvariantCulture);
            }
        }

        public CbCurrencyJsonModel ToJsonModel()
        {
            return new CbCurrencyJsonModel(this);
        }
    }
}