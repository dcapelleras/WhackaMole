using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NO DEBERIA REPETIR NUMERO PERO SE REPITE
public class MolesManager : MonoBehaviour
{
    public List<GameObject> moles = new List<GameObject>();

    [SerializeField] float timeBetweenSpawns = 3f;

    int previous;

    private void Start()
    {
        for (int i = 0;i < moles.Count; i++)
        {
            moles[i].SetActive(false);
        }
        previous = moles.Count + 1;
        StartCoroutine(ChooseMole());
    }

    public GameObject GetMole()
    {
        int randomIndex = ChooseRandomNum();
        previous = randomIndex;
        return moles[randomIndex];
    }

    int ChooseRandomNum()
    {
        int randomInt = Random.Range(0, moles.Count);
        if (randomInt == previous)
        {
            randomInt = ChooseRandomNum();
        }
        return randomInt;
    }

    IEnumerator ChooseMole()
    {
        while (true)
        {
            GetMole().SetActive(true);
            
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
