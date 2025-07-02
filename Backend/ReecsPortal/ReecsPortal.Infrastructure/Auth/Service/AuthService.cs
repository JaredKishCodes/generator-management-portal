
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReecsPortal.Application.DTOs.Auth;
using ReecsPortal.Application.Interfaces;
using ReecsPortal.Infrastructure.Auth.Persistence;
using ReecsPortal.Infrastructure.DTradeModels;
using static ReecsPortal.Infrastructure.Auth.Helper.PasswordHasher;



namespace ReecsPortal.Infrastructure.Identity.Service
{
    public class AuthService(DtradeDbContext _dbContext, IJwtTokenService jwtTokenService, ILogger<AuthService> _logger) : IAuthService
    {
        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            try
            {
                _logger.LogInformation("Attempting to login user: {Username}", loginDto.Username);  

                var user = await _dbContext.TblUsers.SingleOrDefaultAsync(u => u.Username == loginDto.Username);
                if (user == null)
                {
                    return new AuthResponseDto
                    {
                        Message = "User not found",
                        Status = false
                    };
                }

                var inputHash = HashPasswordSHA256(loginDto.Password);
                var passwordMatches = inputHash == user.Password;

                if (!passwordMatches)
                {
                    return new AuthResponseDto
                    {
                        Message = "Invalid credentials",
                    };
                }

                var token = await jwtTokenService.CreateTokenAsync(user);

                var response = new AuthResponseDto
                {
                    Message = "Login Success!",
                    Status = true,
                    Username = user.Username,
                    Token = token,
                };

                return response;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred while logging in user: {Username}", loginDto.Username);

                return new AuthResponseDto
                {
                    Message = ex.Message,
                    Status = false
                };
            }
            
        }

        public async Task<AuthResponseDto> Register(RegisterDto registerDto)
        {
            try
            {
                _logger.LogInformation("Attempting to register user: {Username}", registerDto.Username);

                var usernameExists = await _dbContext.TblUsers.AnyAsync(x => x.Username == registerDto.Username);

                if (usernameExists)
                {
                    return new AuthResponseDto
                    {
                        Message = "Username already exists!",
                        Status = false
                    };
                }

                // Hash the password
                var hashedPassword = HashPasswordSHA256(registerDto.Password);

                var newUser = new TblUser
                {
                    ContactName = registerDto.ContactName,
                    ContactAddress = registerDto.ContactAddress,
                    ContactNum = registerDto.ContactNumber,
                    AccessType = registerDto.AccessType,
                    ContactEmail = registerDto.EmailAddress,
                    Username = registerDto.Username,
                    Password = hashedPassword // Save hashed password
                };

                _logger.LogInformation("User object prepared for registration: {@NewUser}", newUser);

                _dbContext.TblUsers.Add(newUser);
                await _dbContext.SaveChangesAsync();

                var token = await jwtTokenService.CreateTokenAsync(newUser);

                return new AuthResponseDto
                {
                    Message = "Registration Success!",
                    Status = true,
                    Username = newUser.Username,
                    Token = token,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Register User");
                return new AuthResponseDto
                {
                    Message = ex.Message,
                    Status = false
                };
            }
        }


    }
}

