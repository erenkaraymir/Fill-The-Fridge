using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceToFridge : MonoBehaviour
{
    public Transform activeMilkHolder;
    public static PlaceToFridge Instance;
    [SerializeField] private GameObject _milkPrefab;
    private GameObject _tempMilk;
    private float multipleValue;
    [SerializeField] private FoodHolderData milkHolder;
    [SerializeField] private int clampRow;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void PlaceToHolder()
    {
        multipleValue = activeMilkHolder.childCount;
        if (multipleValue < clampRow)
        {
            _tempMilk = milkHolder.GetMilk(activeMilkHolder);
            //_tempMilk = Instantiate(_milkPrefab, activeMilkHolder);
            _tempMilk.transform.localPosition = new Vector3(multipleValue * .25f, 0f, 0f);
            _tempMilk.transform.localRotation = Quaternion.Euler(new Vector3(-90f,90f,90f));
        }
    }

    IEnumerator CO_Place()
    {
        PlaceToHolder();
        yield return new WaitForSeconds(.2f);
        StartCoroutine(CO_Place());
    }

    public void SmoothPlacer()
    {
        StartCoroutine(CO_Place());
    }

    public void StopCorotine()
    {
        //StopCoroutine(CO_Place());
        StopAllCoroutines();
        Debug.Log("Timer çalýþmayý  durdurdu");
    }
}
