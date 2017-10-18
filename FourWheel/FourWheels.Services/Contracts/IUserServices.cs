using FourWheels.Data.Models;
using System.Linq;

namespace FourWheels.Services.Contracts
{
    public interface IUserServices : IService
    {
        IQueryable<User> GetAllUsers();

        User GetUserById(string id);

        IQueryable<CarAd> AllUserAds(string userId);

        void UpdateUserInfo(User user);

        void DeleteUser(string id);
    }
}
