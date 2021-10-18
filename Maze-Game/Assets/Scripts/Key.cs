using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
    public enum KeyType
    {
        Green,
        Black,
        Blue,
        None
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }
}
