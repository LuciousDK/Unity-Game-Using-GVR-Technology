using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

    public GameObject bullet;
    public float shotsPerSecond = 2;
    private float elapsed = 0f;
    private bool targettingEnemy = false;
    private bool changingProjectile = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (targettingEnemy)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= 1f / shotsPerSecond)
            {
                elapsed = elapsed % (1f / shotsPerSecond);
                Fire();
            }
        }

        if ((transform.rotation.z > 0.2 || transform.rotation.z <-0.2)&&!changingProjectile)
        {
            changingProjectile = true;
            ChangeProjectile();

        }
        if((transform.rotation.z < 0.2 && transform.rotation.z > -0.2))
        {
            changingProjectile = false;
        }
    }

    private void ChangeProjectile()
    {
        if (bullet.name.Equals("Carrot"))
        {
            bullet = Resources.Load("prefabs/Feather") as GameObject;
            GameObject projectileIcon = GameObject.FindGameObjectWithTag("Main Canvas").transform.GetChild(1).gameObject;
            projectileIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 174.4f);
            projectileIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/feather") as Sprite;
        }
        else if (bullet.name.Equals("Feather"))
        {
            bullet = Resources.Load("prefabs/Carrot") as GameObject;
            GameObject projectileIcon = GameObject.FindGameObjectWithTag("Main Canvas").transform.GetChild(1).gameObject;
            projectileIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(58.2f, 174.4f);
            projectileIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/carrot") as Sprite;
        }
    }

    public void StartShooting()
    {
        targettingEnemy = true;
    }

    public void StopShooting()
    {
        targettingEnemy = false;
    }

    private void Fire()
    {
        if (bullet.name.Equals("Carrot"))
        {
            GameObject instBullet = Instantiate(bullet, transform.position + (transform.forward), transform.rotation) as GameObject;
            Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(), instBullet.GetComponent<Collider>());

        }
        if (bullet.name.Equals("Feather"))
        {
            GameObject instBullet2 = Instantiate(bullet, transform.position + (transform.forward), transform.rotation * Quaternion.Euler(0,30,0)) as GameObject;
            GameObject instBullet3 = Instantiate(bullet, transform.position + (transform.forward), transform.rotation * Quaternion.Euler(0, -30, 0)) as GameObject;
            Physics.IgnoreCollision(instBullet2.GetComponent<Collider>(), instBullet3.GetComponent<Collider>());
            GameObject instBullet = Instantiate(bullet, transform.position + (transform.forward), transform.rotation) as GameObject;
            Physics.IgnoreCollision(instBullet.GetComponent<Collider>(), instBullet2.GetComponent<Collider>());
            Physics.IgnoreCollision(instBullet.GetComponent<Collider>(), instBullet3.GetComponent<Collider>());
            Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(), instBullet.GetComponent<Collider>());
            Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(), instBullet2.GetComponent<Collider>());
            Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(), instBullet3.GetComponent<Collider>());

            //bullet = Resources.Load("prefabs/Carrot") as GameObject;

        }
        //instBullet.GetComponent<Collider>().enabled = true;
        //instBullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * bullet.GetComponent<Bullet>().speed * 1000);

    }



}
