using UnityEngine;

public class EliteEnemy : Enemy
{
    public SpriteRenderer superSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    
    {
        base.Awake();
        superSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        superSprite.color = Color.blue;
        
    }
}
