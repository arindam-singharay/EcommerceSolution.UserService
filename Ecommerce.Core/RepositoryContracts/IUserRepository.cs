using Ecommerce.Core.Entities;


/// <summary>
/// contracts to be implemented by the UserRepository class for user related database operations.
/// </summary>
namespace Ecommerce.Core.RepositoryContracts
{
    public interface IUserRepository
    {
        /// <summary>
        /// Method to add a new user to the database.   
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ApplicationUser?> AddUserAsync(ApplicationUser user);

        /// <summary>
        /// Method to get a user by email and password from the database.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string? email, string? password); 

    }
}
