using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    [Tooltip("This will allow you to change the players speed")]
    [Range(1.0f,150.0f)]
    public float Speed = 10.0f;

    float TurnSpeed = 40;

    public GameObject prefabBullet;     
   

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // movement of the player 
        if(Input.GetKey(KeyCode.W))
        {
          transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Quaternion rot = Quaternion.AngleAxis(-TurnSpeed * Time.deltaTime, Vector3.up);
            transform.rotation *= rot;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            Quaternion rot = Quaternion.AngleAxis(TurnSpeed * Time.deltaTime, Vector3.up);
            transform.rotation *= rot;
        }

            
        // shooting the bullet when the space bar is pressed
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Transform fireLocation = transform.Find("FirePoint");
            Debug.Assert(fireLocation);

            GameObject gameObject = Instantiate(prefabBullet,fireLocation.position, fireLocation.rotation);
        }
	}
}
