using UnityEngine;

public class Shield : Bonuses
{
    public void OnEnable()
    {
        FullRefresh();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            DestroyBonus();
            Destroy(collision.gameObject);
        }
    }
}
