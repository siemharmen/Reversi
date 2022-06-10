using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReversiMVC.Data;
using ReversiMVC.Hubs;
using ReversiMVC.Models;

namespace ReversiMVC.Controllers
{
    public class SpelsController : Controller
    {
        //terug zetten naar private als 
        private readonly ApplicationDbContext _context;
        private readonly  IHttpClientFactory _httpCLientFactory;
        private readonly static IHttpClientFactory test;

        public SpelsController(ApplicationDbContext context, IHttpClientFactory _httpCLientFactory)
        {
            this._httpCLientFactory = _httpCLientFactory;
            _context = context;
        }

        public async Task<IActionResult> getBoard(int spelid) {
            HttpController httpController = new HttpController(_httpCLientFactory);
             await httpController.GetBoard(spelid);
            //Board mogelijk =
            return View();
        }
            // GET: Spels
            public async Task<IActionResult> Index()
        {
            HttpController httpController = new HttpController(_httpCLientFactory);
            //Boolean mogelijk = await httpController.
            //();
            var guid = TempData["Guid"];
            if (guid != null)
            {
                Response.Cookies.Delete("Cookie");
                Response.Cookies.Append("Cookie", guid.ToString());
            }
            else
            {
                guid = Request.Cookies["Cookie"];
            }  
            return View(await _context.Spellen.Where(m => m.Speler1Token != guid.ToString() && (m.Speler2Token == "" || m.Speler2Token == null)).ToListAsync());
            //return View(await _context.Spellen.ToListAsync());
        }
        public async Task<IActionResult> ZetMogelijk(int spelid, int rij, int kolom)
        {
            //configMap test = JsonSerializer.Serialize(configMap);
            HttpController httpController = new HttpController(_httpCLientFactory);
            Boolean mogelijk = await httpController.Doezet(spelid,rij,kolom);
            //Boolean zet = await httpController.Doezet(spelid, rij, kolom);
            await _context.SaveChangesAsync(); 
            if (mogelijk == true)
             //redirect to action game
            {   
                TempData["Afgelopen"] = await httpController.Afgelopen(spelid);
                TempData["Gameint"] = spelid;
                return RedirectToAction("Game", "Spels");
                //return RedirectToAction("Index", "Home");
                //return true;
            }
                TempData["Afgelopen"] = await httpController.Afgelopen(spelid); 
                TempData["Gameint"] = spelid;
                return RedirectToAction("Game", "Spels");
                return RedirectToAction("Index", "Home");
            //return false;
            //return View(await _context.Spellen.ToListAsync());
        }
        public async Task DoeZet(int spelid, int rij, int kolom)
        {
            HttpController httpController = new HttpController(_httpCLientFactory);
            Boolean mogelijk = await httpController.ZetMogelijk(spelid, rij, kolom);
            Boolean zet = await httpController.Doezet(spelid, rij, kolom);
            await _context.SaveChangesAsync();
            //return View(await _context.Spellen.ToListAsync());
        }

        // GET: Spels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spel = await _context.Spellen
                .FirstOrDefaultAsync(m => m.ID == id);
            if (spel == null)
            {
                return NotFound();
            }

            return View(spel);
        }
        public async Task<IActionResult> Join(int? id)
        {
            if (id == null)
            {
                int game = Convert.ToInt32(TempData["Gameint"]);
                try
                {
                    Spel SpelToken = await _context.Spellen.FirstOrDefaultAsync(m => m.ID == game);
                    if (SpelToken == null)
                    {
                        return NotFound();
                    }
                    return View(SpelToken);
                }
                catch
                {
                    throw;
                }

               
            }

            var spel = await _context.Spellen.FirstOrDefaultAsync(m => m.ID == id);
            if (spel == null)
            {
                return NotFound();
            }
            return View(spel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Game(int spelerID)
        {
            HttpController httpController = new HttpController(_httpCLientFactory);

            Spel newSpel = await _context.Spellen.FirstOrDefaultAsync(m => m.ID == spelerID);
            //breakpoint kijken kijken of ze allemaal krijgen


            newSpel.Speler2Token = Request.Cookies["Cookie"];

            Board board2 = _context.Boards.FirstOrDefault(m => m.Spel == newSpel);

            //hier fout bij join
            newSpel.BoardCreate(board2);

            ViewModels.ViewGame viewGame = new ViewModels.ViewGame(_context, newSpel, newSpel.Speler2Token,_httpCLientFactory);
            viewGame.Afgelopen = await httpController.Afgelopen(newSpel.ID);
            Board board1 = await httpController.GetBoard(newSpel.ID);
            viewGame.board = board1;
            viewGame.Mogeljke = await httpController.GetMogelijke(newSpel.ID);
            viewGame.AfgelpenZetten = await httpController.GetMogelijkeAfgelopen(newSpel.ID);
            //boardload
            _context.Update(newSpel);
            await _context.SaveChangesAsync();
            //_context.Add(Newspel);
            //        _repoEaEnrollment.Detach(model);
            //await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
            return View(viewGame);
            return View(newSpel);
        }
        public async Task<IActionResult> GameJoin(int id)
        {
            //kan weg
            var spel = await _context.Spellen.FirstOrDefaultAsync(m => m.ID == id);
            spel.Speler2Token = Request.Cookies["Cookie"];
            spel.Ingame = 2;
            Board board = await _context.Boards.FirstOrDefaultAsync(m => m.SpelID == spel.ID);
            //vage error
            spel.BoardCreate(board);
            ViewModels.ViewGame viewGame = new ViewModels.ViewGame(_context, spel, spel.Speler1Token,_httpCLientFactory);
            HttpController httpController = new HttpController(_httpCLientFactory);
            viewGame.Afgelopen = await httpController.Afgelopen(spel.ID);

            Board board1 = await httpController.GetBoard(spel.ID);
            viewGame.board = board1;
            viewGame.Mogeljke = await httpController.GetMogelijke(spel.ID);
            viewGame.AfgelpenZetten = await httpController.GetMogelijkeAfgelopen(spel.ID);

            _context.Update(spel);
            await _context.SaveChangesAsync();
            if (spel == null)
            {
                return NotFound();
            }
            return RedirectToAction("Game");
        }
        public async Task<IActionResult> Game(int? id)
        {
            //hier gebeurt het

            if (id != null)
            {
                ViewBag.Join = true;
                string Token = Request.Cookies["Cookie"];
                Spel spelToken = await _context.Spellen.FirstOrDefaultAsync(m => m.ID == id);
                //hier waarschijnlijk

                //spelToken.Speler2Token = Request.Cookies["Cookie"];
                //spelToken.Ingame = 2;
                HttpController httpController1 = new HttpController(_httpCLientFactory);
               // _context.Update(spelToken);
                Board board2 = _context.Boards.FirstOrDefault(m => m.Spel == spelToken);

                //hier fout bij join
                spelToken.BoardCreate(board2);

                ViewModels.ViewGame viewGame2 = new ViewModels.ViewGame(_context, spelToken, spelToken.Speler2Token,_httpCLientFactory);
                viewGame2.Afgelopen = await httpController1.Afgelopen((int)id);

                viewGame2.board = board2;
                viewGame2.Mogeljke = await httpController1.GetMogelijke(spelToken.ID);
                viewGame2.AfgelpenZetten = await httpController1.GetMogelijkeAfgelopen(spelToken.ID);

                await _context.SaveChangesAsync();
                return View(viewGame2);
                return View(spelToken);
            }

            //id = Convert.ToInt32(TempData["Gameint"]);
            Boolean afgelopen = Convert.ToBoolean(TempData["Afgelopen"]);

            var spel = await _context.Spellen.FirstOrDefaultAsync(m => m.ID == id);

            if(spel == null)
            {
                spel = await _context.Spellen.FirstOrDefaultAsync(m => m.Speler1Token == Request.Cookies["Cookie"]);
            }
            if (spel == null)
            {
                spel = await _context.Spellen.FirstOrDefaultAsync(m => m.Speler2Token == Request.Cookies["Cookie"]);
            }


            Board board = await _context.Boards.FirstOrDefaultAsync(m => m.SpelID == spel.ID);
            //vage error
            spel.BoardCreate(board);
            ViewModels.ViewGame viewGame = new ViewModels.ViewGame(_context, spel,spel.Speler1Token,_httpCLientFactory);
            HttpController httpController = new HttpController(_httpCLientFactory);
            viewGame.Afgelopen = await httpController.Afgelopen(spel.ID);

            Board board1 = await httpController.GetBoard(spel.ID);
            viewGame.board = board1;
            viewGame.Mogeljke = await httpController.GetMogelijke(spel.ID);
            viewGame.AfgelpenZetten = await httpController.GetMogelijkeAfgelopen(spel.ID);


            if (spel == null)
            {
                return NotFound();
            }
            return View(viewGame);
            return View(spel);
        }

        // GET: Spels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Omschrijving,AandeBeurt,Speler1Token,Speler2Token")] Spel spel)
        {
            if (ModelState.IsValid)
            {
                spel.Speler1Token = Request.Cookies["Cookie"];
                spel.Speler2Token = "";
                spel.AandeBeurt = Kleur.Wit;
                spel.Ingame = 0;

                _context.Add(spel);

                Board board = new Board();
                board.Id = spel.ID;
                board.Spel = spel;

                board.Row33 = Kleur.Zwart;
                board.Row34 = Kleur.Wit;
                board.Row43 = Kleur.Wit;
                board.Row44 = Kleur.Zwart;

                _context.Add(board);


                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View(spel);
        }

        // GET: Spels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spel = await _context.Spellen.FindAsync(id);
            if (spel == null)
            {
                return NotFound();
            }
            return View(spel);
        }

        // POST: Spels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Omschrijving,AandeBeurt,Speler1Token,Speler2Token")] Spel spel)
        {
            if (id != spel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Spel newSpel = await _context.Spellen.FirstOrDefaultAsync(m => m.ID == id);
                    //breakpoint kijken kijken of ze allemaal krijgen
                    //newSpel.Speler2Token = spel.Speler2Token;
                    newSpel.Ingame = 2;
                    newSpel.Speler2Token = Request.Cookies["Cookie"];
                    _context.Update(newSpel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpelExists(spel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(spel);
        }

        // GET: Spels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spel = await _context.Spellen
                .FirstOrDefaultAsync(m => m.ID == id);
            spel.Ingame--;

            Speler speler = await _context.Spelers.FirstOrDefaultAsync(m => m.Guid == Request.Cookies["Cookie"]);
            Spel newSpel = await _context.Spellen.FirstOrDefaultAsync(m => m.ID == id);
            Board board = await _context.Boards.FirstOrDefaultAsync(m => m.Spel.ID == spel.ID);

            newSpel.BoardCreate(board);
            if (newSpel.OverwegendeKleur(newSpel.Bord) == Kleur.Wit)
            {
                if (newSpel.Speler1Token == speler.Guid)
                {
                    speler.AantalGewonnen += 1;
                    _context.Update(speler);
                }
                else
                {
                    speler.AantalVerloren += 1;
                    _context.Update(speler);
                }
            }
            if (newSpel.OverwegendeKleur(newSpel.Bord) == Kleur.Zwart)
            {
                if (newSpel.Speler2Token == speler.Guid)
                {
                    speler.AantalGewonnen += 1;
                    _context.Update(speler);
                }
                else
                {
                    speler.AantalVerloren += 1;
                    _context.Update(speler);
                }
            }
            if (newSpel.OverwegendeKleur(newSpel.Bord) == Kleur.Geen)
            {
                speler.AantalGelijk += 1;
                _context.Update(speler);

            }

            if (spel == null)
            {
                return NotFound();
            }
            if (spel.Ingame == 0)
            {
                _context.Boards.Remove(board);
                _context.Spellen.Remove(spel);


                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (spel.Speler1Token == Request.Cookies["Cookie"])
            {
                spel.Speler1Token = Request.Cookies["Cookie"] + "\u00A0";
            }
            else
            {
                spel.Speler2Token = Request.Cookies["Cookie"] + "\u00A0";
            }
            _context.Update(spel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            return View(spel);
        }
        public async Task<IActionResult> GeefOp(int id,string user)
        {

            var spel = await _context.Spellen
                .FirstOrDefaultAsync(m => m.ID == id);

            Speler speler = await _context.Spelers.FirstOrDefaultAsync(m => m.Guid == Request.Cookies["Cookie"]);

            speler.AantalVerloren += 1;
            _context.Update(speler);

            if (spel == null)
            {
                return NotFound();
            }   
            if (spel.Speler1Token == Request.Cookies["Cookie"])
            {
                spel.Speler1Token = Request.Cookies["Cookie"] + "\u00A0";
            }
            else
            {
                spel.Speler2Token = Request.Cookies["Cookie"] + "\u00A0";
            }
            spel.Ingame = 1;
            _context.Update(spel);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Leave(int id)
        {

            var spel = await _context.Spellen
                .FirstOrDefaultAsync(m => m.ID == id);
            Board board = await _context.Boards.FirstOrDefaultAsync(m => m.Spel == spel);

            if (spel == null)
            {
                return NotFound();
            }
            _context.Boards.Remove(board);
            _context.Spellen.Remove(spel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ClaimWinst(int id, string user)
        {

            var spel = await _context.Spellen
                .FirstOrDefaultAsync(m => m.ID == id);
            spel.Ingame--;

            Speler speler = await _context.Spelers.FirstOrDefaultAsync(m => m.Guid == Request.Cookies["Cookie"]);
            Board board = await _context.Boards.FirstOrDefaultAsync(m => m.Spel == spel);

            speler.AantalGewonnen += 1;
            _context.Update(speler);

            if (spel == null)
            {
                return NotFound();
            }
            _context.Update(speler);
            _context.Boards.Remove(board);
            _context.Spellen.Remove(spel);


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // POST: Spels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, [Bind("ID")] Spel sp)
        {
            var spel = _context.Spellen.FirstOrDefault(m => m.ID == id);
            spel.Ingame--;
            if (spel.Ingame == 0)
            {
                Board board = await _context.Boards.FirstOrDefaultAsync(m => m.Spel == spel);
                _context.Boards.Remove(board);
                _context.Spellen.Remove(spel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (spel.Speler1Token == Request.Cookies["Cookie"])
            {
                spel.Speler1Token = Request.Cookies["Cookie"] + "\u00A0";
            }
            else
            {
                spel.Speler2Token = Request.Cookies["Cookie"] + "\u00A0";
            }
            _context.Update(spel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        private bool SpelExists(int id)
        {
            return _context.Spellen.Any(e => e.ID == id);
        }
    }
}
