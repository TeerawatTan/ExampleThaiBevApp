using ExampleThaiBevApp.Constants;
using ExampleThaiBevApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleThaiBevApp.Controllers
{
    public class DocumentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Documents.OrderBy(o => o.Id).ToListAsync());
        }

        [HttpPost]
        public IActionResult UpdateStatus(List<int> ids, string status, string remark)
        {
            try
            {
                var docs = _context.Documents.Where(d => ids.Contains(d.Id) && d.Status == "รออนุมัติ").ToList();

                foreach (var doc in docs)
                {
                    doc.Status = status == "อนุมัติ" ? ConstantAndEnum.STATUS_DOCUMENT_APPROVED
                        : status == "ไม่อนุมัติ" ? ConstantAndEnum.STATUS_DOCUMENT_NOT_APPROVED
                        : status == "รออนุมัติ" ? ConstantAndEnum.STATUS_DOCUMENT_WAIT_APPROVED
                        : status;
                    doc.Remark = remark;
                }

                _context.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

    }
}
