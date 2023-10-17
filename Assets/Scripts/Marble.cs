using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : MonoBehaviour
{
    private bool _isActionable;
    private GameObject _marbleParent;

    public bool IsActionable => _isActionable;

    public void SetParent(GameObject marbleParent)
    {
        _marbleParent = marbleParent;
    }

    public void SetIsActionable(bool isActionable)
    {
        _isActionable = isActionable;
    }
}
