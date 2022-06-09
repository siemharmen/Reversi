using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ReversiHerkansing;
using ReversiHerkansing.Model;

namespace NUnitTestProjectReversiSpel
{
    [TestFixture]
    public class TestSpel
    {
        // geen kleur = 0
        // Wit = 1
        // Zwart = 2
        [Test]
        public void TestGetMogelijkeZettenAflopen()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //                     v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 0 0 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     1 <
            // Act
             spel.Bord[3, 3] = Kleur.Geen;
            spel.Bord[3, 4] = Kleur.Geen;
            //spel.Bord[4, 4] = Kleur.Geen;
            //spel.Bord[4, 3] = Kleur.Geen;

            spel.AandeBeurt = ReversiHerkansing.Model.Kleur.Wit;
            //var actual = spel.ZetMogelijk(2,4);
            //var actual = spel.ZetMogelijk(8, 8);
            //var afgelopen = spel.Afgelopen();
            //Assert.IsTrue(actual);
            //< < 2, 4 >, < 3, 5 >, < 4, 2 >, < 5, 3 > >

            List<int[]> LaatAflopen = new List<int[]>();

            Kleur[,] test = spel.Bord;
            Kleur[,] test2 = new Kleur[,]{
                {spel.Bord[0, 0], spel.Bord[0, 1], spel.Bord[0, 2], spel.Bord[0, 3], spel.Bord[0,4], spel.Bord[0, 5], spel.Bord[0, 6], spel.Bord[0, 7]},
                {spel.Bord[1, 0], spel.Bord[1, 1], spel.Bord[1, 2], spel.Bord[1, 3], spel.Bord[1, 4], spel.Bord[1, 5], spel.Bord[1, 6], spel.Bord[1, 7]},
                {spel.Bord[2, 0], spel.Bord[2, 1], spel.Bord[2, 2], spel.Bord[2, 3], spel.Bord[2, 4], spel.Bord[2, 5], spel.Bord[2, 6], spel.Bord[2, 7]},
                {spel.Bord[3, 0], spel.Bord[3, 1], spel.Bord[3, 2], spel.Bord[3, 3], spel.Bord[3, 4], spel.Bord[3, 5], spel.Bord[3, 6], spel.Bord[3, 7]},
                {spel.Bord[4, 0], spel.Bord[4, 1], spel.Bord[4, 2], spel.Bord[4, 3], spel.Bord[4, 4], spel.Bord[4, 5], spel.Bord[4, 6], spel.Bord[4, 7]},
                {spel.Bord[5, 0], spel.Bord[5, 1], spel.Bord[5, 2], spel.Bord[5, 3], spel.Bord[5, 4], spel.Bord[5, 5], spel.Bord[5, 6], spel.Bord[5, 7]},
                {spel.Bord[6, 0], spel.Bord[6, 1], spel.Bord[6, 2], spel.Bord[6, 3], spel.Bord[6, 4], spel.Bord[6, 5], spel.Bord[6, 6], spel.Bord[6, 7]},
                {spel.Bord[7, 0], spel.Bord[7, 1], spel.Bord[7, 2], spel.Bord[7, 3], spel.Bord[7, 4], spel.Bord[7, 5], spel.Bord[7, 6], spel.Bord[7, 7]}
            };


            Kleur[,] afdss = new Kleur[,]{
                { Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen}, //0
                { Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen}, //1
                { Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen}, //2
                { Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Wit,Kleur.Zwart,Kleur.Geen,Kleur.Geen,Kleur.Geen}, //3
                { Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Zwart,Kleur.Wit,Kleur.Geen,Kleur.Geen,Kleur.Geen}, //4
                { Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen}, //5
                { Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen}, //6
                { Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen,Kleur.Geen}  //7

            };      
            foreach (int[] steen in spel.GetMogelijkeZetten())
            {
                spel.DoeZet(steen[0],steen[1]);
                if (spel.GetMogelijkeZetten().Count == 0)
                {
                    LaatAflopen.Add(steen);
                }
                spel.Bord = new Kleur[,]{{ test2[0, 0], test2[0, 1], test2[0, 2], test2[0, 3], test2[0, 4], test2[0, 5], test2[0, 6], test2[0, 7]},
                { test2[1, 0], test2[1, 1], test2[1, 2], test2[1, 3], test2[1, 4], test2[1, 5], test2[1, 6], test2[1, 7]},
                { test2[2, 0], test2[2, 1], test2[2, 2], test2[2, 3], test2[2, 4], test2[2, 5], test2[2, 6], test2[2, 7]},
                { test2[3, 0], test2[3, 1], test2[3, 2], test2[3, 3], test2[3, 4], test2[3, 5], test2[3, 6], test2[3, 7]},
                { test2[4, 0], test2[4, 1], test2[4, 2], test2[4, 3], test2[4, 4], test2[4, 5], test2[4, 6], test2[4, 7]},
                { test2[5, 0], test2[5, 1], test2[5, 2], test2[5, 3], test2[5, 4], test2[5, 5], test2[5, 6], test2[5, 7]},
                { test2[6, 0], test2[6, 1], test2[6, 2], test2[6, 3], test2[6, 4], test2[6, 5], test2[6, 6], test2[6, 7]},
                { test2[7, 0], test2[7, 1], test2[7, 2], test2[7, 3], test2[7, 4], test2[7, 5], test2[7, 6], test2[7, 7]} 
                };

                
            }
            Assert.IsEmpty(LaatAflopen);    
            //Assert.IsEmpty(spel.GetMogelijkeZettenAflopen(spel.Bord));
            // Assert.IsFalse(afgelopen);
            // Assert
            //Assert.IsFalse(actual);
        }
        [Test]
        public void TestGetMogelijkeZettennietAflopen()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //                     v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 0 0 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     1 <
            // Act
            //spel.Bord[3, 3] = Kleur.Geen;
            //spel.Bord[3, 4] = Kleur.Geen;
            //spel.Bord[4, 4] = Kleur.Geen;
            //spel.Bord[4, 3] = Kleur.Geen;

            spel.AandeBeurt = Kleur.Wit;
            //var actual = spel.ZetMogelijk(2,4);
            //var actual = spel.ZetMogelijk(8, 8);
            var afgelopen = spel.Afgelopen();
            //Assert.IsTrue(actual);    
            //< < 2, 4 >, < 3, 5 >, < 4, 2 >, < 5, 3 > >
            Assert.IsEmpty(spel.GetMogelijkeZettenAflopen());
            // Assert.IsFalse(afgelopen);
            // Assert
            //Assert.IsFalse(actual);
        }
        [Test]
        public void ZetMogelijk_BuitenBord_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //                     v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     1 <
            // Act
            //spel.Bord[3, 3] = Kleur.Geen;
            //spel.Bord[3, 4] = Kleur.Geen;
            //spel.Bord[4, 4] = Kleur.Geen;
            //spel.Bord[4, 3] = Kleur.Geen;
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(8, 8);
            var afgelopen = spel.Afgelopen();
            Assert.IsFalse(afgelopen);

            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void ZetMogelijk_StartSituatieZet23Zwart_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 2 0 0 0 0  <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act

            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(2, 3);
            // Assert
            var afgelopen = spel.Afgelopen();
            Assert.IsFalse(afgelopen);
            Assert.IsTrue(actual);
        }

        [Test]
        public void ZetMogelijk_StartSituatieZet23Wit_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 1 0 0 0 0 <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(2, 3);
            // Assert
            var afgelopen = spel.Afgelopen();
            Assert.IsFalse(afgelopen);
            Assert.IsFalse(actual);
        }


        [Test]
        public void ZetMogelijk_ZetAanDeRandBoven_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 2 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(0, 3);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandBoven_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 1 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(0, 3);
            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandBovenEnTotBenedenReedsGevuld_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            spel.Bord[3, 3] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[5, 3] = Kleur.Wit;
            spel.Bord[6, 3] = Kleur.Wit;
            spel.Bord[7, 3] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 2 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 1 1 0 0 0
            // 5   0 0 0 1 0 0 0 0
            // 6   0 0 0 1 0 0 0 0
            // 7   0 0 0 2 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(0, 3);
         
            // Assert
            Assert.IsTrue(actual);
            var afgelopen = spel.Afgelopen();
            Assert.IsFalse(afgelopen);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandBovenEnTotBenedenReedsGevuld_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            spel.Bord[3, 3] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[5, 3] = Kleur.Wit;
            spel.Bord[6, 3] = Kleur.Wit;
            spel.Bord[7, 3] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 2 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 1 1 0 0 0
            // 5   0 0 0 1 0 0 0 0
            // 6   0 0 0 1 0 0 0 0
            // 7   0 0 0 1 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(0, 3);
            // Assert
            Assert.IsFalse(actual);
        }






        [Test]
        public void ZetMogelijk_ZetAanDeRandRechts_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 2 0 0 0 0  
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 1 1 2 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(4, 7);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechts_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 1 0 0 0 0  
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 1 1 1 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(4, 7);
            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsEnTotLinksReedsGevuld_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[4, 0] = Kleur.Zwart;
            spel.Bord[4, 1] = Kleur.Wit;
            spel.Bord[4, 2] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[4, 4] = Kleur.Wit;
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0 
            // 4   2 1 1 1 1 1 1 2 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(4, 7);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsEnTotLinksReedsGevuld_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[4, 0] = Kleur.Zwart;
            spel.Bord[4, 1] = Kleur.Wit;
            spel.Bord[4, 2] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[4, 4] = Kleur.Wit;
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  

            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   2 1 1 1 1 1 1 1 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(4, 7);
            // Assert
            Assert.IsFalse(actual);
        }


        //     0 1 2 3 4 5 6 7
        //                     
        // 0   0 0 0 0 0 0 0 0  
        // 1   0 0 0 0 0 0 0 0
        // 2   0 0 0 0 0 0 0 0
        // 3   0 0 0 1 2 0 0 0
        // 4   0 0 0 2 1 0 0 0
        // 5   0 0 0 0 0 0 0 0
        // 6   0 0 0 0 0 0 0 0
        // 7   0 0 0 0 0 0 0 0



        [Test]
        public void ZetMogelijk_StartSituatieZet22Wit_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //         v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 1 0 0 0 0 0 <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(2, 2);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void ZetMogelijk_StartSituatieZet22Zwart_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //         v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 2 0 0 0 0 0 <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(2, 2);
            // Assert
            Assert.IsFalse(actual);
        }


        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsBoven_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 5] = Kleur.Zwart;
            spel.Bord[1, 6] = Kleur.Zwart;
            spel.Bord[5, 2] = Kleur.Wit;



            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 1  <
            // 1   0 0 0 0 0 0 2 0
            // 2   0 0 0 0 0 2 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 1 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(0, 7);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsBoven_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 5] = Kleur.Zwart;
            spel.Bord[1, 6] = Kleur.Zwart;
            spel.Bord[5, 2] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 2  <
            // 1   0 0 0 0 0 0 2 0
            // 2   0 0 0 0 0 2 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 1 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(0, 7);
            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsOnder_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 2] = Kleur.Zwart;
            spel.Bord[5, 5] = Kleur.Wit;
            spel.Bord[6, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 2 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 1 0 0
            // 6   0 0 0 0 0 0 1 0
            // 7   0 0 0 0 0 0 0 2 <
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(7, 7);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsOnder_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 2] = Kleur.Zwart;
            spel.Bord[5, 5] = Kleur.Wit;
            spel.Bord[6, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  <
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 2 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 1 0 0
            // 6   0 0 0 0 0 0 1 0
            // 7   0 0 0 0 0 0 0 1
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(7, 7);
            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandLinksBoven_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 1] = Kleur.Wit;
            spel.Bord[2, 2] = Kleur.Wit;
            spel.Bord[5, 5] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   2 0 0 0 0 0 0 0  <
            // 1   0 1 0 0 0 0 0 0
            // 2   0 0 1 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 2 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0 
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(0, 0);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandLinksBoven_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 1] = Kleur.Wit;
            spel.Bord[2, 2] = Kleur.Wit;
            spel.Bord[5, 5] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   1 0 0 0 0 0 0 0  <
            // 1   0 1 0 0 0 0 0 0
            // 2   0 0 1 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 2 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0          
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(0, 0);
            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandLinksOnder_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 5] = Kleur.Wit;
            spel.Bord[5, 2] = Kleur.Zwart;
            spel.Bord[6, 1] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 1 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 2 0 0 0 0 0
            // 6   0 2 0 0 0 0 0 0
            // 7   1 0 0 0 0 0 0 0 <
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.ZetMogelijk(7, 0);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandLinksOnder_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 5] = Kleur.Wit;
            spel.Bord[5, 2] = Kleur.Zwart;
            spel.Bord[6, 1] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  <
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 1 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 2 0 0 0 0 0
            // 6   0 2 0 0 0 0 0 0
            // 7   2 0 0 0 0 0 0 0
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.ZetMogelijk(7, 0);
            // Assert
            Assert.IsFalse(actual);
        }

        //---------------------------------------------------------------------------
        [Test]
        public void DoeZet_BuitenBord_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //                     v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     1 <
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(8, 8);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Kleur.Wit, spel.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 3]);

            Assert.AreEqual(Kleur.Wit, spel.AandeBeurt);
        }

        [Test]
        public void DoeZet_StartSituatieZet23Zwart_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 2 0 0 0 0  <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(2, 3);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[2, 3]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[3, 3]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 3]);

            Assert.AreEqual(Kleur.Wit, spel.AandeBeurt);
        }

        [Test]
        public void DoeZet_StartSituatieZet23Wit_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 1 0 0 0 0 <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(2, 3);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Kleur.Wit, spel.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 3]);

            Assert.AreEqual(Kleur.Geen, spel.Bord[2, 3]);

            Assert.AreEqual(Kleur.Wit, spel.AandeBeurt);
        }


        [Test]
        public void DoeZet_ZetAanDeRandBoven_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 2 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(0, 3);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[0, 3]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[1, 3]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[2, 3]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[3, 3]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 3]);

            Assert.AreEqual(Kleur.Wit, spel.AandeBeurt);
        }

        [Test]
        public void DoeZet_ZetAanDeRandBoven_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 1 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(0, 3);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Kleur.Wit, spel.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 3]);

            Assert.AreEqual(Kleur.Wit, spel.Bord[1, 3]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[2, 3]);

            Assert.AreEqual(Kleur.Geen, spel.Bord[0, 3]);

        }

        [Test]
        public void DoeZet_ZetAanDeRandBovenEnTotBenedenReedsGevuld_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            spel.Bord[3, 3] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[5, 3] = Kleur.Wit;
            spel.Bord[6, 3] = Kleur.Wit;
            spel.Bord[7, 3] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 2 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 1 1 0 0 0
            // 5   0 0 0 1 0 0 0 0
            // 6   0 0 0 1 0 0 0 0
            // 7   0 0 0 2 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(0, 3);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[0, 3]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[1, 3]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[2, 3]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[3, 3]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 3]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[5, 3]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[6, 3]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[7, 3]);

        }

        [Test]
        public void DoeZet_ZetAanDeRandBovenEnTotBenedenReedsGevuld_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            spel.Bord[3, 3] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[5, 3] = Kleur.Wit;
            spel.Bord[6, 3] = Kleur.Wit;
            spel.Bord[7, 3] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 2 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 1 1 0 0 0
            // 5   0 0 0 1 0 0 0 0
            // 6   0 0 0 1 0 0 0 0
            // 7   0 0 0 1 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(0, 3);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Kleur.Wit, spel.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[3, 4]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 3]);

            Assert.AreEqual(Kleur.Wit, spel.Bord[1, 3]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[2, 3]);
            Assert.AreEqual(Kleur.Geen, spel.Bord[0, 3]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechts_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 1 1 2 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(4, 7);
            // Assert
            Assert.IsTrue(actual);

            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 3]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 5]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 6]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 7]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechts_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 1 0 0 0 0  
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 1 1 1 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(4, 7);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Kleur.Wit, spel.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 3]);

            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 5]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 6]);
            Assert.AreEqual(Kleur.Geen, spel.Bord[4, 7]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechtsEnTotLinksReedsGevuld_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[4, 0] = Kleur.Zwart;
            spel.Bord[4, 1] = Kleur.Wit;
            spel.Bord[4, 2] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[4, 4] = Kleur.Wit;
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0 
            // 4   2 1 1 1 1 1 1 2 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(4, 7);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 0]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 1]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 2]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 3]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 5]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 6]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 7]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechtsEnTotLinksReedsGevuld_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[4, 0] = Kleur.Zwart;
            spel.Bord[4, 1] = Kleur.Wit;
            spel.Bord[4, 2] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[4, 4] = Kleur.Wit;
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  

            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   2 1 1 1 1 1 1 1 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(4, 7);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Kleur.Wit, spel.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[3, 4]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 3]);

            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 0]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 1]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 2]);

            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 5]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 6]);
            Assert.AreEqual(Kleur.Geen, spel.Bord[4, 7]);
        }


        //     0 1 2 3 4 5 6 7
        //                     
        // 0   0 0 0 0 0 0 0 0  
        // 1   0 0 0 0 0 0 0 0
        // 2   0 0 0 0 0 0 0 0
        // 3   0 0 0 1 2 0 0 0
        // 4   0 0 0 2 1 0 0 0
        // 5   0 0 0 0 0 0 0 0
        // 6   0 0 0 0 0 0 0 0
        // 7   0 0 0 0 0 0 0 0



        [Test]
        public void DoeZet_StartSituatieZet22Wit_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //         v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 1 0 0 0 0 0 <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(2, 2);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Kleur.Wit, spel.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 3]);

            Assert.AreEqual(Kleur.Geen, spel.Bord[2, 2]);
        }

        [Test]
        public void DoeZet_StartSituatieZet22Zwart_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //         v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 2 0 0 0 0 0 <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(2, 2);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Kleur.Wit, spel.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 3]);

            Assert.AreEqual(Kleur.Geen, spel.Bord[2, 2]);
        }


        [Test]
        public void DoeZet_ZetAanDeRandRechtsBoven_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 5] = Kleur.Zwart;
            spel.Bord[1, 6] = Kleur.Zwart;
            spel.Bord[5, 2] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 1  <
            // 1   0 0 0 0 0 0 2 0
            // 2   0 0 0 0 0 2 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 1 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(0, 7);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Kleur.Wit, spel.Bord[5, 2]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 3]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[3, 4]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[2, 5]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[1, 6]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[0, 7]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechtsBoven_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 5] = Kleur.Zwart;
            spel.Bord[1, 6] = Kleur.Zwart;
            spel.Bord[5, 2] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 2  <
            // 1   0 0 0 0 0 0 2 0
            // 2   0 0 0 0 0 2 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 1 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(0, 7);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Kleur.Wit, spel.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 3]);

            Assert.AreEqual(Kleur.Zwart, spel.Bord[1, 6]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[2, 5]);

            Assert.AreEqual(Kleur.Wit, spel.Bord[5, 2]);

            Assert.AreEqual(Kleur.Geen, spel.Bord[0, 7]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechtsOnder_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 2] = Kleur.Zwart;
            spel.Bord[5, 5] = Kleur.Wit;
            spel.Bord[6, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 2 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 1 0 0
            // 6   0 0 0 0 0 0 1 0
            // 7   0 0 0 0 0 0 0 2 <
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(7, 7);
            // Assert
            Assert.IsTrue(actual);

            Assert.AreEqual(Kleur.Zwart, spel.Bord[2, 2]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[3, 3]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[5, 5]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[6, 6]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[7, 7]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechtsOnder_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 2] = Kleur.Zwart;
            spel.Bord[5, 5] = Kleur.Wit;
            spel.Bord[6, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 2 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 1 0 0
            // 6   0 0 0 0 0 0 1 0
            // 7   0 0 0 0 0 0 0 1 <
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(7, 7);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Kleur.Wit, spel.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 3]);

            Assert.AreEqual(Kleur.Zwart, spel.Bord[2, 2]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[5, 5]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[6, 6]);

            Assert.AreEqual(Kleur.Geen, spel.Bord[7, 7]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandLinksBoven_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 1] = Kleur.Wit;
            spel.Bord[2, 2] = Kleur.Wit;
            spel.Bord[5, 5] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   2 0 0 0 0 0 0 0  <
            // 1   0 1 0 0 0 0 0 0
            // 2   0 0 1 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 2 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0 
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(0, 0);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[0, 0]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[1, 1]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[2, 2]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[3, 3]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[5, 5]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandLinksBoven_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[1, 1] = Kleur.Wit;
            spel.Bord[2, 2] = Kleur.Wit;
            spel.Bord[5, 5] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   1 0 0 0 0 0 0 0  <
            // 1   0 1 0 0 0 0 0 0
            // 2   0 0 1 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 2 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0          
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(0, 0);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Kleur.Wit, spel.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 3]);

            Assert.AreEqual(Kleur.Wit, spel.Bord[1, 1]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[2, 2]);

            Assert.AreEqual(Kleur.Zwart, spel.Bord[5, 5]);

            Assert.AreEqual(Kleur.Geen, spel.Bord[0, 0]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandLinksOnder_ReturnTrue()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 5] = Kleur.Wit;
            spel.Bord[5, 2] = Kleur.Zwart;
            spel.Bord[6, 1] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 1 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 2 0 0 0 0 0
            // 6   0 2 0 0 0 0 0 0
            // 7   1 0 0 0 0 0 0 0 <
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.DoeZet(7, 0);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Kleur.Wit, spel.Bord[7, 0]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[6, 1]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[5, 2]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 3]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[3, 4]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[2, 5]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandLinksOnder_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 5] = Kleur.Wit;
            spel.Bord[5, 2] = Kleur.Zwart;
            spel.Bord[6, 1] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 1 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 2 0 0 0 0 0
            // 6   0 2 0 0 0 0 0 0
            // 7   2 0 0 0 0 0 0 0 <
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.DoeZet(7, 0);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Kleur.Wit, spel.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, spel.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[4, 3]);

            Assert.AreEqual(Kleur.Wit, spel.Bord[2, 5]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[5, 2]);
            Assert.AreEqual(Kleur.Zwart, spel.Bord[6, 1]);

            Assert.AreEqual(Kleur.Geen, spel.Bord[7, 7]);

            Assert.AreEqual(Kleur.Geen, spel.Bord[7, 0]);
        }

        [Test]
        public void Pas_ZwartAanZetGeenZetMogelijk_ReturnTrueEnWisselBeurt()
        {
            // Arrange  (zowel wit als zwart kunnen niet meer)
            Spel spel = new Spel();
            spel.Bord[0, 0] = Kleur.Wit;
            spel.Bord[0, 1] = Kleur.Wit;
            spel.Bord[0, 2] = Kleur.Wit;
            spel.Bord[0, 3] = Kleur.Wit;
            spel.Bord[0, 4] = Kleur.Wit;
            spel.Bord[0, 5] = Kleur.Wit;
            spel.Bord[0, 6] = Kleur.Wit;
            spel.Bord[0, 7] = Kleur.Wit;
            spel.Bord[1, 0] = Kleur.Wit;
            spel.Bord[1, 1] = Kleur.Wit;
            spel.Bord[1, 2] = Kleur.Wit;
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[1, 4] = Kleur.Wit;
            spel.Bord[1, 5] = Kleur.Wit;
            spel.Bord[1, 6] = Kleur.Wit;
            spel.Bord[1, 7] = Kleur.Wit;
            spel.Bord[2, 0] = Kleur.Wit;
            spel.Bord[2, 1] = Kleur.Wit;
            spel.Bord[2, 2] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            spel.Bord[2, 4] = Kleur.Wit;
            spel.Bord[2, 5] = Kleur.Wit;
            spel.Bord[2, 6] = Kleur.Wit;
            spel.Bord[2, 7] = Kleur.Wit;
            spel.Bord[3, 0] = Kleur.Wit;
            spel.Bord[3, 1] = Kleur.Wit;
            spel.Bord[3, 2] = Kleur.Wit;
            spel.Bord[3, 3] = Kleur.Wit;
            spel.Bord[3, 4] = Kleur.Wit;
            spel.Bord[3, 5] = Kleur.Wit;
            spel.Bord[3, 6] = Kleur.Wit;
            spel.Bord[3, 7] = Kleur.Geen;
            spel.Bord[4, 0] = Kleur.Wit;
            spel.Bord[4, 1] = Kleur.Wit;
            spel.Bord[4, 2] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[4, 4] = Kleur.Wit;
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Geen;
            spel.Bord[4, 7] = Kleur.Geen;
            spel.Bord[5, 0] = Kleur.Wit;
            spel.Bord[5, 1] = Kleur.Wit;
            spel.Bord[5, 2] = Kleur.Wit;
            spel.Bord[5, 3] = Kleur.Wit;
            spel.Bord[5, 4] = Kleur.Wit;
            spel.Bord[5, 5] = Kleur.Wit;
            spel.Bord[5, 6] = Kleur.Geen;
            spel.Bord[5, 7] = Kleur.Zwart;
            spel.Bord[6, 0] = Kleur.Wit;
            spel.Bord[6, 1] = Kleur.Wit;
            spel.Bord[6, 2] = Kleur.Wit;
            spel.Bord[6, 3] = Kleur.Wit;
            spel.Bord[6, 4] = Kleur.Wit;
            spel.Bord[6, 5] = Kleur.Wit;
            spel.Bord[6, 6] = Kleur.Wit;
            spel.Bord[6, 7] = Kleur.Geen;
            spel.Bord[7, 0] = Kleur.Wit;
            spel.Bord[7, 1] = Kleur.Wit;
            spel.Bord[7, 2] = Kleur.Wit;
            spel.Bord[7, 3] = Kleur.Wit;
            spel.Bord[7, 4] = Kleur.Wit;
            spel.Bord[7, 5] = Kleur.Wit;
            spel.Bord[7, 6] = Kleur.Wit;
            spel.Bord[7, 7] = Kleur.Wit;

            //     0 1 2 3 4 5 6 7
            //     v
            // 0   1 1 1 1 1 1 1 1  
            // 1   1 1 1 1 1 1 1 1
            // 2   1 1 1 1 1 1 1 1
            // 3   1 1 1 1 1 1 1 0
            // 4   1 1 1 1 1 1 0 0
            // 5   1 1 1 1 1 1 0 2
            // 6   1 1 1 1 1 1 1 0
            // 7   1 1 1 1 1 1 1 1
            // Act
            spel.AandeBeurt = Kleur.Zwart;
            var actual = spel.Pas();
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Kleur.Wit, spel.AandeBeurt);
        }

        [Test]
        public void Pas_WitAanZetGeenZetMogelijk_ReturnTrueEnWisselBeurt()
        {
            // Arrange  (zowel wit als zwart kunnen niet meer)
            Spel spel = new Spel();
            spel.Bord[0, 0] = Kleur.Wit;
            spel.Bord[0, 1] = Kleur.Wit;
            spel.Bord[0, 2] = Kleur.Wit;
            spel.Bord[0, 3] = Kleur.Wit;
            spel.Bord[0, 4] = Kleur.Wit;
            spel.Bord[0, 5] = Kleur.Wit;
            spel.Bord[0, 6] = Kleur.Wit;
            spel.Bord[0, 7] = Kleur.Wit;
            spel.Bord[1, 0] = Kleur.Wit;
            spel.Bord[1, 1] = Kleur.Wit;
            spel.Bord[1, 2] = Kleur.Wit;
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[1, 4] = Kleur.Wit;
            spel.Bord[1, 5] = Kleur.Wit;
            spel.Bord[1, 6] = Kleur.Wit;
            spel.Bord[1, 7] = Kleur.Wit;
            spel.Bord[2, 0] = Kleur.Wit;
            spel.Bord[2, 1] = Kleur.Wit;
            spel.Bord[2, 2] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            spel.Bord[2, 4] = Kleur.Wit;
            spel.Bord[2, 5] = Kleur.Wit;
            spel.Bord[2, 6] = Kleur.Wit;
            spel.Bord[2, 7] = Kleur.Wit;
            spel.Bord[3, 0] = Kleur.Wit;
            spel.Bord[3, 1] = Kleur.Wit;
            spel.Bord[3, 2] = Kleur.Wit;
            spel.Bord[3, 3] = Kleur.Wit;
            spel.Bord[3, 4] = Kleur.Wit;
            spel.Bord[3, 5] = Kleur.Wit;
            spel.Bord[3, 6] = Kleur.Wit;
            spel.Bord[3, 7] = Kleur.Geen;
            spel.Bord[4, 0] = Kleur.Wit;
            spel.Bord[4, 1] = Kleur.Wit;
            spel.Bord[4, 2] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[4, 4] = Kleur.Wit;
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Geen;
            spel.Bord[4, 7] = Kleur.Geen;
            spel.Bord[5, 0] = Kleur.Wit;
            spel.Bord[5, 1] = Kleur.Wit;
            spel.Bord[5, 2] = Kleur.Wit;
            spel.Bord[5, 3] = Kleur.Wit;
            spel.Bord[5, 4] = Kleur.Wit;
            spel.Bord[5, 5] = Kleur.Wit;
            spel.Bord[5, 6] = Kleur.Geen;
            spel.Bord[5, 7] = Kleur.Zwart;
            spel.Bord[6, 0] = Kleur.Wit;
            spel.Bord[6, 1] = Kleur.Wit;
            spel.Bord[6, 2] = Kleur.Wit;
            spel.Bord[6, 3] = Kleur.Wit;
            spel.Bord[6, 4] = Kleur.Wit;
            spel.Bord[6, 5] = Kleur.Wit;
            spel.Bord[6, 6] = Kleur.Wit;
            spel.Bord[6, 7] = Kleur.Geen;
            spel.Bord[7, 0] = Kleur.Wit;
            spel.Bord[7, 1] = Kleur.Wit;
            spel.Bord[7, 2] = Kleur.Wit;
            spel.Bord[7, 3] = Kleur.Wit;
            spel.Bord[7, 4] = Kleur.Wit;
            spel.Bord[7, 5] = Kleur.Wit;
            spel.Bord[7, 6] = Kleur.Wit;
            spel.Bord[7, 7] = Kleur.Wit;

            //     0 1 2 3 4 5 6 7
            //     v
            // 0   1 1 1 1 1 1 1 1  
            // 1   1 1 1 1 1 1 1 1
            // 2   1 1 1 1 1 1 1 1
            // 3   1 1 1 1 1 1 1 0
            // 4   1 1 1 1 1 1 0 0
            // 5   1 1 1 1 1 1 0 2
            // 6   1 1 1 1 1 1 1 0
            // 7   1 1 1 1 1 1 1 1
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.Pas();
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Kleur.Zwart, spel.AandeBeurt);
        }

        [Test]
        public void Afgelopen_GeenZetMogelijk_ReturnTrue()
        {
            // Arrange  (zowel wit als zwart kunnen niet meer)
            Spel spel = new Spel();
            spel.Bord[0, 0] = Kleur.Wit;
            spel.Bord[0, 1] = Kleur.Wit;
            spel.Bord[0, 2] = Kleur.Wit;
            spel.Bord[0, 3] = Kleur.Wit;
            spel.Bord[0, 4] = Kleur.Wit;
            spel.Bord[0, 5] = Kleur.Wit;
            spel.Bord[0, 6] = Kleur.Wit;
            spel.Bord[0, 7] = Kleur.Wit;
            spel.Bord[1, 0] = Kleur.Wit;
            spel.Bord[1, 1] = Kleur.Wit;
            spel.Bord[1, 2] = Kleur.Wit;
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[1, 4] = Kleur.Wit;
            spel.Bord[1, 5] = Kleur.Wit;
            spel.Bord[1, 6] = Kleur.Wit;
            spel.Bord[1, 7] = Kleur.Wit;
            spel.Bord[2, 0] = Kleur.Wit;
            spel.Bord[2, 1] = Kleur.Wit;
            spel.Bord[2, 2] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            spel.Bord[2, 4] = Kleur.Wit;
            spel.Bord[2, 5] = Kleur.Wit;
            spel.Bord[2, 6] = Kleur.Wit;
            spel.Bord[2, 7] = Kleur.Wit;
            spel.Bord[3, 0] = Kleur.Wit;
            spel.Bord[3, 1] = Kleur.Wit;
            spel.Bord[3, 2] = Kleur.Wit;
            spel.Bord[3, 3] = Kleur.Wit;
            spel.Bord[3, 4] = Kleur.Wit;
            spel.Bord[3, 5] = Kleur.Wit;
            spel.Bord[3, 6] = Kleur.Wit;
            spel.Bord[3, 7] = Kleur.Geen;
            spel.Bord[4, 0] = Kleur.Wit;
            spel.Bord[4, 1] = Kleur.Wit;
            spel.Bord[4, 2] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[4, 4] = Kleur.Wit;
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Geen;
            spel.Bord[4, 7] = Kleur.Geen;
            spel.Bord[5, 0] = Kleur.Wit;
            spel.Bord[5, 1] = Kleur.Wit;
            spel.Bord[5, 2] = Kleur.Wit;
            spel.Bord[5, 3] = Kleur.Wit;
            spel.Bord[5, 4] = Kleur.Wit;
            spel.Bord[5, 5] = Kleur.Wit;
            spel.Bord[5, 6] = Kleur.Geen;
            spel.Bord[5, 7] = Kleur.Zwart;
            spel.Bord[6, 0] = Kleur.Wit;
            spel.Bord[6, 1] = Kleur.Wit;
            spel.Bord[6, 2] = Kleur.Wit;
            spel.Bord[6, 3] = Kleur.Wit;
            spel.Bord[6, 4] = Kleur.Wit;
            spel.Bord[6, 5] = Kleur.Wit;
            spel.Bord[6, 6] = Kleur.Wit;
            spel.Bord[6, 7] = Kleur.Geen;
            spel.Bord[7, 0] = Kleur.Wit;
            spel.Bord[7, 1] = Kleur.Wit;
            spel.Bord[7, 2] = Kleur.Wit;
            spel.Bord[7, 3] = Kleur.Wit;
            spel.Bord[7, 4] = Kleur.Wit;
            spel.Bord[7, 5] = Kleur.Wit;
            spel.Bord[7, 6] = Kleur.Wit;
            spel.Bord[7, 7] = Kleur.Wit;

            //     0 1 2 3 4 5 6 7
            //     v
            // 0   1 1 1 1 1 1 1 1  
            // 1   1 1 1 1 1 1 1 1
            // 2   1 1 1 1 1 1 1 1
            // 3   1 1 1 1 1 1 1 0
            // 4   1 1 1 1 1 1 0 0
            // 5   1 1 1 1 1 1 0 2
            // 6   1 1 1 1 1 1 1 0
            // 7   1 1 1 1 1 1 1 1
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.Afgelopen();
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void Afgelopen_GeenZetMogelijkAllesBezet_ReturnTrue()
        {
            // Arrange  (zowel wit als zwart kunnen niet meer)
            Spel spel = new Spel();
            spel.Bord[0, 0] = Kleur.Wit;
            spel.Bord[0, 1] = Kleur.Wit;
            spel.Bord[0, 2] = Kleur.Wit;
            spel.Bord[0, 3] = Kleur.Wit;
            spel.Bord[0, 4] = Kleur.Wit;
            spel.Bord[0, 5] = Kleur.Wit;
            spel.Bord[0, 6] = Kleur.Wit;
            spel.Bord[0, 7] = Kleur.Wit;
            spel.Bord[1, 0] = Kleur.Wit;
            spel.Bord[1, 1] = Kleur.Wit;
            spel.Bord[1, 2] = Kleur.Wit;
            spel.Bord[1, 3] = Kleur.Wit;
            spel.Bord[1, 4] = Kleur.Wit;
            spel.Bord[1, 5] = Kleur.Wit;
            spel.Bord[1, 6] = Kleur.Wit;
            spel.Bord[1, 7] = Kleur.Wit;
            spel.Bord[2, 0] = Kleur.Wit;
            spel.Bord[2, 1] = Kleur.Wit;
            spel.Bord[2, 2] = Kleur.Wit;
            spel.Bord[2, 3] = Kleur.Wit;
            spel.Bord[2, 4] = Kleur.Wit;
            spel.Bord[2, 5] = Kleur.Wit;
            spel.Bord[2, 6] = Kleur.Wit;
            spel.Bord[2, 7] = Kleur.Wit;
            spel.Bord[3, 0] = Kleur.Wit;
            spel.Bord[3, 1] = Kleur.Wit;
            spel.Bord[3, 2] = Kleur.Wit;
            spel.Bord[3, 3] = Kleur.Wit;
            spel.Bord[3, 4] = Kleur.Wit;
            spel.Bord[3, 5] = Kleur.Wit;
            spel.Bord[3, 6] = Kleur.Wit;
            spel.Bord[3, 7] = Kleur.Wit;
            spel.Bord[4, 0] = Kleur.Wit;
            spel.Bord[4, 1] = Kleur.Wit;
            spel.Bord[4, 2] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[4, 4] = Kleur.Wit;
            spel.Bord[4, 5] = Kleur.Wit;
            spel.Bord[4, 6] = Kleur.Zwart;
            spel.Bord[4, 7] = Kleur.Zwart;
            spel.Bord[5, 0] = Kleur.Wit;
            spel.Bord[5, 1] = Kleur.Wit;
            spel.Bord[5, 2] = Kleur.Wit;
            spel.Bord[5, 3] = Kleur.Wit;
            spel.Bord[5, 4] = Kleur.Wit;
            spel.Bord[5, 5] = Kleur.Wit;
            spel.Bord[5, 6] = Kleur.Zwart;
            spel.Bord[5, 7] = Kleur.Zwart;
            spel.Bord[6, 0] = Kleur.Wit;
            spel.Bord[6, 1] = Kleur.Wit;
            spel.Bord[6, 2] = Kleur.Wit;
            spel.Bord[6, 3] = Kleur.Wit;
            spel.Bord[6, 4] = Kleur.Wit;
            spel.Bord[6, 5] = Kleur.Wit;
            spel.Bord[6, 6] = Kleur.Wit;
            spel.Bord[6, 7] = Kleur.Zwart;
            spel.Bord[7, 0] = Kleur.Wit;
            spel.Bord[7, 1] = Kleur.Wit;
            spel.Bord[7, 2] = Kleur.Wit;
            spel.Bord[7, 3] = Kleur.Wit;
            spel.Bord[7, 4] = Kleur.Wit;
            spel.Bord[7, 5] = Kleur.Wit;
            spel.Bord[7, 6] = Kleur.Wit;
            spel.Bord[7, 7] = Kleur.Wit;

            //     0 1 2 3 4 5 6 7
            //     v
            // 0   1 1 1 1 1 1 1 1  
            // 1   1 1 1 1 1 1 1 1
            // 2   1 1 1 1 1 1 1 1
            // 3   1 1 1 1 1 1 1 2
            // 4   1 1 1 1 1 1 2 2
            // 5   1 1 1 1 1 1 2 2
            // 6   1 1 1 1 1 1 1 2
            // 7   1 1 1 1 1 1 1 1
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.Afgelopen();
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void Afgelopen_WelZetMogelijk_ReturnFalse()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //                     
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     
            // Act
            spel.AandeBeurt = Kleur.Wit;
            var actual = spel.Afgelopen();
            // Assert
            Assert.IsFalse(actual);
        }



        [Test]
        public void OverwegendeKleur_Gelijk_ReturnKleurGeen()
        {
            // Arrange
            Spel spel = new Spel();
            //     0 1 2 3 4 5 6 7
            //                     
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     
            // Act
            var actual = spel.OverwegendeKleur();
            // Assert
            Assert.AreEqual(Kleur.Geen, actual);
        }

        [Test]
        public void OverwegendeKleur_Zwart_ReturnKleurZwart()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 3] = Kleur.Zwart;
            spel.Bord[3, 3] = Kleur.Zwart;
            spel.Bord[4, 3] = Kleur.Zwart;
            spel.Bord[3, 4] = Kleur.Zwart;
            spel.Bord[4, 4] = Kleur.Wit;

            //     0 1 2 3 4 5 6 7
            //                     
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 2 0 0 0 0
            // 3   0 0 0 2 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     
            // Act
            var actual = spel.OverwegendeKleur();
            // Assert
            Assert.AreEqual(Kleur.Zwart, actual);
        }

        [Test]
        public void OverwegendeKleur_Wit_ReturnKleurWit()
        {
            // Arrange
            Spel spel = new Spel();
            spel.Bord[2, 3] = Kleur.Wit;
            spel.Bord[3, 3] = Kleur.Wit;
            spel.Bord[4, 3] = Kleur.Wit;
            spel.Bord[3, 4] = Kleur.Wit;
            spel.Bord[4, 4] = Kleur.Zwart;


            //     0 1 2 3 4 5 6 7
            //                     
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 1 0 0 0
            // 4   0 0 0 1 2 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     
            // Act
            var actual = spel.OverwegendeKleur();
            // Assert
            Assert.AreEqual(Kleur.Wit, actual);
        }
    }
}