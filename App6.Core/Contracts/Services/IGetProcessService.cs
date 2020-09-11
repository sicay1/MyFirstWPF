using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace App6.Core.Contracts.Services
{
    public interface IGetProcessService
    {
        IEnumerable<Process> GetProcessForComboBoxAsync();
    }
}
