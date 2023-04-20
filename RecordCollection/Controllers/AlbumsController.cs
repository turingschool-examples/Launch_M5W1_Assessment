using Microsoft.AspNetCore.Mvc;
using RecordCollection.DataAccess;

namespace RecordCollection.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly RecordCollectionContext _context;

        public AlbumsController(RecordCollectionContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var albums = _context.Albums.ToList();
            
            return View(albums);
        }
    }
}
