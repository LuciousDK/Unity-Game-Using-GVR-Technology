using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int killCount = 0;
    public int maxHealth = 5;
    private float currentHealth;
    public Transform Camera;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("KillCount").GetComponent<Text>().text = "Kills: " + killCount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-collision.gameObject.transform.forward*2000);
            currentHealth -= collision.gameObject.GetComponent<Enemy>().strength;
            GameObject heart = transform.GetChild(0).GetChild(1).GetChild(3).GetChild(0).gameObject;
            heart.GetComponent<Image>().fillAmount = currentHealth / maxHealth;
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("TutorialScene");
            }
        }
    }
}
