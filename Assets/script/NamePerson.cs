using UnityEngine;
using UnityEngine.UI;

public class NamePerson : MonoBehaviour
{
    public InputField text;

    public void TransferText()
    {
        PlayreData.passName = text.text;
    }

    public void PlayerSelect(int select)
    {
        PlayreData.no = select;
    }
}
