using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsFormsApp_.NET_Framework_
{
    internal static class Program
    {
        // <summary>
        // Der Haupteinstiegspunkt für die Anwendung.
        // </summary>
        public static Form1 mainform = null;

        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainform = new Form1();
            Application.Run(mainform);
        }

        public static void TickStep()
        {
            GS.BodyLength = GS.PlayerBody.Count;

            if (CheckMovablePrime(GS.PlayerBody[0], Con.DeltaX, Con.DeltaY))
            {
                ChangeBoardPrime(GS.PlayerBody[0], Con.DeltaX, Con.DeltaY);
                Data.PlayMoveSound();
                MoveSnakeTailPrime();
                MoveMovers();

                Con.BoardStateIndex++;
                MakeGameState();
            }
            else
            {
                Data.PlaySound(Data.WallHitSound, Data.SoundType.GameSFX, 0.15f);
            }
            AddPlayerToBoard();
            ResetValues();
            Con.Victory = CheckWin().Item2;
            int CurrentVicTiles = CheckWin().Item1;
            if (Con.Victory && mainform.VictoryScreen.Enabled == false) { Data.PlaySound(Data.VictorySound, Data.SoundType.GameSFX, 1); } 
            else if (CurrentVicTiles > Con.PastCoveredVicTiles) { Data.PlaySound(Data.VictoryTileActivation, Data.SoundType.GameSFX, 5); }
            
            Con.PastCoveredVicTiles = CurrentVicTiles;
        }
        public static void MoveMovers()
        {
            List<Mover> TempMoverList = new List<Mover>();
            foreach (Tile tile in GS.Board)
            {
                if (tile is Mover)
                {
                    TempMoverList.Add(tile as Mover);
                }
            }
            foreach (Mover m in TempMoverList)
            {
                if (CheckMovablePrime(m, m.DeltaX, m.DeltaY))
                {
                    ChangeBoardPrime(m, m.DeltaX, m.DeltaY);
                }
                else
                {
                    m.DeltaX *= -1;
                    m.DeltaY *= -1;
                }
            }
        }
        public static (int, bool) CheckWin()
        {
            bool ReturnVal = true;
            int Count = 0;
            foreach (Tile tile in GS.VictoryTiles)
            {
                if (tile is VictoryTile)
                {
                    if (GS.Board[tile.X, tile.Y] is Empty || GS.Board[tile.X, tile.Y] is Edible)
                    {
                        ReturnVal = false;
                    }
                    else
                    {
                        Count++;
                    }
                }
            }
            return (Count, ReturnVal);
        }
        public static void LoadPastGameState()
        {
            if(Con.BoardStateIndex < 1)
            {
                Con.BoardStateIndex = 1;
            }
            GS.PlayerBody = CopyBody(GS.PastPlayerBodies[Con.BoardStateIndex]);
            GS.Board = CopyBoard(GS.PastBoardStates[Con.BoardStateIndex]);
            GS.BodyLength = GS.PlayerBody.Count;
            RemoveFutureGameStates();

            AddPlayerToBoard();
            ResetValues();
        }
        public static void RemoveFutureGameStates()
        {
            for(int i = Con.BoardStateIndex + 1; i < GS.PastBoardStates.Count; i++)
            {
                GS.PastPlayerBodies.RemoveAt(i);
                GS.PastBoardStates.RemoveAt(i);
            }
        }
        public static void MakeGameState()
        {
            GS.PastBoardStates.Add(null);
            GS.PastPlayerBodies.Add(null);
            GS.PastBoardStates[Con.BoardStateIndex] = CopyBoard(GS.Board);
            GS.PastPlayerBodies[Con.BoardStateIndex] = CopyBody(GS.PlayerBody);
        }

        public static bool CheckMovablePrime(Tile ToCheck, int DeltaX, int DeltaY)
        {
            int oldX = ToCheck.X;
            int oldY = ToCheck.Y;
            if(DeltaX == 0 && DeltaY == 0)
            {
                return false;
            }
            int newX = oldX + DeltaX;
            int newY = oldY + DeltaY;
            if (newX >= Set.BoardWidth || newY >= Set.BoardHeight || newX < 0 || newY < 0) // Bounds Check
            {
                return false;
            }
            if (GS.Board[newX, newY] is Movable)
            {
                return (CheckMovablePrime(GS.Board[newX, newY], DeltaX, DeltaY));
            }
            if (GS.Board[newX, newY] is Wall || GS.Board[newX, newY] is Body || GS.Board[newX, newY] is Head)
            {
                return false;
            }
            if (GS.Board[newX, newY] is Edible)
            {
                if (GS.Board[oldX, oldY] is UnMuncher)
                {
                    return false;
                }
                else
                {
                    if (Con.FoodReplenish)
                    {
                        Program.ReplenishFoodPrime();
                    }
                    Program.EatTilePrime(newX, newY);
                }
            }

            return true;
        }

        public static void MoveSnakeTailPrime()
        {
            GS.PlayerBody[0].X -= Con.DeltaX;
            GS.PlayerBody[0].Y -= Con.DeltaY;
            for (int i = GS.PlayerBody.Count - 1; i > 0; i--)
            {
                GS.PlayerBody[i].X = GS.PlayerBody[i - 1].X;
                GS.PlayerBody[i].Y = GS.PlayerBody[i - 1].Y;
            }
            GS.PlayerBody[0].X += Con.DeltaX;
            GS.PlayerBody[0].Y += Con.DeltaY;
        }
        public static void ChangeBoardPrime(Tile ToMove, int DeltaX, int DeltaY)
        {
            int oldX = ToMove.X;
            int oldY = ToMove.Y;
            
            if (GS.Board[oldX + DeltaX, oldY + DeltaY] is Movable || GS.Board[oldX + DeltaX, oldY + DeltaY] is Body)
            {
                ChangeBoardPrime(GS.Board[oldX + DeltaX, oldY + DeltaY], DeltaX, DeltaY);
            }
            ToMove.X += DeltaX;
            ToMove.Y += DeltaY;
            GS.Board[oldX + DeltaX, oldY + DeltaY] = GS.Board[oldX, oldY];
            GS.Board[oldX, oldY] = new Empty(oldX, oldY);
        }
        public static void EatTilePrime(int X, int Y)
        {
            Edible e = GS.Board[X, Y] as Edible;
            GS.Board[X, Y] = new Empty(X, Y);
            for (int i = 0; i < e.GrowthValue; i++)
            {
                Body bodypart = new Body(1000, 1000);
                GS.PlayerBody.Add(bodypart);
                GS.BodyLength++;
            }
        }
        public static void ReplenishFoodPrime()
        {
            List<int[]> EmptySpaceCoords = new List<int[]>();
            for (int i = 0; i < Set.BoardHeight; i++)
            {
                for (int j = 0; j < Set.BoardWidth; j++)
                {
                    if (GS.Board[i, j] is Empty)
                    {
                        int[] XYPair = new int[2];
                        XYPair[0] = i;
                        XYPair[1] = j;
                        EmptySpaceCoords.Add(XYPair);
                    }
                }
            }
            if(EmptySpaceCoords.Count == 0)
            {
                return;
            }
            Random r = new Random();
            int EmptyIndex = r.Next(0, EmptySpaceCoords.Count);
            Edible food = new Edible(EmptySpaceCoords[EmptyIndex][0], EmptySpaceCoords[EmptyIndex][1], 1);
            GS.Board[EmptySpaceCoords[EmptyIndex][0], EmptySpaceCoords[EmptyIndex][1]] = food;
        }
        public static void ResetValues()
        {
            Con.DeltaX = 0;
            Con.DeltaY = 0;
        }

        public static Tile[,] CopyBoard(Tile[,] oldBoard)
        {
            Tile[,] newBoard = new Tile[oldBoard.GetLength(0), oldBoard.GetLength(1)];
            for (int x = 0; x < oldBoard.GetLength(0); x++)
            {
                for (int y = 0; y < oldBoard.GetLength(1); y++)
                {
                    Tile newtile = oldBoard[x, y].CreateSameType();
                    oldBoard[x, y].CopyData(newtile);
                    newBoard[x, y] = newtile;
                }
            }
            return newBoard;
        }
        public static List<Tile> CopyBody(List<Tile> oldBody)
        {
            List<Tile> newBody = new List<Tile>();
            foreach(Tile oldtile in oldBody)
            {
                Tile newtile = oldtile.CreateSameType();
                oldtile.CopyData(newtile);
                newBody.Add(newtile);
            }
            return (newBody);
        }
        public static void InitializeGame(string level)
        {
            Con.Playing = true;
            Con.Victory = false;

            Con.BoardStateIndex = 0;

            GS.PastPlayerBodies = new List<List<Tile>>();
            GS.PastBoardStates = new List<Tile[,]>();
            GS.PastBoardStates.Add(null);
            GS.PastPlayerBodies.Add(new List<Tile>());

            GS.Board = Levels.GetLevel(level);
            GS.BodyLength = Levels.GetLevelBody(level);
            GS.PlayerBody = ConstructBody(GS.BodyLength);


            Set.BoardWidth = GS.Board.GetLength(0);
            Set.BoardHeight = GS.Board.GetLength(1);
            Set.TileHeight = Set.SquareSide / Set.BoardHeight; //Here lies opportunity
            Set.TileWidth = Set.SquareSide / Set.BoardWidth;

            GS.VictoryTiles = Levels.GetVictoryTiles(level);

            //Con.FoodReplenish = level < Levels.replenishfood.Length? Levels.replenishfood[level] : false;
            //if (Con.FoodReplenish)
            //{
            //    Program.ReplenishFoodPrime();
            //}
            Con.BoardStateIndex++;
            MakeGameState();
            mainform.RefreshBoard();
        }
        public static void InitializeGame(int level)
        {
            Con.CurrentLevel = level;
            InitializeGame(Levels.LevelArray[level]);
        }
        public static List<Tile> ConstructBody(int BodyLength)
        {
            Head head = new Head();
            foreach (Tile tile in GS.Board)
            {
                if(tile is Head)
                {
                    head = (Head)tile; 
                }
            }
            List<Tile> Snake = new List<Tile>();
            Snake.Add(head);
            Body[] bodies = new Body[BodyLength];
            for (int i = 0; i < BodyLength; i++)
            {
                bodies[i] = new Body(head.X, head.Y);
                Snake.Add(bodies[i]);
            }
            return Snake;
        }
        public static void AddPlayerToBoard()
        {
            for (int i = 0; i < Set.BoardWidth; i++)
            {
                for (int j = 0; j < Set.BoardHeight; j++)
                {
                    if (GS.Board[i, j] is Body || GS.Board[i, j] is Head)
                    {
                        Empty e = new Empty(i, j);
                        GS.Board[i, j] = e;
                    }
                }
            }
            foreach (Tile bodypart in GS.PlayerBody)
            {
                if (bodypart.X != 1000)
                {
                    GS.Board[bodypart.X, bodypart.Y] = bodypart;
                }
            }
            GS.Board[GS.PlayerBody[0].X, GS.PlayerBody[0].Y] = GS.PlayerBody[0];
        }
    }
}
