using UnityEngine;
using System.Collections;

public enum HealthState
{
    PERSONAL = 0,
    BLUEBASE = 1,
    REDBASE = 2
}

public class HealthBar : MonoBehaviour 
{
    public Sprite[] healthBar;
    public HealthState healthState;
    int placeholderHp = 1000;

    void Update()
    {
        switch (healthState)
        {
            default: // This is just for testing
                GetComponent<UnityEngine.UI.Image>().sprite = healthBar[placeholderHp / 100];

                if (placeholderHp <= 0)
                    placeholderHp = 1000;

                if (Input.GetKey(KeyCode.N))
                    placeholderHp--;
                break;

            case HealthState.PERSONAL:
                GetComponent<UnityEngine.UI.Image>().sprite = healthBar[(int)Health.currentHitPoint / 10];

                break;

            case HealthState.BLUEBASE:
                GetComponent<UnityEngine.UI.Image>().sprite = healthBar[(int)Basehealth1.currentHitPoint / 100];
                break;

            case HealthState.REDBASE:
                GetComponent<UnityEngine.UI.Image>().sprite = healthBar[basehealthteam2.currentHitPoint / 100];
                break;

        }
    



    }
}
