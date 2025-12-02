using hwWebAPI.Models;

namespace hwWebAPI.Repositories
{
    public interface IuserRepository
    {
        bool Login(User user);
        User? Register(User user);
    }
}