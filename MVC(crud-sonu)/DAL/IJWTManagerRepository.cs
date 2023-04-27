using Microsoft.AspNetCore.Mvc;
using MVC_crud_sonu_.Models;

namespace MVC_crud_sonu_.DAL
{
        public interface IJWTManagerRepository
        {
           Task<Tokens> Authenticate(Users users);
    }
}
