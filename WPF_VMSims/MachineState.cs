using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_VMSims
{
    class MachineState
    {
        public static bool IsRunning { get; set; } =false;

        public static TimeSpan LastRunDuration { get; set; } = TimeSpan.Zero;
    }
}
