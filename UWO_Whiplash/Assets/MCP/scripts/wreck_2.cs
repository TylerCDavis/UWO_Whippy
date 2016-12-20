using UnityEngine;
using System.Collections;

public class wreck_2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void onTriggerEnter()
    {
        var wreckTime = GetComponent("crash_P2");
        wreckTime.gameObject.active = false;
    }
}
