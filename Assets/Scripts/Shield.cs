using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public Text duration;
    public int delay = 10;
    public int current = 0;
    public int time = 20;
    public int maxTime = 20;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            DestroyShield();
            Destroy(collision.gameObject);
        }
    }

    public void OnEnable()
    {
        time = maxTime;
        current = 0;
    }

    private void DestroyShield()
    {
        gameObject.SetActive(false);
    }

    private void DecreaseDuration()
    {
        time--;
        duration.text = time.ToString();
    }

    void FixedUpdate()
    {
        if (time <= 0)
        {
            DestroyShield();
            return;
        }
        current++;
        if (current > delay)
        {
            current = 0;
            DecreaseDuration();
        }
    }
}
