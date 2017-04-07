using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUnlock : MonoBehaviour
{
    private bool _doneRotating = false;
    private bool _unlocking = false;
    private Rigidbody _rb;
    private int _i;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider keyhole)
    {
        if (_unlocking)
        {
            return;
        }
        _rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        _unlocking = true;
        StartCoroutine(Rotations());
    }

    private IEnumerator Rotations()
    {
        while (true)
        {
            for (_i = 0; _i < 36; _i++)
            {
                transform.Rotate(5, 0, 0);
                yield return new WaitForSeconds(0.15f);
            }
            Destroy(gameObject);
        }
    }
}
