using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class ScoreManager : MonoBehaviour
{
    public Sprite[] scoreNumbers =  new Sprite[10];
    public Image[] scoreImages = new Image[3];

    private int scoreCount = 0;
    public int rightNumber = 0;
    private int  centerNumber = 0 , leftNumber = 0;



    public void updateScore()
    {
        if(scoreCount == 999) { return; }
           
        scoreCount++;
        updateUIScore();
    }

    private void updateUIScore()
    {
        rightNumber++;

        if (rightNumber > 9)
        {
            centerNumber++;

            if (centerNumber > 9)
            {

                leftNumber++;
                scoreImages[2].sprite = scoreNumbers[leftNumber];
                centerNumber = 0;
            }

            scoreImages[1].sprite = scoreNumbers[centerNumber];

            rightNumber = 0;
        }

       

        scoreImages[0].sprite = scoreNumbers[rightNumber];

    }


    public void resetScore()
    {
        scoreCount = 0;
        rightNumber = 0;
        centerNumber = 0;
        leftNumber = 0;


        for (int i = 0; i < 3; i++)
        {
            scoreImages[i].sprite = scoreNumbers[0];
        }
    }

}
