using Unity.VisualScripting;
using UnityEngine;

public class WaterZone : Zone
{
    [Range(0f, 1f)]
    [SerializeField] private float speedModifier = 0.5f;
    protected override void ApplyZoneEffect(Player player)
    {
        // Change my player's speed modifier value
        player.ApplySpeedModifier(speedModifier);
    }
}
