using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : SliceableObject {

    Rigidbody2D rb; // Rigidbody2D인 요소 rb생성. Rigidbody2D는 물리를 적용할 때 필요

    public GameObject BookSlicedPrefab; // 잘린 책 Prefab을 받아옴
	public float startForce = 14f; // 처음에 책을 던지는 힘
    public float splitForce = 40f;

	void Start () {
		rb = GetComponent<Rigidbody2D>(); // rb에 현재 물체의 Rigidbody2D 값을 준다
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse); // rb에 힘을 가한다(=던진다) (가하는 힘, 힘의 종류(모드)) (위쪽 방향으로 startForce만큼 힘을 가함, 순간적인 힘을 가함)
	}

    override public void Slice()
    {
        GameObject slicedBook = Instantiate(BookSlicedPrefab, transform.position, transform.rotation); // 게임 오브젝트 slicedBook 생성. BookSlicedPrefab을 대입, transform의 위치 대입
        Vector3 torque = transform.right * Random.Range(-splitForce, splitForce) + 
                         transform.up * Random.Range(-splitForce, splitForce);
        slicedBook.GetComponent<Rigidbody>().AddTorque(torque);
        Destroy(gameObject);
        GameManager.instance.SlicedBooks(); // 책을 자른 횟수 증가
        Destroy(slicedBook, 3f); // 3초 후 slicedBook 제거
    }
}
