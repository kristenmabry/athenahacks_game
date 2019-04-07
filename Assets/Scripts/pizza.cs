using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pizza {
public class CPizza
{
    // type ctor
    public CPizza(char orderAddress) 
    {
        timeCreated = Time.time;
        address = orderAddress;
    }
    
    public char GetAddress() { return address; }
    public float GetTime() { return timeCreated; }

    public char address;
    public float timeCreated;
}
}