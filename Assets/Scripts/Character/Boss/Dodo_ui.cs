using UnityEngine;
using UnityEngine.UI;

namespace Character.Boss
{
	public class Dodo_ui : MonoBehaviour
	{
		public DODO_Option dodo_option;
		public Slider slider;

		void Start()
		{
			slider.maxValue = dodo_option.health;
		}

		void Update()
		{
			slider.value = dodo_option.health;
		}
	}
}
