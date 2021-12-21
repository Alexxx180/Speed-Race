using UnityEngine;
using UnityEngine.UI;

public class TransferText : MonoBehaviour
{
    public Text transfer;
    public InputField input;

    public void TransferDirect()
    {
        transfer.text = input.text;
    }
}