using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

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
                    if (!anim.enabled)
                    {
                        anim.enabled = true;
                    }
                    transform.position = hit.collider.transform.position;
                    anim.SetTrigger("Hit");
                    hit.collider.gameObject.GetComponent<Mole>().Stunned();
                    Debug.Log(hit.collider.gameObject.name + " was hit");
                }
            }
        }

    }
}
