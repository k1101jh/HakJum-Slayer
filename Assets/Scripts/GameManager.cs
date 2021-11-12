using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance; // 이 스크립트를 다른 스크립트에서 참조하기 쉽게 하기 위한 변수

    public static float fullTime = 100f;

	public Canvas menuCanvas;
	public Canvas inGameCanvas;
	public Canvas gameOverCanvas;

    private int slicedBooks; // 자른 책의 수를 저장하는 변수
    private float time;
    private int life;

    private int collectedCoins;

    public void CollectedCoin()
    {
        collectedCoins++;
    }

    void Awake() {
		instance = this; // instance가 이 스크립트(객체)를 가리키도록 설정
	}

	// Use this for initialization
	void Start () {
        slicedBooks = 0;
        life = 3;
        time = fullTime;
	}

	// Update is called once per frame
	void Update () {
        if (time != 0)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = 0;
				SceneManager.LoadScene ("WinnerScene");;
            }
        }
    }

    public void SlicedBooks()
    {
        slicedBooks += 1; // 책을 자른 횟수 증가
    }

    public void LoseLife()
    {
        life -= 1;
        ViewInGame.instance.DestroyHeart(life);


        if(life <= 0)
        {
			SceneManager.LoadScene ("GameOverScene");
        }
    }

    public int GetSlicedBooks()
    {
        return slicedBooks;
    }

    public float GetTime()
    {
        return time;
    }

    public int GetLife()
    {
        return life;
    }
}
