using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SelectorCircle : MonoBehaviour
{

    public Transform player;
    public Transform circle;
    public float loadSpeed;
    private int focusing = 0;
    public float pickUpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        circle.GetComponent<Image>().fillAmount += (loadSpeed/100)*focusing * Time.deltaTime;
        circle.transform.LookAt(player);

        if(circle.GetComponent<Image>().fillAmount==1){
        
            Vector3 shotPosition = new Vector3(player.transform.position.x,3,player.transform.position.z+0.2f);
            transform.position = Vector3.MoveTowards(transform.position, shotPosition, pickUpSpeed * Time.deltaTime);
            
            
            //Reset();
            //PickUpObject();
		}
    }

    public void StartLoad(){
        circle.GetComponent<Image>().fillAmount = 0;
        focusing = 1;
	}

    public void Reset(){
     
        circle.GetComponent<Image>().fillAmount = 0;
        focusing = 0;
	}

    private void PickUpObject(){
        Vector3 shotPosition = new Vector3(player.transform.position.x,0.5f,player.transform.position.z+0.2f);
        transform.position = Vector3.MoveTowards(transform.position, shotPosition, pickUpSpeed * Time.deltaTime);
	}
}
