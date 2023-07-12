using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  public class ProgressBar : MonoBehaviour
  {
    [SerializeField]
    private Image targetImg;

    private float _maxValue;

    public float maxValue
    {
      get => _maxValue;
      set
      {
        _maxValue = value;
        this.value = this.value;
      }
    }
    
    private float _value;

    public float value
    {
      get => _value;
      set
      {
        _value = Mathf.Clamp(value, 0, maxValue) ; 
        Refresh();
      }
    }

    private void Refresh()
    {
      targetImg.fillAmount = value / maxValue;
    }
  }
}