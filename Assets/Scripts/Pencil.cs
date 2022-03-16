using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pencil : MonoBehaviour {
	
	public GameObject pencilTrailPrefab;  // 자르는 효과를 저장할 게임 오브젝트 생성
	public float minCuttingVelocity = .001f; // 자르기 위해 필요한 최소 속도

	Vector2 prevPosition; // 이전 위치 저장하는 변수 선언
	GameObject currentPencilTrail; // 현재의 자르는 효과를 저장할 게임 오브젝트 생성

	Camera cam;

	void Start ()
	{
		cam = Camera.main;
        currentPencilTrail = Instantiate(pencilTrailPrefab);
    }

	void Update ()
    {
		CheckSlice();
	}

    void SliceWithRay(Vector2 newP, Vector2 prevP, float distance)
	// 두 위치를 잇는 광선을 생성하여 광선에 닿는 물체를 제거
    {
        RaycastHit2D hit = Physics2D.Raycast(prevP, newP, distance);
        {
			if(hit.collider != null) {
				SliceableObject sliceableObject = hit.collider.GetComponent<SliceableObject>();

				if(sliceableObject != null) {
					sliceableObject.Slice();
				}
			}
        }
    }

    void CheckSlice ()
	{
		// 마우스의 위치를 worldPosition으로 변환해 받음
		Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
		currentPencilTrail.transform.position = newPosition;
		// 속도 계산
		float distance = (newPosition - prevPosition).magnitude;
		float velocity = distance / Time.deltaTime; 
		if (velocity > minCuttingVelocity) // 만약 속도가 최소 요구 속도보다 크면
		{
			// 이전 위치와 현재 위치를 잇는 광선을 생성하여 광선에 닿는 물체를 제거
            SliceWithRay(newPosition, prevPosition, distance);
		}

		prevPosition = newPosition; // 현재 위치를 이전의 위치 변수에 저장
	}
}
