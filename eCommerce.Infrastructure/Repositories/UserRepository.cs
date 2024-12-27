using System;
using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContract;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
   public readonly DapperDbContext _dapperDbContext;
   public UserRepository(DapperDbContext dapperDbContext)
   {
          _dapperDbContext=dapperDbContext;
   }
   public async Task<ApplicationUser?> AddUser(ApplicationUser user)
   {
      user.UserId = Guid.NewGuid();
      string Query= "INSERT INTO public.\"Users\"(\"UserId\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES (@UserId,@Email,@PersonName,@Gender,@Password)";

      int rowsAffected= await _dapperDbContext._dbConnection.ExecuteAsync(Query,user);
      if(rowsAffected>0)
      {
        return user;
      }
      else
      {
         return null;
      }


      
   }

   public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? Email, string? Password)
   {
      return new ApplicationUser
      {
         UserId = Guid.NewGuid(),
         Email = Email,
         Password = Password,
         Gender = GenderOption.Male.ToString(),
         PersonName = "Person Name"
      };
   }
}
