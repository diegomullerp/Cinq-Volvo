using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Controllers;
using WebApi.Models;
using Xunit;

namespace Volvo_Cinq.test
{
    public class VehicleControllerTest
    {
        VehiclesController _controller;

        private readonly ApiContext _context;

        public VehicleControllerTest(ApiContext context)
        {
            _context = context;
        }

      

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            _controller = new VehiclesController(_context);
            // Act
            var okResult = _controller.GetVehicle();

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}
