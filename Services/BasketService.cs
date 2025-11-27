using hwWebAPI.Models;
using hwWebAPI.Repositories;
using static hwWebAPI.DTO_s.ProductsDTO;

namespace hwWebAPI.Services
{
    public class BasketService
    {
        private readonly BasketRepository _repository = new();


        #region CRUD
            public List<Basket> GetAllBaskets()
            {
                return _repository.GetAllBaskets();
            }

            public List<Basket> GetMyBaskets(int idUser)
            {
                return _repository.GetMyBaskets(idUser);
            }
            public Basket? GetOrderById(int idBasket)
            {
                return _repository.GetOrderById(idBasket);
            }
            public bool EnterProdToBasket(CreateBasketDTO basket)
            {
                return _repository.EnterProdToBasket(basket);
            }

        #endregion
    }
}
