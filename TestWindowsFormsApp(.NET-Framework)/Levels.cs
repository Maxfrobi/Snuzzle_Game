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
             ".....",

            "004004" +
             "wnww" +
             "nsnn" +
             "nnnw" +
             "hnww" +
                                  //LEVEL 2
             ".v.." +
             "...v" +
             "...." +
             "....",



            "005005" +
                "nnnnw" +
                "nwsww" +
                "nwnww" +
                "nnsnn" +
                "nnhnn" +
                                    //LEVEL 3
                "....." +
                "....." +
                "....." +
                "....." +
                "vvvvv",

            "005005" +
             "nnhn1" +
             "nwnnn" +
             "nwsws" +
             "nn2n2" +
             "wwnwn" +
                                    //LEVEL 4
             "....." +
             "....." +
             "....." +
             "....." +
             "..v.v",

            "008008" +
                "hnwwnnnn" +
                "nnwwnnnn" +
                "nwwwnnnn" +
                "n777nnnn" +
                "nwwwnnnn" +
                "nnwwnnnn" +
                "nnwwnnnn" +
                "nnwwnnnn" +
                                    //LEVEL 5
                ".....vvv" +
                ".....vvv" +
                ".....vvv" +
                ".....vvv" +
                ".....vvv" +
                ".....vvv" +
                ".....vvv" +
                ".....vvv",


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

                ".........v" +
                "v........." +
                ".........v" +
                "v........." +
                ".........v" +
                "v........." +
                ".........." +
                ".........." +
                "..v......." +
                ".vvvvvvvv." ,

            "005002" +
                "nnnnn" +
                "nnnnn" +
                "....." +
                ".....",
            "002002nnnn....",
            "002002nnnn....",
            "001001n."              //LEVEL 10 -- Editor
        };
        static int[] bodylength = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        public static bool[] replenishfood = { false, false, false, false, false, false, false, false, false, false };
        public static Tile[,] GetVictoryTiles(int Levelchoice)
        {
            Tile[,] victorytiles = new Tile[Set.BoardWidth, Set.BoardHeight];
            int StartingIndex = (Set.BoardWidth * Set.BoardHeight) + 6;
            for (int x = 0; x < Set.BoardWidth; x++)
            {
                for(int y = 0; y < Set.BoardHeight; y++)
                {
                    if (LevelArray[Levelchoice][StartingIndex] == 'v')
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
            return bodylength[LevelChoice];
        }
        public static Tile[,] GetLevel(int LevelChoice)
        {
            string WidthValue = "";
            for (int i = 0; i < 3; i++)
            {
                WidthValue += LevelArray[LevelChoice][i];
            }
            Set.BoardWidth = Convert.ToInt32(WidthValue);
            string HeightValue = "";
            for (int i = 3; i < 6; i++)
            {
                HeightValue += LevelArray[LevelChoice][i];
            }
            Set.BoardHeight = Convert.ToInt32(HeightValue);

            Tile[,] Board = new Tile[Set.BoardWidth, Set.BoardHeight];

            int LevelTileIndex = 6;
            for (int x = 0; x < Set.BoardWidth; x++)
            {
                for (int y = 0; y < Set.BoardHeight; y++)
                {
                    switch (LevelArray[LevelChoice][LevelTileIndex])
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
                        default:
                            Board[x, y] = new Edible(x, y, Convert.ToInt32(Convert.ToString(LevelArray[LevelChoice][LevelTileIndex])));
                            break;
                    }
                    LevelTileIndex++;
                }
            }
            return Board;
        }
    }
}
