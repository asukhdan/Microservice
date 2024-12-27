using System;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Core.ServiceContract;

public interface IUserService
{
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);
    Task<AuthenticationResponse?> RegisterUser(RegisterRequest registerRequest);

}
