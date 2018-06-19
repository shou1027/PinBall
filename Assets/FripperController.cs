using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

	private HingeJoint myHingeJoint;

	private float defaultAngle = 20;

	private float flickAngle = -20;

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

		if (Input.touchSupported) {
			if (Input.touches [0].phase == TouchPhase.Began) {
				if (Input.touches [0].position.x > 540 && tag == "RightFripperTag") {
					SetAngle (this.flickAngle);
				} else if (Input.touches [0].position.x <= 540 && tag == "LeftFripperTag") {
					SetAngle (this.flickAngle);
				}				
			} else if (Input.touches [0].phase == TouchPhase.Ended) {
				if (Input.touches [0].rawPosition.x > 540 && tag == "RightFripperTag") {
					SetAngle (this.defaultAngle);
				} else if (Input.touches [0].rawPosition.x <= 540 && tag == "LeftFripperTag") {
					SetAngle (this.defaultAngle);
				}
			}

			if (Input.touches [1].phase == TouchPhase.Began) {
				if (Input.touches [1].position.x > 540 && tag == "RightFripperTag") {
					SetAngle (this.flickAngle);
				} else if (Input.touches [1].position.x <= 540 && tag == "LeftFripperTag") {
					SetAngle (this.flickAngle);
				}				
			} else if (Input.touches [1].phase == TouchPhase.Ended) {
				if (Input.touches [1].rawPosition.x > 540 && tag == "RightFripperTag") {
					SetAngle (this.defaultAngle);
				} else if (Input.touches [1].rawPosition.x <= 540 && tag == "LeftFripperTag") {
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
