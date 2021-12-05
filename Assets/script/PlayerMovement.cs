using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public GameObject shield;

    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;

    public void Awake()
    {
        PlayreData.shield = shield;
    }

    [SerializeField] LayerMask groundMask;
    private void FixedUpdate()
    {
        if (!alive)
            return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime * PlayreData.speedUp;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier * PlayreData.speedUp;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.y < -5)
            Die();
        if (Input.GetKeyDown(KeyCode.S))
            PlayreData.UseBonus();
        if (Input.GetKeyDown(KeyCode.A))
            PlayreData.bonusSelection = Mathf.Clamp(PlayreData.bonusSelection - 1, 0, 2);
        if (Input.GetKeyDown(KeyCode.D))
            PlayreData.bonusSelection = Mathf.Clamp(PlayreData.bonusSelection + 1, 0, 2);
    }

    

    public void Die()
    {
        alive = false;
        PlayreData.HardReset();
        // Restart the game
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
