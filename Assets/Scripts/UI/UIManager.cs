using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image hearth1, hearth2, hearth3;
    [SerializeField] Sprite emptyHearth, fullHearth;
    PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = Object.FindObjectOfType<PlayerHealth>();
    }

    public void HealthState()
    {
        switch (playerHealth.health)
        {
            case 3:
                hearth1.sprite = fullHearth;
                hearth2.sprite = fullHearth;
                hearth3.sprite = fullHearth;
                break;
            case 2:
                hearth1.sprite = fullHearth;
                hearth2.sprite = fullHearth;
                hearth3.sprite = emptyHearth;
                break;
            case 1:
                hearth1.sprite = fullHearth;
                hearth2.sprite = emptyHearth;
                hearth3.sprite = emptyHearth;
                break;
            case 0:
                hearth1.sprite = emptyHearth;
                hearth2.sprite = emptyHearth;
                hearth3.sprite = emptyHearth;
                break;
        }
    }
}
