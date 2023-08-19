using BlogApp.ClassLib.Model;

namespace BlogApp.Services
{
    public interface IUserService
    {
        Task<List<User>> getUsers();
    }
}
