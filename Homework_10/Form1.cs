namespace Homework_10
{
    public partial class Form1 : Form
    {
        int timeSecond;
        double angleSecond = 0, angleMinute = 0, angleHour = 0;
        int xSecond, ySecond, xMinute, yMinute, xHour, yHour;
        public Form1()
        {
            InitializeComponent();
            timeSecond = DateTime.Now.Second;

            angleSecond = DateTime.Now.Second * 6;

            if (DateTime.Now.Second < 30)
            {
                angleMinute = DateTime.Now.Minute * 6;
            }
            else
            {
                angleMinute = DateTime.Now.Minute * 6 + 3;
            }    

            angleHour = DateTime.Now.Hour * 30 + DateTime.Now.Minute * 0.5;

            xSecond = this.Width / 2;
            ySecond = this.Height / 2;

            xSecond = Convert.ToInt32(xSecond + 100 * Math.Sin(3.14 * angleSecond / 180));
            ySecond = Convert.ToInt32(ySecond - 100 * Math.Cos(3.14 * angleSecond / 180)); 

            xMinute = this.Width / 2;
            yMinute = this.Height / 2;

            xMinute = Convert.ToInt32(xMinute + 75 * Math.Sin(3.14 * angleMinute / 180));
            yMinute = Convert.ToInt32(yMinute - 75 * Math.Cos(3.14 * angleMinute / 180));

            xHour = this.Width / 2;
            yHour = this.Height / 2;

            xHour = Convert.ToInt32(xHour + 50 * Math.Sin(3.14 * angleHour / 180));
            yHour = Convert.ToInt32(yHour - 50 * Math.Cos(3.14 * angleHour / 180));

            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            PaintLine(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (angleSecond % 360 == 0)
            {
                angleSecond = 6;
            }
            if (angleMinute % 360 == 0)
            {
                angleMinute = 3;
            }
            if (angleHour % 360 == 0)
            {
                angleHour = 0.5;
            }

            angleSecond += 6;

            xSecond = this.Width / 2;
            ySecond = this.Height / 2;

            xSecond = Convert.ToInt32(xSecond + 100 * Math.Sin(3.14 * angleSecond / 180));
            ySecond = Convert.ToInt32(ySecond - 100 * Math.Cos(3.14 * angleSecond / 180));

            if (timeSecond % 30 == 0 && timeSecond != 0)
            {
                angleMinute += 3;
                xMinute = this.Width / 2;
                yMinute = this.Height / 2;

                xMinute = Convert.ToInt32(xMinute + 75 * Math.Sin(3.14 * angleMinute / 180));
                yMinute = Convert.ToInt32(yMinute - 75 * Math.Cos(3.14 * angleMinute / 180));
            }

            if (timeSecond % 60 == 0 && timeSecond != 0) 
            {
                angleHour += 0.5;

                xHour = this.Width / 2;
                yHour = this.Height / 2;

                xHour = Convert.ToInt32(xHour + 50 * Math.Sin(3.14 * angleHour / 180));
                yHour = Convert.ToInt32(yHour - 50 * Math.Cos(3.14 * angleHour / 180));

                timeSecond = 0;
            }

            PaintLine(sender, e);
            timeSecond++;
        }

        private void PaintLine(object sender, EventArgs e)
        {
            String text;
            Font font = new Font("Comic Sans MS", 10); ;
            Rectangle rect = new Rectangle(this.Width / 2 - 40, this.Height / 2 + 150, 100, 100); ;

            Graphics g = this.CreateGraphics();
            g.Clear(Color.Aqua);
            Pen pen = new Pen(Color.Black, 4.0f);
            Brush brush = new SolidBrush(Color.Green);
            g.DrawEllipse(pen, new Rectangle(this.Width / 2 - 250 / 2, this.Height / 2 - 250 / 2, 250, 250));
            g.FillEllipse(brush, new Rectangle(this.Width / 2 - 250 / 2, this.Height / 2 - 250 / 2, 250, 250));
            brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, new Rectangle(this.Width / 2 - 20 / 2, this.Height / 2 - 20 / 2, 20, 20));
            int angleArrow = 0;
            int xArrow = 0;
            int yArrow = 0;
            int xArrow2 = 0;
            int yArrow2 = 0;

            int i = 0;
            while (angleArrow < 360)
            {
                xArrow = this.Width / 2;
                yArrow = this.Height / 2;

                xArrow2 = this.Width / 2;
                yArrow2 = this.Height / 2;

                xArrow = Convert.ToInt32(xArrow + 125 * Math.Sin(3.14 * angleArrow / 180));
                yArrow = Convert.ToInt32(yArrow - 125 * Math.Cos(3.14 * angleArrow / 180));

                xArrow2 = Convert.ToInt32(xArrow2 + 110 * Math.Sin(3.14 * angleArrow / 180));
                yArrow2 = Convert.ToInt32(yArrow2 - 110 * Math.Cos(3.14 * angleArrow / 180));

                g.DrawLine(pen, new Point(xArrow2, yArrow2), new Point(xArrow, yArrow));

                if (angleArrow % 30 == 0)
                {
                    xArrow = this.Width / 2;
                    yArrow = this.Height / 2;

                    xArrow = Convert.ToInt32(xArrow + 150 * Math.Sin(3.14 * angleArrow / 180));
                    yArrow = Convert.ToInt32(yArrow - 150 * Math.Cos(3.14 * angleArrow / 180));

                    if (i == 0)
                    {
                        text = "12";
                    }
                    else
                    {
                        text = Convert.ToString(i);
                    }
                    rect = new Rectangle(xArrow - 10, yArrow - 10, 30, 20);
                    g.DrawString(text, font, brush, rect);
                    i++;
                }

                angleArrow += 30;
            }

            g.DrawLine(pen, new Point(this.Width / 2, this.Height / 2), new Point(xSecond, ySecond));
            pen = new Pen(Color.Yellow, 4.0f);
            g.DrawLine(pen, new Point(this.Width / 2, this.Height / 2), new Point(xMinute, yMinute));
            pen = new Pen(Color.Red, 4.0f);
            g.DrawLine(pen, new Point(this.Width / 2, this.Height / 2), new Point(xHour, yHour));

            text = DateTime.Now.ToString("HH:mm:ss");
            rect = new Rectangle(this.Width / 2 - 40, this.Height / 2 + 165, 100, 100);
            g.DrawString(text, font, brush, rect);
            pen.Dispose();
            g.Dispose();
        }
    }
}
