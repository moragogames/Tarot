using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour
{
    [SerializeField] Image cardBackImage;
    [SerializeField] GameObject cardBackObj;
   
    public void BackCard(Sprite _card, bool _isCard)
    {
        cardBackImage.sprite = _card;
        cardBackObj.SetActive(_isCard);
    }
}
