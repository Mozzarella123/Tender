using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TenderApp;
using TenderApp.Controllers;
using TenderApp.Models.AdminViewModels;
using TenderApp.Services;

namespace XunitTenderTests
{
    public class CategoryManageTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public CategoryManageTests()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
            
        }
        //public async Task<IActionResult> TestAddAsync()
        //{
        //    //arrange
        //    CategoryViewModel model = new CategoryViewModel()
        //    {
        //        Name = "New",
        //        Description = "Descr"
        //    };
        //    Mock<IRepository> repos = new Mock<IRepository>();
        //    CategoryManageController controller = new CategoryManageController(repos.Object);
        //    //act
        //    IActionResult result = await controller.Add(model);

        //}

    }
}
