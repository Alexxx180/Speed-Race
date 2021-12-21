using System.Collections;
using System.Collections.Generic;
using static System.Convert;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Input;
using static CurrentStats;

public class BonusesUsing : MonoBehaviour
{
    public List<Outline> bonuses;
    
    public int selected {
        get { return bonusSelection; }
        set { bonusSelection = value; }
    }

    public List<GameObject> bonusesReveal;

    private Text BonusCount(int select)
    {
        GameObject bonusObject = bonuses[select].gameObject;
        return bonusObject.GetComponentInChildren<Text>();
    }

    private bool DecreaseCount(Text value, int increment)
    {
        int count = ToInt32(value.text);
        count -= increment;
        if (count < 0)
            return false;
        value.text = count.ToString();
        return true;
    }

    private void IncreaseCount(Text value, int increment)
    {
        int count = ToInt32(value.text);
        count += increment;
        if (count <= 999)
            value.text = count.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ShieldBonus"))
            IncreaseCount(BonusCount(0), 1);
    }

    private void Activate()
    {
        bool isActivated = DecreaseCount(BonusCount(selected), 1);
        bonusesReveal[selected].SetActive(isActivated);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetButtonDown("UseBonus"))
        {
            BitArray conditions = new BitArray(
                new bool[] {
                    !bonusesReveal[0].activeSelf,
                    speedUp == 1,
                    coinsMultiplier == 1
                }
            );
            if (conditions[selected])
                Activate();
        }

        if (!GetButtonDown("BonusMove"))
            return;

        float axis = GetAxisRaw("Horizontal");
        if (axis > 0)
            SelectBonus(1);
        else if (axis < 0)
            SelectBonus(-1);
    }

    private void SelectBonus(int increment)
    {
        bonuses[selected].enabled = false;
        selected = Mathf.Clamp(selected + increment, 0, 2);
        bonuses[selected].enabled = true;
    }
}
