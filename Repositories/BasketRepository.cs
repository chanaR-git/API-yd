using hwWebAPI.Data;
using hwWebAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static hwWebAPI.DTO_s.ProductsDTO;

namespace hwWebAPI.Repositories
{
    public class BasketRepository
    {
        BigBiteContext context = ContextFactory.createContext();


        #region CRUD
        public List<Basket> GetAllBaskets()
        {
            var a = context.Baskets.Include(o => o.Product).Include(p=>p.User).ToList();
            return a;
        }
        public List<Basket> GetMyBaskets(int idUser)
        {
            return context.Baskets.Where(b=>b.User.Id == idUser).ToList();
        }

        //get order by id
        public Basket  ? GetOrderById(int id)
        {
            var order = context.Baskets.FirstOrDefault(p => p.Id == id);
            return order;
        }

        //create order
        public bool EnterProdToBasket(CreateBasketDTO o)
        {
            try
            {
            Basket? b = new(){ productId = o.productId, UserId = o.UserId};
                var a = context.Baskets.Add(b);
                context.SaveChanges();
                return a != null;
            }
           catch (Exception ex)
            {
                return false;
            }
        }

        ////delete
        /////לא עשינו מחיקה

        #endregion

       
    }
}
