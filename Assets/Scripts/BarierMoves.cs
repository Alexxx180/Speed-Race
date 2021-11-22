using UnityEngine;

public class BarierMoves : MonoBehaviour
{
    public float speed = 0.5f;
    public float sizeInc = 1f;
    public float moveInc = 2.464285714285714f;
    public int rotateX = 0;

    private Vector3 minPosition = new Vector3(-35f, 60f, 0f);
    private Vector3 minSize = new Vector3(0.1f, 0.1f, 0.1f);

    private Vector3 maxPosition = new Vector3(-380f, -385f, 0f);
    private Vector3 maxSize = new Vector3(1.5f, 1.5f, 1.5f);

    public void Awake()
    {
        sizeInc *= speed;
        moveInc *= speed;
    }

    public void Update()
    {
        Vector3 mem = gameObject.transform.position;
        Vector3 size = gameObject.transform.localScale;
        
        float x = mem.x - (moveInc * rotateX) * Time.deltaTime;
        float y = mem.y - moveInc * 1.115942028985507f * Time.deltaTime;
        float inc = size.x + sizeInc * Time.deltaTime;
        gameObject.transform.position = new Vector3(x, y, 0);
        gameObject.transform.localScale = new Vector3(inc, inc, inc);
        if (inc >= maxSize.x)
            Destroy(gameObject);
    }
}
