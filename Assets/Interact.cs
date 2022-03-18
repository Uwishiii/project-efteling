using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {
    public Camera camera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;

                // Do something with the object that was hit by the raycast.
                print((objectHit.gameObject.name));
                if (objectHit.gameObject.CompareTag("Interactable"))
                {   
                    objectHit.SendMessage("RunInteractCode");
                  //  Destroy(hit.transform.gameObject);
                }
            }
      
        }
    }
}