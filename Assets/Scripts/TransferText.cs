using UnityEngine;
using UnityEngine.UI;

public class TransferText : MonoBehaviour
{
    public Text text;
    public InputField input;

    public void TransferDirect()
    {
        text.text = input.text;
    }
}
