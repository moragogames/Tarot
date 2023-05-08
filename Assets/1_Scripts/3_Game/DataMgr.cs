using Boomlagoon.JSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMgr : MonoBehaviour
{
    #region ΩÃ±€≈Ê

    private static DataMgr instance;
    public static DataMgr Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this);
                return;
            }
        }
        LoadTarotData();
    }
    #endregion

    private void Start()
    {
        
    }

    public Dictionary<TarotCategory, List<TarotData>> taroDataDic = new Dictionary<TarotCategory, List<TarotData>>();
    public Dictionary<TarotCategory, TarotMenuData> tarotMenuDic = new Dictionary<TarotCategory, TarotMenuData>();

#if UNITY_EDITOR
    public List<TarotData> tarotDataList = new List<TarotData>();
    public List<TarotMenuData> tarotMenuDataList = new List<TarotMenuData>();
#endif

    bool initTarotData;
    private void LoadTarotData()
    {
        if (initTarotData)
        {
            return;
        }
        initTarotData = true;
        JSONArray tarotArray = JSONArray.Parse(Resources.Load<TextAsset>("JSON/TarotData").text);
        for (int i = 0; i < tarotArray.Length; i++)
        {
            TarotData tData = new TarotData();

            tData.idx = tarotArray[i].Obj.GetString("index");
            tData.tarotCategory = System.Enum.Parse<TarotCategory>(tarotArray[i].Obj.GetString("category"));
            tData.card = Resources.Load<Sprite>("Images/" + tarotArray[i].Obj.GetString("card"));
            tData.mean = tarotArray[i].Obj.GetString("mean").Split('/');

            tData.ask = tarotArray[i].Obj.GetString("ask").Split('/');
            tData.answer = tarotArray[i].Obj.GetString("answer").Split('/');
            tData.end = tarotArray[i].Obj.GetString("end");

            if (!taroDataDic.ContainsKey(tData.tarotCategory))
            {
                taroDataDic.Add(tData.tarotCategory, new List<TarotData>());
            }
            taroDataDic[tData.tarotCategory].Add(tData);

#if UNITY_EDITOR
            tarotDataList.Add(tData);
#endif
        }
    }
    bool initTarotMenuData;
    private void LoadTarotMenuData()
    {
        if (initTarotMenuData)
        {
            return;
        }
        initTarotMenuData = true;
        
        JSONArray tarotMenuArray = JSONArray.Parse(Resources.Load<TextAsset>("JSON/TarotMenuData").text);
        //Debug.Log(tarotMenuArray);
        for (int i = 0; i < tarotMenuArray.Length; i++)
        {
            TarotMenuData tmenuData = new TarotMenuData();

            tmenuData.name = tarotMenuArray[i].Obj.GetString("name");
            tmenuData.tarotCategory = System.Enum.Parse<TarotCategory>(tarotMenuArray[i].Obj.GetString("category"));

            tarotMenuDic.Add(tmenuData.tarotCategory, tmenuData);


#if UNITY_EDITOR
            tarotMenuDataList.Add(tmenuData);
#endif
        }

    }


    public List<TarotData> GetTarotDatas(TarotCategory tarotCategory)
    {
        LoadTarotData();
        if (!taroDataDic.ContainsKey(tarotCategory))
        {
            return null;
        }
        return taroDataDic[tarotCategory];
    }

    public TarotMenuData GetTarotMenuData(TarotCategory tarotCategory)
    {
        LoadTarotMenuData();

        if (!tarotMenuDic.ContainsKey(tarotCategory))
        {
            return null;
        }

        return tarotMenuDic[tarotCategory];
    }

}
[System.Serializable]
public class TarotData
{
    public string idx;
    public TarotCategory tarotCategory;
    public Sprite card;
    public string[] mean;
    public string[] ask;
    public string[] answer;
    public string end;
}
[System.Serializable]
public class TarotMenuData
{
    public TarotCategory tarotCategory;
    public string name;
}
