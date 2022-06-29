using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;

    // ゲームオーバーを表示するテキスト
    private GameObject gameoverText;
    private GameObject scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        // シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    { 
        // ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            // GameOverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text> ().text = "Game Over";
        }

        // ScoreTextオブジェクトを表示
        this.scoreText.GetComponent<Text>().text = "Score : " + this.score;
    }

    // 衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        string otherT = other.gameObject.tag;

        if (otherT == "LargeStarTag")
        {
            this.score += 5;
        }
        else if (otherT == "SmallStarTag")
        {
            this.score += 3;
        }
        else if (otherT == "LargeCloudTag")
        {
            this.score += 4;
        }
        else if (otherT == "SmallCloudTag")
        {
            this.score += 2;
        }
    }
}
