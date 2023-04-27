using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MVC_crud_sonu_.Context;
using MVC_crud_sonu_.Models;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static MVC_crud_sonu_.DAL.IJWTManagerRepository;

namespace MVC_crud_sonu_.DAL
{
      

    public class JWTManagerRepository : IJWTManagerRepository
    {

          
        private readonly AnimaMvcContext _context;

        private readonly IConfiguration iconfiguration;

        public JWTManagerRepository(IConfiguration iconfiguration , AnimaMvcContext context)
        {
            this.iconfiguration = iconfiguration;
            _context = context;

        }
        public async Task<Tokens> Authenticate(Users users)
        {
             List<Users> data = await _context.UsersAuth.ToListAsync();
            if (!data.Any(x => x.Name == users.Name && x.Password == users.Password))
            {
                return null;
            }
          
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                  {
             new Claim(ClaimTypes.Name, users.Name)
                  }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new Tokens { Token = tokenHandler.WriteToken(token) };

        }
    }
}
