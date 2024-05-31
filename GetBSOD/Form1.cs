using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace GetBSOD
{
    public partial class Form1 : Form
    {
        [DllImport("ntdll.dll")]
        private static extern int NtSetInfomationProcess(IntPtr process, int process_class, ref int process_value, int length);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process.EnterDebugMode();
            int status = 1;
            NtSetInfomationProcess(Process.GetCurrentProcess().Handle, 0x1D, ref status,sizeof(int));
            Process.GetCurrentProcess().Kill(); 

        }
    }
}
