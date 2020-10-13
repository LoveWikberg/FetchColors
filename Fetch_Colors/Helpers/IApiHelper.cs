using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fetch_Colors.Helpers
{
    public interface IApiHelper
    {
        Task<T> Fetch<T>(string apiUrl);
    }
}
