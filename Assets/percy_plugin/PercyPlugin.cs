using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class PercyPlugin
{
    [DllImport("PercyPlugin")]
    private static extern IntPtr percy_create(int comm_port, double ranging_m, double ranging_c);

    [DllImport("PercyPlugin")]
    private static extern float percy_get_distance_mm(IntPtr link);

    [DllImport("PercyPlugin")]
    private static extern void percy_delete(IntPtr link);







    private IntPtr _link;

    public PercyPlugin(int comm_port, double ranging_m = 0.0459306, double ranging_c = 16.2135)
    {
        _link = percy_create(comm_port, ranging_m, ranging_c);

        Debug.Assert(IntPtr.Zero != _link, "got a null percy when comm_port = " + comm_port);
        Debug.Assert(NotNull);
    }

    public bool NotNull { get => (IntPtr.Zero != _link); }

    ~PercyPlugin()
    {
        if (NotNull)
            Release();
    }

    public float mmGetDistance()
    {
        Debug.Assert(NotNull);

        return percy_get_distance_mm(_link);

    }

    public void Release()
    {
        Debug.Assert(NotNull);

        percy_delete(_link);

        _link = IntPtr.Zero;
    }
}
