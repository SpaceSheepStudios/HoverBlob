using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapBlob : MonoBehaviour
{
    public string targetTag = "SlimeSphere";
    public SphereCollider centerCol;
    public GameObject slimeGroup;

    // Update is called once per frame
    void Update()
    {
        // Touch input
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            Collider[] colliders = slimeGroup.GetComponentsInChildren<Collider>();

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.CompareTag(targetTag))
                    {
                        Debug.Log("Ein Slime-Objekt wurde angeklickt!");
                        // Insert onTap code
                        break;
                    }
                }
            }
        }
        
// is only executed if game starts in unity editor
#if UNITY_EDITOR

        // Mouse input
        if(Input.GetMouseButtonDown(0))
        {
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Collider[] colliders = slimeGroup.GetComponentsInChildren<Collider>();

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.CompareTag(targetTag))
                    {
                        Debug.Log("Ein Slime-Objekt wurde angeklickt!");
                        // Insert onClick code
                        break;
                    }
                }
            } 
        }

#endif

    }
}
