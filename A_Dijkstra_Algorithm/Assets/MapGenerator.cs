using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject horizontalPrefab;
    public GameObject verticalPrefab;

    public GameObject[] horizontalPos;
    public GameObject[] verticalPos;

    public Vector2 verticalStart;
    public int vLength;
    public Vector2 horizontalStart;
    public int hLength;

    private Vector2 vertical = new Vector2(2, 1);
    private Vector2 horizontal = new Vector2(1.55f, -0.78f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < vLength; i++) {

        }

        for (int i = 0; i < hLength; i++)
        {
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
