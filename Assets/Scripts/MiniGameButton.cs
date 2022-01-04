using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameButton : SliceableObject {

	public GameObject BookSlicedPrefab; // 잘린 책 Prefab을 받아옴

	override public void Slice() {
		GameObject slicedBook = Instantiate(BookSlicedPrefab, transform.position, transform.rotation); // 게임 오브젝트 slicedBook 생성. BookSlicedPrefab을 대입, transform의 위치 대입
		Destroy (gameObject); // 원래의 책 제거
		Destroy(slicedBook, 3f); // 3초 후 slicedBook 제거
		SceneManager.LoadScene ("Scream"); // CPU Game 씬 불러옴
	}
}
