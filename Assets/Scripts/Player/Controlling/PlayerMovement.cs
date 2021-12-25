using System.Collections.Generic;
using static System.Convert;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.SceneManagement.SceneManager;
using static PlayerData;
using static Timing;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;
    public float speedIncreasePerPoint = 0.1f;

    public List<Outline> bonuses;

    private void FixedUpdate()
    {
        if (!alive)
            return;
        BonusesRetiming();

        float totalSpeed = speed * Time.fixedDeltaTime * speedUp;
        float horizontal = horizontalInput * horizontalMultiplier;
        Vector3 forwardMove = transform.forward * totalSpeed;
        Vector3 horizontalMove = transform.right * horizontal * totalSpeed;
        rb.MovePosition(rb.position + forwardMove);

        float check = rb.position.x + horizontalMove.x;
        if (check > -6.025f && check < 5.975f)
            rb.MovePosition(rb.position + horizontalMove);
    }

    private Slider GetSlider(int no)
    {
        GameObject bonusObject = bonuses[no].gameObject;
        return bonusObject.GetComponent<Slider>();
    }

    public void SetSliderValue(int no, byte time)
    {
        Slider timeSlider = GetSlider(no);
        timeSlider.value = time;
    }

    private void BonusesDecreaseTime(TimeBonus bonus, byte no)
    {
        byte time = bonus.time;
        if (time > ToByte(1))
        {
            bonus.time--;
            SetSliderValue(no, time);
        }
        else if (time == ToByte(1))
        {
            bonus.time = 0;
            SetSliderValue(no, time);
            DropBonusEffect(no);
        }
    }

    private void BonusesRetiming()
    {
        if (NoBeat)
            return;

        for (byte i = 0; i < bonusesCount.Count; i++)
        {
            TimeBonus bonus = bonusesCount[i];
            if (bonus.time <= ToByte(0))
                continue;
            BonusesDecreaseTime(bonus, i);
        }
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -1)
            Die();
        if (Input.GetKeyDown(KeyCode.S))
            UseBonus();
        if (Input.GetKeyDown(KeyCode.A))
            SelectBonus(-1);
        if (Input.GetKeyDown(KeyCode.D))
            SelectBonus(1);
    }

    public void SelectBonus(int increment)
    {
        bonuses[bonusSelection].enabled = false;
        bonusSelection = Mathf.Clamp(bonusSelection + increment, 0, 2);
        bonuses[bonusSelection].enabled = true;
    }
    

    public void Die()
    {
        alive = false;
        HardReset();
        Restart();
    }

    void Restart()
    {
        LoadScene(GetActiveScene().name);
    }
}
