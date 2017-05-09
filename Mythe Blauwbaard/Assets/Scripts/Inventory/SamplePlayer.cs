using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlayer : MonoBehaviour
{
    public Inventory Inventory;

    private InventoryGridVisual _inventoryGridVisual;

    private void Start()
    {
        Inventory = new Inventory();
        _inventoryGridVisual = GetComponent<InventoryGridVisual>();
        _inventoryGridVisual.Init(Inventory);
    }

    private KeyCode[] _keyCodes = {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
    };

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _inventoryGridVisual.Toggle();
        }
        for (int i = 0; i < _keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(_keyCodes[i]))
            {
                int numberPressed = i + 1;
                Debug.Log(numberPressed);
                Instantiate(Resources.Load<GameObject>(Inventory.Items[numberPressed-1].Name),transform.position,Quaternion.identity);
                Inventory.RemoveItem(numberPressed);
            }
        }
    }
}
