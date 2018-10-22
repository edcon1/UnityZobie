using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public float TriggerTime = 5;
    float timer = 0;

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
        
        Vector3 DistanceTrigger = transform.position - SpawnerTrigger.transform.position;
        
        timer += Time.deltaTime;

        if (timer >= TriggerTime)
        {
            Debug.Log("timer maxed");
            timer = 0;

            if (DistanceTrigger.magnitude < 4)
            {
                

                GameObject gameObject = Instantiate(zobiePreFab, transform.position, transform.rotation);
            }

        }

       
	}
}
