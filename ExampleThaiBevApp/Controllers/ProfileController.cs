using Microsoft.AspNetCore.Mvc;
using ExampleThaiBevApp.Data;
using ExampleThaiBevApp.Dtos;
using ExampleThaiBevApp.Models;

namespace ExampleThaiBevApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProfileDto profileDto)
        {
            if (ModelState.IsValid)
            {
                var newProfile = new Profile
                {
                    FirstName = profileDto.FirstName,
                    LastName = profileDto.LastName,
                    Email = profileDto.Email,
                    Phone = profileDto.Phone,
                    ProfilePicture = profileDto.ProfilePicture,
                    BirthDate = profileDto.BirthDate,
                    Occupation = profileDto.Occupation,
                    Sex = profileDto.Sex,
                };
                _context.Profiles.Add(newProfile);
                _context.SaveChanges();

                return Json(new { success = true, id = newProfile.Id });
            }
            return Json(new { success = false });
        }

    }
}
