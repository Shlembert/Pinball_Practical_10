﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshCollider))]
public class Bumper : MonoBehaviour
{
    [SerializeField] float power;
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void OnCollisionEnter(Collision col)
    {
        foreach (ContactPoint contact in col.contacts)
        {
            contact.otherCollider.attachedRigidbody.AddForce(-1 * contact.normal * power, ForceMode.Impulse);
        }
        if (anim != null)
        {
            anim.SetTrigger("activate");
        }
    }

}
