using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalWallScript : MonoBehaviour
{
    [SerializeField]
    BallScript ball;
    [SerializeField]
    PaddleScript.side scorer = PaddleScript.side.none;
    [SerializeField]
    GameManagerScript GameMan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        ball.Reset();
        GameMan.pointScored(scorer);
    }
}
