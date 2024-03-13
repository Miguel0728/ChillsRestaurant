using ChillsRestaurant.Models;
using ChillsRestaurant.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace ChillsRestaurant.Controllers
{
    public class ProductoController : Controller
    {

        private readonly ChillsRestaurantDBContext _dbContext;

        public List<MenuItem> _items = new List<MenuItem>();
        IndexCarritoModel _carritoModel;

        public ProductoController(ChillsRestaurantDBContext dBContext)
        {
            _dbContext = dBContext;
            _carritoModel = new IndexCarritoModel();
        }


        [HttpGet]
        public IActionResult IndexCarrito()
        {
            return View(_carritoModel);
        }

        public IActionResult AddMenuItem(string itemName)
        {
            if (itemName == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var item = _dbContext.MenuItems.FirstOrDefault(x => x.Name == itemName);

            if (item == null)
            {
                return RedirectToAction("Index", "Home");
            }

            _carritoModel.MenuItems.Add(item);


            return View("IndexCarrito",new { IndexCarritoModel = _carritoModel });
        }


        public IEnumerable<Models.MenuItem> Listado()
        {
            var productos = new List<MenuItem>()
        {
            new MenuItem(){ Name="Classicburger", Price=Convert.ToDecimal("5.99") , Photo="../images/Comida/Hambuerger.png"},
            new MenuItem(){ Name="Veggieburger", Price=Convert.ToDecimal("8.99") , Photo="../images/Comida/Hambuegervagena.png"},
            new MenuItem(){ Name="BBQburger", Price=Convert.ToDecimal("9.99") , Photo="../images/Comida/bbqbuerger.png"},
            new MenuItem(){ Name="AlfredoPasta", Price=Convert.ToDecimal("14.99") , Photo="../images/Comida/alfredo.png"},
            new MenuItem(){ Name="Lasagna", Price=Convert.ToDecimal("14.99") , Photo="../images/Comida/lasagna.png"},
            new MenuItem(){ Name="Spagetti", Price=Convert.ToDecimal("12.99") , Photo="../images/Comida/spagetti.png"},
            new MenuItem(){Name="Cheesecake", Price=Convert.ToDecimal("5.99") , Photo="../images/Comida/cheescake.png"},
            new MenuItem(){Name="ChocolateCake", Price=Convert.ToDecimal("5.99") , Photo="../images/Comida/chocolate.png"},


        };
            return productos;
        }
    }
}
