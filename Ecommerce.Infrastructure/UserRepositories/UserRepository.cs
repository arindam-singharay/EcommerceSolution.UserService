using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;
using Ecommerce.Core.RepositoryContracts;

namespace Ecommerce.Infrastructure.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Adds a new user to the repository.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
        {
            //for now dummy implementation
            user.UserID = Guid.NewGuid();
            return user;
        }

        /// <summary>
        /// Retrieves a user from the repository based on the provided email and password.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return new ApplicationUser
            {
                UserID = Guid.NewGuid(),
                Email = email,
                Password = password,
                PersonName = "John Doe",
                Gender = GenderOption.Male.ToString()
            };
        }
    }
}
