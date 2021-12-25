using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerData;

public class NameData : MonoBehaviour
{
    public List<GameObject> characters;

    private void Activate(int no, bool active)
    {
        characters[no].SetActive(active);
    }

    public void Awake()
    {
        gameObject.GetComponent<Text>().text = passName;
        for(byte i = 0; i < characters.Count; i++)
            Activate(i, false);
        Activate(no, true);
    }
}