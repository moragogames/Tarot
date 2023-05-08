using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    #region ΩÃ±€≈Ê
    private static User instance;
    public static User Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }

        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    #endregion

    public TarotCategory tarotCategory;


}
