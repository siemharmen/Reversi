using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReversiMVC.Data;
using ReversiMVC.Models;
using Microsoft.AspNetCore.Identity;


namespace ReversiMVC.Controllers
{
    public class SpelersController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;

        private readonly ApplicationDbContext _context;

        public SpelersController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Spelers
        public async Task<IActionResult> Index()
        {
            ViewModels.ViewListSpelers viewListSpeler = new ViewModels.ViewListSpelers(_context.Spelers.ToList(),_context);
            return View(viewListSpeler);
            return View(await _context.Spelers.ToListAsync());
        }
        [Authorize(Policy = "Mediator")]
        public async Task<IActionResult> IndexDelete()
        {
            //ViewModels.ViewListSpelers viewListSpeler = new ViewModels.ViewListSpelers(_context.Spelers.ToList(), _context);
            //return View(viewListSpeler);
            return View(await _context.Spelers.ToListAsync());
        }

        // GET: Spelers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speler = await _context.Spelers
                .FirstOrDefaultAsync(m => m.Guid == id);
            if (speler == null)
            {
                return NotFound();
            }

            return View(speler);
        }

        // GET: Spelers/Create
        public IActionResult Create()
        {
            return View();
        }
   
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckCreate([Bind("Guid,Naam,AantalGewonnen,AantalVerloren,AantalGelijk")] Speler speler)
        {
            IdentityUser user =  await _userManager.FindByNameAsync(speler.Guid);
            //Claims = await _userManager.GetClaimsAsync(user);
            if (speler.Guid != null)
            {
                Response.Cookies.Delete("Cookie");
                Response.Cookies.Append("Cookie", speler.Guid.ToString());
            }
            //mischien index
            var spelerExist = await _context.Spelers.FirstOrDefaultAsync(m => m.Guid == speler.Guid);

            if (speler.Guid != null)
            {
                if (spelerExist == null)
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(speler);
                        var claim = new Claim("Speler", "Speler");
                        var result = await _userManager.AddClaimAsync(user, claim);
                        await _context.SaveChangesAsync();
                        TempData["Guid"] = speler.Guid;
                        return RedirectToAction("Index", "Spels");
                    }
                }
                else
                {
                    Spel SpelToken = await _context.Spellen.FirstOrDefaultAsync(m => m.Speler1Token == speler.Guid || m.Speler2Token == speler.Guid);
                    if (SpelToken != null)
                    {
                        //kijken redirect naar index spel maar doen doet index het niet
                        //tempdata guid meegeven  TempData["Guid"];
                        //navragen waarom alsnog naar checkcreate
                        int Token = SpelToken.ID;
                        if (Token != null)
                        {
                            TempData["Gameint"] = Token;
                            return RedirectToAction("Game", "Spels");
                        }
                        TempData["Guid"] = speler.Guid;

                        return RedirectToAction("Index", "Spels");
                    }
                    else
                    {
                        TempData["Guid"] = speler.Guid;
                        return RedirectToAction("Index", "Spels");
                    }
                }
            }
            else
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                //var claim = new Claim("Speler", "Speler");
                //var result = await _userManager.AddClaimAsync(user, claim);
                TempData["Guid"] = currentUserID;
                return RedirectToAction("Index", "Spels");
                //return View();
            }
            return RedirectToAction("Index", "Home");
            //return View("Details", spelerExist);
        }

        public IEnumerable<Claim> Claims { get; set; }

        // POST: Spelers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Guid,Naam,AantalGewonnen,AantalVerloren,AantalGelijk")] Speler speler)
        {
            if (ModelState.IsValid)
            {

                _context.Add(speler);

                

                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Spels");
                //return RedirectToAction(nameof(Index));
            }
            return View(speler);
        }

        // GET: Spelers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speler = await _context.Spelers.FindAsync(id);
            if (speler == null)
            {
                return NotFound();
            }
            return View(speler);
        }

        // POST: Spelers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Guid,Naam,AantalGewonnen,AantalVerloren,AantalGelijk")] Speler speler)
        {
            if (id != speler.Guid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpelerExists(speler.Guid))
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
            return View(speler);
        }

        // GET: Spelers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speler = await _context.Spelers
                .FirstOrDefaultAsync(m => m.Guid == id);
            if (speler == null)
            {
                return NotFound();
            }

            return View(speler);
        }

        // POST: Spelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var speler = await _context.Spelers.FindAsync(id);
            Spel spel = _context.Spellen.FirstOrDefaultAsync(m => m.Speler1Token == id || m.Speler2Token == id).Result;
            Board board = await _context.Boards.FirstOrDefaultAsync(m => m.Spel == spel);
            IEnumerable<IdentityUser> Users = _context.Users.ToList();

            IdentityUser user =  Users.First(c => c.UserName == id);

            _context.Users.Remove(user); 

            if (board != null)  
            {
                _context.Boards.Remove(board);
            }
            if (spel != null)
            {
                _context.Spellen.Remove(spel);
            }
            if(speler != null)
            {
                _context.Spelers.Remove(speler);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpelerExists(string id)
        {
            return _context.Spelers.Any(e => e.Guid == id);
        }
    }
}
