using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public const int maxHp = 1;
    [Range(0, maxHp)] public int hp = 1;

    public GameObject shield;
    public GameObject menu;

    public void Hurt()
    {
        hp--;
        if (hp <= 0)
        {
            menu.SetActive(true);
            shield.SetActive(false);
            CurrentStats.speedUp = 1;
            CurrentStats.coinsMultiplier = 1;
            gameObject.SetActive(false);
            hp = maxHp;
        }
    }

    
}
