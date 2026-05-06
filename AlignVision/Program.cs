using System;
using System.Threading;
using System.Windows.Forms;

namespace AlignVision
{
    static class Program
    {
        public const string ID = "ALIGN_VISION";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool RunningProgram = false;
            Mutex mutex = new Mutex(true, ID, out RunningProgram);

            if (true == RunningProgram)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new CMainFrame());
            }
            else
            {
                MessageBox.Show("AlignProject is already running.", ID, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
