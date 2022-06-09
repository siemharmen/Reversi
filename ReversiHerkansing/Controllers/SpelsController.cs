using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReversiHerkansing.Model;
using ReversiHerkansing.Data;

namespace ReversiHerkansing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpelsController : ControllerBase
    {
        private readonly ReversiHerkansingContext _context;

        public SpelsController(ReversiHerkansingContext context)
        {
            _context = context;
        }

        // GET: api/Spels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spel>>> GetSpel()
        {
            return await _context.Spellen.ToListAsync();
        }
        [HttpGet("Afgelopen/{id}")]
        public Boolean IsAfgelopen(int id)
        {
            Spel spel = _context.Spellen.Find(id);
            Board board =  _context.Boards.SingleOrDefault(user => user.SpelID == id);

            spel.BoardCreate(board);

            return spel.Afgelopen();
        }

        
        // GET: api/Spels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Spel>> GetSpel(int id)
        {
            var spel = await _context.Spellen.FindAsync(id);

            if (spel == null)
            {
                return NotFound();
            }

            return spel;
        }
        [HttpGet("Mogelijke/{id}")]
        public async Task<ActionResult<List<int[]>>> GetMogelijke(int id)
        {
            var spel = await _context.Spellen.FindAsync(id);
            Board board = _context.Boards.FirstOrDefaultAsync(w => w.SpelID == spel.ID).Result;
            spel.BoardCreate(board);

            return spel.GetMogelijkeZetten();
        }
        [HttpGet("MogelijkeAflopen/{id}")]
        public async Task<ActionResult<List<int[]>>> GetMogelijkeAflopen(int id)
        {
            var spel = await _context.Spellen.FindAsync(id);
            Board board = _context.Boards.FirstOrDefaultAsync(w => w.SpelID == spel.ID).Result;
            spel.BoardCreate(board);

            return spel.GetMogelijkeZettenAflopen();
        }


        // PUT: api/Spels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpel(int id, Spel spel)
        {
            if (id != spel.ID)
            {
                return BadRequest();
            }

            _context.Entry(spel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Spels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Spel>> PostSpel(Spel spel)
        {
            spel.AandeBeurt = Kleur.Wit;
            _context.Spellen.Add(spel);

            Board board = new Board();
            board.Spel = spel;
            board.Row33 = Kleur.Wit;
            board.Row34 = Kleur.Zwart;
            board.Row43 = Kleur.Zwart;
            board.Row44 = Kleur.Wit;
            _context.Boards.Add(board);
          
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpel", new { id = spel.ID }, spel);
        }

        // DELETE: api/Spels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpel(int id)
        {
            var spel = await _context.Spellen.FindAsync(id);
            if (spel == null)
            {
                return NotFound();
            }

            _context.Spellen.Remove(spel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("SpelSpeler/{token}")]
        public Spel GetFromSpeler1(string token)
        {
            return _context.Spellen.FirstOrDefaultAsync(m => m.Speler1Token == token || m.Speler2Token == token).Result;
        }
        [HttpGet("Beurt/{token}")]
        public Kleur GetBeurt(String token)
        {
            return  _context.Spellen.FindAsync(token).Result.AandeBeurt;
        }
        [HttpPut("Zet/{spelId}/{rij}/{kolom}")]
        public Boolean Put(int spelId, int rij, int kolom)
        {   

            Spel spel = _context.Spellen.FirstOrDefaultAsync(x => x.ID == spelId).Result;
            Board boardold = _context.Boards.FirstOrDefaultAsync(w => w.SpelID == spel.ID).Result;
            spel.BoardCreate(boardold);

            int oldWitCount = 0;
            int oldZwartCount = 0;
            //vergelijken count board en oldboard
            foreach (Kleur kleur in spel.Bord)
            {
                if (kleur == Kleur.Wit)
                {
                    oldWitCount++;
                }
                if (kleur == Kleur.Zwart)
                {
                    oldZwartCount++;
                }
            }
            if (spel.ZetMogelijk(rij, kolom))
            {
                 spel.DoeZet(rij, kolom);
                spel.SpelToken = _context.Boards.FirstOrDefaultAsync(w => w.SpelID == spel.ID).Result.Id;
                Board board = spel.Boardupdate();

                if (spel.AandeBeurt == Kleur.Wit)
                {
                    spel.AandeBeurt = Kleur.Zwart;
                }
                else
                {
                    spel.AandeBeurt = Kleur.Wit;
                }
                //_context.Entry(board).State = EntityState.Modified;
                _context.Boards.Remove(boardold);
                _context.Boards.Add(board);
                _context.Spellen.Update(spel);

                int WitCount = 0;
                int ZwartCount = 0;
                //vergelijken count board en oldboard
                foreach (Kleur kleur in spel.Bord)
                {
                    if(kleur == Kleur.Wit)
                    {
                        WitCount++;
                    }
                    if(kleur == Kleur.Zwart)
                    {
                        ZwartCount++;
                    }
                }
                ReversiInfo reversiInfo = new ReversiInfo(1, spelId, ZwartCount,WitCount, ZwartCount-oldZwartCount, WitCount - oldWitCount);
                //get revsiinfo bij spelid count + 1 denk ik
                _context.ReversiInfo.Add(reversiInfo);

                _context.SaveChanges();

                return true;
                //_context.Update(board);
            }
            //_context.Spellen.FirstOrDefaultAsync(w => w.ID == spel.ID).Result.Bord = spel.Bord;






            return false;

        }
        [HttpGet("Mogelijk/{spelId}/{rij}/{kolom}")]
        public Boolean Mogelijk(int spelId, int rij, int kolom)
        {  
            Spel spel = _context.Spellen.FirstOrDefaultAsync(x => x.ID == spelId).Result;
            //_context.Spellen.FirstOrDefaultAsync(w => w.ID == spel.ID).Result.Bord = spel.Bord;
            return spel.ZetMogelijk(rij, kolom);

        }
        [HttpPut("Opgeven")]
        public Kleur Opgeven(int spelid)
        {
            Kleur kleur = _context.Spellen.FirstOrDefaultAsync(x => x.ID == spelid).Result.AandeBeurt;
            if (kleur == Kleur.Zwart)
            {
                kleur = Kleur.Wit; 
            }
            else
            {
                kleur = Kleur.Zwart;
            }
            return kleur;
        }

        private bool SpelExists(int id)
        {
            return _context.Spellen.Any(e => e.ID == id);
        }
    }
}
