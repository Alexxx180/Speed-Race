using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBonus
{
    public TimeBonus()
    {
        count = 0;
        time = 0;
    }

    public TimeBonus(byte cnt) : this()
    {
        count = cnt;
    }

    public byte count { get; set; }
    public byte time { get; set; }
}
