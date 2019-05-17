using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField]
    BallScript ball;
    [SerializeField]
    Text scoreText;

    int leftScore, rightScore;
    // Start is called before the first frame update
    void Start()
    {
        leftScore = 0;
        rightScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void pointScored(PaddleScript.side paddleSide)
    {
        if (paddleSide == PaddleScript.side.left) {
            leftScore++;
        } else if (paddleSide == PaddleScript.side.right) {
            rightScore++;
        }

        scoreText.text = "\n" + leftScore.ToString() + " | " + rightScore.ToString();
        if (leftScore == 3) {
            GameOver(PaddleScript.side.left);
        } else if (rightScore == 3) {
            GameOver(PaddleScript.side.right);
        }
    }

    void GameOver(PaddleScript.side paddleSide)
    {
        ball.Reset();
        leftScore = 0;
        rightScore = 0;
        GlobalManagerScript.instance.winner = paddleSide;
        SceneManager.LoadScene("Menu Scene");
    }
}
