using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBar : MonoBehaviour {
	
	public static TimeBar instance;

	void Awake() {
		instance = this; // instance가 이 스크립트(객체)를 가리키도록 설정
	}
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(0, 5, 0);
		transform.localScale = new Vector3 ((GameManager.instance.GetTime() / GameManager.fullTime) * 0.6f, 1, 1);
	}
}
