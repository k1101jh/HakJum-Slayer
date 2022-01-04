using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : SliceableObject {

	public GameObject bombSlicedPrefab; // 잘린 책 Prefab을 받아옴
	public float startForce = 14f; // 던지는 힘

	private AudioSource audioSource;
	Rigidbody2D rb; // Rigidbody2D인 요소 rb생성. Rigidbody2D는 물리를 적용할 때 필요

	void Start () {
		audioSource = GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody2D>(); // rb에 현재 물체의 Rigidbody2D 값을 준다
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse); // rb에 힘을 가한다(=던진다) (가하는 힘, 힘의 종류(모드)) (위쪽 방향으로 startForce만큼 힘을 가함, 순간적인 힘을 가함)
	}

    override public void Slice()
    {
		audioSource.Play();
        Destroy(gameObject); // 원래의 폭탄 제거
        GameManager.instance.LoseLife(); // 게임 오버
    }
}
