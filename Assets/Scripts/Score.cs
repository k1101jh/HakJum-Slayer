using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
	public Text score;
	// Use this for initialization
	void Start () {
        score.text = "당신은 " + GameManager.instance.GetSlicedBooks().ToString("f0") + "개의 책을 잘랐습니다";
    }
}
