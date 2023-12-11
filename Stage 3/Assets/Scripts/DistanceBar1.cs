using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceBar1 : MonoBehaviour
{
    [SerializeField]
    DistanceBar DistanceBar;

    int distanceTraveled;
    // Start is called before the first frame update
    void Start()
    {
        distanceTraveled = 0;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something");
        if(other.gameObject.GetComponent<Camera>() != null)
        {
            DistanceBar.SetDistance(1);
            gameObject.SetActive(false);
        }
    }
}
