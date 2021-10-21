using UnityEngine;
using UnityEngine.UI;

public class UI_KeyHolder : MonoBehaviour
{
    [SerializeField] private KeyHolder keyHolder;

    public Sprite greenKey, blueKey, blackKey;
    private Transform container;

    private void Awake()
    {
        container = transform.Find("container");
        container.gameObject.SetActive(false);
    }

    private void Start()
    {
        keyHolder.OnKeyChanged += KeyHolder_OnKeyChanged; // subsribe to the key changed event
    }

    private void KeyHolder_OnKeyChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        Key.KeyType keyType = keyHolder.GetKey();
        container.gameObject.SetActive(true);
        Image keyImage = container.Find("image").GetComponent<Image>();

        // set the image to be enabled and the sprite when the player has a key
        if (keyType == Key.KeyType.Green || keyType == Key.KeyType.Black || keyType == Key.KeyType.Blue)
        {
            keyImage.enabled = true; // they have a key so enable the image
            switch (keyType)
            {
                case Key.KeyType.Green: keyImage.sprite = greenKey; break;
                case Key.KeyType.Blue: keyImage.sprite = blueKey; break;
                case Key.KeyType.Black: keyImage.sprite = blackKey; break;
            }
        }
        else // player has no key so disable image
        {
            keyImage.enabled = false;
        }
    }
}
