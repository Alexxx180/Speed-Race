using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public const int maxHp = 1;
    [Range(0, maxHp)] public int hp = 1;

    public GameObject menu;

    public float runSpeed = 40f;
    float horizontalMove = 0f;

    public int leftBorder = -250;
    public int rightBorder = 250;
    public Rigidbody2D body;
    private Vector3 _Velocity = Vector3.zero;

    public void Hurt()
    {
        hp--;
        if (hp <= 0)
        {
            menu.SetActive(true);
            gameObject.SetActive(false);
            hp = maxHp;
        }
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; //

    }

    private void FixedUpdate()
    {
        
        Vector3 targetVelocity = new Vector2(horizontalMove * 10f, body.velocity.y);
        // And then smoothing it out and applying it to the character
        body.velocity = Vector3.SmoothDamp(body.velocity, targetVelocity, ref _Velocity, 0.05f);
        //gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x + gameObject.transform.position.x * horizontalMove * Time.fixedDeltaTime, leftBorder, rightBorder), 0, 0);
        //Debug.Log(gameObject.transform.position.x + gameObject.transform.position.x * horizontalMove * Time.fixedDeltaTime);
        //Debug.Log(gameObject.transform.position);
    }
}
