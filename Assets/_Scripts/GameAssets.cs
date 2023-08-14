using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    #region Singleton
    public static GameAssets i { get; private set; }
    private void Awake()
    {
        if (i == null)
        {
            i = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    #endregion

    public Joystick joystick;
    public GameObject[] PlayerPrefabs;

    [SerializeField] private List<CarSO> aiCarList = new List<CarSO>();
    public List<CarSO> CarList => aiCarList;
    public CarSO GetCarSO(CarClass carClass)
    {
        return aiCarList.Find(c => c.CarClass == carClass);
    }
}