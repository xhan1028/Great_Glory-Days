using System;
using Character.Player;
using Load.Scenes;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
  public class CharacterMarble :
    MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerMoveHandler,
    IPointerClickHandler
  {
    private Animator animator;

    public string characterName;

    public string characterDescription;

    public CharacterType type;

    private GameObject popup;

    private TextMeshProUGUI nameTMP;

    private TextMeshProUGUI descTMP;

    private SelectCharacter sceneStarter;

    [SerializeField]
    private GameObject clickDisplay;

    private void Awake()
    {
      animator = GetComponent<Animator>();
      popup = GameObject.Find("Popup");
      sceneStarter = FindObjectOfType<SelectCharacter>();
      var tmps = popup.GetComponentsInChildren<TextMeshProUGUI>();
      nameTMP = tmps[0];
      descTMP = tmps[1];
      HidePopup();
    }

    private void Update()
    {
      clickDisplay.SetActive(sceneStarter.curSelectedType == type);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
      animator.SetBool("Hover", true);
      ShowPopup();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      animator.SetBool("Hover", false);
      HidePopup();
    }

    public void OnPointerMove(PointerEventData eventData)
    {
      popup.transform.position = transform.position;
    }

    private void ShowPopup()
    {
      nameTMP.text = characterName;
      descTMP.text = characterDescription;
      popup.SetActive(true);
    }

    private void HidePopup()
    {
      popup.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      sceneStarter.curSelectedType = type;
    }
  }
}