using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out hit, 100))
        {
            if (hit.collider.CompareTag("Penguin"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.gameObject.GetComponent<Mole>().Stunned();
                    Debug.Log(hit.collider.gameObject.name + " was hit");
                }
            }
        }

    }
}
