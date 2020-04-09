using UnityEngine;
using System.IO;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class SnapPracticeUI : MonoBehaviour
{
    public string partnerTag;
    public string selfTag;
    public float closeVPDist = 0.05f;
    public float farVPDist = 1;
    public float moveSpeed = 40.0f;
    public float rotateSpeed = 90.0f;

    private Vector3 screenPoint;
    private Vector3 offset;
    private bool isSnaped;
    Color color = new Color(1, 255, 1); //light green color for when objects are snapped

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
    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        Cursor.visible = false;
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
        if (player.GetComponent<BlockManager>().redBlockSnapped == true && player.GetComponent<BlockManager>().blueBlockSnapped == true)
        { 
            SceneManager.LoadScene(7);
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
                selfBlock = GameObject.FindGameObjectWithTag("Block2");
                player.GetComponent<BlockManager>().redBlockSnapped = true;
                snapBlock();
            }
            else if (partnerTag == "Block4")
            {
                if (player.GetComponent<BlockManager>().redBlockSnapped)
                {
                    selfBlock = GameObject.FindGameObjectWithTag("Block4");
                    player.GetComponent<BlockManager>().blueBlockSnapped = true;
                    snapBlock();
                }
                else
                {

                    //report failure
                }

            }
            else if (partnerTag == "Block6")
            {
                if (player.GetComponent<BlockManager>().blueBlockSnapped)
                {
                    selfBlock = GameObject.FindGameObjectWithTag("Block6");
                    player.GetComponent<BlockManager>().greenBlockSnapped = true;
                    snapBlock();
                }
                else
                {
                    //report failure
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