using UnityEngine;

public class BarierMoves : MonoBehaviour
{
    // This list created according 
    // to best fit with game needs
    public float speed = 0.5f;
    public float sizeInc = 1f;
    public float moveInc = 2.464285714285714f;
    public int rotateX = 0;

    private readonly float _maxSize = 1.5f;
    private readonly float _yOffset = 1.115942028985507f;

    public void FixedUpdate()
    {
        Vector3 mem = transform.position;
        Vector3 size = transform.localScale;

        float timing = Time.fixedDeltaTime * speed * CurrentStats.speedUp;

        float x = mem.x + moveInc * rotateX * timing;
        float y = mem.y - moveInc * _yOffset * timing;
        float inc = size.x + sizeInc * timing;

        transform.position = new Vector3(x, y, 0);
        transform.localScale = new Vector3(inc, inc, inc);
        if (inc >= _maxSize)
            Destroy(gameObject);
    }
}