using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWindowsFormsApp_.NET_Framework_
{
    internal static class Levels
    {
        public static char[] TileTypeCycler = {'n', 'w', 's', 'm', 'h', '1'};
        public static string[] LevelArray =
        {
            "005005" +
             "hnwww" +
             "wnnnw" +
             "wwwnw" +
             "wnnnw" +
             "wnwww" +
                                    //LEVEL 1
             "....." +
             "....." +
             "....." +
             ".v..." +
             "....." +
                "002",

            "005005" +
                "hnwww" +
                "wnnnw" +
                "wwwnw" +
                "wnsnw" +
                "wnwww" + // 2
                "....." +
                "....." +
                "....." +
                ".v..." +
                "....." +
                "002",

            "004004" +
             "wnww" +
             "nsnn" +
             "nnnw" +
             "hnww" +
                            //3
             ".v.." +
             "...v" +
             "...." +
             "...." +
                "002",



            "005005" +
                "nnnnw" +
                "nwsww" +
                "nwnww" +
                "nnsnn" +
                "nnhnn" +
                                    //4
                "....." +
                "....." +
                "....." +
                "....." +
                "vvvvv" +
                "002",

            "004004" +
                "nnnn" +
                "wshn" +
                "nnsn" +
                "nnwn" + //5
                "...v" +
                "..v." +
                "v..." +
                ".v..",

            "005005" +
                "hs1nn" +
                "nnwwn" +
                "nwwwn" +
                "nwwwn" +
                "nnnnn" +
                "....." +       //6
                "....." +
                "....." +
                "....." +
                ".vvvv" +
                "002",

            "005005" +
                "wnnww" +
                "hn1nw" +
                "nwnnn" +
                "nwswn" +
                "nnnnn" +       // 7
                ".vv.." +
                "vv.v." +
                "....." +
                "....." +
                "....." +
                "002",

            "005005" +
             "nnhn1" +
             "nwnnn" +
             "nwsws" +
             "nn2n2" +
             "wwnwn" +
                                    // 8
             "....." +
             "....." +
             "....." +
             "....." +
             "..v.v" +
                "002",
            
            "005005"+
                "nnnnh" +
                "nsssn" +
                "nsssn" +
                "nsssn" +
                "nnnnn" +
                                    // 9
                "..v.." +   
                ".v.v." +
                "v...v" +
                ".v.v." +
                "..v.." +
                "002",
            "009009" +
                "wwnsnsnww" +
                "wnnnsnnnw" +
                "nnwnnnwnn" +
                "snnwswnns" +
                "nsnshsnsn" +
                "snnwswnns" +
                "nnwnnnwnn" +
                "wnnnsnnnw" +
                "wwnsnsnww" +
                                        // 10
                "........." +
                "........." +
                "...v.v..." +
                "..v...v.." +
                ".......v." +
                "..v...v.." +
                "...v.v..." +
                "........." +
                "........." +
                "002",
            "006006" +
                "wwwnnw" +
                "wnnsnw" +
                "nssnnw" +
                "wnwwnn" +
                "whnnnn" +
                "wwwwww" +
                "......" +      // 11
                ".v...." +
                "vvv..." +
                "......" +
                ".v...." +
                "......" +
                "002",
            "005005" +
                "wnhnw" +
                "wmwsw" +
                "w1w1w" +
                "wnnnw" +
                "wnwnw" + // 12
                "....." +
                "....." +
                "....." +
                ".v.v." +
                ".v.v.",

            "005005" +
                "n1nnn" +
                "wwnsn" +
                "nnnhn" +
                "nnnmn" +
                "nnnnn" +
                "vv..." + // 13
                "....." +
                ".vv.v" +
                "....." +
                "....." +
                "002",

            "007007" +
                "nnnnnww" +
                "nnnnm2n" +
                "nnhnnww" +
                "2wwnm2n" +
                "snwmwww" +
                "nnw1nnw" +
                "wnnnnnn" +
                "......." + // 14
                "......." +
                "......." +
                "......." +
                "vv....." +
                "vv..vv." +
                ".vvvvvv",

            "007007" +
                "wwwwnww" +
                "nnnhnww" +
                "2wnwnww" +
                "ns2s2sn" +
                "wwnwnww" +
                "wwnnnww" +
                "wwwwwww" + // 15
                "....v.." +
                "......." +
                "..v.v.." +
                "..v.v.v" +
                "..v.v.." +
                "..vvv.." +
                "......." +
                "002",

            "010010" +
                "hwnnnnnnnw" +
                "8wnnnnnnnw" +
                "8wnnnnnnnn" +
                "8wnnwnnnnw" +
                "8wnnnnnnnn" +
                "8wnnnnnnnn" +
                "8wnnnnnwwn" +
                "5wnnnnnwwn" +
                "nnnnnnnnnn" +
                "wwwwwwwwww" +
                "..vvvvvvv." + //16
                "..vvvvvvv." +
                "..vvvvvvvv" +
                "..vv.vvvv." +
                "..vvvvvvvv" +
                "..vvvvvvvv" +
                "..vvvvv..v" +
                "..vvvvv..v" +
                ".........." +
                ".........." +
                "002",

            "005005" +
                "nnnnn" +
                "nnsss" +
                "nshsn" +
                "nwnnn" +
                "1ns1w" + // 17
                "....v" +
                "v...v" +
                ".v..." +
                "v..vv" +
                ".vvv.",

            "010010" +
                "nnnwnnwn1n" +
                "nsn1nnnnw1" +
                "nnnwnnwn1n" +
                "wwwwnnwwww" +
                "nn1mh1wnnw" +
                "nwwwnnssnn" +
                "nwwwnn1nnn" +
                "nwwwnnwnnn" +
                "nnnnnnwwww" +
                "nnnnnnnnnn" + // 18
                ".........." +
                ".........." +
                ".........." +
                ".........." +
                ".........." +
                ".........v" +
                ".........v" +
                ".........v" +
                ".........." +
                "vvvvvvvvvv" +
                "002",
            "011011" +
                "nnnnnhnnnnn" +
                "nnnssmssnnn" +
                "nnns1sssnnn" +
                "nnn1ssssnnn" +
                "nnnss1ssnnn" +
                "nnnsss1snnn" +
                "nnnss1ssnnn" +
                "nnns1sssnnn" +
                "nnnsss1snnn" +
                "nnnnnnnnnnn" + // 19
                "nnnnnnnnnnn" +
                "..........." +
                "vv.......vv" +
                "v.......vvv" +
                ".......vvvv" +
                "vv.......vv" +
                "vvv.......v" +
                "vv.......vv" +
                "v.......vvv" +
                "vvv.......v" +
                "..........." +
                "vvvvvvvvvvv",


            "010010" +
                "nsnnhnnnnn" +
                "s1snnnnnnw" +
                "nwmnnnnnnn" +
                "n1snnnnsww" +
                "wwnnnnss1n" +
                "n1snnnnsww" +
                "nwnnnnnnnn" +
                "n1snnnnnnn" +
                "wssnwwwwwn" +
                "wnnnnnnnnn" +
                                          
                ".........v" + // 20
                "v........." +
                ".........v" +
                "v........." +
                ".........v" +
                "v........." +
                ".........." +
                ".........." +
                "..v......." +
                ".vvvvvvvv." +
                "002",
            "001001n.002"
        };

        //public static bool[] replenishfood = { false, false, false, false, false, false, false, false, false, false };
        public static Tile[,] GetVictoryTiles(int LevelChoice)
        {
            return GetVictoryTiles(LevelArray[LevelChoice]);
        }
        public static Tile[,] GetVictoryTiles(string Level)
        {
            Tile[,] victorytiles = new Tile[Set.BoardWidth, Set.BoardHeight];
            int StartingIndex = (Set.BoardWidth * Set.BoardHeight) + 6;
            for (int x = 0; x < Set.BoardWidth; x++)
            {
                for(int y = 0; y < Set.BoardHeight; y++)
                {
                    if (Level[StartingIndex] == 'v')
                    {
                        victorytiles[x, y] = new VictoryTile(x, y);
                    }
                    else
                    {
                        victorytiles[x, y] = new Empty(x, y);
                    }
                    StartingIndex++;
                }
            }
            return victorytiles;
        }
        public static int GetLevelBody(int LevelChoice)
        {
            return GetLevelBody(LevelArray[LevelChoice]);
        }
        public static int GetLevelBody(string Level)
        {
            string BodyLengthStr = "";
            for (int i = Level.Length - 3; i < Level.Length; i++)
            {
                BodyLengthStr += Level[i];
            }
            if (int.TryParse(BodyLengthStr, out int BodyLength))
            {
                return BodyLength;
            }
            else { return 2; }
        }
        public static Tile[,] GetLevel(int LevelChoice)
        {
            return GetLevel(LevelArray[LevelChoice]);
        }
        public static Tile[,] GetLevel(string Level)
        {
            string WidthValue = "";
            for (int i = 0; i < 3; i++)
            {
                WidthValue += Level[i];
            }
            Set.BoardWidth = Convert.ToInt32(WidthValue);
            string HeightValue = "";
            for (int i = 3; i < 6; i++)
            {
                HeightValue += Level[i];
            }
            Set.BoardHeight = Convert.ToInt32(HeightValue);

            Tile[,] Board = new Tile[Set.BoardWidth, Set.BoardHeight];

            int LevelTileIndex = 6;
            for (int x = 0; x < Set.BoardWidth; x++)
            {
                for (int y = 0; y < Set.BoardHeight; y++)
                {
                    switch (Level[LevelTileIndex])
                    {
                        case 'n':
                            Board[x, y] = new Empty(x, y);
                            break;
                        case 'w':
                            Board[x, y] = new Wall(x, y);
                            break;
                        case 's':
                            Board[x, y] = new UnMuncher(x, y);
                            break;
                        case 'm':
                            Board[x, y] = new Muncher(x,y);
                            break;
                        case 'h':
                            Board[x, y] = new Head(x, y);
                            break;
                        case 'u':
                            Board[x, y] = new Mover(x, y, 0, -1);
                            break;
                        case 'd':
                            Board[x, y] = new Mover(x, y, 0, 1);
                            break;
                        case 'l':
                            Board[x, y] = new Mover(x, y, -1, 0);
                            break;
                        case 'r':
                            Board[x, y] = new Mover(x, y, 1, 0);
                            break;
                        default:
                            Board[x, y] = new Edible(x, y, Convert.ToInt32(Convert.ToString(Level[LevelTileIndex])));
                            break;
                    }
                    LevelTileIndex++;
                }
            }
            return Board;
        }
    }
}
