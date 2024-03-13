using ChillsRestaurant.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChillsRestaurant.Controllers
{
    public class PedidoController : Controller
    {
        public List<MenuItem> _items = new List<MenuItem>();


        public IActionResult Index()
        {
            return View(_items);
        }

        public void AddToCart(MenuItem item)
        {
            _items.Add(item);
        }

        public void SetSession(object obj)
        {
            HttpContext.Session.SetString("carrito", JsonConvert.SerializeObject(obj));
        }

        public string GetSession()
        {
            return HttpContext.Session.GetString("carrito");
        }


        
        
        [HttpPost]
        public void Add([FromBody] PedidoModelo modelo)
        {

            if (GetSession() != null)
            {
                List<PedidoModelo> lista = new List<PedidoModelo>();
                lista.Add(modelo);
                SetSession(lista);

            }
            else
            {
                List<PedidoModelo> lista = JsonConvert.DeserializeObject<List<PedidoModelo>>(GetSession());
                lista.Add(modelo);
                SetSession(lista);

            }

            var Value = GetSession();
        }
    }
}


