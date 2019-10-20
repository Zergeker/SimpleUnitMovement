using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.AI;
using UnityEngine;

public class UnitSelect : MonoBehaviour
{
    public GameObject selectedObject;
    public string[] selectables = {"Enemy", "Player"};
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitUnit;

        if (Physics.Raycast(ray, out hitUnit))
        {
            GameObject hitObject = hitUnit.transform.root.gameObject;

            if (Input.GetMouseButton(0) && IsSelectable(hitObject))
                SelectObject(hitObject);

            if (Input.GetMouseButton(1) && selectedObject.tag == "Player")
            {
                if (hitObject.tag == "Enemy")
                    Destroy(hitUnit.transform.root.gameObject);
                else
                    selectedObject.GetComponent<NavMeshAgent>().destination = hitUnit.point;
            }
        }
    }

    void SelectObject(GameObject obj)
    {
        if (selectedObject != null)
        {
            if (obj == selectedObject)
                return;
            ClearSelection();
        }

        selectedObject = obj;
        selectedObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }
    
    void ClearSelection()
    {
        selectedObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        selectedObject = null;
    }

    bool IsSelectable(GameObject obj)
    {
        return Array.Exists(selectables, element => element == obj.tag);
    }
}
