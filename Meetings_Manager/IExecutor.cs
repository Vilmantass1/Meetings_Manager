using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetings_Manager
{
    public interface IExecutor
    {
        public Task Run();

    }
}