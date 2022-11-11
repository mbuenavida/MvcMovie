using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcMovie.Controllers;
using MvcMovie.Services.Repository;

namespace MvcMovie.Test
{
    [TestClass]
    public class UnitTestMovie
    {
        // Se establece controlador y repositorio a utilizar.
        readonly MovieController controller = new(new FakeMovieRepository());

        [TestMethod]
        public void MovieDetaislTest()
        {
            // Se ejecuta el método del controlador
            var result = controller.Details(2);

            // Se definen las validaciones
            Assert.IsNotNull(result);

        }
    }
}