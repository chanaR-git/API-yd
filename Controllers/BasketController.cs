using hwWebAPI.Models;
using hwWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace hwWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public List<Basket> GetAllBaskets()
        {
           return _basketService.GetAllBaskets();
        }
        [HttpGet]
        [Route("getMyBasket{idUser}")]
        public List<Basket> GetMyBaskets([FromRoute]int idUser)
        {
            return _basketService.GetMyBaskets(idUser);
        }

        [HttpGet]
        [Route("get orderd prod by id{idUser}")]
        //get order by id
        public Basket? GetOrderById(int id)
        {
            return _basketService.GetOrderById(id);
         }

        [HttpPost]
        //create order
        public bool EnterProdToBasket(CreateBasketDTO o)
        {
            return _basketService.EnterProdToBasket(o);
        }
    }
}
