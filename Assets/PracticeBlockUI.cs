using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PracticeBlockUI : MonoBehaviour
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
        if (player.GetComponent<BlockManager>().redBlockSnapped)
        {
            status =
            "Stack the blue block";
        }
        else
        {
            status = "Stack red block";
        }
        currentText.text = status;
    }
}
