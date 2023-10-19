using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : MonoBehaviour
{
    private bool _isActionable;
    private bool _canBePickedUp;

    private GameObject _marbleParent;
    private Collider2D _marbleCollider;

    public bool CanBePickedUp => _canBePickedUp;
    public bool IsActionable => _isActionable;

    private void Start()
    {
        _marbleCollider = GetComponent<Collider2D>();
    }

    public void SetParent(GameObject marbleParent)
    {
        _marbleParent = marbleParent;
    }

    public void SetIsActionable(bool isActionable)
    {
        _isActionable = isActionable;
    }

    public void SetCanBePickedUp(bool canBePickedUp)
    {
        _canBePickedUp = canBePickedUp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
        if (!_isActionable)
        {
            _isActionable = true;
        }
        if (!_canBePickedUp)
        {
            _canBePickedUp = true;
        }
    }
}
