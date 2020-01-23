using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopButtonController : MonoBehaviour
{
    private bool selected = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
            transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount += Time.deltaTime * 0.5f;
        if (selected && transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount >= 1)
            Application.Quit();


    }
    public void StartLoad()
    {
        transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount = 0;
        selected = true;
    }

    public void StopLoad()
    {
        selected = false;
        transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount = 1;
    }
}
