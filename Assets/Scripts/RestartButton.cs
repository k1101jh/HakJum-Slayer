using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : SliceableObject
{
    public GameObject slicedPrefab; // 잘린 책 Prefab을 받아옴

	override public void Slice() {
		GameObject slicedButton = Instantiate(slicedPrefab, transform.position, transform.rotation); // 게임 오브젝트 slicedButton 생성
		Destroy (gameObject); // 원래의 책 제거
		Destroy(slicedButton, 2f); // 3초 후 slicedButton 제거
		SceneManager.LoadScene ("CPU Game start Scene"); // CPU Game 씬 불러옴
	}
}
