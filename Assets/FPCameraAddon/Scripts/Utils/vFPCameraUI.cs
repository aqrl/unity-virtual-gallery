// SJM Tech
// www.sjmtech3d.com
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Invector;

namespace Invector.vCharacterController.vActions
{
    [vClassHeader(" FPCamera UI", "First Person Camera UI", iconName = "FPCameraIcon")]
    public class vFPCameraUI : vMonoBehaviour {
        Image CrosshairImage;

        [SerializeField] Sprite InteratableCrosshair;
        public GameObject ArtDisplayTransform; 
        public RectTransform ArtDisplayChildTransform;
        //[Header("Art Display Stats")]
        public TextMeshProUGUI Header,Description,Cost;
        public Button buyButton;
        Sprite DefaultCrosshair;
        private void Start()
        {
            var canvas= GetComponent<Canvas>();
            //canvas.worldCamera = Camera.main;
            canvas.planeDistance = .3f;
            CrosshairImage = GetComponentInChildren<Image>();
            DefaultCrosshair = CrosshairImage.sprite;
            ArtDisplayChildTransform.DOAnchorPosX(-ArtDisplayChildTransform.rect.width, 0);
            //ArtDisplayTransform.gameObject = Header.transform.parent.gameObject;
            ToggleDisplayScreen(false);
        }
        private void Update()
        {
            if (ArtDisplayTransform.activeSelf)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    ClosePanel();
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    buyButton.onClick.Invoke();
                }
            }
        }
        public void ToggleDisplayScreen(bool toggle)
        {
            ArtDisplayTransform.SetActive(toggle);
            CrosshairImage.gameObject.SetActive(!toggle);
        }
        public void ArtDisplay(Art_Details art_Details)
        {
            Header.text = "Header : " + art_Details.Header;
            Description.text = "Description : " + art_Details.Description;
            Cost.text = "Cost : " + art_Details.Cost;
            var tempUrl = art_Details.Link;
            buyButton.onClick.RemoveAllListeners();
            buyButton.onClick.AddListener(()=> {
                Application.OpenURL(tempUrl);
            });
            ToggleDisplayScreen(true);
            ArtDisplayChildTransform.DOAnchorPosX(0, .5f);
            
        }
        public void ClosePanel()
        {
            ArtDisplayChildTransform.DOAnchorPosX(-ArtDisplayChildTransform.rect.width, .5f).OnComplete(() => {
                ToggleDisplayScreen(false);
            });
        }
        public void CursorOnObject()
        {
            CrosshairImage.sprite = InteratableCrosshair;
        }
        public void CursorDefault()
        {
            CrosshairImage.sprite = DefaultCrosshair;
        }
    }
}