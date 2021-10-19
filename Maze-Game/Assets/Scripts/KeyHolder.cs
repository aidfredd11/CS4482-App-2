using System;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    public event EventHandler OnKeyChanged;

    private Key.KeyType currentKey; // key that the player has

    public Key.KeyType GetKey()
    {
        return currentKey;
    }

    public void AddKey(Key.KeyType keyType)
    {
        currentKey = keyType;
        OnKeyChanged?.Invoke(this, EventArgs.Empty); // update the UI
    }

    public void RemoveKey()//Key.KeyType keyType)
    {
        currentKey = Key.KeyType.None;
        OnKeyChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        if (currentKey == keyType)
            return true;
        else
            return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Key key = other.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        KeyDoor keyDoor = other.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
            if (ContainsKey(keyDoor.GetKeyType()))
            {
                //currently holding the key to open the door
                RemoveKey();
                keyDoor.OpenDoor();
            }
        }
    }
}
