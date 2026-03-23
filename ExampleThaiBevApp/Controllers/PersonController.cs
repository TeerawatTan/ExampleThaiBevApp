using ExampleThaiBevApp.Data;
using ExampleThaiBevApp.Dtos;
using ExampleThaiBevApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleThaiBevApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _context.Persons.Select(s => new PersonDto
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Birthdate = s.Birthdate,
                Address = s.Address,
            }).OrderBy(o => o.Id).ToListAsync();
            return View(list);
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Persons.Add(person);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
