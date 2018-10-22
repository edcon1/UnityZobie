using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public string DefaultObjectToFollow = "player";
    private GameObject gameObjectToFollow;

	// Use this for initialization
	void Start ()
    {
        gameObjectToFollow = GameObject.Find(DefaultObjectToFollow);

    }
	
	// Update is called once per frame
	void Update ()
    {
        // geting the distance between enemy and player
        Vector3 VecToFollow = transform.position - gameObjectToFollow.transform.position;


        // normalising distance to get the direction
        Vector3 normalisedVec = VecToFollow.normalized;

        //getting the enemy to chase the player using the vector3 distance and also stopping the follow function when the enemy is within a certain distance of player
        if(VecToFollow.magnitude > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, gameObjectToFollow.transform.position, 2.7f * Time.deltaTime);
        }
        
	}

    // used for if i make a seperate object i want the enemy to follow instead of the player, so the enemy will follow this object
    public void SetObjectToFollow(GameObject go)
    {
        gameObjectToFollow = go;
    }

    // used to set the player back to the primary target for the enemy
    public void ResetObjectToFollow()
    {
        gameObjectToFollow = GameObject.Find(DefaultObjectToFollow);
    }
}
