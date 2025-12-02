using hwWebAPI.Models;

namespace hwWebAPI.Services
{
    public interface IBasketService
    {
        bool EnterProdToBasket(CreateBasketDTO basket);
        List<Basket> GetAllBaskets();
        List<Basket> GetMyBaskets(int idUser);
        Basket? GetOrderById(int idBasket);
    }
}