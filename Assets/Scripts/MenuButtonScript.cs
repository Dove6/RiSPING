using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonScript : MonoBehaviour
{
    [SerializeField]
    Text winnerText;

    // Start is called before the first frame update
    void Start()
    {
        if (GlobalManagerScript.instance.winner != PaddleScript.side.none) {
            winnerText.text = "Zwycięzca: " + (GlobalManagerScript.instance.winner == PaddleScript.side.left ? "lewy" : "prawy");
        } else {
            winnerText.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) {
            SceneManager.LoadScene("Game Scene");
        }
    }
}
