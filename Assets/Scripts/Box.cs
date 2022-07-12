using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Box : MonoBehaviour
{
    [Header("Target Position")]
    [SerializeField] private Vector3 _destinationPos;

    [Space]

    [Header("Speed For DOTween")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private Collider _collider;
    private Vector3 _startPos;

    public bool isActive;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _startPos = transform.position;
    }

    public void OpenBox()
    {
        transform.DOMove(_destinationPos, _moveSpeed);
        transform.DORotate(new Vector3(0,-90,45),_rotateSpeed).OnComplete(() => { isActive = true; });
        _collider.enabled = false;
    }

    public void CloseBox()
    {
        transform.DOMove(_startPos, _moveSpeed);
        transform.DORotate(new Vector3(0, -90, 0), _rotateSpeed).OnComplete(() => { isActive = false; });
        _collider.enabled = true;
    }


}
