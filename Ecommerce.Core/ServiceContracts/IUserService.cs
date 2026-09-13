using Ecommerce.Core.DTO;

namespace Ecommerce.Core.ServiceContracts
{
    /// <summary>
    /// Represents the contract for user-related services in the e-commerce application.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Authenticates a user based on the provided login request and returns an authentication response.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> LoginAsync(LoginRequest request);


        /// <summary>
        /// Registers a new user based on the provided registration request and returns an authentication response.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> RegisterAsync(RegisterRequest request);
    }
}
