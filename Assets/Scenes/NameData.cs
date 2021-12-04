using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameData : MonoBehaviour
{
    public List<GameObject> characters;
    public void Awake()
    {
        gameObject.GetComponent<Text>().text = PlayreData.passName;
        characters[0].SetActive(false);
        characters[1].SetActive(false);
        characters[2].SetActive(false);
        characters[3].SetActive(false);
        characters[PlayreData.no].SetActive(true);
    }
}
