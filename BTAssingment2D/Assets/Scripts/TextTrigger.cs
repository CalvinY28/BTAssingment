using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public TextMeshProUGUI textToChange;
    public string Message = "You did it! :)";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textToChange.text = Message;
        }
    }
}
