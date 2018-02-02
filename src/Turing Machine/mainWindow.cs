using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Turing_Machine.GUI;
using Turing_Machine.TuringMachineLib;
using System.Text;


namespace Turing_Machine
{
    
    public partial class mainWindow : Form
    {
        

        //TextBox inputBox;
        TuringMachineLib.TuringMachine tm;

        Graphics g;
        PictureBox pb;

        public mainWindow()
        {
            InitializeComponent();
            InitializeComponentManual();
        }

        Label label1;

        private void InitializeComponentManual()
        {
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;

           

            pb = new PictureBox();
            //
            pb.Size = new Size(this.Size.Width, 125 + TapeGUI.tapeVerticalOffset);

            pb.BackColor = Color.GhostWhite;

            renderedArea = new Bitmap(pb.Size.Width, pb.Size.Height );
            pb.Image = renderedArea;

            g = Graphics.FromImage(renderedArea);

            

            machineTimer.Enabled = false;
            renderTimer.Enabled = false;

            machineTimer.Interval = 50;
            renderTimer.Interval = 25;

            g.DrawLine(linePen, new Point(0, 25), new Point(pb.Width, 25));
            g.DrawLine(linePen, new Point(0, 100), new Point(pb.Width, 100));

            AnswerLabel.Text = "End state";
            

            initTuringMachine("Turing Machine programs\\Decimal to binary.txt");

            this.Controls.Add(pb);
        }

        void initTuringMachine(string s )
        {

            renderTimer.Enabled = false;
            tm = new TuringMachine();

            if (s != "")
            {
                programReader inReader2 = new programReader();
                inReader2.ReadFromFile(ref tm, s);
            }
            else
            {
                programReader inReader = new programReader();
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "TM program |*.txt";
                fileDialog.Title = "Select a Turing Machine program";

                fileDialog.InitialDirectory = "";
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string path = fileDialog.FileName;
                    if (inReader.ReadFromFile(ref tm, path) == programReader.INPUT_CODE.SUCCESSFUL)
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = path.Length - 1; i >= 0; i--)
                        {
                            if (path[i] != '\\')
                                sb.Insert(0, path[i]);
                            else
                                break;
                        }
                        sb.Replace(".txt", "");
                        //this.Text = "Turing Machine" + "(" + sb.ToString() + ")";
                    }
                }
            }
            this.Show();
            if (tm.hasInitState)
            {
                initTapeGui();
                renderTimer.Enabled = true;
            }

        }

        void initTuringMachine()
        {
            
            renderTimer.Enabled = false;
            tm = new TuringMachine();

            if (false)
            {
                programReader inReader2 = new programReader();
                //inReader2.ReadFromFile(ref tm, s);
            }
            else
            {
                programReader inReader = new programReader();
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "TM program |*.txt";
                fileDialog.Title = "Select a Turing Machine program";

                fileDialog.InitialDirectory = "";
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string path = fileDialog.FileName;
                    if (inReader.ReadFromFile(ref tm, path) == programReader.INPUT_CODE.SUCCESSFUL)
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = path.Length - 1; i >= 0; i--)
                        {
                            if (path[i] != '\\')
                                sb.Insert(0, path[i]);
                            else
                                break;
                        }
                        sb.Replace(".txt", "");
                        //this.Text = "Turing Machine" + "(" + sb.ToString() + ")";
                    }
                }
            }
            this.Show();
            if (tm.hasInitState)
            {
                initTapeGui();
                renderTimer.Enabled = true;
            }
                 
        }

        
        public bool isPaused = true;

        void UpdateLabels()
        {
            if (this.tm == null)
                return;
            CurrentStateLabel.Text = "State: " + this.tm.CurrentState;
            this.stepCountLabel.Text = "Steps: " + tm.StepCount().ToString();
            if (this.tm.isFinished)
            {
                if (this.tm.CurrentState != "Rejected")
                {
                    AnswerLabel.Text = "Accepted";
                    AnswerLabel.ForeColor = Color.Green;
                }

                if(this.tm.CurrentState == "Rejected")
                {
                    AnswerLabel.ForeColor = Color.Red;
                    AnswerLabel.Text = "Rejected";
                }



                ContinueButton.Text = "..";
            }
            else
            {
                    AnswerLabel.Text = ".";
                AnswerLabel.ForeColor = Color.Black;
            }       
        }

        private void machineTimer_Tick(object sender, EventArgs e)
        {
            if (isPaused)
                return;
            

            if (!tm.isFinished )
            {
                if (animationFinished)
                {
                    tm.Tick();
                    this.stepCountLabel.Text = "Steps: " + tm.StepCount().ToString();
                }
            }
            else
            {
                
                this.isInitialized = false;
            }
        }

        Bitmap renderedArea;
        List<GUI.TapeGUI> tapesGUI;

        void initTapeGui()
        {
            if (tm == null)
                return;
            
            this.tapesGUI = new List<GUI.TapeGUI>(this.tm.tapes.Count);

            //for(int i = 0; i < this.tm.tapes.Count; i++)
            //{
            //    this.tapesGUI.Add(new GUI.TapeGUI(this));
            //    this.tapesGUI[i].tape = tm.tapes[i];
            //    this.tapesGUI[i].Location = new Point(pb.Width / 2 - 35, pb.Height * (i+1) * 5 / 100 + i * GUI.TapeGUI.tapeVerticalOffset);
            //    this.tapesGUI[i].screenLocation = this.tapesGUI[i].Location;
            //}
            this.tapesGUI.Add(new TapeGUI(this));
            this.tapesGUI[0].tape = tm.tapes[0];
            this.tapesGUI[0].Location = new Point(pb.Width / 2 - 35, pb.Height / 2 - 50);
            this.tapesGUI[0].screenLocation = this.tapesGUI[0].Location;
            
        }

        
        
        public bool animationFinished = true;

        Pen linePen = new Pen(Color.Gray, 1);


        private void renderTimer_Tick(object sender, EventArgs e)
        {

            
            g = Graphics.FromImage(renderedArea);      
            g.Clear(pb.BackColor);
            UpdateLabels();

            g.DrawLine(linePen, new Point(0, 25), new Point(pb.Width, 25));
            g.DrawLine(linePen, new Point(0, 120), new Point(pb.Width, 120));

            for (int i = 0; i < tapesGUI.Count; i++)
                tapesGUI[i].Draw(ref g, ref renderedArea);
            pb.Image = renderedArea;
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        List<char> input;

        private void StartButton_Click(object sender, EventArgs e) //Load input
        {
            if (tm == null )
                return;
            input = new List<char>();
            foreach(char c in textBox1.Text)
            {
                input.Add(c);
            }

            this.tm.ReadInput(ref input);
            ContinueButton.Text = "Play";

            this.isPaused = true;
            this.isInitialized = true;
            this.animationFinished = true;

            UpdateLabels();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.initTuringMachine();
        }

        private void button2_Click(object sender, EventArgs e) //Next step
        {
            if (this.tm == null || this.tm.isFinished || !this.isPaused || !this.animationFinished)
                return;

            this.tm.Tick();
        }
        bool isInitialized = false;
        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if (!this.isInitialized)
                return;

            this.isPaused = !isPaused;
            machineTimer.Enabled = this.isPaused ? false : true;
            ContinueButton.Text = this.isPaused ? "Play" : "Stop";
        }

       

      
        Info ow;

        private void ShowOutputButton_Click(object sender, EventArgs e)
        {
            if (ow != null)
                return;
            ow = new Info("Info");
            ow.FormClosed += new FormClosedEventHandler(ow_FormClosed);
            ow.Show();
        }

        //private void ShowOutputButton_Click(object sender, EventArgs e)
        //{
        //    if (this.input == null || !tm.isFinished)
        //        return;

        //    if (ow != null)
        //        return;
        //    ow = new OutputWindow("Output");

        //    ow.FormClosed += new FormClosedEventHandler(ow_FormClosed);

        //    List<string> output = new List<string>();

        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();

        //    sb.Append(CurrentStateLabel.Text + '(' + AnswerLabel.Text + ')');
        //    output.Add(sb.ToString());
        //    sb = new StringBuilder();
            
        //    foreach(char c in this.input)
        //    {               
        //        sb.Append(c);
        //    }

            

        //    output.Add(sb.ToString());

        //    int i = 1;
        //    foreach(Tape tape in tm.tapes)
        //    {
        //        sb = new StringBuilder();
        //        sb.Append(tape.GetData());
        //        output.Add( sb.ToString() );
        //    }

           
        //    ow.InitializeOutput(output);
        //    ow.ShowOutput();
        //    ow.Show();
        //}

        void ow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ow = null;
        }

        private void mainWindow_Resize(object sender, EventArgs e)
        {
            //pb.Width = this.Width;
            //pb.Size = new Size(this.Size.Width, this.Size.Height * 65 / 100);
            if (pb == null)
                return;

            if (this.Width < 660)
                Width = 660;
            if (this.Height < 344)
                Height = 344;
            
            pb.Size = new Size(this.Size.Width, 125 + TapeGUI.tapeVerticalOffset);
            renderedArea = new Bitmap(pb.Size.Width, pb.Size.Height);
            initTapeGui();
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {

        }

        
    }

    
}
