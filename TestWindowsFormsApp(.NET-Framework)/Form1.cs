using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsFormsApp_.NET_Framework_
{
    public partial class Form1 : Form
    {
        public Pen OutLiner = new Pen(Color.White);
        public Font font1 = new Font("Arial", 80, FontStyle.Bold, GraphicsUnit.Point);
        public Font EdibleFont = new Font("Arial", 25, FontStyle.Bold, GraphicsUnit.Point);
        public Button EditorSelector = new Button();
        public TableLayoutPanel LevelSelectorPanel;
        public TableLayoutPanel EditorMaker;
        public TableLayoutPanel EditorOverlay;

        public Image VariableImage;
        StringFormat stringFormat = new StringFormat();
        public Form1()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) - (Set.CanvasWidth / 2), 0);
            this.Size = new Size(Set.CanvasWidth, Set.CanvasWidth);
            this.DoubleBuffered = true;
            this.KeyDown += new KeyEventHandler(LeaveGame);
        }

        public void MakeLevelSelector(int numButtons)
        {
            LevelSelectorPanel = new TableLayoutPanel();
            LevelSelectorPanel.SuspendLayout();
            LevelSelectorPanel.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            LevelSelectorPanel.Dock = DockStyle.Fill;
            LevelSelectorPanel.Location = new Point(0, 0);
            int ButtonsPerSide = (int)Math.Sqrt(numButtons);
            LevelSelectorPanel.RowCount = ButtonsPerSide + 1;
            LevelSelectorPanel.Enabled = true;
            LevelSelectorPanel.Visible = true;
            pictureBox1.Controls.Add(LevelSelectorPanel);
            List<Button> ButtonList = new List<Button>();
            for (int i = 0; i < numButtons; i++)
            {
                ButtonList.Add(new Button());
                ButtonList[i].Text = (i + 1).ToString();
                ButtonList[i].Tag = i;
                ButtonList[i].Dock = DockStyle.Fill;
                LevelSelectorPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / ButtonsPerSide));
                LevelSelectorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / ButtonsPerSide));
                LevelSelectorPanel.Controls.Add(ButtonList[i]);
                ButtonList[i].Click += new EventHandler(LevelSelector_Click);
            }
            
            EditorSelector = new Button();
            EditorSelector.Enabled = true;
            EditorSelector.Visible = true;
            EditorSelector.Text = "Level Editor";
            EditorSelector.Dock = DockStyle.Fill;
            EditorSelector.Click += new EventHandler(InitEditorSelection);

            LevelSelectorPanel.Controls.Add(EditorSelector, ButtonsPerSide / 2, ButtonsPerSide);
            LevelSelectorPanel.ResumeLayout();
        }
        public void InitEditorSelection(object sender, EventArgs e)
        {
            DeactivateLevelSelector();
            EditorMaker = new TableLayoutPanel();
            pictureBox1.Controls.Add(EditorMaker);
            EditorMaker.Size = new Size(EditorMaker.Parent.Size.Width / 2, EditorMaker.Parent.Size.Height / 2);
            EditorMaker.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            EditorMaker.ColumnCount = 3;
            TextBox BoardHeightInput = new TextBox() { Text = "10"};
            BoardHeightInput.TabStop = false;
            TextBox BoardWidthInput = new TextBox() { Text = "10" };
            BoardWidthInput.TabStop = false;
            Button BuildEditor = new Button() { Text = "Build Clean Slate"};
            BuildEditor.TabStop = false;

            BuildEditor.Click += new EventHandler(BuildEditor_Click);
            EditorMaker.Controls.Add(BoardHeightInput);       
            EditorMaker.Controls.Add(BoardWidthInput);
            EditorMaker.Controls.Add(BuildEditor);
        }
        public void BuildEditor_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            int Index = 0;
            int[] SideLengths = new int[2];
            foreach(Control t in EditorMaker.Controls)
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
            Levels.LevelArray[9] = WidthStr + HeightStr + BoardStr + VicsStr;
            Program.InitializeGame(9);
            InitializeEditorOverlay(SideLengths);
        }
        public void InitializeEditorOverlay(int[] SideLengths)
        {
            EditorOverlay = new TableLayoutPanel();
            EditorOverlay.Visible = true;
            EditorOverlay.BackColor = Color.Transparent;
            
            pictureBox1.Controls.Add(EditorOverlay);
            EditorOverlay.Dock = DockStyle.Fill;
            EditorOverlay.SuspendLayout();
            EditorOverlay.ColumnCount = SideLengths[1];
            EditorOverlay.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            for (int i = 0; i< SideLengths[0]; i++)
            {
                for(int j = 0; j< SideLengths[1]; j++)
                {
                    EditorOverlay.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / SideLengths[0]));
                    EditorOverlay.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / SideLengths[1]));
                    Button mybutton = new Button() { Tag = new int[2] { i, j} };
                    mybutton.Dock = DockStyle.Fill;
                    mybutton.Margin = new Padding(0);
                    mybutton.Click += new EventHandler(LevelEditorButton_Click);
                    mybutton.FlatStyle = FlatStyle.Flat;
                    mybutton.FlatAppearance.BorderColor = BackColor;
                    mybutton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, Color.White);
                    mybutton.FlatAppearance.MouseDownBackColor = BackColor;
                    EditorOverlay.Controls.Add(mybutton);
                }
            }
            EditorOverlay.ResumeLayout();
        }
        public void LevelEditorButton_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            Button converter = sender as Button;
            int[] Pos = converter.Tag as int[];
            int maxheight = Convert.ToInt32(Levels.LevelArray[9].Substring(0, 3));
            int maxwidth = Convert.ToInt32(Levels.LevelArray[9].Substring(3, 3));
            if (Con.VicEdit)
            {
                char CurrentTile = Levels.LevelArray[9][6 + Pos[0] + maxheight * Pos[1]];
                StringBuilder LevelCopy = new StringBuilder(Levels.LevelArray[9]);
                LevelCopy[6 + Pos[0] + maxheight * Pos[1]] = Levels.TileTypeCycler[(Array.IndexOf(Levels.TileTypeCycler, CurrentTile) + 1) % Levels.TileTypeCycler.Length];
                Levels.LevelArray[9] = LevelCopy.ToString();
            }
            else
            {
                char CurrentVic = Levels.LevelArray[9][6 + maxheight * maxwidth + Pos[0] + maxheight * Pos[1]];
                StringBuilder LevelCopy = new StringBuilder(Levels.LevelArray[9]);
                LevelCopy[6 + maxheight * maxwidth + Pos[0] + maxheight * Pos[1]] = CurrentVic == 'v'?  '.' : 'v';
                Levels.LevelArray[9] = LevelCopy.ToString();
            }
            Program.InitializeGame(9);
        }
        private void LevelSelector_Click(object sender, EventArgs e)
        {
            Button senderConversion = sender as Button;
            DeactivateLevelSelector();
            Program.InitializeGame(Convert.ToInt32(senderConversion.Tag));

        }
        public void DeactivateLevelSelector()
        {
            LevelSelectorPanel.Visible = false;
            LevelSelectorPanel.Enabled = false;
        }
        public void DeactivateEditorMaker()
        {
            EditorMaker.Visible = false;
            EditorMaker.Enabled = false;
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
            e.SuppressKeyPress = true;
            if (Con.Playing)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        Con.DeltaY = -1;
                        Program.TickStep();
                        break;
                    case Keys.S:
                        Con.DeltaY = 1;
                        Program.TickStep();
                        break;
                    case Keys.A:
                        Con.DeltaX = -1;
                        Program.TickStep();
                        break;
                    case Keys.D:
                        Con.DeltaX = 1;
                        Program.TickStep();
                        break;
                    case Keys.Back:
                        Con.BoardStateIndex--;
                        Program.LoadPastGameState();
                        break;
                    case Keys.Space:
                        EditorOverlay.Visible = !EditorOverlay.Visible;
                        break;
                    case Keys.V:
                        Con.VicEdit = !Con.VicEdit;
                        break;
                    case Keys.Enter:
                        Console.WriteLine(Levels.LevelArray[9]);
                        break;
                }
            }
            pictureBox1.Refresh();
        }
        public void InitializeForm()
        {
            pictureBox1.Dock = DockStyle.Fill;
            
            ContinueButton.Location = new Point(Set.CanvasWidth / 2 - ContinueButton.Width / 2, Set.CanvasHeight / 2 + 50);
            pictureBox1.Controls.Add(ContinueButton);

            MakeLevelSelector(Levels.LevelArray.Length - 1);

            pictureBox1.Refresh();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        public void DrawBoard(Graphics g)
        {
            if (!(GS.Board == null))
            {
                for (int y = 0; y < Set.BoardHeight; y++)
                {
                    for (int x = 0; x < Set.BoardWidth; x++)
                    {
                        VariableImage = GS.Board[x, y].GetImage();
                        //g.FillRectangle(VariableImage, x * Set.TileWidth, y * Set.TileHeight, Set.TileWidth, Set.TileHeight);
                        //g.DrawRectangle(OutLiner, x * Set.TileWidth, y * Set.TileHeight, Set.TileWidth - Set.OutLineThickness, Set.TileHeight - Set.OutLineThickness);
                        g.DrawImage(VariableImage, new Rectangle(x * Set.TileWidth, y * Set.TileHeight, Set.TileWidth, Set.TileHeight), 0, 0, 160, 160, GraphicsUnit.Pixel);
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
        }

        public void DrawVictoryTiles(Graphics g)
        {
            if (GS.VictoryTiles != null)
            {
                DrawEmptyVic(g);
                DrawActivatedVic(g);
            }
        }
        public void DrawActivatedVic(Graphics g)
        {
            foreach (Tile tile in GS.VictoryTiles)
            {
                if (tile is VictoryTile)
                {
                    if (!(GS.Board[tile.X, tile.Y] is Empty || GS.Board[tile.X, tile.Y] is Edible))
                    {
                        //OutLiner = new Pen(Color.Gold, Set.OutLineThickness / 2);
                        //g.DrawRectangle(OutLiner, tile.X * Set.TileWidth - Set.OutLineThickness / 4, tile.Y * Set.TileHeight - Set.OutLineThickness / 4, Set.TileWidth - Set.OutLineThickness / 2, Set.TileHeight - Set.OutLineThickness / 2);
                        g.DrawImage(Sprites.YesVicImage, new Rectangle(tile.X * Set.TileWidth, tile.Y * Set.TileHeight, Set.TileWidth, Set.TileHeight));
                    }
                }
            }
        }
        public void DrawEmptyVic(Graphics g)
        {
            foreach (Tile tile in GS.VictoryTiles)
            {
                if (tile is VictoryTile)
                {
                    if (GS.Board[tile.X, tile.Y] is Empty || GS.Board[tile.X, tile.Y] is Edible)
                    {
                        //OutLiner = new Pen(Color.Gray, Set.OutLineThickness / 2);
                        //g.DrawRectangle(OutLiner, tile.X * Set.TileWidth - Set.OutLineThickness / 4, tile.Y * Set.TileHeight - Set.OutLineThickness / 4, Set.TileWidth - Set.OutLineThickness / 2, Set.TileHeight - Set.OutLineThickness / 2);
                        g.DrawImage(Sprites.UnVicImage, new Rectangle(tile.X * Set.TileWidth, tile.Y * Set.TileHeight, Set.TileWidth, Set.TileHeight));
                    }
                }
            }
        }
        public void DrawVictory(Graphics g)
        {
            string text1 = "Victory!";
            
            Rectangle rect1 = new Rectangle(0, 0, Set.CanvasWidth, Set.CanvasHeight);
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            g.DrawString(text1, font1, Brushes.Blue, rect1, stringFormat);
            g.DrawRectangle(Pens.Black, rect1);
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
            g.Clear(Color.White);
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
        }
        public void EnableContinueButton()
        {
            ContinueButton.Enabled = true;
            ContinueButton.Visible = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Con.Victory)
            {
                ContinueButton.Enabled = true;
                ContinueButton.Visible = true;
            }
            
        }

        public void ActivateLevelSelector()
        {
            LevelSelectorPanel.Visible = true;
            LevelSelectorPanel.Enabled = true;
        }
            
        public void RefreshBoard()
        {
            pictureBox1.Refresh();
        }
        private void ContinueButton_Click(object sender, EventArgs e)
        {
            Con.Playing = false;
            Con.Victory = false;
            ContinueButton.Enabled = false;
            ContinueButton.Visible = false;
            ActivateLevelSelector();
        }
    }
}