using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Linq;

namespace Turing_Machine.GUI
{
    class Info : Form
    {   
        
        //private ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.IContainer components;
        private Label label1;
        //List<Label> labels;

        //public void InitializeOutput(List<string> content)
        //{
        //    this.outputs = new List<string>();

        //    StringBuilder sb = new StringBuilder();

        //    int i = 0;
        //    foreach(string s in content)
        //    {
        //        sb = new StringBuilder();
        //        if (i == 0)
        //            sb.Append("State :  ");

        //        if (i == 1)
        //            sb.Append("Input :  ");

        //        if(i > 1)
        //            sb.Append("Tape " + (i-1).ToString() + ":  ");
        //        sb.Append(s);

        //        outputs.Add(sb.ToString());
        //        i++;
        //    }
        //}

        //const int LABEL_OFFSET_Y = 25;
        //const int LABEL_LOCATION_X = 15;
        //const int LABEL_LOCATION_Y = 10;

        //public void ShowOutput()
        //{
        //    labels = new List<Label>();

            
            
        //    int offsetMultiplier = 0;
        //    foreach (string s in outputs.Take(2))
        //    {               
        //        Label newLabel = new Label();
        //        newLabel.AutoSize = true;
        //        newLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
        //        newLabel.Location = new System.Drawing.Point(LABEL_LOCATION_X, LABEL_LOCATION_Y + LABEL_OFFSET_Y * (offsetMultiplier++));
        //        newLabel.Text = s;
                
        //        labels.Add(newLabel);
        //    }


        //    StringBuilder sb = new StringBuilder();

        //    foreach (string s in outputs.Skip(2))
        //    {
        //        sb = new StringBuilder();
        //        for (int j = 0; j < 9; j++)
        //            sb.Append(s[j]);

        //        int jLeft;
        //        int jRight;
        //        for(jLeft = 10; jLeft < s.Length; jLeft++)
        //        {
        //            if (s[jLeft] != '_')
        //            {
        //                break;
        //            }
        //        }

        //        for (jRight = s.Length - 1; jRight >= 0; jRight--)
        //        {
        //            if (s[jRight] != '_')
        //                break;
        //        }

        //        for(int j = jLeft; j <= jRight; j++)
        //        {
        //            sb.Append(s[j]);
        //        }

        //        Label newLabel = new Label();
        //        newLabel.AutoSize = true;
        //        newLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
        //        newLabel.Location = new System.Drawing.Point(LABEL_LOCATION_X, LABEL_LOCATION_Y + LABEL_OFFSET_Y * (offsetMultiplier++));
        //        newLabel.Text = sb.ToString();

        //        labels.Add(newLabel);
        //    }

        //    foreach (Label label in labels)
        //    {
        //        this.Controls.Add(label);
        //    }
        //}

        //void HideUnderscores()
        //{
        //    if (labels == null)
        //        return;

        //    StringBuilder sb = new StringBuilder();
        //    for(int i = 0; i < labels.Count; i++)
        //    {
        //        sb.Append(labels[i].Text);
        //        sb.Replace("_", "");
        //    }
        //}

        public Info(string name)
        {
            this.Text = name;
            this.AutoScroll = true;
            InitializeComponent();
        }

        void InitializeControls()
        {
            
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Info));
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(452, 402);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Info
            // 
            this.ClientSize = new System.Drawing.Size(454, 433);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Info";
            this.ResumeLayout(false);

        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
