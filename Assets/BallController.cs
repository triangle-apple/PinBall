using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //�{�[����������\���̂���z���̍ŏ��l
    private float visiblePosZ = -6.5f;

    // �Q�[���I�[�o�[��\������e�L�X�g
    private GameObject gameoverText;
    private GameObject scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // �V�[������GameOverText�I�u�W�F�N�g���擾
        this.gameoverText = GameObject.Find("GameOverText");

        // �V�[������ScoreText�I�u�W�F�N�g���擾
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    { 
        // �{�[������ʊO�ɏo���ꍇ
        if (this.transform.position.z < this.visiblePosZ)
        {
            // GameOverText�ɃQ�[���I�[�o�[��\��
            this.gameoverText.GetComponent<Text> ().text = "Game Over";
        }

        // ScoreText�I�u�W�F�N�g��\��
        this.scoreText.GetComponent<Text>().text = "Score : " + this.score;
    }

    // �Փˎ��ɌĂ΂��֐�
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
