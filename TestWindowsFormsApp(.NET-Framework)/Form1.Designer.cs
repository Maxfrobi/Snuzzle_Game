using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Data;

namespace TestWindowsFormsApp_.NET_Framework_
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        /// 
        public void InitEditorSelection(object sender, EventArgs e)
        {
            Data.PlaySound(Data.ButtonClickSound, Data.SoundType.MenuSFX, 1);
            DeactivateLevelSelector();
            LeftScreen.BackgroundImage = Data.ImportExplanation;
            RightScreen.BackgroundImage = Data.EditorExplanation;
            EditorMakerPanel = new Panel();
            ImportLevelPanel = new Panel();
            pictureBox1.Controls.Add(EditorMakerPanel);
            pictureBox1.Controls.Add(ImportLevelPanel);
            EditorMakerPanel.Size = new Size(EditorMakerPanel.Parent.Size.Width / 5 * 2, EditorMakerPanel.Parent.Size.Height / 2);
            EditorMakerPanel.Location = new Point(EditorMakerPanel.Parent.Size.Width / 2 + EditorMakerPanel.Parent.Size.Width / 20, EditorMakerPanel.Parent.Size.Height / 4);
            EditorMakerPanel.BackColor = Color.MediumPurple;
            ImportLevelPanel.Size = EditorMakerPanel.Size;
            ImportLevelPanel.Location = new Point(EditorMakerPanel.Parent.Size.Width / 20, ImportLevelPanel.Parent.Size.Height / 4);
            ImportLevelPanel.BackColor = Color.FromArgb(255, 87, 151, 76);
            Button ImportLevelButton = new Button() { Visible = true, Enabled = true } ;
            ImportLevelButton.BackgroundImage = Data.ImportImage;
            ImportLevelButton.BackgroundImageLayout = ImageLayout.Stretch;
            ImportLevelButton.Dock = DockStyle.None;
            ImportLevelButton.Font = new Font(ImportLevelButton.Font.FontFamily, 50);
            ImportLevelButton.Size = new Size(EditorMakerPanel.Size.Width / 2, EditorMakerPanel.Size.Height / 6);
            ImportLevelButton.Location = new Point(ImportLevelPanel.Size.Width / 4, ImportLevelPanel.Size.Height / 5 * 3);
            ImportLevelButton.TabStop = false;
            ImportLevelButton.Click += new EventHandler(ImportLevelButton_Click);
            ImportLevelPanel.Controls.Add(ImportLevelButton);

            Panel ImportTextImage = new Panel();
            ImportLevelPanel.Controls.Add(ImportTextImage);
            ImportTextImage.BackgroundImage = Data.ImportTextImage;
            ImportTextImage.Size = new Size(ImportLevelPanel.Size.Width / 4 * 3, ImportLevelPanel.Size.Height / 4);
            ImportTextImage.Location = new Point(ImportLevelPanel.Size.Width / 8, ImportLevelPanel.Size.Height / 13 * 6 - ImportLevelPanel.Size.Height / 4);
            ImportTextImage.BackgroundImageLayout = ImageLayout.Stretch;
            TextBox ImportInput = new TextBox() { Text = "Enter Level Code Here" };
            ImportInput.Font = new Font(ImportInput.Font.FontFamily, 20);
            ImportInput.AutoSize = false;
            ImportInput.TextAlign = HorizontalAlignment.Center;
            ImportInput.Dock = DockStyle.None;
            ImportInput.Size = new Size(ImportLevelPanel.Size.Width / 3 * 2, ImportLevelPanel.Size.Height / 8);
            ImportInput.Location = new Point(ImportLevelPanel.Size.Width / 6, ImportLevelPanel.Size.Height * 75 / 160);
            ImportInput.TabStop = false;
            ImportLevelPanel.Controls.Add(ImportInput);

            Panel WidthImage = new Panel();
            EditorMakerPanel.Controls.Add(WidthImage);
            WidthImage.BackgroundImage = Data.WidthImage;
            WidthImage.Size = new Size(EditorMakerPanel.Size.Width / 2, EditorMakerPanel.Size.Height / 8);
            WidthImage.Location = new Point(EditorMakerPanel.Size.Width / 4, EditorMakerPanel.Size.Height / 13 * 6 - EditorMakerPanel.Size.Height / 8);
            WidthImage.BackgroundImageLayout = ImageLayout.Stretch;

            Panel HeightImage = new Panel();
            HeightImage.BackgroundImage = Data.HeightImage;
            HeightImage.Size = new Size(EditorMakerPanel.Size.Width / 2, EditorMakerPanel.Size.Height / 8);
            HeightImage.Location = new Point(EditorMakerPanel.Size.Width / 4, EditorMakerPanel.Size.Height / 5 - EditorMakerPanel.Size.Height / 8);
            HeightImage.BackgroundImageLayout = ImageLayout.Stretch;
            EditorMakerPanel.Controls.Add(HeightImage);
            TextBox BoardHeightInput = new TextBox() { Text = "10" };
            BoardHeightInput.Font = new Font(BoardHeightInput.Font.FontFamily, 50);
            BoardHeightInput.AutoSize = false;
            BoardHeightInput.TextAlign = HorizontalAlignment.Center;
            BoardHeightInput.Dock = DockStyle.None;
            BoardHeightInput.Size = new Size(EditorMakerPanel.Size.Width / 2, EditorMakerPanel.Size.Height / 8);
            BoardHeightInput.Location = new Point(EditorMakerPanel.Size.Width / 4, EditorMakerPanel.Size.Height / 5);
            BoardHeightInput.TabStop = false;

            TextBox BoardWidthInput = new TextBox() { Text = "10" };
            BoardWidthInput.Font = new Font(BoardWidthInput.Font.FontFamily, 50);
            BoardWidthInput.TextAlign = HorizontalAlignment.Center;
            BoardWidthInput.AutoSize = false;
            BoardWidthInput.Dock = DockStyle.None;
            BoardWidthInput.Size = new Size(EditorMakerPanel.Size.Width / 2, EditorMakerPanel.Size.Height / 8);
            BoardWidthInput.Location = new Point(EditorMakerPanel.Size.Width / 4, EditorMakerPanel.Size.Height / 13 * 6);
            BoardWidthInput.TabStop = false;

            Button BuildEditor = new Button();
            BuildEditor.BackgroundImage = Data.BuildImage;
            BuildEditor.BackgroundImageLayout = ImageLayout.Stretch;
            BuildEditor.Dock = DockStyle.None;
            BuildEditor.Font = new Font(BoardHeightInput.Font.FontFamily, 50);
            BuildEditor.Size = new Size(EditorMakerPanel.Size.Width / 2, EditorMakerPanel.Size.Height / 6);
            BuildEditor.Location = new Point(EditorMakerPanel.Size.Width / 4, EditorMakerPanel.Size.Height / 5 * 3);
            BuildEditor.TabStop = false;

            BuildEditor.Click += new EventHandler(BuildEditor_Click);
            EditorMakerPanel.Controls.Add(BoardHeightInput);
            EditorMakerPanel.Controls.Add(BoardWidthInput);
            EditorMakerPanel.Controls.Add(BuildEditor);
        }
        public void InitializeEditorOverlay(int[] SideLengths)
        {
            LeftScreen.BackgroundImage = Data.DesignExplanation;
            RightScreen.BackgroundImage = Data.ExportExplanation;
            EditorOverlay = new TableLayoutPanel();
            EditorOverlay.Visible = true;
            EditorOverlay.BackColor = Color.Transparent;

            pictureBox1.Controls.Add(EditorOverlay);
            EditorOverlay.Dock = DockStyle.Fill;
            EditorOverlay.SuspendLayout();
            EditorOverlay.ColumnCount = SideLengths[0];
            EditorOverlay.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            for (int i = 0; i < SideLengths[0]; i++)
            {
                for (int j = 0; j < SideLengths[1]; j++)
                {
                    EditorOverlay.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / SideLengths[0]));
                    EditorOverlay.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / SideLengths[1]));
                    Button mybutton = new Button() { Tag = new int[2] { i, j } };
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
        public void MakeLevelSelector(int numButtons)
        {
            int Padding = 20;
            LevelSelectorPanel = new TableLayoutPanel();
            LevelSelectorPanel.SuspendLayout();
            LevelSelectorPanel.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            LevelSelectorPanel.Padding = new Padding(Padding);
            LevelSelectorPanel.Size = new Size(Set.SquareSide / 6 * 5, Set.SquareSide / 6 * 5);
            LevelSelectorPanel.Location = new Point(Set.SquareSide / 12, Set.SquareSide / 6);
            int ButtonsPerSide = (int)Math.Sqrt(numButtons + 2);
            LevelSelectorPanel.RowCount = ButtonsPerSide + 1;
            LevelSelectorPanel.Enabled = true;
            LevelSelectorPanel.Visible = true;
            pictureBox1.Controls.Add(LevelSelectorPanel);
            List<Button> ButtonList = new List<Button>();
            for (int i = 0; i < numButtons; i++)
            {
                ButtonList.Add(new Button());
                ButtonList[i].Text = "Level\n" + (i + 1).ToString();
                ButtonList[i].BackgroundImage = Data.GrayButtonImage; 
                ButtonList[i].FlatStyle = FlatStyle.Popup;
                ButtonList[i].BackgroundImageLayout = ImageLayout.Stretch;
                ButtonList[i].BackColor = Color.Transparent;
                ButtonList[i].Font = new Font("Arial", 25, FontStyle.Bold, GraphicsUnit.Point);
                ButtonList[i].Tag = i;
                ButtonList[i].Dock = DockStyle.Fill;
                ButtonList[i].Margin = new Padding(Padding);
                LevelSelectorPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / ButtonsPerSide));
                LevelSelectorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / ButtonsPerSide));
                LevelSelectorPanel.Controls.Add(ButtonList[i]);
                ButtonList[i].Click += new EventHandler(LevelSelector_Click);
                ButtonList[i].KeyDown += new KeyEventHandler(LeaveGame);
            }

            EditorSelector = new Button();
            EditorSelector.Font = new Font("Arial", 25, FontStyle.Bold, GraphicsUnit.Point);
            EditorSelector.BackgroundImage = Data.EditorButtonImage;
            EditorSelector.BackgroundImageLayout = ImageLayout.Stretch;
            EditorSelector.Enabled = true;
            EditorSelector.Visible = true;
            EditorSelector.Text = "Custom\nLevel";
            EditorSelector.Dock = DockStyle.Fill;
            EditorSelector.Click += new EventHandler(InitEditorSelection);
            EditorSelector.Tag = -1;

            LevelSelectorPanel.Controls.Add(EditorSelector, ButtonsPerSide, ButtonsPerSide);
            //LevelSelectorPanel.Controls.Add(ImportSelector, ButtonsPerSide, ButtonsPerSide);

            LevelSelectorPanel.ResumeLayout();
            ActivateLevelSelector();
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ContinueButton = new System.Windows.Forms.Button();
            this.BackColor = Color.Black;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1008, 1008);
            this.pictureBox1.TabIndex = 9;
            pictureBox1.BackColor = Color.Black;
            this.pictureBox1.TabStop = false;
            pictureBox1.Dock = DockStyle.None;
            pictureBox1.Size = new Size(Set.SquareSide, Set.SquareSide);
            pictureBox1.Location = new Point(Set.CanvasWidth / 2 - Set.SquareSide / 2, Set.CanvasHeight / 2 - Set.SquareSide / 2);
            pictureBox1.Controls.Add(VictoryScreen);

            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // timer1
            // 
            //this.timer1.Enabled = true;
            //this.timer1.Interval = 500;
            //this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ContinueButton
            // 
            this.ContinueButton.Enabled = false;
            this.ContinueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.ContinueButton.Location = new System.Drawing.Point(0, 0);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(480, 130);
            this.ContinueButton.TabIndex = 11;
            //this.ContinueButton.Text = "Continue?";
            this.ContinueButton.UseVisualStyleBackColor = true;
            this.ContinueButton.Visible = false;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            ContinueButton.Image = Data.ContinueButtonBackGround;
            ContinueButton.FlatStyle = FlatStyle.Popup;
            ContinueButton.BackgroundImageLayout = ImageLayout.Stretch;
            ContinueButton.BackColor = Color.Transparent;
            ContinueButton.Location = new Point(Set.SquareSide / 2 - ContinueButton.Width / 2, (Set.SquareSide / 3) * 2);
            ContinueButton.Visible = true;
            ContinueButton.Enabled = true;
            //
            // VictoryScreen
            //
            VictoryScreen.Controls.Add(ContinueButton);
            VictoryScreen.BackColor = Color.Transparent;
            VictoryScreen.BackgroundImage = Data.VictoryScreenBackGround;
            VictoryScreen.BackgroundImageLayout = ImageLayout.Stretch;
            VictoryScreen.Dock = DockStyle.Fill;

            VictoryScreen.Enabled = false;
            VictoryScreen.Visible = false;
            //
            // TutorialScreen
            // 
            LeftScreen.BackgroundImage = Data.TutorialImage;
            LeftScreen.Size = new Size(420, 1080);
            LeftScreen.BackgroundImageLayout = ImageLayout.Stretch;
            LeftScreen.Location = new Point(0, 0);
            LeftScreen.Visible = true;
            //GoalScreen
            RightScreen.BackgroundImage = Data.GoalImage;
            RightScreen.Size = new Size(420, 1080);
            RightScreen.BackgroundImageLayout = ImageLayout.Stretch;
            RightScreen.Location = new Point(Set.CanvasWidth / 2 + Set.SquareSide / 2, 0);
            RightScreen.Visible = true;
            //
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 686);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(LeftScreen);
            this.Controls.Add(RightScreen);
            this.Location = new System.Drawing.Point(500, 500);
            this.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Button ContinueButton;
    }
}

