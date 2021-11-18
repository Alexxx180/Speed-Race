using UnityEngine;

public class BarierMoves : MonoBehaviour
{
    public float speed = 4f;
    //public Rigidbody body;
    public void Update()
    {
        
        //Vector3 targetVelocity = new Vector2(horizontalMove * 10f, body.velocity.y);
        // And then smoothing it out and applying it to the character
        //body.velocity = Vector3.SmoothDamp(body.velocity, targetVelocity, ref _Velocity, 0.05f);


        Vector3 mem = gameObject.transform.position;
        float z = mem.z - 4.385964912280702f * Time.deltaTime;
        float y = mem.y - 1 * Time.deltaTime;
        gameObject.transform.position = new Vector3(mem.x, y, Mathf.Clamp(z, 0, 1500));
        if (y <= -200f)
            Destroy(gameObject);
    }
}
