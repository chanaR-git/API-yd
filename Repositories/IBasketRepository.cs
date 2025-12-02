using hwWebAPI.Models;

namespace hwWebAPI.Repositories
{
    public interface IBasketRepository
    {
        bool EnterProdToBasket(CreateBasketDTO o);
        List<Basket> GetAllBaskets();
        List<Basket> GetMyBaskets(int idUser);
        Basket? GetOrderById(int id);
    }
}