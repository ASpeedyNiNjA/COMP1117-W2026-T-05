using UnityEngine;
using UnityEngine.Events;

public class TremorZone : Zone
{

    public UnityEvent shock;
    private void Start()
    {
        InvokeRepeating("ShockwaveEvent", 1f, 2f);
    }

    protected override void ApplyZoneEffect(Player player)
    {
        Debug.Log("Tremor Zone");
        shock.Invoke();
    }
}
