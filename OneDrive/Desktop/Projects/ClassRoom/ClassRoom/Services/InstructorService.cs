using ClassRoom.Interfaces;
using ClassRoom.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace ClassRoom.Services
{
    public class InstructorService : SigningService<Instructor>,IUser<Instructor>,IInstructor
    {
        private readonly AppDbContext _context;
        public InstructorService(AppDbContext context,Jwt jwt) : base(jwt)
        {
            _context = context;
        }
        public async Task<InstructorToken> refreshToken(string refreshToken)
        {
            var instructor=await _context.Instructors.Include(a=>a.tokens).Where(a=>a.tokens.Any(a=>a.token==refreshToken)).FirstOrDefaultAsync();
            if(instructor==null)
            {
                throw new ArgumentException("instructor is not found");
            }
            var token=instructor.tokens.Where(a=>a.token==refreshToken).FirstOrDefault();
            if(token==null)
            {
                throw new ArgumentException("token is not found");
            }
            if(token.isActive==false)
            {
                token.revoked=DateTime.Now;
                var newRefreshToken = generateRefreshToken(instructor);
                instructor.tokens.Add(newRefreshToken);
                await _context.SaveChangesAsync();
                var newJWtToken = generateJwtToken(instructor);
                return newRefreshToken;   
            }
            return token;
        }

        protected InstructorToken generateRefreshToken(Instructor instructor)
        {
            var randomBytes = new byte[32];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return new InstructorToken
            {
                user = instructor,
                userId = instructor.id,
                token = Convert.ToBase64String(randomBytes),
                expires = DateTime.Now.AddMinutes(1),
                created = DateTime.Now,
            };
        }
        public async Task deleteToken(int instructorId)
        {
            var userToken = await _context.instructorTokens.Where(a => a.userId == instructorId).FirstOrDefaultAsync();
            if (userToken == null)
            {
                throw new ArgumentException("user token is not found");
            }
            _context.instructorTokens.Remove(userToken);
            await _context.SaveChangesAsync();
        }
        public async Task deleteInstructor(int id)
        {
            var instructor=await getInstructor(id);
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
        }

        public async Task<Instructor> getInstructor(int id)
        {
            var instructor=await _context.Instructors.Where(a=>a.id==id).FirstOrDefaultAsync();
            if (instructor == null)
            {
                throw new ArgumentException("instructor is not found");
            }
            return instructor;
        }

        public async Task<SigningResponse> signIn(string email, string password)
        {
            var instructor=await _context.Instructors.Where(a=>a.email==email).FirstOrDefaultAsync();
            if (instructor==null || !verifyPassword(password,instructor.password))
            {
                throw new ArgumentException("instructor is not found");
            }
            var accessToken = generateJwtToken(instructor);
            var refreshToken = generateRefreshToken(instructor);

            _context.instructorTokens.Add(refreshToken);
            await _context.SaveChangesAsync();
            instructor.tokens.Add(refreshToken);
            await _context.SaveChangesAsync();
            return new SigningResponse
            {
                user = instructor,
                token = accessToken,
            };
        }

        public async Task<Instructor> signup(string userName, string email, string password)
        {
            var instructor=new Instructor(userName,email,hashPassword(password));
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
            return instructor;
        }
    }
}
