using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;



namespace Turing_Machine.GUI
{
    class TapeFrame
    {
        public char ch;
        int index;
        public static Size size;

        public Point location;

        public TapeFrame(int i, char c, Point location)
        {
            this.index = i;
            this.ch = c;
            this.location = location;
        }
    }

   

    class TapeGUI
    {
        public TuringMachineLib.Tape tape;

        public Point Location;      //Center of tape;
        public Point screenLocation;
        List<TapeFrame> activeFrames = new List<TapeFrame>();

        public static int tapeVerticalOffset = 55;



        

        mainWindow window = null;

        public TapeGUI(mainWindow window)
        {

            frameBrush = new SolidBrush(Color.FromArgb(70, 130, 180));
            this.window = window;
            TapeFrame.size = new Size(50, 50);
        }

        static Point offsetPointTriangle = new Point(3, 3);
        private static Point[] triangle = { new Point(0, 18), new Point(8, 18) , new Point(4, 10) };
        private Point[] coordTriangle = null;

        private const int MIDDLE_ICON_SCALE = 4;


        const int MID_ICON_OFFSET_X = 7;
        const int MID_ICON_OFFSET_Y = -10;

        void GetTriangle()
        {
            if (this.coordTriangle == null)
            {
                this.coordTriangle = new Point[] { triangle[0], triangle[1], triangle[2] };
                for (int i = 0; i < triangle.Length; i++)
                {
                    coordTriangle[i].X *= MIDDLE_ICON_SCALE;
                    coordTriangle[i].Y *= MIDDLE_ICON_SCALE;
                }
                for (int i = 0; i < triangle.Length; i++)
                {
                    coordTriangle[i].X += this.Location.X + MID_ICON_OFFSET_X;
                    coordTriangle[i].Y += this.Location.Y + TapeFrame.size.Height / 4 + MID_ICON_OFFSET_Y;
                }
            }
        }


        void DrawMiddleIcon(ref Graphics g, ref Bitmap drawArea)
        {
            SolidBrush brush = new SolidBrush(Color.Black);

            GetTriangle();


            g.FillPolygon(brush, coordTriangle);

        }

        int index = 0;

        public static int frameCount = 42;

        

        void GetActiveFrames(ref List<TapeFrame> frameList)
        {

            frameList.Clear();

            index = tape.CurrentIndex();

            int left = -frameCount / 2;
            int right = (frameCount - frameCount / 2);
            

            for(int i = left; i < right; i++)
            {
                Point loc = new Point(this.Location.X + i * TapeFrame.size.Width, this.Location.Y );
                
                frameList.Add(new TapeFrame(index + i, tape.Read(index + i), loc ));
            }
        }

        

        private Pen framePen = new Pen(Color.WhiteSmoke, 2);

        const int CHAR_OFFSET_X = -10;
        const int CHAR_OFFSET_Y = -12;
        

        SolidBrush brush = new SolidBrush(Color.White);
        SolidBrush frameBrush;
        Font charFont = new Font("Calibri", 16, FontStyle.Bold);

        public void Draw(ref Graphics g, ref Bitmap drawArea)
        {
            GetActiveFrames(ref activeFrames);
            
            foreach (TapeFrame frame in activeFrames)
            {
                Rectangle rect = new Rectangle(frame.location, TapeFrame.size);
                g.FillRectangle(frameBrush, Rectangle.Inflate(rect, -1, -1) );

                Point charLocation = new Point(rect.Location.X + TapeFrame.size.Width / 2 + CHAR_OFFSET_X, rect.Location.Y + TapeFrame.size.Height / 2 + CHAR_OFFSET_Y);

                if(frame.ch != '_')
                    g.DrawString(frame.ch.ToString(), charFont, brush, charLocation);
            }

            DrawMiddleIcon(ref g, ref drawArea);
        }

    }
}
