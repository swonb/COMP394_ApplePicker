using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text scoreTxt;

    private void Start()
    {
        GameObject scoreGO = GameObject.Find("Score");
        scoreTxt = scoreGO.GetComponent<Text>();
        scoreTxt.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        //Debug.Log("Mouse Position = " + mousePos);

        mousePos.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        if (go.tag == "Apple")
        {
            Destroy(go);
            // TODO: scoring
        }

        int score = int.Parse(scoreTxt.text.Substring(6));
        score += 10;
        Debug.Log(score);
        scoreTxt.text = "Score: " + score.ToString();

        // New Oct.09
        // Track the highscore
        if (score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}
