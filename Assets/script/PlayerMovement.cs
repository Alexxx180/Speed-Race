using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public GameObject shield;

    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;
    public float speedIncreasePerPoint = 0.1f;

    public int current = 0;
    public int delay = 50;

    public List<Outline> bonuses;

    public void Awake()
    {
        PlayreData.shield = shield;
    }

    [SerializeField] LayerMask groundMask;
    private void FixedUpdate()
    {
        if (!alive)
            return;

        current++;
        if (current >= delay)
        {
            current = 0;
            BonusesRetiming();
        }

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime * PlayreData.speedUp;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier * PlayreData.speedUp;
        //(rb.transform.position.x > -6 && rb.transform.position.x < 6) ?
            rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private Slider GetSlider(int no)
    {
        GameObject bonusObject = bonuses[no].gameObject;
        return bonusObject.GetComponent<Slider>();
    }

    private void SetSliderValue(int no)
    {
        Slider timeSlider = GetSlider(no);
        timeSlider.value = PlayreData.bonusesCount[no].time;
    }

    private void SetSliderActive(int no, bool isActive)
    {
        Slider timeSlider = GetSlider(no);
        timeSlider.enabled = isActive;
    }

    private void BonusesRetiming()
    {
        for (byte i = 0; i < PlayreData.bonusesCount.Count; i++)
        {
            if (PlayreData.bonusesCount[i].time >= 19)
            {
                PlayreData.bonusesCount[i].time--;
                SetSliderActive(i, true);
            }
            else if (PlayreData.bonusesCount[i].time >= 2)
            {
                PlayreData.bonusesCount[i].time--;
                SetSliderValue(i);
            }
            else if (PlayreData.bonusesCount[i].time == 1)
            {
                PlayreData.bonusesCount[i].time = 0;
                SetSliderActive(i, false);
                SetSliderValue(i);
            }
            Debug.Log(PlayreData.bonusesCount[i].time);
        }
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");//Input.GetButton("ChangeRoad") ? Input.GetAxis("Horizontal") : 0;

        if (transform.position.y < -5)
            Die();
        if (Input.GetKeyDown(KeyCode.S))
            PlayreData.UseBonus();
        if (Input.GetKeyDown(KeyCode.A))
        {
            bonuses[PlayreData.bonusSelection].enabled = false;
            PlayreData.bonusSelection = Mathf.Clamp(PlayreData.bonusSelection - 1, 0, 2);
            bonuses[PlayreData.bonusSelection].enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            bonuses[PlayreData.bonusSelection].enabled = false;
            PlayreData.bonusSelection = Mathf.Clamp(PlayreData.bonusSelection + 1, 0, 2);
            bonuses[PlayreData.bonusSelection].enabled = true;
        }
    }

    

    public void Die()
    {
        alive = false;
        PlayreData.HardReset();
        // Restart the game
        Restart();
        //Invoke("Restart");
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
