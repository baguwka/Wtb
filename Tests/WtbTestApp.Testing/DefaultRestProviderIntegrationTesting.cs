using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using WtbTestApp.ApiWrapper.Model;
using WtbTestApp.RestProvider;
using WtbTestApp.Utils;

namespace WtbTestApp.Testing
{
    [TestFixture]
    public class DefaultRestProviderIntegrationTesting
    {
        [Test]
        public async Task GetCbCurrencyResponse()
        {
            var provider = new CbRestProvider();
            var response = await provider.GetAsync("XML_daily.asp");
            Assert.That(response.IsSuccess, Is.True);
        }
    }
}
