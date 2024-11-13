using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DRCaseLib;

namespace RecordREST.Controllers
{
    [Route("records")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly RecordRepo _recordRepo;

        public RecordController(RecordRepo recordRepo)
        {
            _recordRepo = recordRepo;
        }


        [HttpGet]
        public IEnumerable<Record> Get()
        {
            return _recordRepo.GetAllRecords();
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public ActionResult<Record> Get(int id)
        {
            if (id == 0) { return BadRequest("Id not recognized"); }
            Record record = _recordRepo.GetById(id);
            if (record == null)
            {
                return NotFound("Record not found");
            }
            return Ok(record);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("FilterWP")]
        public IEnumerable<Record> FilterWP([FromQuery] string title)
        {
            return _recordRepo.GetAllRecords().Where(record => record.Title.Contains(title));
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("Search")]
        public ActionResult<IEnumerable<Record>> Get([FromQuery] string? title = null, [FromQuery] string? artist = null, [FromQuery] int? duration = null, [FromQuery] int? publicationYear = null, [FromQuery] string? orderBy = null)
        {
            var records = _recordRepo.Get(title, artist, duration, publicationYear, orderBy);
            return Ok(records);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]

        public ActionResult<Record> Post([FromBody] Record value)
        {
            if (value == null)
            {
                return NotFound("Its Null");
            }
            _recordRepo.Add(value);
            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        // PUT api/<WoodPelletsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Record> Put(int id, [FromBody] Record value)
        {
            Record record = _recordRepo.GetById(id);
            if (record == null)
            {
                return NotFound("No Such Id: " + id);
            }
            return Ok(record);
        }

        // DELETE api/<WoodpelletsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Record> Delete(int id)
        {
            Record record = _recordRepo.GetById(id);
            if (record == null)
            {
                return NotFound("No Such Id: " + id);
            }
            return Ok(record);
        }







    }
}
