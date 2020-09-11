using App6.Core.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace App6.Core.Services
{
    public class GetProcessService : IGetProcessService
    {
        public GetProcessService()
        {
        }
        public IEnumerable<Process> GetProcessForComboBoxAsync()
        {
            
            var PSList = 
                Process.GetProcesses().Where(x => x.MainWindowHandle != IntPtr.Zero
                && x.ProcessName != "explorer"
                && !string.IsNullOrEmpty(x.MainWindowTitle));

            return PSList;
        }

        
    }
}
