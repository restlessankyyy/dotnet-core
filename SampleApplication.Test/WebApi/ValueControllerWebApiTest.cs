// <copyright file="ValueControllerWebApiTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SampleApplication.Test.WebApi
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using SampleApplication.Controllers;
    using Xunit;

    public class ValueControllerWebApiTest
    {
        private readonly ValuesController valueService;

        public ValueControllerWebApiTest()
        {
            this.valueService = new ValuesController();
        }

        [Fact]
        public void ReturnGetDataById_Equal()
        {
            var result = this.valueService.Get(1);

            Assert.Equal("value", result);
        }

        [Fact]
        public void ReturnGetDataById_NotEqual()
        {
            var result = this.valueService.Get(1);

            Assert.NotEqual("values will not match", result);
        }

        [Fact]
        public void ConfigureServices_RegistersDependenciesCorrectly()
        {
            //  Arrange

            //  Setting up the stuff required for Configuration.GetConnectionString("DefaultConnection")
            Mock<IConfigurationSection> configurationSectionStub = new Mock<IConfigurationSection>();

            Mock<Microsoft.Extensions.Configuration.IConfiguration> configurationStub = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
            //configurationStub.Setup(x => x.GetSection("ConnectionStrings")).Returns(configurationSectionStub.Object);

            IServiceCollection services = new ServiceCollection();
            var target = new Startup(configurationStub.Object);

            //  Act

            target.ConfigureServices(services);
            //  Mimic internal asp.net core logic.
            services.AddTransient<ValuesController>();

            //  Assert

            var serviceProvider = services.BuildServiceProvider();

            var controller = serviceProvider.GetService<ValuesController>();
            Assert.NotNull(controller);
        }
    }
}
