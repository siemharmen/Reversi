using ReversiHerkansing.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiHerkansing.Model
{
    public class Spel
    {
        public int ID { get; set; }
        public string Omschrijving { get; set; }
        [NotMapped]
        public string Token { get; set; }
        public string Speler1Token { get; set; }
        public string Speler2Token { get; set; }

        public Kleur AandeBeurt { get; set; }
        [NotMapped]
        public Kleur[,] Bord;
        [NotMapped]
        public int SpelToken;

        public Spel()
        {
            Bord = new Kleur[,]{
                { Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen}, //0
                { Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen}, //1
                { Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen}, //2
                { Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Wit,Kleur.Zwart,Kleur.Geen,Kleur.Geen,Kleur.Geen}, //3
                { Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Zwart,Kleur.Wit,Kleur.Geen,Kleur.Geen,Kleur.Geen}, //4
                { Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen}, //5
                { Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen}, //6
                { Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen}  //7

            };
        }
        public void BoardCreate(Board board)
        {
            SpelToken = board.Id;
            Bord = new Kleur[,] {
                    { board.Row00, board.Row01,board.Row02,board.Row03,board.Row04,board.Row05,board.Row06,board.Row07},
                    { board.Row10, board.Row11,board.Row12,board.Row13,board.Row14,board.Row15,board.Row16,board.Row17},
                    { board.Row20, board.Row21,board.Row22,board.Row23,board.Row24,board.Row25,board.Row26,board.Row27},
                    { board.Row30, board.Row31,board.Row32,board.Row33,board.Row34,board.Row35,board.Row36,board.Row37},
                    { board.Row40, board.Row41,board.Row42,board.Row43,board.Row44,board.Row45,board.Row46,board.Row47},
                    { board.Row50, board.Row51,board.Row52,board.Row53,board.Row54,board.Row55,board.Row56,board.Row57},
                    { board.Row60, board.Row61,board.Row62,board.Row63,board.Row64,board.Row65,board.Row66,board.Row67},
                    { board.Row70, board.Row71,board.Row72,board.Row73,board.Row74,board.Row75,board.Row76,board.Row77},
                };
        }
        public Board Boardupdate()
        {
            Board bord = new Board(SpelToken,null,ID,
                Bord[0, 0], Bord[0, 1], Bord[0, 2], Bord[0, 3], Bord[0, 4], Bord[0, 5], Bord[0, 6], Bord[0, 7],
                Bord[1, 0], Bord[1, 1], Bord[1, 2], Bord[1, 3], Bord[1, 4], Bord[1, 5], Bord[1, 6], Bord[1, 7],
                Bord[2, 0], Bord[2, 1], Bord[2, 2], Bord[2, 3], Bord[2, 4], Bord[2, 5], Bord[2, 6], Bord[2, 7],
                Bord[3, 0], Bord[3, 1], Bord[3, 2], Bord[3, 3], Bord[3, 4], Bord[3, 5], Bord[3, 6], Bord[3, 7],
                Bord[4, 0], Bord[4, 1], Bord[4, 2], Bord[4, 3], Bord[4, 4], Bord[4, 5], Bord[4, 6], Bord[4, 7],
                Bord[5, 0], Bord[5, 1], Bord[5, 2], Bord[5, 3], Bord[5, 4], Bord[5, 5], Bord[5, 6], Bord[5, 7],
                Bord[6, 0], Bord[6, 1], Bord[6, 2], Bord[6, 3], Bord[6, 4], Bord[6, 5], Bord[6, 6], Bord[6, 7],
                Bord[7, 0], Bord[7, 1], Bord[7, 2], Bord[7, 3], Bord[7, 4], Bord[7, 5], Bord[7, 6], Bord[7, 7]
                );
            return bord;
        }

        public List<int[]> GetMogelijkeZetten()
        {
            List<int[]> Mogelijke = new List<int[]>();
            for (int rij = 0; rij < 8; rij++)
            {
                for (int kolom = 0; kolom < 8; kolom++)
                {
                    if (ZetMogelijk(rij, kolom))
                    {
                        int[] Steen = {rij,kolom };
                        Mogelijke.Add(Steen);
                    }
                }
            }
            return Mogelijke;
        }
        public List<int[]> GetMogelijkeZettenAflopen()
        {
            Kleur[,] test2 = new Kleur[,]{
                {Bord[0, 0], Bord[0, 1], Bord[0, 2], Bord[0, 3], Bord[0,4], Bord[0, 5], Bord[0, 6], Bord[0, 7]},
                {Bord[1, 0], Bord[1, 1], Bord[1, 2], Bord[1, 3], Bord[1, 4], Bord[1, 5], Bord[1, 6], Bord[1, 7]},
                {Bord[2, 0], Bord[2, 1], Bord[2, 2], Bord[2, 3], Bord[2, 4], Bord[2, 5], Bord[2, 6], Bord[2, 7]},
                {Bord[3, 0], Bord[3, 1], Bord[3, 2], Bord[3, 3], Bord[3, 4], Bord[3, 5], Bord[3, 6], Bord[3, 7]},
                {Bord[4, 0], Bord[4, 1], Bord[4, 2], Bord[4, 3], Bord[4, 4], Bord[4, 5], Bord[4, 6], Bord[4, 7]},
                {Bord[5, 0], Bord[5, 1], Bord[5, 2], Bord[5, 3], Bord[5, 4], Bord[5, 5], Bord[5, 6], Bord[5, 7]},
                {Bord[6, 0], Bord[6, 1], Bord[6, 2], Bord[6, 3], Bord[6, 4], Bord[6, 5], Bord[6, 6], Bord[6, 7]},
                {Bord[7, 0], Bord[7, 1], Bord[7, 2], Bord[7, 3], Bord[7, 4], Bord[7, 5], Bord[7, 6], Bord[7, 7]}
            };

            Kleur basisKleur = AandeBeurt;
            List<int[]> Mogelijke = new List<int[]>();
            for (int rij = 0; rij < 8; rij++)
            {
                for (int kolom = 0; kolom < 8; kolom++)
                {
                    if (ZetMogelijk(rij, kolom))
                    {
                        int[] Steen = { rij, kolom };
                        Mogelijke.Add(Steen);

                    }
                }
            }
            List<int[]> LaatAflopen = new List<int[]>();
            int a = GetMogelijkeZetten().Count;
            foreach (int[] mogelijk in Mogelijke)
            {
                //Bord = basisBord;   
                int b = GetMogelijkeZetten().Count();

                DoeZet(mogelijk[0], mogelijk[1]);
                if (AandeBeurt == Kleur.Wit)
                {
                    AandeBeurt = Kleur.Zwart;
                }
                else
                {
                    AandeBeurt = Kleur.Wit;
                }
                //AandeBeurt = Kleur.Zwart;
                int rijZet = mogelijk[0];
                int kolomZet = mogelijk[1];
                //LookDown(rijZet, kolomZet, true);
                //LookUp(rijZet, kolomZet, true);
                //LookLeft(rijZet, kolomZet, true);
                //LookRight(rijZet, kolomZet, true);
                //LookDownRight(rijZet, kolomZet, true);
                //LookDownLeft(rijZet, kolomZet, true);
                //LookUpRight(rijZet, kolomZet, true);
                //LookUpLeft(rijZet, kolomZet, true);
       
                if (GetMogelijkeZetten().Count() == 0)
                {
                    LaatAflopen.Add(mogelijk);
                }
                //kijken hoe niet bord aan wijzen werkt
                Bord = new Kleur[,]{{ test2[0, 0], test2[0, 1], test2[0, 2], test2[0, 3], test2[0, 4], test2[0, 5], test2[0, 6], test2[0, 7]},
                { test2[1, 0], test2[1, 1], test2[1, 2], test2[1, 3], test2[1, 4], test2[1, 5], test2[1, 6], test2[1, 7]},
                { test2[2, 0], test2[2, 1], test2[2, 2], test2[2, 3], test2[2, 4], test2[2, 5], test2[2, 6], test2[2, 7]},
                { test2[3, 0], test2[3, 1], test2[3, 2], test2[3, 3], test2[3, 4], test2[3, 5], test2[3, 6], test2[3, 7]},
                { test2[4, 0], test2[4, 1], test2[4, 2], test2[4, 3], test2[4, 4], test2[4, 5], test2[4, 6], test2[4, 7]},
                { test2[5, 0], test2[5, 1], test2[5, 2], test2[5, 3], test2[5, 4], test2[5, 5], test2[5, 6], test2[5, 7]},
                { test2[6, 0], test2[6, 1], test2[6, 2], test2[6, 3], test2[6, 4], test2[6, 5], test2[6, 6], test2[6, 7]},
                { test2[7, 0], test2[7, 1], test2[7, 2], test2[7, 3], test2[7, 4], test2[7, 5], test2[7, 6], test2[7, 7]}
                };
                
                AandeBeurt = basisKleur;
                }
            return LaatAflopen;
        }

        public bool Afgelopen()
        {
            for (int rij = 0; rij < 8; rij++)
            {
                for (int kolom = 0; kolom < 8; kolom++)
                {
                    if (ZetMogelijk(rij, kolom))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool DoeZet(int rijZet, int kolomZet)
        {
            try
            {
                //Bord[1,1] = AandeBeurt;
                LookDown(rijZet, kolomZet, true);
                LookUp(rijZet, kolomZet, true);
                LookLeft(rijZet, kolomZet, true);
                LookRight(rijZet, kolomZet, true);
                LookDownRight(rijZet, kolomZet, true);
                LookDownLeft(rijZet, kolomZet, true);
                LookUpRight(rijZet, kolomZet, true);
                LookUpLeft(rijZet, kolomZet, true);
                if (Bord[rijZet, kolomZet] == Kleur.Geen && (LookDown(rijZet, kolomZet, true) || LookUp(rijZet, kolomZet, true) || LookLeft(rijZet, kolomZet, true) || LookRight(rijZet, kolomZet, true) || LookDownRight(rijZet, kolomZet, true) || LookDownLeft(rijZet, kolomZet, true) || LookUpRight(rijZet, kolomZet, true) || LookUpLeft(rijZet, kolomZet, true)))
                {

                    if (AandeBeurt == Kleur.Wit)
                    {
                        AandeBeurt = Kleur.Zwart;
                    }else
                    {
                        AandeBeurt = Kleur.Wit;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public Kleur OverwegendeKleur()
        {
            int Wit = 0;
            int Zwart = 0;
            foreach (Kleur kleur in Bord)
            {
                switch (kleur)
                {
                    case Kleur.Wit:
                        Wit++;
                        break;
                    case Kleur.Zwart:
                        Zwart++;
                        break;

                }
            }
            if (!Wit.Equals(Zwart))
            {
                if (Wit > Zwart)
                {
                    return Kleur.Wit;
                }
                else
                {
                    return Kleur.Zwart;
                }
            }
            else
            {
                return Kleur.Geen;
            }

        }



        public bool Pas()
        {
            if (AandeBeurt.Equals(Kleur.Wit))
            {
                AandeBeurt = Kleur.Zwart;
            }
            else
            {
                AandeBeurt = Kleur.Wit;
            }
            return true;

        }

        public bool ZetMogelijk(int rijZet, int kolomZet)
        {
            try
            {
                if (Bord[rijZet, kolomZet] == Kleur.Geen && (LookDown(rijZet, kolomZet, false) || LookUp(rijZet, kolomZet, false) || LookLeft(rijZet, kolomZet, false) || LookRight(rijZet, kolomZet, false) || LookDownRight(rijZet, kolomZet, false) || LookDownLeft(rijZet, kolomZet, false) || LookUpRight(rijZet, kolomZet, false) || LookUpLeft(rijZet, kolomZet, false)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }


        }
        private void TurnStones(List<int[]> Stones, Boolean zet)
        {
            if (zet == true)
            {
                foreach (int[] array in Stones)
                {
                    Bord[array[0], array[1]] = AandeBeurt;
                }
            }


        }

        public bool LookDown(int rijZet, int kolomZet, Boolean Turn)
        {
            Boolean Voldaan = false;
            List<int[]> Omdraaien = new List<int[]>();

            for (int i = 1; i < 8 - rijZet; i++)
            {
                switch (Bord[rijZet + i, kolomZet])
                {
                    case Kleur.Geen:
                        return false;
                    case Kleur.Zwart:
                        if (AandeBeurt == Kleur.Zwart)
                        {
                            if (Voldaan == true)
                            {
                                if (Turn)
                                {
                                    Bord[rijZet, kolomZet] = Kleur.Zwart;
                                }
                                TurnStones(Omdraaien, Turn);
                                return true;
                            }
                            if (!Omdraaien.Any())
                            {
                                //fixen
                                return false;
                            }
                        }
                        else
                        {
                            Voldaan = true;
                            int[] Steen = { rijZet + i, kolomZet };
                            Omdraaien.Add(Steen);
                        }
                        break;
                    case Kleur.Wit:
                        if (AandeBeurt == Kleur.Wit)
                        {
                            if (Voldaan == true)
                            {
                                if (Turn)
                                {
                                    Bord[rijZet, kolomZet] = Kleur.Wit;
                                }
                                TurnStones(Omdraaien, Turn);
                                return true;
                            }
                            if (!Omdraaien.Any())
                            {
                                //fixen
                                return false;
                            }
                        }
                        else
                        {
                            Voldaan = true;
                            int[] Steen = { rijZet + i, kolomZet };
                            Omdraaien.Add(Steen);
                        }
                        break;
                }
            }
            return false;

        }
        public bool LookDownLeft(int rijZet, int kolomZet, Boolean Turn)
        {
            List<int[]> Omdraaien = new List<int[]>();
            Boolean Voldaan = false;
            for (int i = 1; i < 7 - rijZet && i < kolomZet; i++)
            {
                switch (Bord[rijZet + i, kolomZet - i])
                {
                    case Kleur.Geen:
                        return false;
                    case Kleur.Zwart:
                        if (AandeBeurt == Kleur.Zwart)
                        {
                            if (Voldaan == true)
                            {
                                if (Turn)
                                {
                                    Bord[rijZet, kolomZet] = Kleur.Zwart;
                                }
                                Bord[rijZet, kolomZet] = Kleur.Zwart;
                                TurnStones(Omdraaien, Turn);
                                return true;
                            }
                            if (!Omdraaien.Any())
                            {
                                //fixen
                                return false;
                            }
                        }
                        else
                        {
                            Voldaan = true;
                            int[] Steen = { rijZet + i, kolomZet - i };
                            Omdraaien.Add(Steen);
                        }
                        break;
                    case Kleur.Wit:
                        if (AandeBeurt == Kleur.Wit)
                        {
                            if (Voldaan == true)
                            {
                                if (Turn)
                                {
                                    Bord[rijZet, kolomZet] = Kleur.Wit;
                                }
                                TurnStones(Omdraaien, Turn);
                                return true;
                            }
                            if (!Omdraaien.Any())
                            {
                                //fixen
                                return false;
                            }
                        }
                        else
                        {
                            Voldaan = true;
                            int[] Steen = { rijZet + i, kolomZet - i };
                            Omdraaien.Add(Steen);
                        }
                        break;
                }
            }
            return false;

        }
        public bool LookUpLeft(int rijZet, int kolomZet, Boolean Turn)
        {
            List<int[]> Omdraaien = new List<int[]>();
            Boolean Voldaan = false;
            for (int i = 1; i < rijZet && i < 7 - kolomZet; i++)
            {
                switch (Bord[rijZet - i, kolomZet + i])
                {
                    case Kleur.Geen:
                        return false;
                    case Kleur.Zwart:
                        if (AandeBeurt == Kleur.Zwart)
                        {
                            if (Voldaan == true)
                            {
                                if (Turn)
                                {
                                    Bord[rijZet, kolomZet] = Kleur.Zwart;
                                }
                                TurnStones(Omdraaien, Turn);
                                return true;
                            }
                            if (!Omdraaien.Any())
                            {
                                //fixen
                                return false;
                            }
                        }
                        else
                        {
                            Voldaan = true;
                            int[] Steen = { rijZet - i, kolomZet + i };
                            Omdraaien.Add(Steen);
                        }
                        break;
                    case Kleur.Wit:
                        if (AandeBeurt == Kleur.Wit)
                        {
                            if (Voldaan == true)
                            {
                                if (Turn)
                                {
                                    Bord[rijZet, kolomZet] = Kleur.Wit;
                                }
                                TurnStones(Omdraaien, Turn);
                                return true;
                            }
                            if (!Omdraaien.Any())
                            {
                                //fixen
                                return false;
                            }
                        }
                        else
                        {
                            Voldaan = true;
                            int[] Steen = { rijZet - i, kolomZet + i };
                            Omdraaien.Add(Steen);
                        }
                        break;
                }
            }
            return false;

        }
        public bool LookDownRight(int rijZet, int kolomZet, Boolean Turn)
        {
            List<int[]> Omdraaien = new List<int[]>();
            Boolean Voldaan = false;
            for (int i = 1; i < 7 - kolomZet && i < 7 - rijZet; i++)
            {
                switch (Bord[rijZet + i, kolomZet + i])
                {
                    case Kleur.Geen:
                        return false;
                    case Kleur.Zwart:
                        if (AandeBeurt == Kleur.Zwart)
                        {
                            if (Voldaan == true)
                            {
                                if (Turn)
                                {
                                    Bord[rijZet, kolomZet] = Kleur.Zwart;
                                }
                                TurnStones(Omdraaien, Turn);
                                return true;
                            }
                            if (!Omdraaien.Any())
                            {
                                //fixen
                                return false;
                            }
                        }
                        else
                        {
                            Voldaan = true;
                            int[] Steen = { rijZet + i, kolomZet + i };
                            Omdraaien.Add(Steen);
                        }
                        break;
                    case Kleur.Wit:
                        if (AandeBeurt == Kleur.Wit)
                        {
                            if (Voldaan == true)
                            {
                                if (Turn)
                                {
                                    Bord[rijZet, kolomZet] = Kleur.Wit;
                                }
                                TurnStones(Omdraaien, Turn);
                                return true;
                            }
                            if (!Omdraaien.Any())
                            {
                                //fixen
                                return false;
                            }
                        }
                        else
                        {
                            Voldaan = true;
                            int[] Steen = { rijZet + i, kolomZet + i };
                            Omdraaien.Add(Steen);
                        }
                        break;
                }
            }
            return false;

        }
        public bool LookUpRight(int rijZet, int kolomZet, Boolean Turn)
        {
            List<int[]> Omdraaien = new List<int[]>();
            Boolean Voldaan = false;
            for (int i = 1; i < rijZet && i < kolomZet; i++)
            {
                switch (Bord[rijZet - i, kolomZet - i])
                {
                    case Kleur.Geen:
                        return false;
                    case Kleur.Zwart:
                        if (AandeBeurt == Kleur.Zwart)
                        {
                            if (Voldaan == true)
                            {
                                if (Turn)
                                {
                                    Bord[rijZet, kolomZet] = Kleur.Zwart;
                                }
                                TurnStones(Omdraaien, Turn);
                                return true;
                            }
                            if (!Omdraaien.Any())
                            {
                                //fixen
                                return false;
                            }
                        }
                        else
                        {
                            Voldaan = true;
                            int[] Steen = { rijZet - i, kolomZet - i };
                            Omdraaien.Add(Steen);
                        }
                        break;
                    case Kleur.Wit:
                        if (AandeBeurt == Kleur.Wit)
                        {
                            if (Voldaan == true)
                            {
                                if (Turn)
                                {
                                    Bord[rijZet, kolomZet] = Kleur.Wit;
                                }
                                TurnStones(Omdraaien, Turn);
                                return true;
                            }
                            if (!Omdraaien.Any())
                            {
                                //fixen
                                return false;
                            }
                        }
                        else
                        {
                            Voldaan = true;
                            int[] Steen = { rijZet - i, kolomZet - i };
                            Omdraaien.Add(Steen);
                        }
                        break;
                }

            }
            return false;

        }

        public bool LookLeft(int rijZet, int kolomZet, Boolean Turn)
        {
            List<int[]> Omdraaien = new List<int[]>();
            Boolean Voldaan = false;
            for (int i = 1; i < kolomZet + 1; i++)
            {
                switch (Bord[rijZet, kolomZet - i])
                {
                    case Kleur.Geen:
                        return false;
                    case Kleur.Zwart:
                        if (AandeBeurt == Kleur.Zwart)
                        {
                            if (Voldaan == true)
                            {
                                if (Turn)
                                {
                                    Bord[rijZet, kolomZet] = Kleur.Zwart;
                                }
                                TurnStones(Omdraaien, Turn);
                                return true;
                            }
                            if (!Omdraaien.Any())
                            {
                                //fixen
                                return false;
                            }
                        }
                        else
                        {
                            Voldaan = true;
                            int[] Steen = { rijZet, kolomZet - i };
                            Omdraaien.Add(Steen);
                        }
                        break;
                    case Kleur.Wit:
                        if (AandeBeurt == Kleur.Wit)
                        {
                            if (Voldaan == true)
                            {
                                if (Turn)
                                {
                                    Bord[rijZet, kolomZet] = Kleur.Wit;
                                }
                                TurnStones(Omdraaien, Turn);
                                return true;
                            }
                            if (!Omdraaien.Any())
                            {
                                //fixen
                                return false;
                            }
                        }
                        else
                        {
                            Voldaan = true;
                            int[] Steen = { rijZet, kolomZet - i };
                            Omdraaien.Add(Steen);
                        }
                        break;
                }
            }
            return false;

        }
        public bool LookRight(int rijZet, int kolomZet, Boolean Turn)
        {
            List<int[]> Omdraaien = new List<int[]>();
            Boolean Voldaan = false;
            for (int i = 1; i < 8 - kolomZet; i++)
            {
                switch (Bord[rijZet, kolomZet + i])
                {
                    case Kleur.Geen:
                        return false;
                    case Kleur.Zwart:
                        if (AandeBeurt == Kleur.Zwart)
                        {
                            if (Voldaan == true)
                            {
                                if (Turn)
                                {
                                    Bord[rijZet, kolomZet] = Kleur.Zwart;
                                }
                                TurnStones(Omdraaien, Turn);
                                return true;
                            }
                            if (!Omdraaien.Any())
                            {
                                //fixen
                                return false;
                            }
                        }
                        else
                        {
                            Voldaan = true;
                            int[] Steen = { rijZet, kolomZet + i };
                            Omdraaien.Add(Steen);
                        }
                        break;
                    case Kleur.Wit:
                        if (AandeBeurt == Kleur.Wit)
                        {
                            if (Voldaan == true)
                            {
                                if (Turn)
                                {
                                    Bord[rijZet, kolomZet] = Kleur.Wit;
                                }
                                TurnStones(Omdraaien, Turn);
                                return true;
                            }
                            if (!Omdraaien.Any())
                            {
                                //fixen
                                return false;
                            }
                        }
                        else
                        {
                            Voldaan = true;
                            int[] Steen = { rijZet, kolomZet + i };
                            Omdraaien.Add(Steen);
                        }
                        break;
                }
            }
            return false;

        }
        public bool LookUp(int rijZet, int kolomZet, Boolean Turn)
        {
            List<int[]> Omdraaien = new List<int[]>();
            Boolean Voldaan = false;
            for (int i = 1; i < rijZet + 1; i++)
            {
                switch (Bord[rijZet - i, kolomZet])
                {
                    case Kleur.Geen:
                        return false;
                    case Kleur.Zwart:
                        if (AandeBeurt == Kleur.Zwart)
                        {
                            if (Voldaan == true)
                            {
                                if (Turn)
                                {
                                    Bord[rijZet, kolomZet] = Kleur.Zwart;
                                }
                                TurnStones(Omdraaien, Turn);
                                return true;
                            }
                            if (!Omdraaien.Any())
                            {
                                //fixen
                                return false;
                            }
                        }
                        else
                        {
                            Voldaan = true;
                            int[] Steen = { rijZet - i, kolomZet };
                            Omdraaien.Add(Steen);
                        }
                        break;
                    case Kleur.Wit:
                        if (AandeBeurt == Kleur.Wit)
                        {
                            if (Voldaan == true)
                            {
                                if (Turn)
                                {
                                    Bord[rijZet, kolomZet] = Kleur.Wit;
                                }
                                TurnStones(Omdraaien, Turn);
                                return true;
                            }
                            if (!Omdraaien.Any())
                            {
                                //fixen
                                return false;
                            }
                        }
                        else
                        {
                            Voldaan = true;
                            int[] Steen = { rijZet - i, kolomZet };
                            Omdraaien.Add(Steen);
                        }
                        break;
                }
            }
            return false;
        }
    }
}
