using ArcadeVP;
using UnityEngine;

public class CarPlayer : MonoBehaviour, ICar
{
    public static CarPlayer CreateCar(CarSO carSO, Vector3 spawnPosition)
    {
        GameObject go = Instantiate(GameAssets.i.PlayerPrefabs[0], spawnPosition, Quaternion.identity);
        CarPlayer carAI = go.GetComponent<CarPlayer>();
        carAI.carSO = carSO;
        return carAI;
    }

    ArcadeVehicleController vehicleController;
    [SerializeField] CarSO carSO;

    public string CarName => carSO.CarName;

    private void Start()
    {
        vehicleController = GetComponent<ArcadeVehicleController>();
        vehicleController.MaxSpeed = carSO.MaxSpeed;
        vehicleController.accelaration = carSO.Accelaration;
        vehicleController.turn = carSO.TurnSpeed;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
