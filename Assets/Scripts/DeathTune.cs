using UnityEngine;

class DeathTune : MonoBehaviour, Spawnable
{
    private PlayerID owner;
    private bool crit;

    public void Crit(bool crit)
    {
        this.crit = crit;
    }

    public void Owner(PlayerID owner)
    {
        this.owner = owner;
    }

    // Use this for initialization
    void Start()
    {
        PlayerLife[] lifes = FindObjectsOfType<PlayerLife>() as PlayerLife[];
        foreach (PlayerLife l in lifes)
        {

            if (crit)
            {
                if (l.gameObject.GetComponent<BaseControl>().player != owner)
                    l.DealDamage(1f);
            }
            else
            {
                if (l.gameObject.GetComponent<BaseControl>().player == owner)
                    l.DealDamage(.75f);
            }
        }
        Destroy(transform.root.gameObject);
    }
}
