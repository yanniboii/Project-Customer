using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageUI : MonoBehaviour
{
    public List<string> messages = new List<string>();
    TMP_Text message;
    int messageIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        message= GetComponent<TMP_Text>();
    }

    public void SetNewMessage()
    {
        message.text= messages[messageIndex];
        messageIndex++;
    }
}
