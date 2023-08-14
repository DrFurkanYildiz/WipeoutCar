using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAISpawner : MonoBehaviour
{
    public Transform[] spwnArray;
    public int coin;
    public int[] testLevel;
    private LevelSystem levelSystem;
    public int level;
    public int exp;

    private CarPlayer carPlayer;
    [SerializeField] private CarSO playerCarSO;

    void Start()
    {

        levelSystem = new LevelSystem(testLevel);
        levelSystem.OnLevelChanged += () => playerCarSO.MaxSpeed += 2f;

        SpawnPlayer();

        CarAI.CreateCar(GameAssets.i.CarList[0], spwnArray[2].position);

        //StartCoroutine(SpawnCar());
    }
    private void Update()
    {
        level = levelSystem.GetLevel();
        exp = levelSystem.GetExperience();
    }
    public void Test()
    {
        levelSystem.AddExperience(10);
    }
    public void SpawnPlayer()
    {
        if (carPlayer != null)
            carPlayer.DestroySelf();


        carPlayer = CarPlayer.CreateCar(playerCarSO, spwnArray[4].position);
    }
    IEnumerator SpawnCar()
    {
        for (int i = 0; i < spwnArray.Length; i++)
        {
            CarAI.CreateCar(GameAssets.i.CarList[i], spwnArray[i].position);
            yield return new WaitForSeconds(.5f);
        }
    }
}
