using UnityEngine;

public class GravityZone : Zone
{
    protected override void ApplyZoneEffect(Player player)
    {
        player.Gravity();
    }
}
