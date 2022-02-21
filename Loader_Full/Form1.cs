using Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loader_Full
{
    public partial class lieth : Form
    {
        public lieth()
        {
            InitializeComponent();
        }

        [DllImport("KERNEL32.DLL")]
        public static extern IntPtr CreateToolhelp32Snapshot(uint flags, uint processid);
        [DllImport("KERNEL32.DLL")]
        public static extern int Process32First(IntPtr handle, ref ProcessEntry32 pe);
        [DllImport("KERNEL32.DLL")]
        public static extern int Process32Next(IntPtr handle, ref ProcessEntry32 pe);

        private async Task PutTaskDelay(int Time)
        {
            await Task.Delay(Time);
        }
        private async Task<IntPtr> FUCK_IS_ALWAYS_REAL(string type)
        {
            string Bluestacks = "HD-Player";

            var intPtr = IntPtr.Zero;
            uint num = 0U;
            var intPtr2 = CreateToolhelp32Snapshot(2U, 0U);
            if ((int)intPtr2 > 0)
            {
                ProcessEntry32 processEntry = default;
                processEntry.dwSize = (uint)Marshal.SizeOf(processEntry);
                int num2 = Process32First(intPtr2, ref processEntry);
                while (num2 == 1)
                {
                    var intPtr3 = Marshal.AllocHGlobal((int)processEntry.dwSize);
                    Marshal.StructureToPtr(processEntry, intPtr3, true);
                    ProcessEntry32 processEntry2 = (ProcessEntry32)Marshal.PtrToStructure(intPtr3, typeof(ProcessEntry32));
                    Marshal.FreeHGlobal(intPtr3);
                    if (processEntry2.szExeFile.Contains(Bluestacks) && processEntry2.cntThreads > num)
                    {
                        num = processEntry2.cntThreads;
                        intPtr = (IntPtr)(long)(ulong)processEntry2.th32ProcessID;
                    }

                    num2 = Process32Next(intPtr2, ref processEntry);
                }
                PID.Text = Convert.ToString(intPtr);
                await PutTaskDelay(1000);

                if (type == "NORECOIL")
                {
                    changeMEMORY("ODAgMzcgOEYgM0M=", "MDAgRDcgNUIgMDA=");
                }

                else if (type == "AIMLOCK")
                {
                    changeMEMORY("N0YgNDUgNEMgNDYgMDEgMDEgMDEgMDA=", "MDEgMDAgQTAgRTMgMUUgRkYgMkYgRTE=");
                }
                else if (type == "NORECOILDESATIVAR")
                {
                    changeMEMORY("MDAgRDcgNUIgMDA=", "ODAgMzcgOEYgM0M=");
                }
                else if (type == "AIMLOCKDESATIVAR")
                {
                    changeMEMORY("MDEgMDAgQTAgRTMgMUUgRkYgMkYgRTE=", "N0YgNDUgNEMgNDYgMDEgMDEgMDEgMDA=");
                }
            }
            return intPtr;
        }

        private string sr;

        public async void DRIERSSSS_LOAD_AUTO_IN_PROCESSS(string type)
        {
            Console.Beep(420, 250);
            x = 0;
            await FUCK_IS_ALWAYS_REAL(type);
        }
        public long enumerable = new long();

        public async void changeMEMORY(string search, string replace)
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                PSPS.ForeColor = Color.Red;
                PSPS.Text = "Falha ao Conectar.";
                Console.Beep(1250, 250);
            }
            else
            {
                PSPS.ForeColor = Color.Green;
                PSPS.Text = "Conectado.";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                PSPS.ForeColor = Color.Orange;
                PSPS.Text = "Aplicando...";

                var enumerable = await MemLib.AoBScan(67108864L, 4294967295L, infile(search), true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");

                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", infile(replace), string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    Console.Beep(1250, 250);
                    PSPS.Text = "Aplicado!";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    Console.Beep(1250, 250);
                    PSPS.ForeColor = Color.Red;
                    PSPS.Text = "Falha ao Aplicar";
                    counter += 1;
                }
                else
                {
                    Console.Beep(1250, 250);
                    PSPS.Text = "Falha ao Aplicar";
                    PSPS.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");

            }
        }

        public static string infile(string value)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(value));
        }

        private int x;
        public Mem MemLib = new Mem();
        private static string string_0;
        private IContainer icontainer_0;

        public struct ProcessEntry32
        {
            public uint dwSize;
            public uint cntUsage;
            public uint th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public uint th32ModuleID;
            public uint cntThreads;
            public uint th32ParentProcessID;
            public int pcPriClassBase;
            public uint dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExeFile;
        }
        private void siticoneButton5_Click_1(object sender, EventArgs e)
        {
            PSPS.Text = "Conectando...";
            PSPS.ForeColor = Color.Orange;
            DRIERSSSS_LOAD_AUTO_IN_PROCESSS("AIMLOCK");
        }

        private void siticoneButton8_Click(object sender, EventArgs e)
        {
            PSPS.Text = "Conectando...";
            PSPS.ForeColor = Color.Orange;
            DRIERSSSS_LOAD_AUTO_IN_PROCESSS("NORECOILDESATIVAR");
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            PSPS.Text = "Conectando...";
            PSPS.ForeColor = Color.Orange;
            DRIERSSSS_LOAD_AUTO_IN_PROCESSS("NORECOIL");
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            PSPS.Text = "Conectando...";
            PSPS.ForeColor = Color.Orange;
            DRIERSSSS_LOAD_AUTO_IN_PROCESSS("AIMLOCKDESATIVAR");
        }
    }
}
