using System;
using System.Threading.Tasks;
using NUnit.Framework;
using WtbTestApp.RestProvider;

namespace WtbTestApp.Testing
{
    [TestFixture]
    public class DefaultRestProviderIntegrationTesting
    {
        [Test]
        public async Task GetCbCurrency()
        { 
            var provider = new CbRestProvider();
            var response = await provider.GetAsync("XML_daily.asp");
        }
    }
}
