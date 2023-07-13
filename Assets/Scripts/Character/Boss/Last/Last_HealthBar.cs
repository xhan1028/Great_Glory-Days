using UnityEngine;
using UnityEngine.UI;

namespace Character.Boss.Last
{
  public class Last_HealthBar : MonoBehaviour
  {
    [SerializeField]
    private Last_Hp lasthp;

    private Slider sliderhp;

    private void Awake()
    {
      sliderhp = GetComponent<Slider>();
    }

    private void Update()
    {
      sliderhp.value = lasthp.CurrentHP / lasthp.MaxHP;
    }
  }
}
