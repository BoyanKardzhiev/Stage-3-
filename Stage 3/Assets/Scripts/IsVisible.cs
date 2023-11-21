using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisible : MonoBehaviour
{
    // Start is called before the first frame update
    Renderer m_Renderer;
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Renderer.isVisible)
        {
            Debug.Log("Object is visible!");
        }
        else
        {
            Debug.Log("Object is not visible!");
        }
    }
}
