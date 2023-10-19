using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : MonoBehaviour
{
    private bool _isActionable;
    [SerializeField] private bool _canBePickedUp;

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
        
        if (canBePickedUp == true)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), _marbleParent.GetComponent<Collider2D>(), false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == _marbleParent)
        {
            _marbleParent.GetComponent<PlayerCombat>().SetHasMarble(true);
            _marbleParent.GetComponent<PlayerCombat>().ResetMarbleActions();
            Destroy(this.gameObject);
            return;
        }

        if (!_isActionable)
        {
            _isActionable = true;
        }
        if (!_canBePickedUp)
        {
            SetCanBePickedUp(true);
        }
    }
}
