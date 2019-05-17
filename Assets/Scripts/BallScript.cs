using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField]
    float forceValue = 4.5f;
    [SerializeField]
    float rotation = 10.0f;

    Rigidbody2D ballRigidbody;
    Transform ballTransform;
    bool inMotion = false;
    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        ballTransform = transform;
        Reset();
    }

    void Move()
    {
        ballRigidbody.AddForce(new Vector2(forceValue * 50, 100));
        inMotion = true;
    }

    void Update()
    {
        if (!inMotion) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                Move();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ballTransform.Rotate(0, 0, rotation);
    }

    public void Reset()
    {
        inMotion = false;
        ballTransform.position = new Vector2(0, 0);
        ballRigidbody.velocity = new Vector2(0, 0);
        timer = 3.0f;
    }
}
