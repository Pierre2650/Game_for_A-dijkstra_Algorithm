using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject easyMob;
    [SerializeField] private GameObject mediumMob;
    [SerializeField] private GameObject hardMob;

    [Header("Spawner")]
    [SerializeField] private float easySpawnRate;
    [SerializeField] private float mediumSpawnRate;
    [SerializeField] private float hardSpawnRate;
    private float easyElapsedTime = 0f;
    private float mediumElapsedTime = 0f;
    private float HardElapsedTime = 0f;
    public bool stopSpawn = true;

    [Header("UI")]
    public ScoreManager scoreManager;


    private List<GameObject> mobs = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopSpawn) { easyElapsedTime += Time.deltaTime; mediumElapsedTime += Time.deltaTime; HardElapsedTime += Time.deltaTime; } 
        else { easyElapsedTime = mediumElapsedTime = HardElapsedTime = 0; }

        if (easyElapsedTime > easySpawnRate)
        {
            spawnEasyMob();
            easyElapsedTime = 0f;
        }


        if (mediumElapsedTime > mediumSpawnRate)
        {
            spawnMediumMob();
            mediumElapsedTime = 0f;
        }



        if (HardElapsedTime > hardSpawnRate)
        {
            spawnHardMob();
            HardElapsedTime = 0f;
        }

    }

    private void spawnEasyMob()
    {
        float randX = Random.Range(0, 8.5f);
        Vector2 spawnPos = new Vector2(randX, 0);
        GameObject temp = Instantiate(easyMob, transform.parent,false);
        temp.transform.localPosition = spawnPos;
        temp.GetComponent<MobHealth>().scoreManager = scoreManager;
        temp.GetComponent<MobEasyController>().spawner = this;
        mobs.Add(temp);

    }

    private void spawnMediumMob()
    {
        float randX = Random.Range(0, 8.5f);
        Vector2 spawnPos = new Vector2(randX, 0);
        GameObject temp = Instantiate(mediumMob, transform.parent, false);

        temp.transform.localPosition = spawnPos;
        temp.GetComponent<MobHealth>().scoreManager = scoreManager;
        temp.GetComponent<MobMediumController>().spawner = this;
        mobs.Add(temp);
    }


    private void spawnHardMob()
    {
        float randX = Random.Range(0, 8.5f);
        Vector2 spawnPos = new Vector2(randX, 0);
        GameObject temp = Instantiate(hardMob, transform.parent, false);
        temp.transform.localPosition = spawnPos;
        temp.GetComponent<MobHealth>().scoreManager = scoreManager;
        temp.GetComponent<MobHardController>().spawner = this;
        mobs.Add(temp);
    }

    public void destroyAllMobs(bool wait)
    {
        if (wait){ StartCoroutine(waitToSpawn()); }
        
        foreach (GameObject mob in mobs.ToList())
        {
            mobs.Remove(mob);
            Destroy(mob);
        }

    }

    private IEnumerator waitToSpawn()
    {
        stopSpawn = true;
        yield return new WaitForSeconds(2);
        stopSpawn = false;
    }
    public void removeMob(GameObject mob)
    {
        mobs.Remove(mob);
    }

}
