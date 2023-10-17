using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private GameObject _marblePrefab;
    [SerializeField] private int _initialMarbleActions = 2;
    [SerializeField] private float _marbleLaunchSpeed = 5;

    private int _currentMarbleActions;
    private bool _hasMarble;


    private Rigidbody2D _rb;
    private GameObject _currentMarble;

    // Start is called before the first frame update
    void Start()
    {
        _currentMarbleActions = _initialMarbleActions;
        _hasMarble = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void MeleeAttack()
    {

    }

    public void ChargeMarble()
    {

    }

    public void LaunchMarble()
    {
        if(_currentMarbleActions <= 0) { return; }

        Vector2 relativeMousePos = new Vector2();
        
        // instantiate the marble and have it initially ignore the collision it has with the player

        if (_hasMarble) 
        {
            _currentMarble = Instantiate(_marblePrefab);
            Physics2D.IgnoreCollision(_currentMarble.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
            relativeMousePos = GetRelativeMousePos(transform.position);
            _currentMarble.transform.position = transform.position;
            _hasMarble = false;
        }

        else 
        {
            relativeMousePos = GetRelativeMousePos(_currentMarble.transform.position); 
        }


        // get the marbles rigidbody, then apply a velocity to the rigidbody in relation the the mouse position
        _rb = _currentMarble.GetComponent<Rigidbody2D>();
        _rb.velocity = relativeMousePos * _marbleLaunchSpeed;
        _hasMarble = false;

        _currentMarbleActions--;
    }

    private Vector2 GetRelativeMousePos(Vector2 objPosition)
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 relativeMousePos = new Vector2(mouseWorldPos.x - objPosition.x, mouseWorldPos.y - objPosition.y).normalized;
        return relativeMousePos;
    }

    private void RicochetMarble()
    {

    }

    private void RecallMarble()
    {

    }

    private void TeleportToMarble()
    {

    }
}
