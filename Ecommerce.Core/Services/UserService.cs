using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;
using Ecommerce.Core.RepositoryContracts;
using Ecommerce.Core.ServiceContracts;

namespace Ecommerce.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<AuthenticationResponse?> LoginAsync(LoginRequest request)
        {
            ApplicationUser? user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, request.Password);
            if (user == null)
            {
                //Will implement logging later and formatting the response to include error messages
                return null;
            }

            return new AuthenticationResponse(
                user.UserID,
                user.Email,
                user.PersonName,
                user.Gender,
                "dummy-token", // Will implement JWT token generation later
                true
            );



        }

        public async Task<AuthenticationResponse?> RegisterAsync(RegisterRequest request)
        {
            ApplicationUser applicationUser = new ApplicationUser
            {
                Email = request.Email,
                Password = request.Password,
                PersonName = request.PersonName,
                Gender = request.Gender.ToString()
            };

           ApplicationUser? regiteredUser = await _userRepository.AddUserAsync(applicationUser);
            if(regiteredUser == null)
            {
                //Will implement logging later and formatting the response to include error messages
                return null;
            }

            return new AuthenticationResponse(
                regiteredUser.UserID,
                regiteredUser.Email,
                regiteredUser.PersonName,
                regiteredUser.Gender,
                "dummy-token", // Will implement JWT token generation"
                true
            );

        }
    }
}
