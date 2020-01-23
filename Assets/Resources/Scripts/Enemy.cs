
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Transform player;
    public Transform healthBar;
    public int maxHealth = 100;
    private float currentHealth;
    public int strength = 1;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
        transform.LookAt(player);

        healthBar.transform.LookAt(player);

        if (currentHealth/maxHealth < healthBar.GetComponent<Image>().fillAmount)
        {
            healthBar.GetComponent<Image>().fillAmount -= 1f * Time.deltaTime;
        }
    }

    public void LoseHealth(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            player.GetComponentInParent<Player>().killCount++;
            Destroy(gameObject);
            Camera.main.GetComponent<Shoot>().StopShooting();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{
        //    GetComponent<Rigidbody>().AddForce(-transform.forward*1000);
        //}
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Camera.main.GetComponent<Shoot>().StartShooting();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Camera.main.GetComponent<Shoot>().StopShooting();
    }
}
