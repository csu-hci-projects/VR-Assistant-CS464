using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorUIScript : MonoBehaviour
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
            status = "Player has red key. Open the blue door.";
        }

        else if (player.GetComponent<Inventory>().hasBlue)
        {
            status = "Player has blue key. Open the green door.";
        }
        else if (player.GetComponent<Inventory>().hasOrange)
        {
            status = "Player has orange key. Open the violet door.";
        }
        else if (player.GetComponent<Inventory>().hasViolet)
        {
            status = "Player has violet key. Open the indigo door.";
        }
        else if (player.GetComponent<Inventory>().hasIndigo)
        {
            status = "Player has indigo key. Open the yellow door.";
        }
        else if (player.GetComponent<Inventory>().hasYellow)
        {
            status = "Player has yellow key. Open the orange door.";
        }
        else if (player.GetComponent<Inventory>().hasGreen)
        {
            status = "Player has green key. Open the red door.";
        }
        else
        {
            status = "Collect a Key";
        }
        currentText.text = status;
    }
}
