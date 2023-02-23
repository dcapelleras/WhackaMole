using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mole : MonoBehaviour
{
    [SerializeField] float hitTime = 5f;
    [SerializeField] float lifeTime = 7f;
    Animator anim;
    bool canBeHit = false;
    Vector3 startingPosition;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        startingPosition= transform.position;
    }

    private void OnEnable()
    {
        transform.position= startingPosition;
        Appear();
        StartCoroutine(Counter());
        StartCoroutine(DisappearCoroutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Appear();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Stunned();
        }
    }

    public void Stunned()
    {
        if (!canBeHit)
        {
            return;
        }
        canBeHit= false;
        PointCounter.instance.Score();
        anim.SetTrigger("stun");
        anim.Play("stun");
        StopCoroutine(Counter());
    }



    public void Appear()
    {
        canBeHit = true;
        anim.SetTrigger("Idle");
    }

    IEnumerator Counter()
    {
        yield return new WaitForSeconds(hitTime);
        gameObject.SetActive(false);

    }

    IEnumerator DisappearCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }

   
}
