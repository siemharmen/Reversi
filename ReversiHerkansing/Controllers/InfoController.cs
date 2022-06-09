using Microsoft.AspNetCore.Mvc;
using ReversiHerkansing.Data;
using ReversiHerkansing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReversiHerkansing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly ReversiHerkansingContext _context;

        public InfoController(ReversiHerkansingContext context)
        {
            _context = context;
        }

        // GET: api/<InfoController>
        [HttpGet]
        public IEnumerable<ReversiInfo> Get()
        {
            return _context.ReversiInfo.ToList();
        }
        //get where spelid
        [HttpGet("BySpelID/{spelId}")]
        public IEnumerable<ReversiInfo> GetSpelid(int spelId)
        {
            return _context.ReversiInfo.ToList().Where(element => element.SpelId == spelId);
        }
        // GET api/<InfoController>/5
        [HttpGet("{id}")]
        public ReversiInfo Get(int id)
        {
            ReversiInfo reversi = _context.ReversiInfo.First(user => user.Id == id);
            if (reversi == null)
            {
                return null;
            }
            return reversi;
        }

        // POST api/<InfoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        [HttpPost("Add")]
        public async Task<ActionResult<ReversiInfo>> PostReversiInfo([FromBody] int beurt, int SpelId, int Zwart, int Wit, int addZwart, int addWit)
        {
            ReversiInfo reversiInfo = new ReversiInfo(beurt, SpelId, Zwart, Wit, addZwart, addWit);
            _context.ReversiInfo.Add(reversiInfo);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetReversiInfo", new { id = reversiInfo.Id }, reversiInfo);
        }

            // PUT api/<InfoController>/5
            [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InfoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
