using UnityEngine;
using System.Collections;


public class Rotate : MonoBehaviour {
	private Vector3 yAxis, xAxis;
	// Use this for initialization
	void Start () {
		 yAxis = Vector3.up;
		 //xAxis = Vector3.left;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touches.Length > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){
			this.transform.rotation *= Quaternion.AngleAxis(-Input.GetTouch(0).deltaPosition.x, yAxis);
		}
	}
}