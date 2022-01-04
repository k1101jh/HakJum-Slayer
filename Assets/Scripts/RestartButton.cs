using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public GameObject slicedPrefab; // 잘린 책 Prefab을 받아옴

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Pencil")
        { // 만약 충돌한 물체의 태그가 "Pencil"이면
            GameObject restartButton = Instantiate(slicedPrefab, transform.position, transform.rotation); // 게임 오브젝트 slicedBook 생성. BookSlicedPrefab을 대입, transform의 위치 대입
            Destroy(gameObject); // 원래의 책 제거
            Destroy(restartButton, 2f); // 3초 후 slicedBook 제거
            SceneManager.LoadScene("CPU Game start Scene"); // CPU Game 씬 불러옴
        }
    }
}
