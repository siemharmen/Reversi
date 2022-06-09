using ReversiHerkansing.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiHerkansing.Model
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        public Spel Spel { get; set; }
        public int SpelID { get; set; }
        public Kleur Row00 { get; set; }
        public Kleur Row01 { get; set; }
        public Kleur Row02 { get; set; }
        public Kleur Row03 { get; set; }
        public Kleur Row04 { get; set; }
        public Kleur Row05 { get; set; }
        public Kleur Row06 { get; set; }
        public Kleur Row07 { get; set; }
        public Kleur Row10 { get; set; }
        public Kleur Row11 { get; set; }
        public Kleur Row12 { get; set; }
        public Kleur Row13 { get; set; }
        public Kleur Row14 { get; set; }
        public Kleur Row15 { get; set; }
        public Kleur Row16 { get; set; }
        public Kleur Row17 { get; set; }
        public Kleur Row20 { get; set; }
        public Kleur Row21 { get; set; }
        public Kleur Row22 { get; set; }
        public Kleur Row23 { get; set; }
        public Kleur Row24 { get; set; }
        public Kleur Row25 { get; set; }
        public Kleur Row26 { get; set; }
        public Kleur Row27 { get; set; }
        public Kleur Row30 { get; set; }
        public Kleur Row31 { get; set; }
        public Kleur Row32 { get; set; }
        public Kleur Row33 { get; set; }
        public Kleur Row34 { get; set; }
        public Kleur Row35 { get; set; }
        public Kleur Row36 { get; set; }
        public Kleur Row37 { get; set; }
        public Kleur Row40 { get; set; }
        public Kleur Row41 { get; set; }
        public Kleur Row42 { get; set; }
        public Kleur Row43 { get; set; }
        public Kleur Row44 { get; set; }
        public Kleur Row45 { get; set; }
        public Kleur Row46 { get; set; }
        public Kleur Row47 { get; set; }
        public Kleur Row50 { get; set; }
        public Kleur Row51 { get; set; }
        public Kleur Row52 { get; set; }
        public Kleur Row53 { get; set; }
        public Kleur Row54 { get; set; }
        public Kleur Row55 { get; set; }
        public Kleur Row56 { get; set; }
        public Kleur Row57 { get; set; }
        public Kleur Row60 { get; set; }
        public Kleur Row61 { get; set; }
        public Kleur Row62 { get; set; }
        public Kleur Row63 { get; set; }
        public Kleur Row64 { get; set; }
        public Kleur Row65 { get; set; }
        public Kleur Row66 { get; set; }
        public Kleur Row67 { get; set; }
        public Kleur Row70 { get; set; }
        public Kleur Row71 { get; set; }
        public Kleur Row72 { get; set; }
        public Kleur Row73 { get; set; }
        public Kleur Row74 { get; set; }
        public Kleur Row75 { get; set; }
        public Kleur Row76 { get; set; }
        public Kleur Row77 { get; set; }

        public Board(int id, Spel spel, int spelID, Kleur row00, Kleur row01, Kleur row02, Kleur row03, Kleur row04, Kleur row05, Kleur row06, Kleur row07, Kleur row10, Kleur row11, Kleur row12, Kleur row13, Kleur row14, Kleur row15, Kleur row16, Kleur row17, Kleur row20, Kleur row21, Kleur row22, Kleur row23, Kleur row24, Kleur row25, Kleur row26, Kleur row27, Kleur row30, Kleur row31, Kleur row32, Kleur row33, Kleur row34, Kleur row35, Kleur row36, Kleur row37, Kleur row40, Kleur row41, Kleur row42, Kleur row43, Kleur row44, Kleur row45, Kleur row46, Kleur row47, Kleur row50, Kleur row51, Kleur row52, Kleur row53, Kleur row54, Kleur row55, Kleur row56, Kleur row57, Kleur row60, Kleur row61, Kleur row62, Kleur row63, Kleur row64, Kleur row65, Kleur row66, Kleur row67, Kleur row70, Kleur row71, Kleur row72, Kleur row73, Kleur row74, Kleur row75, Kleur row76, Kleur row77)
        {
            Id = id;
            Spel = spel;
            SpelID = spelID;
            Row00 = row00;
            Row01 = row01;
            Row02 = row02;
            Row03 = row03;
            Row04 = row04;
            Row05 = row05;
            Row06 = row06;
            Row07 = row07;
            Row10 = row10;
            Row11 = row11;
            Row12 = row12;
            Row13 = row13;
            Row14 = row14;
            Row15 = row15;
            Row16 = row16;
            Row17 = row17;
            Row20 = row20;
            Row21 = row21;
            Row22 = row22;
            Row23 = row23;
            Row24 = row24;
            Row25 = row25;
            Row26 = row26;
            Row27 = row27;
            Row30 = row30;
            Row31 = row31;
            Row32 = row32;
            Row33 = row33;
            Row34 = row34;
            Row35 = row35;
            Row36 = row36;
            Row37 = row37;
            Row40 = row40;
            Row41 = row41;
            Row42 = row42;
            Row43 = row43;
            Row44 = row44;
            Row45 = row45;
            Row46 = row46;
            Row47 = row47;
            Row50 = row50;
            Row51 = row51;
            Row52 = row52;
            Row53 = row53;
            Row54 = row54;
            Row55 = row55;
            Row56 = row56;
            Row57 = row57;
            Row60 = row60;
            Row61 = row61;
            Row62 = row62;
            Row63 = row63;
            Row64 = row64;
            Row65 = row65;
            Row66 = row66;
            Row67 = row67;
            Row70 = row70;
            Row71 = row71;
            Row72 = row72;
            Row73 = row73;
            Row74 = row74;
            Row75 = row75;
            Row76 = row76;
            Row77 = row77;
        }

        public Board()
        {
        }
    }
}
