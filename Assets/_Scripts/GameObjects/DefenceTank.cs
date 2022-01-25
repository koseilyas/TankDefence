using UnityEngine;

public class DefenceTank : MonoBehaviour
{
    public DefenceTankSpecs defenceTankSpecs;
    private bool _isActive;

    public void Activate()
    {
        _isActive = true;
    }
}