using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class Snap : MonoBehaviour
{

    public string partnerTag;
    public string selfTag;
    public float closeVPDist = 0.05f;
    public float farVPDist = 1;
    public float moveSpeed = 40.0f;
    public float rotateSpeed = 90.0f;

    public bool startedTimer = false;
    string fileName = "blocksnapping.txt";
    public Stopwatch stopWatch = new Stopwatch();

    private Vector3 screenPoint;
    private Vector3 offset;
    private bool isSnaped;
    Color color = new Color(255, 255, 0); //yellow color for when objects are snapped

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
        if (player.GetComponent<BlockManager>().redBlockSnapped == true && player.GetComponent<BlockManager>().blueBlockSnapped == true && player.GetComponent<BlockManager>().greenBlockSnapped == true && player.GetComponent<BlockManager>().pinkBlockSnapped == true)
        {
            SceneManager.LoadScene(0);
        }
    }

    void OnMouseUp()
    {

        Cursor.visible = true;
        if (dist < closeVPDist)
        {
            transform.SetParent(partnerGO.transform);
            StartCoroutine(InstallPart());
            isSnaped = true;
            if(partnerTag == "Block1")
            {
                selfBlock = GameObject.FindGameObjectWithTag("Block1");
                selfBlock.GetComponent<MeshRenderer>().material.color = color;
                player.GetComponent<BlockManager>().redBlockSnapped = true;
                player.GetComponent<BlockManager>().blueBlockSnapped = true;
            }
            else if (partnerTag == "Block2")
            {
                selfBlock = GameObject.FindGameObjectWithTag("Block2");
                selfBlock.GetComponent<MeshRenderer>().material.color = color;
                player.GetComponent<BlockManager>().blueBlockSnapped = true;
                if(player.GetComponent<BlockManager>().redBlockSnapped == true)
                {
                    player.GetComponent<BlockManager>().greenBlockSnapped = true;
                }
            }
            else if (partnerTag == "Block3")
            {
                selfBlock = GameObject.FindGameObjectWithTag("Block3");
                selfBlock.GetComponent<MeshRenderer>().material.color = color;
                player.GetComponent<BlockManager>().greenBlockSnapped = true;
                if(player.GetComponent<BlockManager>().blueBlockSnapped == true)
                {
                    selfBlock = GameObject.FindGameObjectWithTag("Block4");
                    selfBlock.GetComponent<MeshRenderer>().material.color = color;
                    player.GetComponent<BlockManager>().pinkBlockSnapped = true;
                }
            }

        }
        if (dist > farVPDist)
        {
            //  transform.SetParent(null);
        }
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