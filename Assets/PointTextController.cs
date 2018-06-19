using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointTextController : MonoBehaviour {

	private int point = 0;

	private Text pointText;
	// Use this for initialization
	void Start () {
		pointText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addPoint(int p){
		point += p;

		pointText.text = point.ToString();
	}
}
