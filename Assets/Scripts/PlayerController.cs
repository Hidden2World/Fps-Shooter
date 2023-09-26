using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject knifePrefab; // Reference to the knife prefab.
    public Transform throwPoint;   // The point from where the knife is thrown.
    public float throwForce = 1500f; // The force applied to the knife.

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ThrowKnife();
        }
    }

    void ThrowKnife()
    {
        GameObject knife = Instantiate(knifePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody knifeRigidbody = knife.GetComponent<Rigidbody>();
        knifeRigidbody.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);
    }
}
