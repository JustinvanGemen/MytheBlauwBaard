using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private Item _item;

    private void OnCollisionEnter(Collision go)
    {
        if (go.transform.tag == "Player")
        {
            Debug.Log("player toched");
            go.transform.root.GetComponent<SamplePlayer>().Inventory.AddItem(_item);
            Destroy(gameObject);
        }
    }
}
