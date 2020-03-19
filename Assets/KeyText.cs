using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyText : MonoBehaviour
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
        string status =
            "Player has red key : " + player.GetComponent<Inventory>().hasRed + "\n" +
            "Player has blue key : " + player.GetComponent<Inventory>().hasBlue + "\n" +
            "Player has green key : " + player.GetComponent<Inventory>().hasGreen;
        currentText.text = status;
    }
}
