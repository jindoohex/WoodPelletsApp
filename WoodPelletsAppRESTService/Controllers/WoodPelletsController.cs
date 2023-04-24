using Microsoft.AspNetCore.Mvc;
using WoodPelletsAppLibrary.model;
using WoodPelletsAppRESTService.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WoodPelletsAppRESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WoodPelletsController : ControllerBase
    {
        private static IWoodPelletsManager wdmgr = new WoodPelletsManager();

        // GET: api/<WoodPelletsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            List<WoodPellet> woodPelletList = wdmgr.GetAll();
            return (woodPelletList.Count == 0) ? NoContent() : Ok(woodPelletList);
        }

        // GET api/<WoodPelletsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            try
            {
                WoodPellet? woodpellet = wdmgr.GetById(id);
                return Ok(woodpellet);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        // POST api/<WoodPelletsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Post([FromBody] WoodPellet woodPellet)
        {
            try
            {
                WoodPellet newWoodPellet = wdmgr.Create(woodPellet);
                string uri = "api/WoodPellets" + newWoodPellet.Id;
                return Created(uri, newWoodPellet);
            }
            catch (ArgumentException ae)
            {
                return Conflict(ae);
            }
        }

        // PUT api/<WoodPelletsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WoodPellet woodPellet)
        {
            try
            {
                return Ok(wdmgr.Update(id, woodPellet));
            }
            catch (KeyNotFoundException kfne)
            {
                return NotFound(kfne.Message);
            }
        }
    }
}
