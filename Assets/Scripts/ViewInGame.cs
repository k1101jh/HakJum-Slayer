using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewInGame : MonoBehaviour
{
    public static ViewInGame instance;

    public Text scoreLabel;
    public GameObject life;
    public Transform[] spawnPoints;
    
    private GameObject[] lifes;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        lifes = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            lifes[i] = Instantiate(life, spawnPoints[i]);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = "Score : " + GameManager.instance.GetSlicedBooks().ToString("f0");
    }
    
    public void DestroyHeart(int num)
    {
        Destroy(lifes[num]);
    }
}
