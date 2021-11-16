using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHp = 1;
    [Range(0..maxHp)] public int hp = 1;

    public GameObject menu;

    public float runSpeed = 40f;
    float horizontalMove = 0f;

    public int leftBorder = -250;
    public int rightBorder = 250;

    private void Hurt()
    {
        hp--;
        if (hp <= 0)
        {
            menu.SetActive(true);
        }
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")) * runSpeed;
        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x * horizontalMove, leftBorder, rightBorder), 0, 0);
    }
}
