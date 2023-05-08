using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameMgr : MonoBehaviour
{
    
    [SerializeField] TarotData[] tarotDatas;

    [SerializeField] TMP_Text dialogText;
    [SerializeField] TMP_Text[] PlayerText;
    [SerializeField] GameObject nextBtn;

    int curCard;
    int nextDialog;

   
    private void Start()
    {
        Debug.Log("����Ǿߵ� ���� : " + User.Instance.tarotCategory);
        tarotDatas = DataMgr.Instance.GetTarotDatas(User.Instance.tarotCategory).ToArray();
        Init();


    }

    [SerializeField] CardInfo cardInfo;
     Sprite tCards;

    public void Init()
    {
        nextBtn.SetActive(false);
        nextDialog = -1;
    }

    public void RandomTarotCard()
    {
        int rand = Random.Range(0, tarotDatas.Length);
        tCards =tarotDatas[rand].card;
        curCard = rand;
    }

    public void ClickCardOpen()
    {
        StartCoroutine("TarotCardOpen"); // �ڷ�ƾ ����
    }

    IEnumerator TarotCardOpen() // Ÿ�� ī�� ����
    {
        RandomTarotCard();
        cardInfo.BackCard(tCards, true);
        Debug.Log(tCards.name);
        yield return new WaitForSeconds(1);
        nextBtn.SetActive(true);
    }

    IEnumerator CoTypingText()
    {
        for (int i = 0; i < tarotDatas[curCard].mean[nextDialog].Length+1; i++)
        {
            dialogText.text = tarotDatas[curCard].mean[nextDialog].Substring(0, i);
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void NextDialog()
    {
        nextDialog++;
        StartCoroutine("CoTypingText");
        Debug.Log(nextDialog);
    }




#if UNITY_EDITOR
    public void Back()
    {
        SceneManager.LoadScene("2_MenuScene");
    }

#endif


}
