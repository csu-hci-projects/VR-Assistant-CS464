using UnityEngine;
using System.IO;
using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class RayCastRoom2 : MonoBehaviour
{
    public float distanceToGrab;
    RaycastHit whatIHit;
    //door currentDoor;
    public GameObject player;
    public int errorCount = 0;
    public bool startedTimer = false;
    string fileName = "dooropen.txt";
    public Stopwatch stopWatch = new Stopwatch();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
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
            if (Input.GetKeyDown(KeyCode.E))
            {

                string objName = whatIHit.collider.gameObject.name;
                UnityEngine.Debug.Log("I picked up " + whatIHit.collider.gameObject.name);

                if (whatIHit.collider.tag == "Keycard")
                {
                    if (startedTimer == false)
                    {
                        stopWatch.Start();
                        startedTimer = true;
                    }
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
                        if (player.GetComponent<Inventory>().hasGreen == true)
                        {
                            player.GetComponent<Inventory>().hasGreen = false;
                            player.GetComponent<Inventory>().hasRedDoor = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                        else
                        {
                            errorCount += 1;
                            UnityEngine.Debug.Log("User has messed up " + errorCount + " times");
                        }
                    }
                    if (objName == "Orange door")
                    {
                        if (player.GetComponent<Inventory>().hasYellow == true)
                        {
                            player.GetComponent<Inventory>().hasYellow = false;
                            player.GetComponent<Inventory>().hasOrangeDoor = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                        else
                        {
                            errorCount += 1;
                            UnityEngine.Debug.Log("User has messed up " + errorCount + " times");
                        }
                    }
                    if (objName == "Yellow door")
                    {
                        if (player.GetComponent<Inventory>().hasIndigo == true)
                        {
                            player.GetComponent<Inventory>().hasIndigo = false;
                            player.GetComponent<Inventory>().hasYellowDoor = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                        else
                        {
                            errorCount += 1;
                            UnityEngine.Debug.Log("User has messed up " + errorCount + " times");
                        }
                    }
                    if (objName == "Indigo door")
                    {
                        if (player.GetComponent<Inventory>().hasViolet == true)
                        {
                            player.GetComponent<Inventory>().hasViolet = false;
                            player.GetComponent<Inventory>().hasIndigoDoor = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                        else
                        {
                            errorCount += 1;
                            UnityEngine.Debug.Log("User has messed up " + errorCount + " times");
                        }
                    }
                    if (objName == "Violet door")
                    {
                        if (player.GetComponent<Inventory>().hasOrange == true)
                        {
                            player.GetComponent<Inventory>().hasOrange = false;
                            player.GetComponent<Inventory>().hasVioletDoor = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                        else
                        {
                            errorCount += 1;
                            UnityEngine.Debug.Log("User has messed up " + errorCount + " times");
                        }
                    }
                    if (objName == "Green door")
                    {
                        if (player.GetComponent<Inventory>().hasBlue == true)
                        {
                            player.GetComponent<Inventory>().hasBlue = false;
                            player.GetComponent<Inventory>().hasGreenDoor = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                        else
                        {
                            errorCount += 1;
                            UnityEngine.Debug.Log("User has messed up " + errorCount + " times");
                        }
                    }
                    if (objName == "Blue door")
                    {
                        if (player.GetComponent<Inventory>().hasRed == true)
                        {
                            player.GetComponent<Inventory>().hasRed = false;
                            player.GetComponent<Inventory>().hasBlueDoor = true;
                            Destroy(whatIHit.collider.gameObject);
                        }
                        else
                        {
                            errorCount += 1;
                            UnityEngine.Debug.Log("User has messed up " + errorCount + " times");
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

                        var writeFile = File.CreateText(fileName);
                        writeFile.WriteLine("This user made " + errorCount + " errors");
                        writeFile.WriteLine("This user took " + elapsedTime + " to complete the task");
                        writeFile.Close();

                        SceneManager.LoadScene(4);
                    }
                }
            }
        }
    }
}