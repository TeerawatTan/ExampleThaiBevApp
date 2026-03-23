using ExampleThaiBevApp.Data;
using ExampleThaiBevApp.Dtos;
using ExampleThaiBevApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExampleThaiBevApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtSettingDto _jwtSettings;

        public UserController(ApplicationDbContext context, IOptions<JwtSettingDto> jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var findUser = await _context.Users.FirstOrDefaultAsync(f => f.Username == loginDto.Username);
                if (findUser != null && BCrypt.Net.BCrypt.Verify(loginDto.Password, findUser.Password))
                {
                    var token = GenerateJwtToken(findUser.Username);

                    // เก็บ Token ไว้ใน Cookie หรือ LocalStorage เพื่อใช้ Validate ในหน้าถัดไป
                    Response.Cookies.Append("jwt", token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        Expires = DateTime.Now.AddHours(1)
                    });

                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Login));
            }
            return View(loginDto);
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (registerDto.Password != registerDto.ConfirmPassword)
            {
                ViewBag.Error = "รหัสผ่านไม่ตรงกัน";
                return View(registerDto);
            }

            User user = new();
            user.Username = registerDto.Username!;
            user.Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            user.Fullname = registerDto.Username!;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Login));
        }

        private string GenerateJwtToken(string username)
        {
            var claims = new[] { new Claim(ClaimTypes.Name, username) };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(Convert.ToInt32(_jwtSettings.ExpireInHours)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
