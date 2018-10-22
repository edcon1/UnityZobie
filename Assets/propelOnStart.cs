using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class propelOnStart : MonoBehaviour
{
    // giving a min and max speed for the bullet
    [Range(1.0f,100.0f)]
    public float forceAmount = 10.0f;

	// Use this for initialization
	void Start ()
        // giving the bullet the force it needs when it is shot, only gets calle dwhen the bullet gets called
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * forceAmount, ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
