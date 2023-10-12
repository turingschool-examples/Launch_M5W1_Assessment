using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecordCollection.DataAccess;
using Serilog;

namespace RecordCollection.Controllers
{
    [Route("api/albums")]
    [ApiController]
    public class AlbumsAPIController : ControllerBase
    {
        private readonly RecordCollectionContext _context;
        private readonly Serilog.ILogger _logger;

        public AlbumsAPIController(RecordCollectionContext context, Serilog.ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult GetAll()
        {
            var albums = _context.Albums.ToList();
            
            if (!ModelState.IsValid)
            {
                _logger.Warning("Cannot find albums in database");
                return NotFound();
            }

            _logger.Information("Found all albums in database");
            return new JsonResult(albums);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int? id)
        {
            if (id == null)
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

            return new JsonResult(album);
        }

        [HttpDelete("{id}")]
        public void DeleteOne(int? id)
        {
            if (id == null)
            {
                _logger.Error("id for album is null");
            }

            var album = _context.Albums.FirstOrDefault(a => a.Id == id);

            if(!ModelState.IsValid)
            {
                _logger.Warning("Cannot find albums in database");
            }

            _context.Albums.Remove(album);
            _context.SaveChanges();
        }
    }
}
