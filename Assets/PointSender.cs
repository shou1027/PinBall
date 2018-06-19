using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSender : MonoBehaviour {

	private PointTextController ptController;

	private int smallStarPoint = 10;
	private int largeStarPoint = 20;
	private int smallCloudPoint = 30;
	private int largeCloudPoint = 50;
	// Use this for initialization
	void Start () {
		ptController = GameObject.Find ("PointText").GetComponent<PointTextController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){
		if (tag == "SmallStarTag") {
			ptController.addPoint (smallStarPoint);
		} else if (tag == "LargeStarTag") {
			ptController.addPoint (largeStarPoint);
		} else if (tag == "SmallCloudTag") {
			ptController.addPoint (smallCloudPoint);
		} else if (tag == "LargeCloudTag") {
			ptController.addPoint (smallCloudPoint);
		}
	}
}
