using UnityEngine;
using System.Collections;

public class PCar_position : MonoBehaviour {    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float playerPositionX = GameObject.Find("Player_WP_Collider").transform.position.x;
        float playerPositionZ = GameObject.Find("Player_WP_Collider").transform.position.z;

        Vector3 playerFinalPosition =new Vector3(playerPositionX, 1, playerPositionZ);

        Quaternion playerRotation = GameObject.Find("Player_WP_Collider").transform.rotation;

        this.transform.position = playerFinalPosition;
        this.transform.rotation = playerRotation;
	}
}
