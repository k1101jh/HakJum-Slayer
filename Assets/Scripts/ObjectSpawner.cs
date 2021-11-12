using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	struct ObjectStruct {
        bool isBomb;
        float delay;
		int spawnPointNum;

		public ObjectStruct(bool isBomb, float delay, int spawnPointNum) {
            this.isBomb = isBomb;
            this.delay = delay;
			this.spawnPointNum = spawnPointNum;
		}
        public bool IsBomb()
        {
            return isBomb;
        }
        public float GetDelay() {
			return delay;
		}
		public int GetSP() {
			return spawnPointNum;
		}
	}

	public GameObject[] bookPrefab; // GameObject로 책을 받아옴
	public GameObject bombPrefab; // GameObject로 폭탄을 받아옴
	public Transform[] spawnPoints; // 오브젝트 생성 위치를 받아옴

    // 27 + 75 + 208
	private ObjectStruct[] gameobs = new ObjectStruct[310];

	// Use this for initialization
	void Start () { // 코드 처음 실행시
		int i = 0;
		int j = 0;

        for (j = 0; j < 7; j++)
            spawnPoints[j].rotation = Quaternion.Euler(0, 0, -9 + j * 3);

        //phase 1   max delay = 2f  num = 27    4 + 3 + 5 + 5 + 5 + 5
        gameobs [i++] = new ObjectStruct (false, 2f, 0);
		gameobs [i++] = new ObjectStruct (false, 1.5f, 3);
		gameobs [i++] = new ObjectStruct (false, 1.5f, 6);
		gameobs [i++] = new ObjectStruct (true, 1.5f, 3);

		gameobs [i++] = new ObjectStruct (false, 2f, 2);
		gameobs [i++] = new ObjectStruct (false, 0f, 3);
		gameobs [i++] = new ObjectStruct (false, 0f, 4);

		gameobs [i++] = new ObjectStruct (false, 1.5f, 1);
		gameobs [i++] = new ObjectStruct (false, .2f, 2);
		gameobs [i++] = new ObjectStruct (false, .2f, 3);
		gameobs [i++] = new ObjectStruct (false, .2f, 5);
		gameobs [i++] = new ObjectStruct (true, .7f, 4);

		gameobs [i++] = new ObjectStruct (false, 2f, 6);
		gameobs [i++] = new ObjectStruct (false, .2f, 4);
		gameobs [i++] = new ObjectStruct (false, .2f, 3);
		gameobs [i++] = new ObjectStruct (false, .2f, 5);
		gameobs [i++] = new ObjectStruct (true, .7f, 2);

		gameobs [i++] = new ObjectStruct (false, 2f, 1);
		j = i;
		while(i < j + 4) {
			gameobs [i++] = new ObjectStruct (false, 0f, i - j + 1);
		}
			
		gameobs [i++] = new ObjectStruct (false, 2f, 5);
		j = i;
		while(i < j + 4) {
			gameobs [i++] = new ObjectStruct (false, .1f, 5 - (i - j));
		}

        //phase 2   max delay = 1.5f    num = 75  3 + 5 + 7 + 7 + 5 + 3 + 6 + 3 + 5 + 5 + 4 + 7 + 4 + 3 + 5 + 3
        gameobs[i++] = new ObjectStruct (false, 2f, 0);
		gameobs [i++] = new ObjectStruct (false, 0f, 6);
        gameobs[i++] = new ObjectStruct(false, .2f, 3);

        gameobs [i++] = new ObjectStruct (false, 1.5f, 1);
		gameobs [i++] = new ObjectStruct (false, .2f, 2);
		gameobs [i++] = new ObjectStruct (false, .2f, 3);
		gameobs [i++] = new ObjectStruct (false, .2f, 5);
		gameobs [i++] = new ObjectStruct (true, .6f, 4);

        gameobs[i++] = new ObjectStruct(false, 1f, 0);
        j = i;
		while(i < j + 6) {
			gameobs [i++] = new ObjectStruct (false, 0f, i - j);
		}

		gameobs [i++] = new ObjectStruct (false, 1.3f, 6);
		j = i;
		while(i < j + 6) {
			gameobs [i++] = new ObjectStruct (false, .1f, 6 - (i - j));
		}
			

		gameobs [i++] = new ObjectStruct (false, 1.5f, 4);
        gameobs[i++] = new ObjectStruct(false, 0f, 2);
        gameobs[i++] = new ObjectStruct(false, .2f, 3);
        gameobs[i++] = new ObjectStruct(true, .6f, 4);
        gameobs[i++] = new ObjectStruct(true, 0f, 2);

        gameobs [i++] = new ObjectStruct (false, 1.5f, 6);
		gameobs [i++] = new ObjectStruct (false, .2f, 3);
		gameobs [i++] = new ObjectStruct (false, .2f, 0);

        gameobs [i++] = new ObjectStruct (false, 1.5f, 5);
		gameobs [i++] = new ObjectStruct (false, .2f, 4);
        gameobs[i++] = new ObjectStruct(true, .6f, 1);
        gameobs [i++] = new ObjectStruct (false, .2f, 3);
		gameobs [i++] = new ObjectStruct (false, .2f, 2);
		gameobs [i++] = new ObjectStruct (true, .5f, 1);

		gameobs [i++] = new ObjectStruct (false, 1.5f, 4);
		gameobs [i++] = new ObjectStruct (false, 0f, 3);
		gameobs [i++] = new ObjectStruct (false, 0f, 2);

		gameobs [i++] = new ObjectStruct (false, 1f, 5);
		j = i;
		while(i < j + 4) {
			gameobs [i++] = new ObjectStruct (false, .1f, 5 - (i - j));
		}

		gameobs [i++] = new ObjectStruct (false, .5f, 1);
		j = i;
		while(i < j + 4) {
			gameobs [i++] = new ObjectStruct (false, .1f, (i - j) + 1);
		}

        gameobs[i++] = new ObjectStruct(false, 1f, 1);
        gameobs[i++] = new ObjectStruct(false, .2f, 2);
        gameobs[i++] = new ObjectStruct(false, .2f, 3);
        gameobs[i++] = new ObjectStruct(true, .3f, 4);

        gameobs[i++] = new ObjectStruct(false, 1f, 0);
        j = i;
        while (i < j + 6)
        {
            gameobs[i++] = new ObjectStruct(false, .1f, i - j);
        }

        gameobs[i++] = new ObjectStruct(false, 1f, 2);
        j = i;
        while (i < j + 3)
        {
            gameobs[i++] = new ObjectStruct(false, .1f, i - j + 2);
        }

        gameobs[i++] = new ObjectStruct(false, 1f, 4);
        gameobs[i++] = new ObjectStruct(false, .3f, 3);
        gameobs[i++] = new ObjectStruct(false, .3f, 2);

        gameobs[i++] = new ObjectStruct(true, 1f, 0);
        gameobs[i++] = new ObjectStruct(false, 0f, 1);
        gameobs[i++] = new ObjectStruct(true, 0f, 3);
        gameobs[i++] = new ObjectStruct(false, 0f, 5);
        gameobs[i++] = new ObjectStruct(true, 0f, 6);

        gameobs[i++] = new ObjectStruct(false, 1f, 0);
        gameobs[i++] = new ObjectStruct(false, .3f, 3);
        gameobs[i++] = new ObjectStruct(false, .3f, 6);

        //phase 3   max delay = 1f  num = 208   2 + 19 + 7 + 7 + 7 + 7 + 28 + 6 + 28 + 1 + 20 + 7 + 7 + 13 + 13 + 13 + 13 + 10
        gameobs [i++] = new ObjectStruct (false, .8f, 6);
		gameobs [i++] = new ObjectStruct (false, .2f, 0);

        gameobs[i++] = new ObjectStruct(false, .5f, 0);
        gameobs[i++] = new ObjectStruct(true, .5f, 1);
        gameobs[i++] = new ObjectStruct(false, .5f, 2);
        gameobs[i++] = new ObjectStruct(true, .5f, 3);
        gameobs[i++] = new ObjectStruct(false, .5f, 4);
        gameobs[i++] = new ObjectStruct(true, .5f, 5);
        gameobs[i++] = new ObjectStruct(false, .5f, 6);
        gameobs[i++] = new ObjectStruct(true, .5f, 5);
        gameobs[i++] = new ObjectStruct(false, .5f, 4);
        gameobs[i++] = new ObjectStruct(true, .5f, 3);
        gameobs[i++] = new ObjectStruct(false, .5f, 2);
        gameobs[i++] = new ObjectStruct(true, .5f, 1);
        gameobs[i++] = new ObjectStruct(false, .5f, 0);
        gameobs[i++] = new ObjectStruct(true, .5f, 1);
        gameobs[i++] = new ObjectStruct(false, .5f, 2);
        gameobs[i++] = new ObjectStruct(true, .5f, 3);
        gameobs[i++] = new ObjectStruct(false, .5f, 4);
        gameobs[i++] = new ObjectStruct(true, .5f, 5);
        gameobs[i++] = new ObjectStruct(false, .5f, 6);

        gameobs[i++] = new ObjectStruct(false, .6f, 0);
        gameobs[i++] = new ObjectStruct(false, 0f, 1);
        gameobs[i++] = new ObjectStruct(false, 0f, 2);
        gameobs[i++] = new ObjectStruct(false, 0f, 3);
        gameobs[i++] = new ObjectStruct(false, 0f, 4);
        gameobs[i++] = new ObjectStruct(false, 0f, 5);
        gameobs[i++] = new ObjectStruct(false, 0f, 6);

        gameobs[i++] = new ObjectStruct(true, 1f, 0);
        gameobs[i++] = new ObjectStruct(true, 0f, 1);
        gameobs[i++] = new ObjectStruct(true, 0f, 2);
        gameobs[i++] = new ObjectStruct(true, 0f, 3);
        gameobs[i++] = new ObjectStruct(true, 0f, 4);
        gameobs[i++] = new ObjectStruct(true, 0f, 5);
        gameobs[i++] = new ObjectStruct(true, 0f, 6);

        gameobs[i++] = new ObjectStruct(false, 1f, 0);
        gameobs[i++] = new ObjectStruct(false, 0f, 1);
        gameobs[i++] = new ObjectStruct(false, 0f, 2);
        gameobs[i++] = new ObjectStruct(false, 0f, 3);
        gameobs[i++] = new ObjectStruct(false, 0f, 4);
        gameobs[i++] = new ObjectStruct(false, 0f, 5);
        gameobs[i++] = new ObjectStruct(false, 0f, 6);

        gameobs[i++] = new ObjectStruct(true, 1f, 0);
        gameobs[i++] = new ObjectStruct(true, 0f, 1);
        gameobs[i++] = new ObjectStruct(true, 0f, 2);
        gameobs[i++] = new ObjectStruct(true, 0f, 3);
        gameobs[i++] = new ObjectStruct(true, 0f, 4);
        gameobs[i++] = new ObjectStruct(true, 0f, 5);
        gameobs[i++] = new ObjectStruct(true, 0f, 6);

        gameobs[i++] = new ObjectStruct(false, 1f, 0);
        gameobs[i++] = new ObjectStruct(false, .4f, 1);
        gameobs[i++] = new ObjectStruct(false, .4f, 2);
        gameobs[i++] = new ObjectStruct(false, .4f, 3);
        gameobs[i++] = new ObjectStruct(false, .4f, 4);
        gameobs[i++] = new ObjectStruct(false, 0f, 0);
        gameobs[i++] = new ObjectStruct(false, .4f, 5);
        gameobs[i++] = new ObjectStruct(false, 0f, 1);
        gameobs[i++] = new ObjectStruct(false, .4f, 6);
        gameobs[i++] = new ObjectStruct(false, 0f, 2);
        gameobs[i++] = new ObjectStruct(false, .4f, 3);
        gameobs[i++] = new ObjectStruct(false, .4f, 4);
        gameobs[i++] = new ObjectStruct(false, 0f, 0);
        gameobs[i++] = new ObjectStruct(false, .4f, 5);
        gameobs[i++] = new ObjectStruct(false, 0f, 1);
        gameobs[i++] = new ObjectStruct(false, .4f, 6);
        gameobs[i++] = new ObjectStruct(false, 0f, 2);
        gameobs[i++] = new ObjectStruct(false, .4f, 3);
        gameobs[i++] = new ObjectStruct(false, .4f, 4);
        gameobs[i++] = new ObjectStruct(false, 0f, 0);
        gameobs[i++] = new ObjectStruct(false, .4f, 5);
        gameobs[i++] = new ObjectStruct(false, 0f, 1);
        gameobs[i++] = new ObjectStruct(false, .4f, 6);
        gameobs[i++] = new ObjectStruct(false, 0f, 2);
        gameobs[i++] = new ObjectStruct(false, .4f, 3);
        gameobs[i++] = new ObjectStruct(false, .4f, 4);
        gameobs[i++] = new ObjectStruct(false, .4f, 5);
        gameobs[i++] = new ObjectStruct(false, .4f, 6);

        gameobs[i++] = new ObjectStruct(true, .8f, 0);
        gameobs[i++] = new ObjectStruct(true, 0f, 6);
        gameobs[i++] = new ObjectStruct(true, .2f, 1);
        gameobs[i++] = new ObjectStruct(true, 0f, 5);
        gameobs[i++] = new ObjectStruct(true, .2f, 2);
        gameobs[i++] = new ObjectStruct(true, 0f, 4);
        gameobs[i++] = new ObjectStruct(true, .2f, 3);

        gameobs[i++] = new ObjectStruct(false, .8f, 6);
        gameobs[i++] = new ObjectStruct(false, .4f, 5);
        gameobs[i++] = new ObjectStruct(false, .4f, 4);
        gameobs[i++] = new ObjectStruct(false, .4f, 3);
        gameobs[i++] = new ObjectStruct(false, .4f, 2);
        gameobs[i++] = new ObjectStruct(false, 0f, 6);
        gameobs[i++] = new ObjectStruct(false, .4f, 1);
        gameobs[i++] = new ObjectStruct(false, 0f, 5);
        gameobs[i++] = new ObjectStruct(false, .4f, 0);
        gameobs[i++] = new ObjectStruct(false, 0f, 4);
        gameobs[i++] = new ObjectStruct(false, .4f, 3);
        gameobs[i++] = new ObjectStruct(false, .4f, 2);
        gameobs[i++] = new ObjectStruct(false, 0f, 6);
        gameobs[i++] = new ObjectStruct(false, .4f, 1);
        gameobs[i++] = new ObjectStruct(false, 0f, 5);
        gameobs[i++] = new ObjectStruct(false, .4f, 0);
        gameobs[i++] = new ObjectStruct(false, 0f, 4);
        gameobs[i++] = new ObjectStruct(false, .4f, 3);
        gameobs[i++] = new ObjectStruct(false, .4f, 2);
        gameobs[i++] = new ObjectStruct(false, 0f, 6);
        gameobs[i++] = new ObjectStruct(false, .4f, 1);
        gameobs[i++] = new ObjectStruct(false, 0f, 5);
        gameobs[i++] = new ObjectStruct(false, .4f, 0);
        gameobs[i++] = new ObjectStruct(false, 0f, 4);
        gameobs[i++] = new ObjectStruct(false, .4f, 3);
        gameobs[i++] = new ObjectStruct(false, .4f, 2);
        gameobs[i++] = new ObjectStruct(false, .4f, 1);
        gameobs[i++] = new ObjectStruct(false, .4f, 0);

        gameobs[i++] = new ObjectStruct(true, .2f, 6);

        gameobs[i++] = new ObjectStruct(false, 1f, 0);
        gameobs[i++] = new ObjectStruct(false, 0f, 6);
        gameobs[i++] = new ObjectStruct(false, .4f, 1);
        gameobs[i++] = new ObjectStruct(false, 0f, 5);
        gameobs[i++] = new ObjectStruct(false, .4f, 2);
        gameobs[i++] = new ObjectStruct(false, 0f, 4);
        gameobs[i++] = new ObjectStruct(false, .4f, 3);
        gameobs[i++] = new ObjectStruct(false, .4f, 4);
        gameobs[i++] = new ObjectStruct(false, 0f, 2);
        gameobs[i++] = new ObjectStruct(false, .4f, 5);
        gameobs[i++] = new ObjectStruct(false, 0f, 1);
        gameobs[i++] = new ObjectStruct(false, .4f, 6);
        gameobs[i++] = new ObjectStruct(false, 0f, 0);
        gameobs[i++] = new ObjectStruct(false, .5f, 0);
        gameobs[i++] = new ObjectStruct(false, 0f, 6);
        gameobs[i++] = new ObjectStruct(false, .4f, 1);
        gameobs[i++] = new ObjectStruct(false, 0f, 5);
        gameobs[i++] = new ObjectStruct(false, .4f, 2);
        gameobs[i++] = new ObjectStruct(false, 0f, 4);
        gameobs[i++] = new ObjectStruct(false, .4f, 3);

        gameobs[i++] = new ObjectStruct(false, .4f, 4);
        gameobs[i++] = new ObjectStruct(false, 0f, 2);
        gameobs[i++] = new ObjectStruct(false, .4f, 5);
        gameobs[i++] = new ObjectStruct(false, 0f, 1);
        gameobs[i++] = new ObjectStruct(false, .4f, 6);
        gameobs[i++] = new ObjectStruct(false, 0f, 0);

        gameobs[i++] = new ObjectStruct(true, .6f, 6);
        gameobs[i++] = new ObjectStruct(true, 0f, 0);
        gameobs[i++] = new ObjectStruct(true, .2f, 5);
        gameobs[i++] = new ObjectStruct(true, 0f, 1);
        gameobs[i++] = new ObjectStruct(true, .2f, 4);
        gameobs[i++] = new ObjectStruct(true, 0f, 2);
        gameobs[i++] = new ObjectStruct(true, .2f, 3);

        gameobs[i++] = new ObjectStruct(false, .7f, 6);
        gameobs[i++] = new ObjectStruct(false, .2f, 5);
        gameobs[i++] = new ObjectStruct(false, .2f, 4);
        gameobs[i++] = new ObjectStruct(true, 0f, 0);
        gameobs[i++] = new ObjectStruct(false, .2f, 3);
        gameobs[i++] = new ObjectStruct(true, 0f, 1);
        gameobs[i++] = new ObjectStruct(false, .2f, 2);
        gameobs[i++] = new ObjectStruct(false, .2f, 1);
        gameobs[i++] = new ObjectStruct(true, 0f, 3);
        gameobs[i++] = new ObjectStruct(false, .2f, 0);
        gameobs[i++] = new ObjectStruct(true, 0f, 4);
        gameobs[i++] = new ObjectStruct(true, .2f, 5);
        gameobs[i++] = new ObjectStruct(true, .2f, 6);

        gameobs[i++] = new ObjectStruct(false, .7f, 0);
        gameobs[i++] = new ObjectStruct(false, .2f, 1);
        gameobs[i++] = new ObjectStruct(false, .2f, 2);
        gameobs[i++] = new ObjectStruct(true, 0f, 6);
        gameobs[i++] = new ObjectStruct(false, .2f, 3);
        gameobs[i++] = new ObjectStruct(true, 0f, 5);
        gameobs[i++] = new ObjectStruct(false, .2f, 4);
        gameobs[i++] = new ObjectStruct(false, .2f, 5);
        gameobs[i++] = new ObjectStruct(true, 0f, 3);
        gameobs[i++] = new ObjectStruct(false, .2f, 6);
        gameobs[i++] = new ObjectStruct(true, 0f, 2);
        gameobs[i++] = new ObjectStruct(true, .2f, 1);
        gameobs[i++] = new ObjectStruct(true, .2f, 0);

        gameobs[i++] = new ObjectStruct(true, .7f, 0);
        gameobs[i++] = new ObjectStruct(true, .2f, 1);
        gameobs[i++] = new ObjectStruct(true, .2f, 2);
        gameobs[i++] = new ObjectStruct(false, 0f, 6);
        gameobs[i++] = new ObjectStruct(true, .2f, 3);
        gameobs[i++] = new ObjectStruct(false, 0f, 5);
        gameobs[i++] = new ObjectStruct(true, .2f, 4);
        gameobs[i++] = new ObjectStruct(true, .2f, 5);
        gameobs[i++] = new ObjectStruct(false, 0f, 3);
        gameobs[i++] = new ObjectStruct(true, .2f, 6);
        gameobs[i++] = new ObjectStruct(false, 0f, 2);
        gameobs[i++] = new ObjectStruct(false, .2f, 1);
        gameobs[i++] = new ObjectStruct(false, .2f, 0);

        gameobs[i++] = new ObjectStruct(true, .7f, 6);
        gameobs[i++] = new ObjectStruct(true, .2f, 5);
        gameobs[i++] = new ObjectStruct(true, .2f, 4);
        gameobs[i++] = new ObjectStruct(false, 0f, 0);
        gameobs[i++] = new ObjectStruct(true, .2f, 3);
        gameobs[i++] = new ObjectStruct(false, 0f, 1);
        gameobs[i++] = new ObjectStruct(true, .2f, 2);
        gameobs[i++] = new ObjectStruct(true, .2f, 1);
        gameobs[i++] = new ObjectStruct(false, 0f, 3);
        gameobs[i++] = new ObjectStruct(true, .2f, 0);
        gameobs[i++] = new ObjectStruct(false, 0f, 4);
        gameobs[i++] = new ObjectStruct(false, .2f, 5);
        gameobs[i++] = new ObjectStruct(false, .2f, 6);

        gameobs[i++] = new ObjectStruct(true, 1f, 2);
        gameobs[i++] = new ObjectStruct(true, 0f, 4);
        gameobs[i++] = new ObjectStruct(true, .15f, 1);
        gameobs[i++] = new ObjectStruct(true, 0f, 5);
        gameobs[i++] = new ObjectStruct(true, .2f, 3);
        gameobs[i++] = new ObjectStruct(true, 0f, 1);
        gameobs[i++] = new ObjectStruct(true, 0f, 5);
        gameobs[i++] = new ObjectStruct(true, .2f, 2);
        gameobs[i++] = new ObjectStruct(true, 0f, 4);
        gameobs[i++] = new ObjectStruct(true, .2f, 3);


        StartCoroutine(Spawn()); // SpawnBooks()를 주기적으로 실행
	}

	IEnumerator Spawn () {
		int i = 0;
        int booknum = 0;
        GameObject spawnedObject;

		while (true) {
            if (gameobs[i].IsBomb())
            {
                spawnedObject = Instantiate(bombPrefab, spawnPoints[gameobs[i].GetSP()].position, spawnPoints[gameobs[i].GetSP()].rotation);
                spawnedObject.gameObject.tag = "Bomb";
            }
            else
            {
                spawnedObject = Instantiate(bookPrefab[booknum % 8], spawnPoints[gameobs[i].GetSP()].position, spawnPoints[gameobs[i].GetSP()].rotation);
                spawnedObject.gameObject.tag = "Book";
                booknum++;
            }

			Destroy (spawnedObject, 5f);

			i++;

			if(i >= gameobs.Length)
				break;
			yield return new WaitForSeconds(gameobs[i].GetDelay()); // 딜레이를 리턴

			/*
			float delay = Random.Range (minDelay, maxDelay); // 생성 딜레이를 최소 딜레이 ~ 최대 딜레이 사이의 랜덤한 값으로 설정
            yield return new WaitForSeconds(delay); // 딜레이를 리턴

            int spawnIndex = Random.Range (0, spawnPoints.Length); // 스폰 포인트 (현재는 5개 존재) 중 하나를 고름
			int ObjectIndex = Random.Range (0, bookPrefab.Length); // 스폰할 책 (현재는 1개 존재) 중 하나 또는 폭탄을 고름
            int spawnbomb = Random.Range(0, 10);
			Transform spawnPoint = spawnPoints[spawnIndex]; // 고른 스폰 포인트의 값을 받아옴

            if (spawnbomb >= 8)
            {
                GameObject spawnedBomb = Instantiate(bombPrefab, spawnPoint.position, spawnPoint.rotation); // Game Object 폭탄을 생성. (폭탄 prefab, 스폰할 위치, 스폰시 회전정도)
                Destroy(spawnedBomb, 5f); // 5초 후 스폰했던 폭탄을 제거
            } else {
                GameObject spawnedBook = Instantiate(bookPrefab[ObjectIndex], spawnPoint.position, spawnPoint.rotation); // Game Object 책을 생성. (책의 종류, 스폰할 위치, 스폰시 회전정도)
                Destroy(spawnedBook, 5f); // 5초 후 스폰했던 책을 제거
            }*/
			
        }
	}
}
