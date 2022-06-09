using ReversiHerkansing.Data;
using ReversiHerkansing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiHerkansing.DAL
{
    public class SpelAccessReversi
    {
        public readonly ReversiHerkansingContext _context;


        public SpelAccessReversi(ReversiHerkansingContext context)
        {
            _context = context;
        }
        public Spel GetSpela(string spelToken)
        {
            return _context.Spellen.FirstOrDefault(m => m.Token == spelToken);
        }

        public static Spel GetSpel(string spelToken,ReversiHerkansingContext reversiHerkansingContext)
        {
            return reversiHerkansingContext.Spellen.FirstOrDefault(m => m.Token == spelToken);
        }
    }
}
