using UnityEngine;

public class PlayerGolds : MonoBehaviour
{
    [SerializeField] private int _gold = 0;

    public int Gold => _gold;

    public void AddGold()
    {
        _gold++;
    }
}
