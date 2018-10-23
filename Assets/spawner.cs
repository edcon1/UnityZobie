using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public float TriggerTime = 5;
    float timer = 0;
    bool IsInRange = false;

    public GameObject zobiePreFab;
    private GameObject SpawnerTrigger;
    public string Trigger = "player";
  
    // Use this for initialization
    void Start ()
    {
        SpawnerTrigger = GameObject.Find(Trigger);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // finding the positoion of the player
        Vector3 DistanceTrigger = transform.position - SpawnerTrigger.transform.position;
        

        if (DistanceTrigger.magnitude < 4)
        {
            if(IsInRange == false)
            {
                IsInRange = true;
                timer = 0;
            }
            timer += Time.deltaTime;

            if(timer >= TriggerTime)
            {
                GameObject gameObject = Instantiate(zobiePreFab, transform.position, transform.rotation);
                timer = 0;
            }
           
        }
        else
        {
            IsInRange = false;
            timer = 0;
        }

	}
}
