using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlignVision
{
    public partial class FormStatusPC : Form
    {
        private PerformanceCounter cpuCounter;
        public FormStatusPC()
        {
            InitializeComponent();
        }

        private void FormStatusPC_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        public bool Initialize()
        {
            bool result = false;
            if (InitializeForm())
            {
                result = true;
            }
            return result;
        }
        private bool InitializeForm()
        {
            bool result = false;

            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            timer.Interval = 1000;
            timer.Start();
            result = true;
            return result;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateStatusPC();
        }
        /// <summary>
        /// Get and update system statistics such as CPU, RAM, and Disk usage.
        /// </summary>
        private void UpdateStatusPC()
        {
            // CPU Usage
            // Get the current CPU usage using PerformanceCounter
            uiProcessBar_CPU.Value = (int)cpuCounter.NextValue();

            // RAM Usage
            // Used WMI to get the total and free physical memory
            ManagementClass RAMInfor = new ManagementClass("Win32_OperatingSystem");
            ManagementObjectCollection instances = RAMInfor.GetInstances();
            foreach (ManagementObject index in instances)
            {
                int totalMemory = int.Parse(index["TotalVisibleMemorySize"].ToString());
                int freeMemory = int.Parse(index["FreePhysicalMemory"].ToString());
                int usedMemory = totalMemory - freeMemory;

                uiProcessBar_RAM.Value = (int)(((double)usedMemory / (double)totalMemory) * 100);
            }

            // Disk Usage
            // Get all drives and update the progress bars for C, D, E, F drives
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                switch (drive.DriveType)
                {
                    case DriveType.Fixed:
                        {
                            switch (drive.Name)
                            {
                                case "C:\\":
                                    uiProcessBar_DiskC.Value = (int)(100 - (double)drive.AvailableFreeSpace / (double)drive.TotalSize * 100);
                                    break;
                                case "D:\\":
                                    uiProcessBar_DiskD.Value = (int)(100 - (double)drive.AvailableFreeSpace / (double)drive.TotalSize * 100);
                                    break;
                                case "E:\\":
                                    uiProcessBar_DiskE.Value = (int)(100 - (double)drive.AvailableFreeSpace / (double)drive.TotalSize * 100);
                                    break;
                                case "F:\\":
                                    uiProcessBar_DiskF.Value = (int)(100 - (double)drive.AvailableFreeSpace / (double)drive.TotalSize * 100);
                                    break;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
