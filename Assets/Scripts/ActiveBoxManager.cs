using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBoxManager : MonoBehaviour
{
    public GameObject activeBox;

    public static ActiveBoxManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public GameObject GetActiveBox()
    {
        return activeBox;
    }

    public void SetActiveBox(GameObject _activeBox)
    {
        activeBox = _activeBox; //
    }
}
