using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public enum side {left, right, none};
    enum direction {up = 1, down = -1, none = 0};
    [SerializeField]
    side paddleSide = side.none;
    [SerializeField]
    static float paddleSpeed = 0.2f;
    [SerializeField]
    float directionImpact = 5.0f;

    Transform paddleTransform;
    direction paddleDirection = direction.none;
    float previousPositionY;
    // Start is called before the first frame update
    void Start()
    {
        paddleTransform = transform;
        previousPositionY = paddleTransform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (paddleSide == side.left)  {
            if (Input.GetKey(KeyCode.W)) {
                moveUp();
            } else if (Input.GetKey(KeyCode.S)) {
                moveDown();
            }
        } else if (paddleSide == side.right) {
            if (Input.GetKey(KeyCode.UpArrow)) {
                moveUp();
            } else if (Input.GetKey(KeyCode.DownArrow)) {
                moveDown();
            }
        }

        if (previousPositionY < paddleTransform.position.y) {
            paddleDirection = direction.up;
        } else if (previousPositionY > paddleTransform.position.y) {
            paddleDirection = direction.down;
        } else {
            paddleDirection = direction.none;
        }
    }

    void moveUp()
    {
        paddleTransform.position = new Vector2(paddleTransform.position.x, paddleTransform.position.y + paddleSpeed);
    }

    void moveDown()
    {
        paddleTransform.position = new Vector2(paddleTransform.position.x, paddleTransform.position.y - paddleSpeed);
    }

    void LateUpdate()
    {
        previousPositionY = paddleTransform.position.y;
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("Top")) {
            moveDown();
        } else if (other.gameObject.name.Contains("Bottom")) {
            moveUp();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("Ball")) {
            float adjust = directionImpact * (int)paddleDirection;
            other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x, other.rigidbody.velocity.y + adjust);
        }
    }

    public static float getSpeed()
    {
        return paddleSpeed;
    }
}
