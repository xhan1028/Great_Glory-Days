using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    [SerializeField]
    private PlayerHp playerHp;
    private Slider sliderHp;

    private void Awake()
    {
        sliderHp = GetComponent<Slider>();
    }

    private void Update()
    {
        sliderHp.value = playerHp.CurrentHp / playerHp.MaxHp; // 현재 체력 정보 업데이트
    }
}
