using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarAISpawner : MonoBehaviour
{
    private List<CarAI> allCars = new List<CarAI>();
    public Transform[] spwnArray;
    private int countdownTime = 3;
    private CarPlayer carPlayer;
    [SerializeField] private CarSO playerCarSO;

    [SerializeField] private TextMeshProUGUI countdownText;

    void Start()
    {

        SpawnPlayer();

        CarAI car = CarAI.CreateCar(GameAssets.i.CarList[0], spwnArray[1].position);
        allCars.Add(car);

        StartCoroutine(CountdownStart());
        //StartCoroutine(SpawnCar());
    }
    public void Test()
    {
        LevelManager.Instance.LoadScene(SceneType.Main);   
    }
    public void SpawnPlayer()
    {
        if (carPlayer != null)
            carPlayer.DestroySelf();


        carPlayer = CarPlayer.CreateCar(playerCarSO, spwnArray[0].position);
    }
    IEnumerator SpawnCar()
    {
        for (int i = 0; i < spwnArray.Length; i++)
        {
            if (i == 4)
                continue;
            CarAI car = CarAI.CreateCar(GameAssets.i.CarList[i], spwnArray[i].position);
            allCars.Add(car);
            yield return new WaitForSeconds(.05f);
        }
    }


    IEnumerator CountdownStart()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            //DontDestroyAudio.Instance.EffectOneShot(SoundType.BonusCountdownEffect);

            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        countdownText.text = "GO!";
        //DontDestroyAudio.Instance.EffectOneShot(SoundType.BonusCountdownStartEffect);

        //GameStart

        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);
        //isTimeCompleted = false;
        allCars.ForEach(c => c.SetStart(true));
    }
}
