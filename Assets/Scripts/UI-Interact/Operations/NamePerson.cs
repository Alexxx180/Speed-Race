using UnityEngine;
using UnityEngine.UI;
using static PlayerData;

public class NamePerson : MonoBehaviour
{
    public InputField text;

    public void TransferText()
    {
        passName = text.text;
    }

    public void PlayerSelect(int select)
    {
        no = select;
    }
}
