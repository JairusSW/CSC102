using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System;
class Effects
{
    public static void Bounce(Label label, int h = 5)
    {
        int y = label.Location.Y;
        int s = 5;
        int direction = -1;

        Timer timer = new Timer { Interval = 50 };
        timer.Tick += (_, e) =>
        {
            label.Location = new Point(label.Location.X, label.Location.Y + direction * s);

            if (direction == -1 && label.Location.Y <= y - h)
            {
                direction = 1;
            }
            else if (direction == 1 && label.Location.Y >= y)
            {
                label.Location = new Point(label.Location.X, y);
                timer.Stop();
                timer.Dispose();
                //if (h-- <= 0) return;
                //Bounce(label, h);

            }
        };

        timer.Start();
    }
    public static Timer Rebounce(Label label, int h = 5)
    {
        int y = label.Location.Y;
        int s = 5;
        int direction = -1;

        Timer timer = new Timer { Interval = 50 };
        timer.Tick += (_, e) =>
        {
            label.Location = new Point(label.Location.X, label.Location.Y + direction * s);

            if (direction == -1 && label.Location.Y <= y - h)
            {
                direction = 1;
            }
            else if (direction == 1 && label.Location.Y >= y)
            {
                label.Location = new Point(label.Location.X, y);
                direction = -1;
            }
        };

        timer.Start();
        return timer;
    }
    public static async Task Flip(Label label)
    {
        Timer timer = new Timer { Interval = 15 };
        int direction = -1;
        int h = 50;
        int x = label.Location.X;
        string text = label.Text;

        timer.Tick += (s, e) =>
        {
            if (direction == -1)
            {
                if (label.Height <= 0) direction = 1;
                else
                {
                    label.Height -= 4;
                    label.Location = new Point(x, label.Location.Y + 2);
                }
            }
            else if (direction == 1)
            {
                if (label.Height >= 50) direction = 0;
                else
                {
                    label.Height += 4;
                    label.Location = new Point(x, label.Location.Y - 2);
                }
            }
            else
            {
                timer.Stop();
                timer.Dispose();
            }
        };

        timer.Start();
        await Task.Delay(400);
    }
}