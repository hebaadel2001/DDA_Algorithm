using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDA_Algorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

                                          // When press on button:
            private void button1_Click(object sender, EventArgs e)
        {
            /****************************************************************************
                       get values of starting point (x , y) from its textBoxs: 
            ****************************************************************************/
            
            int x0 = Convert.ToInt32(boxForX0.Text);  // => for X0
            int y0 = Convert.ToInt32(boxForY0.Text);  // => for Y0
            
            /****************************************************************************
                       get values of starting point (x , y) from its textBoxs: 
            ****************************************************************************/

            int x1 = Convert.ToInt32(boxForX1.Text);
            int y1 = Convert.ToInt32(boxForY1.Text);
            
            /****************************************************************************
                            add x0 , y0 in =>startPoint =>object from Point
                            add x1 , y1 in =>endPoint =>object from Point
             ***************************************************************************/
            
            Point startPoint = new Point(x0, y0);
            Point endPoint = new Point(x1, y1);

            /****************************************************************************
                          Calling DDA Algorithm to apply it and draw the line
             ***************************************************************************/

            DDA_Algorithm(startPoint , endPoint);
        
        }

                                                             // DDA algorithm => 
        public void DDA_Algorithm(Point start, Point end)
        {
            /**********************************************************************************
                          create a graghic object to draw in the panel
                          abrush is the line that will be drawn
             **********************************************************************************/
            
            var graphic = panel1.CreateGraphics();
            var aBrush = Brushes.Black;

            /*********************************************************************************
                            calculate deltaX and deltaY: => deltaX = x1-x0
                                                         => deltaY = y1-y0
             ********************************************************************************/
            
            int dX = end.X - start.X;
            int dY = end.Y - start.Y;
            /********************************************************************************
                            k is a variable that will be used in the for loop
                            steps ia a variable to identify the number of steps to put pixel
             ******************************************************************************/
            int steps;
            int k;

            double incrementX;
            double incrementY;
            
            /*******************************************************************************
                                   assign the value of starting point to x and y
             ******************************************************************************/
            
            float x = start.X;
            float y = start.Y;
            /****************************************************************************
             in the other way:
                    if (fabs (dx) > fabs (dy))
                        steps = fabs (dx);
                    else
                        steps = fabs (dy);
             *************************************************************************/
            
            steps = Math.Abs(dX) > Math.Abs(dY) ? Math.Abs(dX) : Math.Abs(dY);

            /************************************************************************
             Calculate xIncrement and yIncrement
             ***********************************************************************/
            
            incrementX = dX / (float) steps;
            incrementY = dY / (float) steps;
            
            /***********************************************************************
             Math.Round => is a function returns the value of a number rounded to the nearest integer.
             **********************************************************************/
            
            for (k = 0; k < steps; k++)
            {
                x = (float)(x + incrementX);
                y = (float)(y + incrementY);
                graphic.FillRectangle(aBrush, (int)Math.Round(x, 0), (int)Math.Round(y, 0), 2, 2);
            }

        }

    }
}
