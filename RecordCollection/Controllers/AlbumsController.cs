using Microsoft.AspNetCore.Mvc;
using RecordCollection.DataAccess;
using RecordCollection.Models;

namespace RecordCollection.Controllers
{
    public class AlbumsController : Controller {

        private readonly RecordCollectionContext _context;
        private readonly Serilog.ILogger _logger;

        public AlbumsController(RecordCollectionContext context, Serilog.ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var albums = _context.Albums.ToList();

            if(!ModelState.IsValid)
            {
                _logger.Warning("Cannot find any albums in database for user to accese on index");
                return NotFound();
            }

            _logger.Information("User accesed index page for albums");
            return View(albums);
        }

        [Route("/albums/{id:int}")]
        public IActionResult Show(int? id)
        {
            if(id == null) 
            {
                _logger.Error("id for album is null");
                return NotFound();
            }

            var album = _context.Albums.FirstOrDefault(a => a.Id == id);

            if (!ModelState.IsValid)
            {
                _logger.Warning($"Could not find album with id: {id}");
                return NotFound();
            }

            _logger.Information("Album found successfully");
            return View(album);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Album album)
        {
            if (!ModelState.IsValid)
            {
                _logger.Warning("Album is null or incomplete when trying to create");
                return View("New", album);
            }

            _context.Albums.Add(album);
            _context.SaveChanges();

            _logger.Information("Album created successfully");

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("/albums/{id:int}")]
        public IActionResult Delete(int? id)
        {
            var album = _context.Albums.FirstOrDefault(a => a.Id == id);
            
            if (!ModelState.IsValid)
            {
                _logger.Warning($"Could not find album with id: {id}");
                return NotFound();
            }

            _context.Albums.Remove(album);
            _context.SaveChanges();

            _logger.Information($"Success! {album.Title} was removed from the database.");

            return RedirectToAction(nameof(Index));
        }
    }
}
