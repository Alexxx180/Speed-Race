using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusesUsing : MonoBehaviour
{
    public List<Outline> bonuses;
    
    public int selected {
        get { return CurrentStats.bonusSelection; }
        set
        {
            CurrentStats.bonusSelection = value;
        }
    }


    public List<GameObject> bonusesReveal;

    private Text BonusCount(int select)
    {
        GameObject bonusObject = bonuses[select].gameObject;
        return bonusObject.GetComponentInChildren<Text>();
    }

    private bool DecreaseCount(Text value)
    {
        int count = Convert.ToInt32(value.text);
        count--;
        if (count < 0)
            return false;
        value.text = count.ToString();
        return true;
    }

    private void IncreaseCount(Text value)
    {
        int count = Convert.ToInt32(value.text);
        count++;
        if (count <= 999)
            value.text = count.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ShieldBonus"))
        {
            IncreaseCount(BonusCount(0));
        }
    }

    private void Activate()
    {
        if (DecreaseCount(BonusCount(selected)))
            bonusesReveal[selected].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("UseBonus"))
        {
            BitArray conditions = new BitArray(
                new bool[] {
                    !bonusesReveal[0].activeSelf,
                    CurrentStats.speedUp == 1,
                    CurrentStats.coinsMultiplier == 1
                }
            );
            if (conditions[selected])
                Activate();
        }

        if (Input.GetButtonDown("BonusMove") && Input.GetAxisRaw("Horizontal") > 0)
        {
            bonuses[selected].enabled = false;
            selected = Mathf.Clamp(selected + 1, 0, 2);
            bonuses[selected].enabled = true;
        }
        else if (Input.GetButtonDown("BonusMove") && Input.GetAxisRaw("Horizontal") < 0)
        {
            bonuses[selected].enabled = false;
            selected = Mathf.Clamp(selected - 1, 0, 2);
            bonuses[selected].enabled = true;
        }
    }
}
