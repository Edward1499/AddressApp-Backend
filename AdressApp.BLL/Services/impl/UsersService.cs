using AddressApp.BLL.DTOs.Users;
using AddressApp.BLL.Exceptions;
using AddressApp.BLL.Mappers.Users;
using AddressApp.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static AddressApp.DAL.Enumerator;

namespace AddressApp.BLL.Services.impl
{
    public class UsersService : IUsersService
    {
        private readonly IConfiguration configuration;
        private readonly IUsersRepository usersRepository;
        public UsersService(
            IConfiguration configuration,
            IUsersRepository usersRepository
        )
        {
            this.configuration = configuration;
            this.usersRepository = usersRepository;
        }
        public UserResponseDto CreateUser(UserRequestDto user)
        {
            if (usersRepository.Any(x => x.Email == user.Email))
            {
                throw new UnprocessedObjectException("Ya existe una cuenta con este correo electrónico.");
            }

            user.UserRoleId = (int)UserRoles.NormalUser;
            user.Password = HashPassword(user.Password);

            var newUser = UsersMapper.Map(user);
            newUser.Photo = user.Photo != null ? SavePhoto(user.Photo, user.RootPath) : null;

            usersRepository.Add(newUser);

            var userLoginRequest = new UserLoginDto
            {
                Email = newUser.Email,
                Password = newUser.Password,
                RootPath = user.RootPath
            };

            return Authenticate(userLoginRequest);
        }

        public UserResponseDto Login(UserLoginDto user)
        {
            user.Password = HashPassword(user.Password);
            return Authenticate(user);
        }

        public void EnableUser(int userId)
        {
            var user = usersRepository.Get(x => x.Id == userId);
            user.IsEnabled = true;
            usersRepository.Update(user);
        }

        public void DisableUser(int userId)
        {
            var user = usersRepository.Get(x => x.Id == userId);
            user.IsEnabled = false;
            usersRepository.Update(user);
        }

        public List<GetAllUsersResponseDto> GetAllUsers()
        {
            return UsersMapper.Map(usersRepository.GetAllUsers());
        }

        private UserResponseDto Authenticate(UserLoginDto user)
        {
            var userData = usersRepository.Get(x => x.Email == user.Email && x.Password == user.Password);

            if (userData == null)
            {
                throw new UnauthorizedResourceException("Usuario o Contraseña incorrecta.");
            }

            if (!userData.IsEnabled)
                throw new UnauthorizedResourceException("Esta cuenta se encuentra inactiva, por favor comuniquese con el administrador.");

            UserResponseDto userResponse = UsersMapper.Map(userData);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["AppSettings:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userResponse.Id.ToString()),
                    new Claim(ClaimTypes.Role, userResponse.UserRoleId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            userResponse.Token = tokenHandler.WriteToken(token);

            if (userData.Photo != null)
            {
                userResponse.Image = ConvertImageToBase64(Path.Combine(user.RootPath + "\\statics\\images", userData.Photo));
            }

            return userResponse;
        }

        private string ConvertImageToBase64(string path)
        {
            byte[] imageArray = File.ReadAllBytes(@path);
            return Convert.ToBase64String(imageArray);
        }

        private string SavePhoto(IFormFile image, string rootPath)
        {
            if (image != null && image.Length > 0)
            {
                var file = image;
                //There is an error here
                var uploads = Path.GetTempFileName();
                if (file.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                    using (var fileStream = new FileStream(Path.Combine(rootPath + "\\statics\\images", fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    return fileName;
                }
            }

            return null;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                // Get the hashed string.  
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash;
            }
        }
    }
}
