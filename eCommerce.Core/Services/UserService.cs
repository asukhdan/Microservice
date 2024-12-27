using System;
using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContract;
using eCommerce.Core.ServiceContract;

namespace eCommerce.Core.Services;

public class UserService : IUserService
{
    public readonly IUserRepository _userRepository;
    public readonly IMapper _mapper;
    public UserService(IUserRepository userRepository,IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper=mapper;
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? user =
        await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return null;
        }
       
      //  return new AuthenticationResponse(user.UserId, user.Email, user.Password, user.PersonName, user.Gender, "token", true);
    return _mapper.Map<AuthenticationResponse>(user) with {Success=true,Token="token"};

      
       
    }

    public async Task<AuthenticationResponse?> RegisterUser(RegisterRequest registerRequest)
    {
        ApplicationUser user = new ApplicationUser
        {
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            PersonName = registerRequest.PersonName,
            Gender = registerRequest.Gender.ToString()
        };
        //ApplicationUser user=_mapper.Map<ApplicationUser>(registerRequest);
        ApplicationUser? registeredUser = await _userRepository.AddUser(user);
        if (registeredUser == null)
        {
            return null;
        }


        //Return Success Response
        // return new AuthenticationResponse(
        //     registeredUser.UserId,
        //     registeredUser.Email,
        //     registeredUser.Password,
        //     registeredUser.PersonName,
        //     registeredUser.Gender,
        //     "token",
        //     Success: true
        //     );

        return _mapper.Map<AuthenticationResponse>(registeredUser) with {Success=true,Token="token"};

    }
}
