using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RayCastPractice : MonoBehaviour
{
    public float distanceToGrab;
    RaycastHit whatIHit;
    //door currentDoor;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player.GetComponent<Inventory>().hasRed = false;
        player.GetComponent<Inventory>().hasGreen = false;
        player.GetComponent<Inventory>().hasRedDoor = false;
        player.GetComponent<Inventory>().hasGreenDoor = false;
        player.GetComponent<BlockManager>().redBlockSnapped = false;
        player.GetComponent<BlockManager>().greenBlockSnapped = false;
    }

    // Update is called once per frame
    void Update()
    {

        UnityEngine.Debug.DrawRay(this.transform.position, this.transform.forward * distanceToGrab, Color.magenta);

        if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToGrab))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                string objName = whatIHit.collider.gameObject.name;
                UnityEngine.Debug.Log("I picked up " + whatIHit.collider.gameObject.name);

                if (whatIHit.collider.tag == "Keycard")
                {
        
                    if (objName == "Red Key")
                    {
                        player.GetComponent<Inventory>().hasRed = true;
                        Destroy(whatIHit.collider.gameObject);
                    }
       
                    if (objName == "Green Key")
                    {
                        player.GetComponent<Inventory>().hasGreen = true;
                        Destroy(whatIHit.collider.gameObject);
                    }


                }

                if (whatIHit.collider.tag == "Door")
                {
                    if (objName == "Red door")
                    {
                        if (player.GetComponent<Inventory>().hasRed == true)
                        {
                            player.GetComponent<Inventory>().hasRed = false;
                            player.GetComponent<Inventory>().hasRedDoor = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
           
                    }
                    if (objName == "Green door")
                    {
                        if (player.GetComponent<Inventory>().hasGreen == true)
                        {
                            player.GetComponent<Inventory>().hasGreen = false;
                            player.GetComponent<Inventory>().hasGreenDoor = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
      
                    }

                    if (player.GetComponent<Inventory>().hasRedDoor == true && player.GetComponent<Inventory>().hasGreenDoor == true)
                    {
                        if (player.GetComponent<BlockManager>().redBlockSnapped == true  && player.GetComponent<BlockManager>().greenBlockSnapped == true)
                        {
                            SceneManager.LoadScene(4);
                        }
                            
                    }
                }
            }
        }
    }
}
