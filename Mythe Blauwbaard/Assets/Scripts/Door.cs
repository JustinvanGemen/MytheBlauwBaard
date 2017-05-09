using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private void OnCollisionEnter(Collision go)
    {
        if (go.transform.name == "Key")
        {
            Open();
            Destroy(go.gameObject);
        }
    }

    private void Open()
    {
        Debug.Log("Key");
        transform.rotation = new Quaternion(0,-90,0,0);
    }
}
