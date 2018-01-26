using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HmiWaterTower
{
    public enum TState
    {
        DISCONNECTED = 0,
        CONNECTED,
        CONNECTING,
    }

    public enum TPlcStatus
    {
        NOT_CONNECTED = 0,
        EMERGENCY_STOP,
        SAFE_MODE, // STOP mode
        READY // RUN mode
    }
}
