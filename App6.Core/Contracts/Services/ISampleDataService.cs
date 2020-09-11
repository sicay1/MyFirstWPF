using System.Collections.Generic;
using System.Threading.Tasks;

using App6.Core.Models;

namespace App6.Core.Contracts.Services
{
    public interface ISampleDataService
    {
        Task<IEnumerable<SampleOrder>> GetMasterDetailDataAsync();
    }
}
