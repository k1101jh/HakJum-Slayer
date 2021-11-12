using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencil : MonoBehaviour {
	
	public GameObject pencilTrailPrefab;  // 자르는 효과를 저장할 게임 오브젝트 생성
    public AudioSource audioSource;
	public float minCuttingVelocity = .001f; // 자르기 위해 필요한 최소 속도

	//bool isCutting = true; // 현재 자르는 중인지에 대한 변수

	Vector2 previousPosition; // 이전 위치 저장하는 변수 선언

	GameObject currentPencilTrail; // 현재의 자르는 효과를 저장할 게임 오브젝트 생성

	Rigidbody2D rb;
	Camera cam;

	void Start ()
	{
		cam = Camera.main;
        audioSource = GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody2D>(); // rb에 현재 물체의 Rigidbody2D 값을 준다
        currentPencilTrail = Instantiate(pencilTrailPrefab, transform);
    }

	void Update ()
    { // 매 프레임마다 호출
		UpdateCut(); // UpdateCut 함수 호출
	}

    void GenerateRay(Vector2 newP, Vector2 prevP)
    {
        RaycastHit hit;
        if (Physics.Raycast(prevP, newP - prevP, out hit, (newP - prevP).magnitude))
        {
            if (hit.transform.parent.gameObject.tag == "Book")
            {
                hit.transform.parent.gameObject.GetComponent<Book>().Slice();
            }
            else if(hit.transform.parent.gameObject.tag == "Bomb")
            {
                audioSource.Play();
                hit.transform.parent.gameObject.GetComponent<Bomb>().Slice();
            }
        }

    }

    void UpdateCut ()
	{
		Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition); // 마우스의 위치를 worldPosition으로 변환해 받음
		rb.position = newPosition; // rb의 위치를 마우스 위치로 변환

		float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime; // 속도를 현재 마우스 위치와 이전 마우스 위치 사이의 거리를 구한 후 프레임을 렌더링하는데 걸리는 시간을 곱함
		if (velocity > minCuttingVelocity) // 만약 속도가 최소 요구 속도보다 크면
		{
			//circleCollider.enabled = true; // 충돌 적용
            GenerateRay(newPosition ,previousPosition);
		}

		previousPosition = newPosition; // 현재 위치를 이전의 위치 변수에 저장
	}
}
