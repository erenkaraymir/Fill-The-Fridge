using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHolderData : MonoBehaviour
{
    [SerializeField] private List<GameObject> milkConteiner;
    private GameObject temp;

    public GameObject GetMilk(Transform holder)
    {
        temp =  milkConteiner[0];
        milkConteiner.Remove(temp);
        temp.transform.parent = holder;
        return temp;
    }
}
