using UnityEngine;
using System.IO;
using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class DoorUIPractice : MonoBehaviour
{
    public float distanceToGrab;
    RaycastHit whatIHit;
    //door currentDoor;
    public GameObject player;
    public GameObject currentGameObject;
    GameObject lastHighlightedObject;

    Color color = new Color(255, 255, 1); //yellow color for when objects are highlighted
    Color originalColor;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player.GetComponent<Inventory>().hasRed = false;
        player.GetComponent<Inventory>().hasYellow = false;
        player.GetComponent<Inventory>().hasOrange = false;
        player.GetComponent<Inventory>().hasRedDoor = false;
        player.GetComponent<Inventory>().hasOrangeDoor = false;
        player.GetComponent<Inventory>().hasYellowDoor = false;

    }

    // Update is called once per frame
    void Update()
    {

        UnityEngine.Debug.DrawRay(this.transform.position, this.transform.forward * distanceToGrab, Color.magenta);

        if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToGrab))
        {

            string objName = whatIHit.collider.gameObject.name;
            currentGameObject = GameObject.Find(objName);
            string objectTag = whatIHit.collider.tag;

            if (objectTag == "Keycard" || objectTag == "Door")
            {
                if (lastHighlightedObject != currentGameObject)
                {
                    ClearHighlighted();
                    originalColor = currentGameObject.GetComponent<Renderer>().material.color;
                    currentGameObject.GetComponent<Renderer>().material.color = color;
                    lastHighlightedObject = currentGameObject;
                }
            }
            else
            {
                ClearHighlighted();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (objectTag == "Keycard")
                {

                    if (objName == "Red Key")
                    {
                        player.GetComponent<Inventory>().hasRed = true;
                        Destroy(whatIHit.collider.gameObject);
                    }
                    if (objName == "Orange Key")
                    {
                        player.GetComponent<Inventory>().hasOrange = true;
                        Destroy(whatIHit.collider.gameObject);
                    }
                    if (objName == "Yellow Key")
                    {
                        player.GetComponent<Inventory>().hasYellow = true;
                        Destroy(whatIHit.collider.gameObject);
                    }
                }
                if (whatIHit.collider.tag == "Door")
                {
                    if (objName == "Red door")
                    {
                        if (player.GetComponent<Inventory>().hasYellow == true)
                        {
                            player.GetComponent<Inventory>().hasGreen = false;
                            player.GetComponent<Inventory>().hasRedDoor = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                    }
                    if (objName == "Orange door")
                    {
                        if (player.GetComponent<Inventory>().hasRed == true)
                        {
                            player.GetComponent<Inventory>().hasRed = false;
                            player.GetComponent<Inventory>().hasOrangeDoor = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                    }
                    if (objName == "Yellow door")
                    {
                        if (player.GetComponent<Inventory>().hasOrange == true)
                        {
                            player.GetComponent<Inventory>().hasOrange = false;
                            player.GetComponent<Inventory>().hasYellowDoor = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                    }

                    if (player.GetComponent<Inventory>().hasRedDoor == true &&
                        player.GetComponent<Inventory>().hasYellowDoor == true &&
                        player.GetComponent<Inventory>().hasOrangeDoor == true)
                    {
                        SceneManager.LoadScene(3);
                    }
                }
            }
        }
    }
    void ClearHighlighted()
    {
        if (lastHighlightedObject != null)
        {
            lastHighlightedObject.GetComponent<Renderer>().material.color = originalColor;
            lastHighlightedObject = null;
        }

    }
}