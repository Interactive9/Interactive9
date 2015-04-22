using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			
			Debug.Log ("onResume Received");
			AndroidJavaClass jc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer"); 
			AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject> ("currentActivity"); 
			jo.Call ("onBackPressed");
		}
	}
}
