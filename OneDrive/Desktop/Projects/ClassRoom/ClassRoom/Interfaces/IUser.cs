using ClassRoom.Models;

namespace ClassRoom.Interfaces
{
    public interface IUser<T> where T : class
    {
        Task<SigningResponse> signIn(string email, string password);
        Task<T> signup(string userName, string email, string password);
    }
}
