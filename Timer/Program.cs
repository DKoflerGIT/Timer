using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerTool
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormTimerMenu());
        }

        public static string resourcePath = "..\\..\\..\\Timer\\";
    }

    public class Timer
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public List<Button> TimerButtons { get; set; }
        public List<Label> TimerLabels { get; set; }
        public Panel TimerPanel { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int HoursInit { get; set; }
        public int MinutesInit { get; set; }
        public int SecondsInit { get; set; }
        public bool pause { get; set; }
        public bool reset { get; set; }
        public bool running { get; set; }

public Timer() : this("Timer1", 0, 5, 0, new Color(255, 0, 0)) { }

        public Timer(string n, int h, int m, int s, Color c)
        {
            Name = n;
            Hours = HoursInit = h;
            Minutes = MinutesInit = m;
            Seconds = SecondsInit = s;
            Color = c;
            TimerButtons = new List<Button>() { };
            TimerLabels = new List<Label>() { };
            TimerPanel = null;
            pause = false;
            reset = false;
            running = false;
        }
    }

    public class Color
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        public Color(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }
        public Color() : this(255,255,255) { }
    }
}