﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float force;
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("aaaaa");
        if(other.tag == "Player")
            {
                Debug.Log("spikes");
                Vector3 recoil = transform.InverseTransformDirection(transform.right) *
                Random.Range(-0.1f,0.1f) + transform.InverseTransformDirection(transform.forward) * -1f;
                other.GetComponent<CharacterController>().Move(recoil * Time.deltaTime * force);
            }
    }
}
