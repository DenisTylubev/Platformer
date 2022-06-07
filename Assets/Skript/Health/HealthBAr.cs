using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBAr : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    private void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealyh / 6;
    }
    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealyh /6;
    }
}
