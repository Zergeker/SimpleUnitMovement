using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionStatus : MonoBehaviour
{
    UnitSelect mm;
    void Start()
    {
        mm = GameObject.FindObjectOfType<UnitSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mm.selectedObject != null)
        {
            Renderer rend = mm.selectedObject.GetComponentInChildren<Renderer>();
            float d = rend.bounds.size.x;

            this.transform.position = mm.selectedObject.transform.position;
            this.transform.localScale = new Vector3(d, -rend.bounds.size.y, d);
        }
    }
}