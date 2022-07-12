using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject activeBox;
    private Box box;
    public void BackToFridge()
    {
        activeBox = ActiveBoxManager.Instance.GetActiveBox();
        box = activeBox.GetComponent<Box>();
        if (box.isActive == true)
        {
            activeBox.GetComponent<Box>().CloseBox();
        }
        else
        {
            Debug.Log("Box henüz active degl");
        }
    }

}
