using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;



public class CreateMap : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    [SerializeField]
    List<GameObject> PlacebleObjects = new List<GameObject>();

    [SerializeField]
    List<GameObject> FoundObjects = new List<GameObject>();


    Camera arCam;
    GameObject spawnedObject;
    GameObject spawnablePrefab;

    public int objectNumber;
    int foundNumber;
    // Start is called before the first frame update
    void Start()
    {
        spawnedObject = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();

        objectNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnablePrefab = PlacebleObjects[objectNumber];

        if (Input.touchCount == 0)
            return;

        RaycastHit hit;
        Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);

        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && spawnedObject == null)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Spawnable")
                    {
                        spawnedObject = hit.collider.gameObject;
                    }
                    else if (hit.collider.gameObject.tag == "Collectable")
                    {
                        //foundNumber = hit.collider.gameObject.GetComponent<FoundObject>().obj.CollectableNumber;
                        FoundObjects[foundNumber].SetActive(true);
                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        SpawnPrefab(m_Hits[0].pose.position, m_Hits[0].pose.rotation);
                    }
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null)
            {
                spawnedObject.transform.position = m_Hits[0].pose.position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                spawnedObject = null;
            }
        }
    }

    private void SpawnPrefab(Vector3 spawnPosition, Quaternion rotation)
    {
        spawnedObject = Instantiate(spawnablePrefab, spawnPosition, rotation);
    }

    public void ChangeObjectNumber(int change)
    {
        objectNumber = change;
    }
}

