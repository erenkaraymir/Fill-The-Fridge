using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerManager : MonoBehaviour
{
    private GameObject _clickedObject;
    private Vector3 _mousePos;
    private Ray _ray;
    private RaycastHit hit;
    public LayerMask _layer;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickedObject = Ray();
            if(_clickedObject.TryGetComponent(out Box box))
            {
                box.OpenBox();
                ActiveBoxManager.Instance.SetActiveBox(_clickedObject);
                Debug.Log(_clickedObject.name);
            }
            else
            {
                Debug.Log("Componenta eriþilemedi");
            }
            if (_clickedObject.CompareTag("Holder") && _clickedObject.transform.parent.GetComponent<Box>().isActive == true)
            {
                PlaceToFridge.Instance.activeMilkHolder = _clickedObject.transform;
                PlaceToFridge.Instance.SmoothPlacer();
            }
        }

        else if (Input.GetMouseButton(0))
        {
            Debug.Log("Þuan yerleþim yapýyor");
        }
        else if (Input.GetMouseButtonUp(0))
        {
            PlaceToFridge.Instance.StopCorotine();
        }
        
    }

    GameObject Ray()
    {
        _mousePos = Input.mousePosition;
        _mousePos.z = Camera.main.transform.position.z;
        _ray = Camera.main.ScreenPointToRay(_mousePos);

        if (Physics.Raycast(_ray, out hit, Mathf.Infinity,_layer))
        {
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }
}
