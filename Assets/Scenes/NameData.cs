using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameData : MonoBehaviour
{
    public List<GameObject> characters;
    public void Awake()
    {
        gameObject.GetComponent<Text>().text = PlayreData.passName;
        for(byte i = 0; i < characters.Count; i++)
            characters[i].SetActive(false);
        characters[PlayreData.no].SetActive(true);
    }
}
