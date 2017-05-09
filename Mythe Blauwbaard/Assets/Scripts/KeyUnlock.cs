using System.Collections;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class KeyUnlock : MonoBehaviour
{
    private bool _unlocking;
    private Rigidbody _rb;

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
        Destroy(GetComponent<Throwable>());
        Destroy(GetComponent<InteractableHoverEvents>());
        Destroy(GetComponent<VelocityEstimator>());
        Destroy(GetComponent<Interactable>());
        transform.parent = null;
        transform.position = new Vector3(6.36f,1.02f,-4.48f);
        _rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        _unlocking = true;
        StartCoroutine(Rotations());
    }

    private IEnumerator Rotations()
    {
        while (true)
        {
            int i;
            for (i = 0; i < 54; i++)
            {
                transform.Rotate(2.5f, 0, 0);
                yield return new WaitForSeconds(0.05f);
            }
            Destroy(gameObject);
        }
    }
}
