using ClassRoom.Interfaces;
using ClassRoom.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace ClassRoom.Services
{
    public class StudentService : SigningService<Student>,IUser<Student>, IStudent
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context,Jwt jwt):base(jwt)
        {
            _context = context;
        }

        public async Task<StudentToken> refreshToken(string refreshToken)
        {
            var student = await _context.Students.Include(a => a.tokens).FirstOrDefaultAsync(a => a.tokens.Any(a => a.token == refreshToken));
            if (student == null)
            {
                throw new ArgumentException("user is not found");
            }

            var token = student.tokens.Where(a => a.token == refreshToken).FirstOrDefault();
            
            if(token == null)
            {
                throw new ArgumentException("decodedToken is not found");
            }

            if (!token.isActive)
            {
                token.revoked = DateTime.Now;
                var newRefreshToken = await generateRefreshToken(student);
                student.tokens.Add(newRefreshToken);
                await _context.SaveChangesAsync();

                var newJWtToken = generateJwtToken(student);
                return newRefreshToken;
            }
            else
            {
                return token;
            }
        }

        protected async Task<StudentToken> generateRefreshToken(Student student)
        {
            var randomBytes = new byte[32];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            var studentToken= new StudentToken
            {
                user = student,
                userId =student.id,
                token = Convert.ToBase64String(randomBytes),
                expires = DateTime.Now.AddMinutes(1),
                created = DateTime.Now,
            };

            _context.studentTokens.Add(studentToken);
            await _context.SaveChangesAsync();
            return studentToken;
        }
        public async Task deleteToken(int userId)
        {
            var userToken=await _context.studentTokens.Where(a=>a.userId == userId).FirstOrDefaultAsync();
            if (userToken == null)
            {
                throw new ArgumentException("user token is not found");
            }
            _context.studentTokens.Remove(userToken);
            await _context.SaveChangesAsync();
        }
        public async Task<SigningResponse> signIn(string email, string password)
        {
            var student=await _context.Students.Where(a=>a.email==email).FirstOrDefaultAsync();
            if(student == null || !(verifyPassword(password,student.password)))
            {
                throw new ArgumentException("student is not found");
            }
            var accessToken = generateJwtToken(student);
            var refreshToken = await generateRefreshToken(student);

            
            student.tokens.Add(refreshToken);
            await _context.SaveChangesAsync();

            return new SigningResponse 
            { 
                user=student,
                token = accessToken,
            };
        }

        public async Task deleteStudent(int id)
        {
            var student = await getStudent(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<Student> getStudent(int id)
        {
            var student = await _context.Students.Where(a => a.id == id).FirstOrDefaultAsync();
            if (student == null)
            {
                throw new ArgumentException("student is not found");
            }
            return student;
        }

        public async Task<Student> signup(string userName, string email, string password)
        {
            var newStudent=new Student(userName,email,hashPassword(password));
            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync();

            generateJwtToken(newStudent);
            await generateRefreshToken(newStudent);
            return newStudent;
        }
    }
}
