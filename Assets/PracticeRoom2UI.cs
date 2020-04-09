using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PracticeRoom2UI : MonoBehaviour
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
        if (player.GetComponent<Inventory>().hasRed)
        {
            status =
            "Player has red key. Open the orange door.";
        }
       
        else if (player.GetComponent<Inventory>().hasYellow)
        {
            status =
            "Player has yellow key. Open the red door.";
        }
        else if (player.GetComponent<Inventory>().hasOrange)
        {
            status =
            "Player has orange key. Open the yellow door.";
        }
        else
        {
            status = "Collect a Key";
        }
        currentText.text = status;
    }
}
