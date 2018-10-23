using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    [Tooltip("This will allow you to change the players speed")]
    [Range(1.0f,150.0f)]
    public float Speed = 10.0f;

    bool IsJumping = false;
    public float JumpTimer = 0;
    float RestetTimer = 0.7f;

    float TurnSpeed = 40;

    public GameObject prefabBullet;

    private Rigidbody RB;

	// Use this for initialization
	void Start ()
    {
        RB = GetComponent<Rigidbody>();
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
        if(Input.GetKey(KeyCode.Space))
        {
            if(IsJumping == false)
            {
                IsJumping = true;
                JumpTimer = 0;
                RB.AddForce(5 * Vector3.up, ForceMode.VelocityChange);
            }
            
        }
        JumpTimer += Time.deltaTime;

        if (JumpTimer >= RestetTimer)
        {
            IsJumping = false;
            JumpTimer = 0;
        }


        // shooting the bullet when the space bar is pressed
        if (Input.GetMouseButtonDown(0))
        {
            Transform fireLocation = transform.Find("FirePoint");
            Debug.Assert(fireLocation);

            GameObject gameObject = Instantiate(prefabBullet,fireLocation.position, fireLocation.rotation);
        }
	}
}
