using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLifePortfolio
{
    public partial class Form1 : Form
    {
        bool[,] universe = new bool[20, 20];
        bool[,] scratchPad = new bool[20, 20];

        public static int TimerInterval = 100;


        // Drawing colors
        Color gridColor = Color.Black;
        Color cellColor = Color.Gray;

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        int generations = 0;

        public Form1()
        {
            InitializeComponent();

            // Setup the timer
            timer.Interval = Properties.Settings.Default.TimerInterval; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer running

            //Reading the properties
            graphicsPanel1.BackColor = Properties.Settings.Default.PanelColor;



        }



        // Calculate the next generation of cells
        private void NextGeneration()
        {


            int aliveCells = 0;

            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {

                   // counting alive cells
                    if (universe[x, y] == true)
                    {
                        aliveCells++;
                    }


                    // int count = CountNeighborsFinite(x, y);

                    int count = CountNeighborsToroidal(x, y);

                    //Apply the rules

                    if (universe[x, y] == true)
                    {

                        if (count < 2 || count > 3)
                        {
                            scratchPad[x, y] = false;
                        }
                        else
                        {
                            scratchPad[x, y] = true;
                        }
                    }
                    else
                    {
                        if (count == 3)
                        {
                            scratchPad[x, y] = true;

                        }
                        else
                        {
                            scratchPad[x, y] = false;
                        }
                    }
                    //Turn it on/off in the scratchpad

                }
            }

            //Copy from scratchPad to universe. Code is in Miscellaneous How tos
            bool[,] temp = universe;
            universe = scratchPad;
            scratchPad = temp;
            // Increment generation count
            generations++;

            // Update status strip 
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
            IntervalStatus.Text = "Interval: " + Properties.Settings.Default.TimerInterval;
            SeedStatus.Text = "Seed: " + Properties.Settings.Default.RandomSeed;
            AliveCellsStatus.Text = "Alive Cells: " + aliveCells;


            //Add invalidate here
            graphicsPanel1.Invalidate();
        }

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();

        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            //FLOATS! MAKES THE PROGRAM LOOK A LOT BETTER


            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            float cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            float cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(Properties.Settings.Default.PanelGridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(Properties.Settings.Default.PanelCellColor);

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // A rectangle to represent each cell in pixels

                    //RectangleF ---> converts to float

                    RectangleF cellRect = RectangleF.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;


                    // Fill the cell with a brush if alive
                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                    }

                    // Outline the cell with a pen
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);


                    RectangleF rect = new RectangleF(cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);

                    Font font = new Font("Arial", 13f);

                    StringFormat stringFormat = new StringFormat();

                    stringFormat.Alignment = StringAlignment.Center;

                    stringFormat.LineAlignment = StringAlignment.Center;

                    int temp = CountNeighborsFinite(x, y);

                    if (temp != 0)
                    {
                        e.Graphics.DrawString(temp.ToString(), font, Brushes.Blue, rect, stringFormat);

                    }
                    temp = 0;

                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                //FLOATS
                // Calculate the width and height of each cell in pixels
                int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
                int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                int x = e.X / cellWidth;
                // CELL Y = MOUSE Y / CELL HEIGHT
                int y = e.Y / cellHeight;

                // Toggle the cell's state
                universe[x, y] = !universe[x, y];

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();
            }
        }

        private int CountNeighborsToroidal(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);
        

            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;

                   

                    // if xOffset and yOffset are both equal to 0 then continue

                    if (xOffset == 0 && yOffset == 0)
                    {
                        continue;
                    }

                    // if xCheck is less than 0 then set to xLen - 1
                    if (xCheck < 0)
                    {
                        xCheck = xLen - 1;
                    }

                    // if yCheck is less than 0 then set to yLen - 1

                    if (yCheck < 0)
                    {
                        yCheck = yLen - 1;

                    }


                    // if xCheck is greater than or equal too xLen then set to 0
                    if (xCheck >= xLen)
                    {
                        xCheck = 0;
                    }

                    // if yCheck is greater than or equal too yLen then set to 0
                    if (yCheck >= yLen)
                    {
                        yCheck = 0;
                    }


                    if (universe[xCheck, yCheck] == true) count++;
                }
            }
           
            return count;
        }

        private int CountNeighborsFinite(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;
                    // if xOffset and yOffset are both equal to 0 then continue

                    if (xOffset == 0 && yOffset == 0)
                    {
                        continue;
                    }
                    // if xCheck is less than 0 then continue

                    if (xCheck < 0)
                    {
                        continue;
                    }
                    // if yCheck is less than 0 then continue
                    if (yCheck < 0)
                    {
                        continue;
                    }

                    // if xCheck is greater than or equal too xLen then continue
                    if (xCheck >= xLen)
                    {
                        continue;
                    }
                    // if yCheck is greater than or equal too yLen then continue
                    if (yCheck >= yLen)
                    {
                        continue;
                    }

                    if (universe[xCheck, yCheck] == true) count++;
                }
            }
            return count;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Next Generation on click


        private void PlayButton_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void NextGenButton_Click(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y] = false;
                    generations = 0;
                    timer.Enabled = false;
                    toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();

                }
            }

            graphicsPanel1.Invalidate();
        }

        private void LoadFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                CurrentFile = dlg.FileName;
                StreamReader reader = new StreamReader(dlg.FileName);

                // Create a couple variables to calculate the width and height
                // of the data in the file.
                int maxWidth = 0;
                int maxHeight = 0;

                // Iterate through the file once to get its size.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then it is a comment
                    // and should be ignored.
                    if (row[0] == '!')
                    {
                        continue;
                    }
                    else
                    {
                        maxWidth = row.Length;

                        maxHeight++;
                    }

                    // If the row is not a comment then it is a row of cells.
                    // Increment the maxHeight variable for each row read.

                    // Get the length of the current row string
                    // and adjust the maxWidth variable if necessary.
                }

                // Resize the current universe and scratchPad
                // to the width and height of the file calculated above.
                bool[,] newUniverse = new bool[maxWidth, maxHeight];

                // Reset the file pointer back to the beginning of the file.
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                int yPos = 0;

                // Iterate through the file again, this time reading in the cells.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();


                    // If the row begins with '!' then
                    // it is a comment and should be ignored.
                    if (row[0] == '!')
                    {
                        continue;
                    }
                    else
                    {

                        // If the row is not a comment then 
                        // it is a row of cells and needs to be iterated through.
                        for (int xPos = 0; xPos < row.Length; xPos++)
                        {
                            // If row[xPos] is a 'O' (capital O) then
                            // set the corresponding cell in the universe to alive.

                            if (row[xPos] == 'O')
                            {
                                newUniverse[xPos, yPos] = true;
                            }
                            // If row[xPos] is a '.' (period) then
                            // set the corresponding cell in the universe to dead.

                            else if (row[xPos] == '.')
                            {
                                newUniverse[xPos, yPos] = false;
                            }


                        }
                    }


                    yPos++;
                }

                universe = newUniverse;
                graphicsPanel1.Invalidate();

                // Close the file.
                reader.Close();
            }
        }


        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(CurrentFile))
            {
                StreamWriter writer = new StreamWriter(CurrentFile);

                // Write any comments you want to include first.
                // Prefix all comment strings with an exclamation point.
                // Use WriteLine to write the strings to the file. 
                // It appends a CRLF for you.
                writer.WriteLine("!HAVE A GREAT DAY!");

                // Iterate through the universe one row at a time.
                for (int y = 0; y < universe.GetLength(1); y++) //Height
                {
                    // Create a string to represent the current row.
                    String currentRow = string.Empty;

                    // Iterate through the current row one cell at a time.
                    for (int x = 0; x < universe.GetLength(0); x++) //width
                    {
                        // If the universe[x,y] is alive then append 'O' (capital O)
                        // to the row string.

                        if (universe[x, y] == true)
                        {
                            currentRow += 'O';
                        }
                        // Else if the universe[x,y] is dead then append '.' (period)
                        // to the row string.
                        else
                        {
                            currentRow += '.';
                        }


                    }

                    // Once the current row has been read through and the 
                    // string constructed then write it to the file using WriteLine.

                    writer.WriteLine(currentRow);
                }

                // After all rows and columns have been written then close the file.
                writer.Close();

            }
            else
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "All Files|*.*|Cells|*.cells";
                dlg.FilterIndex = 2; dlg.DefaultExt = "cells";
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    CurrentFile = dlg.FileName;
                    StreamWriter writer = new StreamWriter(dlg.FileName);

                    // Write any comments you want to include first.
                    // Prefix all comment strings with an exclamation point.
                    // Use WriteLine to write the strings to the file. 
                    // It appends a CRLF for you.
                    writer.WriteLine("!HAVE A GREAT DAY!.");

                    // Iterate through the universe one row at a time.
                    for (int y = 0; y < universe.GetLength(1); y++) //Height
                    {
                        // Create a string to represent the current row.
                        String currentRow = string.Empty;

                        // Iterate through the current row one cell at a time.
                        for (int x = 0; x < universe.GetLength(0); x++) //width
                        {
                            // If the universe[x,y] is alive then append 'O' (capital O)
                            // to the row string.

                            if (universe[x, y] == true)
                            {
                                currentRow += 'O';
                            }
                            // Else if the universe[x,y] is dead then append '.' (period)
                            // to the row string.
                            else
                            {
                                currentRow += '.';
                            }


                        }

                        // Once the current row has been read through and the 
                        // string constructed then write it to the file using WriteLine.

                        writer.WriteLine(currentRow);
                    }

                    // After all rows and columns have been written then close the file.
                    writer.Close();
                }
            }
        }

        string CurrentFile = null;

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (File.Exists(CurrentFile))
            {
                StreamWriter writer = new StreamWriter(CurrentFile);

                // Write any comments you want to include first.
                // Prefix all comment strings with an exclamation point.
                // Use WriteLine to write the strings to the file. 
                // It appends a CRLF for you.
                writer.WriteLine("!HAVE A GREAT DAY!");

                // Iterate through the universe one row at a time.
                for (int y = 0; y < universe.GetLength(1); y++) //Height
                {
                    // Create a string to represent the current row.
                    String currentRow = string.Empty;

                    // Iterate through the current row one cell at a time.
                    for (int x = 0; x < universe.GetLength(0); x++) //width
                    {
                        // If the universe[x,y] is alive then append 'O' (capital O)
                        // to the row string.

                        if (universe[x, y] == true)
                        {
                            currentRow += 'O';
                        }
                        // Else if the universe[x,y] is dead then append '.' (period)
                        // to the row string.
                        else
                        {
                            currentRow += '.';
                        }


                    }

                    // Once the current row has been read through and the 
                    // string constructed then write it to the file using WriteLine.

                    writer.WriteLine(currentRow);
                }

                // After all rows and columns have been written then close the file.
                writer.Close();

            }
            else
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "All Files|*.*|Cells|*.cells";
                dlg.FilterIndex = 2; dlg.DefaultExt = "cells";
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    CurrentFile = dlg.FileName;
                    StreamWriter writer = new StreamWriter(dlg.FileName);

                    // Write any comments you want to include first.
                    // Prefix all comment strings with an exclamation point.
                    // Use WriteLine to write the strings to the file. 
                    // It appends a CRLF for you.
                    writer.WriteLine("!This is my comment.");

                    // Iterate through the universe one row at a time.
                    for (int y = 0; y < universe.GetLength(1); y++) //Height
                    {
                        // Create a string to represent the current row.
                        String currentRow = string.Empty;

                        // Iterate through the current row one cell at a time.
                        for (int x = 0; x < universe.GetLength(0); x++) //width
                        {
                            // If the universe[x,y] is alive then append 'O' (capital O)
                            // to the row string.

                            if (universe[x, y] == true)
                            {
                                currentRow += 'O';
                            }
                            // Else if the universe[x,y] is dead then append '.' (period)
                            // to the row string.
                            else
                            {
                                currentRow += '.';
                            }


                        }

                        // Once the current row has been read through and the 
                        // string constructed then write it to the file using WriteLine.

                        writer.WriteLine(currentRow);
                    }

                    // After all rows and columns have been written then close the file.
                    writer.Close();
                }
            }



        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            LoadFile();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile();

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2; dlg.DefaultExt = "cells";
            if (DialogResult.OK == dlg.ShowDialog())
            {
                CurrentFile = dlg.FileName;
                StreamWriter writer = new StreamWriter(dlg.FileName);

                // Write any comments you want to include first.
                // Prefix all comment strings with an exclamation point.
                // Use WriteLine to write the strings to the file. 
                // It appends a CRLF for you.
                writer.WriteLine("!This is my comment.");

                // Iterate through the universe one row at a time.
                for (int y = 0; y < universe.GetLength(1); y++) //Height
                {
                    // Create a string to represent the current row.
                    String currentRow = string.Empty;

                    // Iterate through the current row one cell at a time.
                    for (int x = 0; x < universe.GetLength(0); x++) //width
                    {
                        // If the universe[x,y] is alive then append 'O' (capital O)
                        // to the row string.

                        if (universe[x, y] == true)
                        {
                            currentRow += 'O';
                        }
                        // Else if the universe[x,y] is dead then append '.' (period)
                        // to the row string.
                        else
                        {
                            currentRow += '.';
                        }


                    }

                    // Once the current row has been read through and the 
                    // string constructed then write it to the file using WriteLine.

                    writer.WriteLine(currentRow);
                }

                // After all rows and columns have been written then close the file.
                writer.Close();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y] = false;
                    generations = 0;
                    timer.Enabled = false;
                    toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();

                }
            }

            CurrentFile = null;
            graphicsPanel1.Invalidate();

        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = graphicsPanel1.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                graphicsPanel1.BackColor = dlg.Color;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Updating the property
            Properties.Settings.Default.PanelColor = graphicsPanel1.BackColor;
            //Properties.Settings.Default.TimerInterval = TimerInterval;
            //saves the properties
            Properties.Settings.Default.Save();

        }

        private void cellColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = graphicsPanel1.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                Properties.Settings.Default.PanelCellColor = dlg.Color;
                graphicsPanel1.Invalidate();
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();

            //Reading the property
            graphicsPanel1.BackColor = Properties.Settings.Default.PanelColor;
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();

            //Reading the property
            graphicsPanel1.BackColor = Properties.Settings.Default.PanelColor;
        }

        private void gridColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = graphicsPanel1.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                Properties.Settings.Default.PanelGridColor = dlg.Color;
                graphicsPanel1.Invalidate();
            }
        }

        private void Randomize()
        {
            Random rand = new Random(); // Time




            //filling the universe randomly
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {


                    int num = rand.Next(0, 3);

                    //if random number is == 0 turn on
                    if (num == 0)
                    {
                        universe[x, y] = true;
                    }
                    else
                    {
                        universe[x, y] = false;
                    }


                }
            }

            //invalidate
            graphicsPanel1.Invalidate();
        }

        public void RandomizeSeed()
        {
            Random ran = new Random(Properties.Settings.Default.RandomSeed);


            //filling the universe randomly
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {


                    int num = ran.Next(0, 3);

                    //if random number is == 0 turn on
                    if (num == 0)
                    {
                        universe[x, y] = true;
                    }
                    else
                    {
                        universe[x, y] = false;
                    }


                }
            }

            //invalidate
            graphicsPanel1.Invalidate();

        }

        private void fromTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Randomize();
        }



        private void fromSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 randomSeed = new Form2();

            if (DialogResult.OK == randomSeed.ShowDialog())
            {
                RandomizeSeed();

            }


        }

        private void timerIntervalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimerInterval timer1 = new TimerInterval();

            timer1.ShowDialog();

            timer.Interval = TimerInterval;

            Properties.Settings.Default.TimerInterval = TimerInterval;
        }


    }
}
