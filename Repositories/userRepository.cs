using hwWebAPI.Data;
using hwWebAPI.Models;

namespace hwWebAPI.Repositories
{
    public class userRepository
    {
        BigBiteContext context = ContextFactory.createContext();

        public User? Register(User user)
        {
            var a = context.Users.Add(user);
            if (a != null) 
            { 
                context.SaveChanges();
                return user;
            }
            else
                return null;
        } 
    
        public bool Login(User user)
        {
            //var a = context.Users.FirstOrDefault(u=>u.Name == user.Name && u.);
            //if (a != null)
            //{
            //    context.SaveChanges();
            //    return user;
            //}
            //else
            //    return null;
            return true;
        }
}

}
