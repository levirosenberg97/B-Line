using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {

    public Transform pos;
	
	// Update is called once per frame
	void Update () {
        transform.position = pos.position + new Vector3(0,0,-1);
	}
}
