using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    int score;
    public static GameManager inst;

    public Text scoreText;

    public void IncrementScore() {

        score++;
        scoreText.text = "SCORE: " + score;
    }

    private void Awake()
    {
        inst = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
