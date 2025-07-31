using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using TestWindowsFormsApp_.NET_Framework_.Properties;

namespace TestWindowsFormsApp_.NET_Framework_
{
    public partial class Form1 : Form
    {
        //public Pen OutLiner = new Pen(Color.White);
        public Font VictoryFont = new Font("Arial", 80, FontStyle.Bold, GraphicsUnit.Point);
        public Font EdibleFont = new Font("Arial", 25, FontStyle.Bold, GraphicsUnit.Point);
        public Panel LeftScreen = new Panel();
        public Panel RightScreen = new Panel();
        public Button EditorSelector = new Button();
        public Panel VictoryScreen = new Panel();
        public TableLayoutPanel LevelSelectorPanel;
        public Panel EditorMakerPanel;
        public Panel ImportLevelPanel;
        public TableLayoutPanel EditorOverlay;
        StringFormat stringFormat = new StringFormat();
        public Form1()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);
            this.MaximumSize = new Size(Set.CanvasWidth, Set.CanvasHeight);
            this.MinimumSize = new Size(Set.CanvasWidth, Set.CanvasHeight);
            this.Size = new Size(Set.CanvasWidth, Set.CanvasHeight);
            this.DoubleBuffered = true;
            this.KeyDown += new KeyEventHandler(LeaveGame);
        }

        public void ImportLevelButton_Click(object sender, EventArgs e)
        {
            Data.PlaySound(Data.ButtonClickSound, Data.SoundType.MenuSFX, 1);
            Button ImportButton = (Button)sender;
            Data.PlaySound(Data.ButtonClickSound, Data.SoundType.MenuSFX, 1);
            TextBox ImportTextBox = ImportButton.Parent.Controls.OfType<TextBox>().FirstOrDefault();
            DeactivateEditorMaker();

            try
            {

                Program.InitializeGame(ImportTextBox.Text);
            }
            catch
            {
                ImportTextBox.Text = "Invalid Level Code";
                ActivateEditorMaker();
            }
        }

        public void BuildEditor_Click(object sender, EventArgs e)
        {
            Data.PlaySound(Data.ButtonClickSound, Data.SoundType.MenuSFX, 1);
            this.ActiveControl = null;
            int Index = 0;
            int[] SideLengths = new int[2];
            foreach(Control t in EditorMakerPanel.Controls)
            {
                if(!(t is TextBox))
                {
                    continue;
                }
                if (Int32.TryParse(t.Text, out int a) && a > 0)
                {
                    SideLengths[Index] = a;
                    Index++;
                }
                else
                {
                    return;
                }
            }
            DeactivateEditorMaker();
            string WidthStr = Convert.ToString(SideLengths[0]);
            while(WidthStr.Length < 3)
            {
                WidthStr = "0" + WidthStr;
            }
            string HeightStr = Convert.ToString(SideLengths[1]);
            while (HeightStr.Length < 3)
            {
                HeightStr = "0" + HeightStr;
            }
            string BoardStr = new string('n', SideLengths[0] * SideLengths[1]);
            string VicsStr = new string('.', SideLengths[0] * SideLengths[1] - 1);
            VicsStr += 'v';
            Levels.LevelArray[Levels.LevelArray.GetLength(0) - 1] = WidthStr + HeightStr + BoardStr + VicsStr;
            Program.InitializeGame(Levels.LevelArray.GetLength(0) - 1);
            InitializeEditorOverlay(SideLengths);
        }
        
        public void LevelEditorButton_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            Button converter = sender as Button;
            int[] Pos = converter.Tag as int[];
            int maxheight = Convert.ToInt32(Levels.LevelArray[Levels.LevelArray.GetLength(0) - 1].Substring(0, 3));
            int maxwidth = Convert.ToInt32(Levels.LevelArray[Levels.LevelArray.GetLength(0) - 1].Substring(3, 3));
            if (!Con.VicEdit)
            {
                char CurrentTile = Levels.LevelArray[Levels.LevelArray.GetLength(0) - 1][6 + Pos[0] + maxheight * Pos[1]];
                StringBuilder LevelCopy = new StringBuilder(Levels.LevelArray[Levels.LevelArray.GetLength(0) - 1]);
                LevelCopy[6 + Pos[0] + maxheight * Pos[1]] = Levels.TileTypeCycler[(Array.IndexOf(Levels.TileTypeCycler, CurrentTile) + 1) % Levels.TileTypeCycler.Length];
                Levels.LevelArray[Levels.LevelArray.GetLength(0) - 1] = LevelCopy.ToString();
            }
            else
            {
                char CurrentVic = Levels.LevelArray[Levels.LevelArray.GetLength(0) - 1][6 + maxheight * maxwidth + Pos[0] + maxheight * Pos[1]];
                StringBuilder LevelCopy = new StringBuilder(Levels.LevelArray[Levels.LevelArray.GetLength(0) - 1]);
                LevelCopy[6 + maxheight * maxwidth + Pos[0] + maxheight * Pos[1]] = CurrentVic == 'v'?  '.' : 'v';
                Levels.LevelArray[Levels.LevelArray.GetLength(0) - 1] = LevelCopy.ToString();
            }
            Program.InitializeGame(Levels.LevelArray.GetLength(0) - 1);
        }
        private void LevelSelector_Click(object sender, EventArgs e)
        {
            Data.PlaySound(Data.ButtonClickSound, Data.SoundType.MenuSFX, 1);
            Button senderConversion = sender as Button;
            //if(Con.PlayedLevels.Contains(Convert.ToInt32(senderConversion.Tag)) || Con.NextLevel == Convert.ToInt32(senderConversion.Tag))
            //{
                DeactivateLevelSelector();
                Program.InitializeGame(Convert.ToInt32(senderConversion.Tag));
                Con.NextLevel = Convert.ToInt32(senderConversion.Tag) + 1;
                Data.PlaySound(Data.BackGroundMusic, Data.SoundType.BGMusic, 1f);
            //}
        }
        public void DeactivateLevelSelector()
        {
            if(LevelSelectorPanel != null)
            {
                LevelSelectorPanel.Visible = false;
                LevelSelectorPanel.Enabled = false;
            }
        }
        public void DeactivateEditorMaker()
        {
            if(ImportLevelPanel != null)
            {
                ImportLevelPanel.Visible = false;
                ImportLevelPanel.Enabled = false;
            }
            if(EditorMakerPanel != null)
            {
                EditorMakerPanel.Visible = false;
                EditorMakerPanel.Enabled = false;
            }
        }
        public void ActivateEditorMaker()
        {
            LeftScreen.BackgroundImage = Data.ImportExplanation;
            RightScreen.BackgroundImage= Data.EditorExplanation;   
            ImportLevelPanel.Visible = true;
            ImportLevelPanel.Enabled = true;
            EditorMakerPanel.Visible = true;
            EditorMakerPanel.Enabled = true;
        }
        public void LeaveGame(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //if(e.KeyCode == GS.OppositeLastKeyPressed)
            //{
            //    return;
            //}
            e.SuppressKeyPress = true;
            if(e.KeyCode == Keys.M)
            {
                if(Data.SoundPlayer.PlaybackState == PlaybackState.Playing) Data.SoundPlayer.Pause();
                else Data.SoundPlayer.Play();
            }
            if (Con.Playing)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        Con.DeltaY = -1;
                        Program.TickStep();
                        break;
                    case Keys.Up: //Duplicates for arrow keys
                        Con.DeltaY = -1;
                        Program.TickStep();
                        break;
                    case Keys.S:
                        Con.DeltaY = 1;
                        Program.TickStep();
                        break;
                    case Keys.Down:
                        Con.DeltaY = 1;
                        Program.TickStep();
                        break;
                    case Keys.A:
                        Con.DeltaX = -1;
                        Program.TickStep();
                        break;
                    case Keys.Left:
                        Con.DeltaX = -1;
                        Program.TickStep();
                        break;
                    case Keys.D:
                        Con.DeltaX = 1;
                        Program.TickStep();
                        break;
                    case Keys.Right:
                        Con.DeltaX = 1;
                        Program.TickStep();
                        break;
                    case Keys.Back:
                        Con.BoardStateIndex--;
                        Data.PlaySound(Data.ReverseSound, Data.SoundType.GameSFX, 1f);
                        Program.LoadPastGameState();
                        break;
                    case Keys.Space:
                        if(EditorOverlay != null) EditorOverlay.Visible = !EditorOverlay.Visible;
                        break;
                    case Keys.V:
                        Con.VicEdit = !Con.VicEdit;
                        break;
                    case Keys.Enter:
                        Console.WriteLine("▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄\nYour Custom Level Code:\n" + Levels.LevelArray[Levels.LevelArray.GetLength(0) - 1] + "\n▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ");
                        break;
                    case Keys.B:
                        Con.Playing = false;
                        Con.Victory = false;
                        DisableContinueButton();
                        DeactivateEditorMaker();
                        DeactivateEditorOverlay();
                        ActivateLevelSelector();
                        break;
                }
            }
            pictureBox1.Refresh();
        }
        public void InitializeForm()
        {
            MakeLevelSelector(Levels.LevelArray.Length - 1);
            
            //pictureBox1.Refresh();
        }
        public void DrawBoard(Graphics g)
        {
            if (!(GS.Board == null))
            {
                for (int y = 0; y < Set.BoardHeight; y++)
                {
                    for (int x = 0; x < Set.BoardWidth; x++)
                    {
                        Image VariableImage = GS.Board[x, y].GetImage();
                        //g.FillRectangle(VariableImage, x * Set.TileWidth, y * Set.TileHeight, Set.TileWidth, Set.TileHeight);
                        //g.DrawRectangle(OutLiner, x * Set.TileWidth, y * Set.TileHeight, Set.TileWidth - Set.OutLineThickness, Set.TileHeight - Set.OutLineThickness);
                        g.DrawImage(VariableImage, new Rectangle(x * Set.TileWidth, y * Set.TileHeight, Set.TileWidth + 1, Set.TileHeight + 1), 0, 0, 160, 160, GraphicsUnit.Pixel);
                        if (GS.Board[x, y] is Edible)
                        {
                            SolidBrush TextBrush = new SolidBrush(Color.Black);
                            Edible copyEdible = GS.Board[x, y] as Edible;
                            stringFormat.Alignment = StringAlignment.Center;
                            stringFormat.LineAlignment = StringAlignment.Center;
                            g.DrawString(Convert.ToString(copyEdible.GrowthValue), EdibleFont, TextBrush, new Rectangle(x * Set.TileWidth + Set.TileWidth / 2, y * Set.TileHeight + Set.TileHeight / 2, 0, 0), stringFormat);
                        }
                    }
                }
            }
            if(GS.PlayerBody != null)
            {
                for(int i = 0; i < GS.PlayerBody.Count - 1; i++)
                {
                    if (GS.PlayerBody[i + 1].X == 1000)
                    {
                        int DistantBodyCount = GS.PlayerBody.Count - i;
                        for(int j = 0; j < DistantBodyCount; j++)
                        {
                            g.DrawImage(GS.PlayerBody[i].GetImage(), new Rectangle(GS.PlayerBody[i].X * Set.TileWidth - 15 * j, GS.PlayerBody[i].Y * Set.TileHeight - 15 * j, Set.TileWidth, Set.TileHeight));
                        }
                        //g.FillEllipse(new SolidBrush(Color.DarkGreen), new Rectangle(GS.PlayerBody[i].X * Set.TileWidth, GS.PlayerBody[i].Y * Set.TileHeight, Set.TileWidth, Set.TileHeight));
                        break;
                    }
                    else
                    {
                        //g.DrawLine(new Pen(Color.Red) { Width = 10 }, (GS.PlayerBody[i].X + 0.5f) * Set.TileWidth, (GS.PlayerBody[i].Y + 0.5f) * Set.TileHeight, (GS.PlayerBody[i + 1].X + 0.5f) * Set.TileWidth, (GS.PlayerBody[i + 1].Y + 0.5f) * Set.TileHeight);
                    }
                }
            }
        }

        public void DrawVictoryTiles(Graphics g)
        {
            if (GS.VictoryTiles != null)
            {
                DrawVicTiles(g);
            }
        }
        public void DrawVicTiles(Graphics g)
        {
            foreach (Tile tile in GS.VictoryTiles)
            {
                if (tile is VictoryTile)
                {
                    if (!(GS.Board[tile.X, tile.Y] is Empty || GS.Board[tile.X, tile.Y] is Edible))
                    {
                        //OutLiner = new Pen(Color.Gold, Set.OutLineThickness / 2);
                        //g.DrawRectangle(OutLiner, tile.X * Set.TileWidth - Set.OutLineThickness / 4, tile.Y * Set.TileHeight - Set.OutLineThickness / 4, Set.TileWidth - Set.OutLineThickness / 2, Set.TileHeight - Set.OutLineThickness / 2);
                        g.DrawImage(Data.YesVicImage, new Rectangle(tile.X * Set.TileWidth, tile.Y * Set.TileHeight, Set.TileWidth + 1, Set.TileHeight + 1));
                    }
                    else
                    {
                        g.DrawImage(Data.UnVicImage, new Rectangle(tile.X * Set.TileWidth, tile.Y * Set.TileHeight, Set.TileWidth + 1, Set.TileHeight + 1));
                    }
                }
            }
        }
        
        public void DrawVictory(Graphics g)
        {
            //string text1 = "Victory!";
            //
            //Rectangle rect1 = new Rectangle(0, 0, Set.CanvasWidth, Set.CanvasHeight);
            //stringFormat.Alignment = StringAlignment.Center;
            //stringFormat.LineAlignment = StringAlignment.Center;
            //g.DrawString(text1, VictoryFont, Brushes.Blue, rect1, stringFormat);
            //g.DrawRectangle(Pens.Black, rect1);
        }
        public void WriteMoveNumber(Graphics g)
        {
            string text2 = "Moves: " + Convert.ToString(Con.BoardStateIndex);
            Font font2 = new Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Point);
            Rectangle rect2 = new Rectangle(0, Set.CanvasHeight, 100, 1000);
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            g.DrawString(text2, font2, Brushes.Blue, rect2, stringFormat);
            g.DrawRectangle(Pens.Black, rect2);
        }

        public void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            RectangleF Center = new RectangleF(Set.CanvasWidth / 2, Set.CanvasHeight / 2, Set.CanvasWidth, Set.CanvasHeight / 2);
            g.Clear(Color.Black);
            if (Con.Playing)
            {
                DrawBoard(g);
                DrawVictoryTiles(g);
                WriteMoveNumber(g);
            }
            if (Con.Victory)
            {
                DrawVictory(g);
                EnableContinueButton();
            }
            else
            {
                DisableContinueButton();
            }
            
        }
        public void EnableContinueButton()
        {
            VictoryScreen.Enabled = true;
            VictoryScreen.Visible = true;
        }
        public void DisableContinueButton()
        {
            VictoryScreen.Enabled = false;
            VictoryScreen.Visible = false;
        }
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (Con.Victory)
        //    {
        //        VictoryScreen.Enabled = true;
        //        VictoryScreen.Visible = true;
        //    }
        //}

        public void ActivateLevelSelector()
        {
            LeftScreen.BackgroundImage = Data.TutorialImage;
            RightScreen.BackgroundImage = Data.GoalImage;
            foreach(Control control in LevelSelectorPanel.Controls)
            {
                if(control.GetType() == typeof(Button))
                {
                    if(Con.PlayedLevels.Contains(Convert.ToInt32(control.Tag) - 1)) 
                    {
                        control.BackgroundImage = Data.BlueButtonImage;
                    }
                    else
                    {
                        control.BackgroundImage = Data.GrayButtonImage;
                    }
                    if (Con.PlayedLevels.Contains(Convert.ToInt32(control.Tag) ))
                    {
                        control.BackgroundImage = Data.GreenButtonImage;
                    }
                    if(Convert.ToInt32(control.Tag) == -1)
                    {
                        control.BackgroundImage = Data.EditorButtonImage;
                    }
                }
            }
            LevelSelectorPanel.Visible = true;
            LevelSelectorPanel.Enabled = true;
        }
        public void DeactivateEditorOverlay()
        {
            if (EditorOverlay != null)
            {
                EditorOverlay.Enabled = false;
                EditorOverlay.Visible = false;
            }
        }     
        public void RefreshBoard()
        {
            pictureBox1.Refresh();
        }
        private void ContinueButton_Click(object sender, EventArgs e)
        {
            Data.PlaySound(Data.ButtonClickSound, Data.SoundType.MenuSFX, 1);
            Con.Playing = false;
            Con.Victory = false;
            Con.PlayedLevels.Add(Con.CurrentLevel);
            DisableContinueButton();
            DeactivateEditorOverlay();
            ActivateLevelSelector();
        }
    }
}