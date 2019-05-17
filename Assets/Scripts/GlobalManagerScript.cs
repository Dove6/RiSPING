using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManagerScript : MonoBehaviour
{
    public static GlobalManagerScript instance = null;
    public PaddleScript.side winner = PaddleScript.side.none;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
