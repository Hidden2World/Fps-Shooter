using Mono.Cecil.Cil;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Dashing : MonoBehaviour
{
    [Header("Refrences")]
    public Transform orientation;
    public Transform playerCam;
    private Rigidbody rb;
    private FirstPersonController pm;

    [Header("Dashing")]
    public float dashForce;
    public float dashUpwardForce;
    public float dashDuration;

    [Header("Cooldown")]
    public float dashCd;
    private float dashCdTimer;

    [Header("Input")]
    public KeyCode dashKey = KeyCode.E;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<FirstPersonController>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(dashKey))
            Dash();
    }
    private void Dash()
    {
        Vector3 forceToApply = orientation.forward * dashForce + orientation.up * dashUpwardForce;

        rb.AddForce(forceToApply, ForceMode.Impulse);

        Invoke(nameof(ResetDash), dashDuration);
       
    }


    private void ResetDash()
    {

    }


}
