using UnityEngine;
using System.IO;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class BlockUISnap : MonoBehaviour
{
    public string partnerTag;
    public string selfTag;
    public float closeVPDist = 0.05f;
    public float farVPDist = 1;
    public float moveSpeed = 40.0f;
    public float rotateSpeed = 90.0f;

    public bool startedTimer = false;
    string fileName = "BlockSnapUI.txt";
    public Stopwatch stopWatch = new Stopwatch();

    private Vector3 screenPoint;
    private Vector3 offset;
    private bool isSnaped;
    private int failCount = 0;
    Color color = new Color(1, 255, 1); //yellow color for when objects are snapped

    float dist = Mathf.Infinity;
    Color normalColor;
    GameObject selfBlock;
    GameObject partnerGO;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        normalColor = GetComponent<Renderer>().material.color; //gets the default color of the object
        partnerGO = GameObject.FindGameObjectWithTag(partnerTag); //gets the current selected objects partner tag so it knows what to snap to
        player.GetComponent<BlockManager>().redBlockSnapped = false;
        player.GetComponent<BlockManager>().blueBlockSnapped = false;
        player.GetComponent<BlockManager>().greenBlockSnapped = false;
        player.GetComponent<BlockManager>().pinkBlockSnapped = false;
        player.GetComponent<BlockManager>().orangeBlockSnapped = false;
    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        Cursor.visible = false;
        if (startedTimer == false)
        {
            stopWatch.Start();
            startedTimer = true;
        }
    }
    void OnMouseDrag()
    {
        //transform.SetParent(null);
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
        Vector3 partnerPos = Camera.main.WorldToViewportPoint(partnerGO.transform.position);
        Vector3 myPos = Camera.main.WorldToViewportPoint(transform.position);
        dist = Vector2.Distance(partnerPos, myPos);
        GetComponent<Renderer>().material.color = (dist < closeVPDist) ? color : normalColor;
    }
    void Update()
    {
        if (player.GetComponent<BlockManager>().redBlockSnapped == true && player.GetComponent<BlockManager>().blueBlockSnapped == true && player.GetComponent<BlockManager>().greenBlockSnapped == true
            && player.GetComponent<BlockManager>().pinkBlockSnapped == true && player.GetComponent<BlockManager>().orangeBlockSnapped == true)
        {
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            var writeFile = File.CreateText(fileName);
            writeFile.WriteLine("This user took " + elapsedTime + " to complete the task");
            writeFile.WriteLine("This user made  " + failCount + " errors");
            writeFile.Close();


            SceneManager.LoadScene(10);
        }
    }

    void OnMouseUp()
    {
        Cursor.visible = true;
        if (dist < closeVPDist)
        {
            isSnaped = true;
            if (partnerTag == "Block2")
            {
                if (player.GetComponent<BlockManager>().blueBlockSnapped)
                {
                    selfBlock = GameObject.FindGameObjectWithTag("Block2");
                    player.GetComponent<BlockManager>().redBlockSnapped = true;
                    snapBlock();
                }
                else
                {
                    failCount = failCount + 1;
                }
            }
            else if (partnerTag == "Block4")
            {
                if (player.GetComponent<BlockManager>().pinkBlockSnapped)
                {
                    selfBlock = GameObject.FindGameObjectWithTag("Block4");
                    player.GetComponent<BlockManager>().blueBlockSnapped = true;
                    snapBlock();
                }
                else
                {
                    failCount = failCount + 1;
                }

            }
            else if (partnerTag == "Block6")
            {
                if (player.GetComponent<BlockManager>().orangeBlockSnapped)
                {
                    selfBlock = GameObject.FindGameObjectWithTag("Block6");
                    player.GetComponent<BlockManager>().greenBlockSnapped = true;
                    snapBlock();
                }
                else
                {
                    failCount = failCount + 1;
                }
            }
            else if (partnerTag == "Block8")
            {
                 selfBlock = GameObject.FindGameObjectWithTag("Block8");
                 player.GetComponent<BlockManager>().pinkBlockSnapped = true;
                 snapBlock();
            }
            else if (partnerTag == "Block10")
            {
                if (player.GetComponent<BlockManager>().redBlockSnapped)
                {
                    selfBlock = GameObject.FindGameObjectWithTag("Block8");
                    player.GetComponent<BlockManager>().orangeBlockSnapped = true;
                    snapBlock();
                }
                else
                {
                    failCount = failCount + 1;
                }
            }

        }
        if (dist > farVPDist)
        {
            //  transform.SetParent(null);
        }
    }

    void snapBlock()
    {
        transform.SetParent(partnerGO.transform);
        StartCoroutine(InstallPart());
    }

    IEnumerator InstallPart()
    {
        while (transform.localPosition != Vector3.right || transform.localRotation != Quaternion.identity)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.right, Time.deltaTime * moveSpeed);
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.identity, Time.deltaTime * rotateSpeed);
            yield return new WaitForEndOfFrame();
        }
    }
}
