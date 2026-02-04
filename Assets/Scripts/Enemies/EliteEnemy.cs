using UnityEngine;

public class EliteEnemy : Enemy
{
    public SpriteRenderer superSprite;
    public Transform transform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    
    {
        base.Awake();
        superSprite = GetComponent<SpriteRenderer>(); //This line of code doesn't do anything and I'm not sure why, the SuperEagle still changes colour.
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        superSprite.color = Color.blue;
        transform.localScale = new Vector3(2,2,2);
        
        
    }
}
