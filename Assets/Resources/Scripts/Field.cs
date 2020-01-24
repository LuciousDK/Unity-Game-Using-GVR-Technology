using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Field : MonoBehaviour
{

    private float elapsed = 0;
    public int spawnRate = 1;
    public int maxSpawns = 5;
    private int spawnCount = 0;
    private float countdown = 0;
    private bool victory = false;
    private ArrayList enemies = new ArrayList();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCount < maxSpawns)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= (1f / spawnRate))
            {
                elapsed = elapsed % (1f / spawnRate);

                GenerateEnemy(GenerateSpawnLocation());
            }
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().killCount >= maxSpawns)
        {
            if (!victory)
            {
                GetComponent<AudioSource>().Play();
                victory = true;
                Camera.main.GetComponent<AudioSource>().Pause();
            }
            GameObject canvas = GameObject.FindGameObjectWithTag("Main Canvas");
            canvas.transform.GetChild(0).gameObject.SetActive(true);
            var childrenCount = canvas.transform.childCount;
            for (int i = 1; i < childrenCount; i++)
            {
                canvas.transform.GetChild(i).gameObject.SetActive(false);
            }
            countdown += Time.deltaTime;
            if (countdown >= 5)
            {
                SceneManager.LoadScene("TutorialScene");
            }

        }

    }

    private Vector3 GenerateSpawnLocation()
    {
        int quadrent = Random.Range(1, 5);

        int xPos = 20;
        int zPos = 20;

        switch (quadrent)
        {
            case 1:
                xPos = Random.Range(-20, 20);
                zPos = Random.Range(10, 20);
                break;
            case 2:
                xPos = Random.Range(10, 20);
                zPos = Random.Range(-20, 20);
                break;
            case 3:
                xPos = Random.Range(-20, 20);
                zPos = Random.Range(-10, -20);
                break;
            case 4:
                xPos = Random.Range(-10, -20);
                zPos = Random.Range(-20, 20);
                break;
        }

        Vector3 position = new Vector3(xPos, 0, zPos);

        return position;
    }

    private void GenerateEnemy(Vector3 location)
    {

        GameObject enemyObject = Resources.Load("prefabs/Enemy") as GameObject;
        GameObject instEnemy = Instantiate(enemyObject, location, transform.rotation) as GameObject;
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
                Physics.IgnoreCollision(enemy.GetComponent<Collider>(), instEnemy.GetComponent<Collider>());
        }
        enemies.Add(instEnemy);
        spawnCount++;
    }

}
