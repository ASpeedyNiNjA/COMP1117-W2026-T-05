using UnityEngine;

public class DeathZone : Zone
{
    protected override void ApplyZoneEffect(Player player)
    {
        //We can't access the family heirloom from here
        player.Die();


    }
}
