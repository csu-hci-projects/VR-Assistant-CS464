using UnityEngine;
using System.IO;
using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class RayCastTabletMain : MonoBehaviour
{
    public float distanceToGrab;
    RaycastHit whatIHit;
    //door currentDoor;
    public GameObject player;
    public int errorCount = 0;
    string fileName = "DoorTablet.txt";
    public Stopwatch stopWatch = new Stopwatch();

    public GameObject currentGameObject;
    GameObject lastHighlightedObject;

    Color color = new Color(255, 255, 1); //yellow color for when objects are highlighted
    Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        stopWatch.Start();
        player.GetComponent<Inventory>().hasRed = false;
        player.GetComponent<Inventory>().hasYellow = false;
        player.GetComponent<Inventory>().hasOrange = false;
        player.GetComponent<Inventory>().hasIndigo = false;
        player.GetComponent<Inventory>().hasViolet = false;
        player.GetComponent<Inventory>().hasGreen = false;
        player.GetComponent<Inventory>().hasBlue = false;
        player.GetComponent<Inventory>().hasRedDoor = false;
        player.GetComponent<Inventory>().hasOrangeDoor = false;
        player.GetComponent<Inventory>().hasYellowDoor = false;
        player.GetComponent<Inventory>().hasIndigoDoor = false;
        player.GetComponent<Inventory>().hasVioletDoor = false;
        player.GetComponent<Inventory>().hasGreenDoor = false;
        player.GetComponent<Inventory>().hasBlueDoor = false;
    }

    // Update is called once per frame
    void Update()
    {

        UnityEngine.Debug.DrawRay(this.transform.position, this.transform.forward * distanceToGrab, Color.magenta);

        if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToGrab))
        {
            string objName = whatIHit.collider.gameObject.name;
            string objectTag = whatIHit.collider.tag;
            currentGameObject = GameObject.Find(objName);

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

                if (whatIHit.collider.tag == "Keycard")
                {
                    if (player.GetComponent<Inventory>().hasBlue || player.GetComponent<Inventory>().hasGreen || player.GetComponent<Inventory>().hasRed)
                    {
                        //do nothing
                    }
                    else
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
                        if (objName == "Indigo Key")
                        {
                            player.GetComponent<Inventory>().hasIndigo = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                        if (objName == "Violet Key")
                        {
                            player.GetComponent<Inventory>().hasViolet = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                        if (objName == "Blue Key")
                        {
                            player.GetComponent<Inventory>().hasBlue = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                        if (objName == "Green Key")
                        {
                            player.GetComponent<Inventory>().hasGreen = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                    }


                }

                if (whatIHit.collider.tag == "Door")
                {
                    if (objName == "Red door")
                    {
                        if (player.GetComponent<Inventory>().hasOrange == true)
                        {
                            player.GetComponent<Inventory>().hasOrange = false;
                            player.GetComponent<Inventory>().hasRedDoor = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                        else
                        {
                            errorCount += 1;
                        }
                    }
                    if (objName == "Orange door")
                    {
                        if (player.GetComponent<Inventory>().hasGreen == true)
                        {
                            player.GetComponent<Inventory>().hasGreen = false;
                            player.GetComponent<Inventory>().hasOrangeDoor = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                        else
                        {
                            errorCount += 1;
                        }
                    }
                    if (objName == "Yellow door")
                    {
                        if (player.GetComponent<Inventory>().hasRed == true)
                        {
                            player.GetComponent<Inventory>().hasRed = false;
                            player.GetComponent<Inventory>().hasYellowDoor = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                        else
                        {
                            errorCount += 1;
                        }
                    }
                    if (objName == "Indigo door")
                    {
                        if (player.GetComponent<Inventory>().hasBlue == true)
                        {
                            player.GetComponent<Inventory>().hasBlue = false;
                            player.GetComponent<Inventory>().hasIndigoDoor = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                        else
                        {
                            errorCount += 1;
                        }
                    }
                    if (objName == "Violet door")
                    {
                        if (player.GetComponent<Inventory>().hasYellow == true)
                        {
                            player.GetComponent<Inventory>().hasYellow = false;
                            player.GetComponent<Inventory>().hasVioletDoor = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                        else
                        {
                            errorCount += 1;
                        }
                    }
                    if (objName == "Green door")
                    {
                        if (player.GetComponent<Inventory>().hasViolet == true)
                        {
                            player.GetComponent<Inventory>().hasViolet = false;
                            player.GetComponent<Inventory>().hasGreenDoor = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                        else
                        {
                            errorCount += 1;
                        }
                    }
                    if (objName == "Blue door")
                    {
                        if (player.GetComponent<Inventory>().hasIndigo == true)
                        {
                            player.GetComponent<Inventory>().hasIndigo = false;
                            player.GetComponent<Inventory>().hasBlueDoor = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                        else
                        {
                            errorCount += 1;
                        }
                    }

                    if (player.GetComponent<Inventory>().hasRedDoor == true &&
                        player.GetComponent<Inventory>().hasGreenDoor == true &&
                        player.GetComponent<Inventory>().hasBlueDoor == true &&
                        player.GetComponent<Inventory>().hasYellowDoor == true &&
                        player.GetComponent<Inventory>().hasOrangeDoor == true &&
                        player.GetComponent<Inventory>().hasIndigoDoor == true &&
                        player.GetComponent<Inventory>().hasVioletDoor == true)
                    {
                        stopWatch.Stop();
                        TimeSpan ts = stopWatch.Elapsed;
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

                        string dataPath = System.Environment.GetFolderPath( (System.Environment.SpecialFolder.Desktop)) + "/logfiles/";
                        if(!Directory.Exists(dataPath)){
                            Directory.CreateDirectory(dataPath);
                         }
        
                        var writeFile = File.CreateText(dataPath + fileName);
                        writeFile.WriteLine("This user made " + errorCount + " errors");
                        writeFile.WriteLine("This user took " + elapsedTime + " to complete the task");
                        writeFile.Close();

                        SceneManager.LoadScene(10);
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