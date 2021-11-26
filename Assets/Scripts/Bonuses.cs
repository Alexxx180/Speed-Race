using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bonuses : MonoBehaviour
{
    public List<Outline> bonuses;
    public int selected = 0;

    public GameObject shield;
    
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

    private void ActivateShield()
    {
        if (DecreaseCount(BonusCount(selected)))
            shield.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("UseBonus"))
        {
            switch (selected)
            {
                case 0:
                    if (!shield.activeSelf)
                        ActivateShield();
                    break;
                default:
                    break;
            }
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
