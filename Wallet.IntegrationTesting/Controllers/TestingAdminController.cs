using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wallet.IntegrationTesting.Infrastructures;
using Xunit;

namespace Wallet.IntegrationTesting.Controllers
{
    public class TestingAdminController : IClassFixture<WalletAppFactory<Program>>
    {
        private readonly HttpClient _client;

        public TestingAdminController(WalletAppFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllTransactions_WhenCalled_ReturnsOk()
        {
            var response = await _client.GetAsync("api/Admin/GetAllTransactions");
            response.EnsureSuccessStatusCode();

        }
    }
}
