using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CategoryBtn : MonoBehaviour
{
    [SerializeField] TMP_Text MenuText;
    [SerializeField] TarotCategory tarotCategory;


    private void Awake()
    {
    }
    private void Start()
    {
        MenuText = GetComponentInChildren<TMP_Text>();
        tarotCategory = (TarotCategory)GetComponent<RectTransform>().GetSiblingIndex();

        TarotMenuData tdata = DataMgr.Instance.GetTarotMenuData(tarotCategory);

        MenuText.text = tdata.name;

        GetComponent<Button>().onClick.AddListener(OnClickMenu);


    }

    public void OnClickMenu()
    {
        User.Instance.tarotCategory = tarotCategory;
        SceneManager.LoadScene("3_CardScene");
    }


}
public enum TarotCategory
{
    love,
    today,
}
