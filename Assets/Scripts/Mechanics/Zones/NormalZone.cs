using UnityEngine;

public class NormalZone : Zone
{

    protected override void ApplyZoneEffect(Player player)
    {
        player.Normal();
    }
}
