using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

	private HingeJoint myHingeJoint;

	private float defaultAngle = 20;

	private float flickAngle = -20;

	private int rightId = 0;
	private int leftId = 0;

	// Use this for initialization
	void Start () {
		this.myHingeJoint = GetComponent<HingeJoint> ();

		SetAngle (this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag"){
			SetAngle(this.flickAngle);
		}

		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}

		if(Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag"){
			SetAngle(this.defaultAngle);
		}

		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}

		for(int i = 0;i < Input.touchCount;i++){

			Debug.Log (Input.touches [i].fingerId);

			if (Input.touches [i].phase == TouchPhase.Began) {
				if (Input.touches [i].position.x > Screen.width / 2 && tag == "RightFripperTag") {
					SetAngle (this.flickAngle);
					rightId = Input.touches [i].fingerId;
				} else if (Input.touches [i].position.x <= Screen.width / 2 && tag == "LeftFripperTag") {
					SetAngle (this.flickAngle);
					leftId = Input.touches [i].fingerId;
				}				
			} else if (Input.touches [i].phase == TouchPhase.Ended) {
				if (Input.touches[i].fingerId == rightId && tag == "RightFripperTag") {
					SetAngle (this.defaultAngle);
				} else if (Input.touches[i].fingerId == leftId && tag == "LeftFripperTag") {
					SetAngle (this.defaultAngle);
				}
			}
		}
	}

	public void SetAngle(float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}
