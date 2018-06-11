using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FastFoodOnline.Base.Services;
using FastFoodOnline.Core.DataAccess;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Models;
using FastFoodOnline.Resources.ViewModels;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace FastFoodOnline.Services
{
    public class AuthenticateService : BaseService, IAuthenticateService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork Dependancy</param>
        /// <param name="configuration">Configutaions of Application</param>
        /// <param name="mapper">Auto Mapper Injection</param>
        public AuthenticateService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration) : base(unitOfWork, mapper, configuration)
        { }


        /// <summary>
        /// Create Password Hash And Password Salt
        /// </summary>
        /// <param name="password">Password</param>
        /// <param name="passwordHash">Out - Password Hash</param>
        /// <param name="passwordSalt">Out - Password Salt</param>
        private static void CreatePasswordHashAndSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// Verify provided password is match with password hash and salt
        /// </summary>
        /// <param name="password">Password</param>
        /// <param name="passwordHash">Password Hash</param>
        /// <param name="passwordSalt">Password Salt</param>
        /// <returns>If password matches Password Hash and Password Salt then retuns True</returns>
        private static bool IsPasswordVerified(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return !computedHash.Where((cHash, index) => cHash != passwordHash[index]).Any();
            }
        }

        /// <summary>
        /// Genarate Token For User
        /// </summary>
        /// <param name="user">User Details</param>
        /// <returns>TokenViewModel</returns>
        private TokenViewModel GenarateTokenViewModelForUser(User user)
        {
            // Create Authentication Token
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(Configuration.GetSection("ApplicationSettings")["AuthenticationEncodingKey"]);

            DateTime issueDateTime = DateTime.Now;

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Username),
                    new Claim(ClaimTypes.Name, $"{ user.FirstName } { user.LastName }"),
                     
                }),
                IssuedAt = issueDateTime,
                NotBefore = issueDateTime,
                Expires = issueDateTime.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            string tokenString = tokenHandler.WriteToken(token);

            return new TokenViewModel()
            {
                TokenString = tokenString,
                IssuedDateTime = issueDateTime,
                ExpireDateTime = issueDateTime.AddDays(1)
            };
        }

        /// <summary>
        /// Check weather given username has reserved by another user - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>If username is avalable then return True</returns>
        public async Task<bool> AuthenticateUsernameAsync(string username)
        {
            return await UnitOfWork.AuthorizationRepository.IsUserExistsAsync(username);
        }

        /// <summary>
        /// Authenticate Username and Password - Async
        /// For Login
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Plain text password</param>
        /// <returns>TokenViewModel</returns>
        public async Task<TokenViewModel> LoginUserByUsernameAndPassword(string username, string password)
        {
            User userCredentials = await UnitOfWork.AuthorizationRepository.GetUserCredentialsByUsername(username);

            if (userCredentials != null &&
                IsPasswordVerified(password, userCredentials.PasswordHash, userCredentials.PasswordSalt))
            {
                User userDetails = await UnitOfWork.UserRepository.GetUserDetailsByUsernameAsync(userCredentials.Username);

                return GenarateTokenViewModelForUser(userDetails);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Register User - Async
        /// </summary>
        /// <param name="userViewModel">UserViewModel</param>
        /// <param name="password">Password</param>
        /// <returns>Is user Registered or not</returns>
        public async Task<bool> RegisterUserAsync(UserViewModel userViewModel, string password)
        {
            if (await UnitOfWork.AuthorizationRepository.IsUserExistsAsync(userViewModel.Username))
                return false;

            User user = Mapper.Map<UserViewModel, User>(userViewModel);

            CreatePasswordHashAndSalt(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            int effectedRowsCount;

            using (var transaction = await UnitOfWork.BeginTransactionAsync())
            {
                try
                {
                    await UnitOfWork.AuthorizationRepository.RegisterUserAsync(user);
                    effectedRowsCount = await UnitOfWork.CompleteAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return effectedRowsCount > 0;
        }
    }
}
