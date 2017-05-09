using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

[Serializable]
public class Item
{
    public string Name;

    public Item(string n)
    {
        Name = n;
    }
}
