using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockUIMainScript : MonoBehaviour
{ 
    public GameObject player;
    public Text currentText = null;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        currentText.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        string status = null;
        if (player.GetComponent<BlockManager>().pinkBlockSnapped && player.GetComponent<BlockManager>().blueBlockSnapped != true)
        {
            status ="Stack the blue block";
        }
        else if (player.GetComponent<BlockManager>().pinkBlockSnapped && player.GetComponent<BlockManager>().redBlockSnapped != true)
        {
            status = "Stack the red block";
        }
        else if (player.GetComponent<BlockManager>().redBlockSnapped && player.GetComponent<BlockManager>().orangeBlockSnapped != true)
        {
            status = "Stack the orange block";
        }
        else if (player.GetComponent<BlockManager>().orangeBlockSnapped && player.GetComponent<BlockManager>().greenBlockSnapped != true)
        {
            status = "Stack the green block";
        }
        else
        {
            status = "Stack pink block";
        }
        currentText.text = status;
    }
}