using UnityEngine;
using UnityEngine.UI;

public class PlayerLifesManager : MonoBehaviour
{

    [Header("Images")]
    public Image[] lifes = new Image[3];
    private int imageIndex = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void removeLife()
    {
        lifes[imageIndex].enabled = false;
        imageIndex--;
    }

    public void resetLifes()
    {
        for (int i = 0; i < 3; i++)
        {
            lifes[i].enabled = true;
        }
        imageIndex = 2;
    }
}
