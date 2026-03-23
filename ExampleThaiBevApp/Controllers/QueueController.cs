using ExampleThaiBevApp.Data;
using ExampleThaiBevApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleThaiBevApp.Controllers
{
    public class QueueController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QueueController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string GetNextQueue(string currentQue)
        {
            if (string.IsNullOrEmpty(currentQue) || currentQue == "00") return "A0";

            char letter = currentQue[0];
            int number = int.Parse(currentQue[1].ToString());

            if (number < 9)
            {
                number++;
            }
            else
            {
                number = 0;
                letter++;

                if (letter > 'Z') letter = 'A';
            }

            return $"{letter}{number}";
        }

        [HttpPost]
        public IActionResult TakeQueue()
        {
            var lastQue = _context.Queues.OrderByDescending(x => x.Id).FirstOrDefault();
            string nextQue = GetNextQueue(lastQue?.QueueNo!);

            var newQueue = new Queue
            {
                QueueNo = nextQue,
                CreatedAt = DateTime.Now
            };
            _context.Queues.Add(newQueue);
            _context.SaveChanges();

            return RedirectToAction("Detail", new { id = newQueue.Id });
        }

        public IActionResult Detail(int id)
        {
            var que = _context.Queues.Find(id);
            if (que != null)
                return View(que);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Reset()
        {
            var que = _context.Queues.OrderByDescending(o => o.Id).FirstOrDefault();
            if (que != null)
                return View(que);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Reset(int id)
        {
            try
            {
                var que = _context.Queues.Find(id);
                if (que != null)
                {
                    var newQueue = new Queue
                    {
                        QueueNo = "00",
                        CreatedAt = DateTime.Now
                    };
                    _context.Queues.Add(newQueue);
                    _context.SaveChanges();
                }
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }
    }
}
