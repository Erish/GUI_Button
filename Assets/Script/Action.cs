using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Debug.Log ("Press");
	}

	void OnMouseUp(){
		Debug.Log ("Release");
	}
}
