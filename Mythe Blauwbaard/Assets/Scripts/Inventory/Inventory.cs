using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory
{
    public List<Item> Items;

    private Action<Inventory> OnChanged;

    public Inventory()
    {
        Items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        Items.Add(item);

        if(OnChanged != null) OnChanged.Invoke(this);
    }

    public void RemoveItem(int i)
    {
        if (i < 0 || i > Items.Count) return;

        RemoveItem(Items[i-1]);
    }

    public void RemoveItem(Item item)
    {
        Items.Remove(item);

        if(OnChanged != null) OnChanged.Invoke(this);
    }

    public void RegisterOnChanged(Action<Inventory> cb)
    {
        OnChanged += cb;
    }
}
