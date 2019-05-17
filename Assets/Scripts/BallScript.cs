using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField]
    float forceValue = 4.5f;
    [SerializeField]
    float torqueValue = 50.0f;

    Rigidbody2D ballRigidbody;
    Transform ballTransform;
    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        ballTransform = transform;
        ballRigidbody.isKinematic = true;
        Reset();
    }

    void Move()
    {
        ballRigidbody.isKinematic = false;
        ballRigidbody.AddForce(new Vector2(forceValue * 50, 100));
        ballRigidbody.AddTorque(torqueValue);
    }

    void Update()
    {
        print(ballRigidbody.isKinematic);
        if (ballRigidbody.isKinematic) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                Move();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //ballTransform.Rotate(0, 0, rotation);
    }

    public void Reset()
    {
        ballTransform.position = new Vector2(0, 0);
        ballRigidbody.velocity = new Vector2(0, 0);
        ballRigidbody.angularVelocity = 0.0f;
        ballRigidbody.isKinematic = true;
        timer = 3.0f;
    }
}
