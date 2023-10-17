using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterMovement _characterMovement;
    private PlayerCombat _playerCombat;

    // Start is called before the first frame update
    void Start()
    {
        _characterMovement = GetComponent<CharacterMovement>();
        _playerCombat = GetComponent<PlayerCombat>();
    }

    private void OnLaunchMarble(InputValue value)
    {
        if (value.isPressed)
        {
            _playerCombat.ChargeMarble();
        }
        else if (!value.isPressed)
        {
            _playerCombat.LaunchMarble();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
