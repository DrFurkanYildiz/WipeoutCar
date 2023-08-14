using ArcadeVP;
using UnityEngine;

public class CarAI : MonoBehaviour
{
    public static CarAI CreateCar(CarSO carSO, Vector3 spawnPosition)
    {
        GameObject go = Instantiate(carSO.Prefab ,spawnPosition, Quaternion.identity);
        CarAI carAI = go.GetComponent<CarAI>();
        carAI.carSO = carSO;
        return carAI;
    }

    ArcadeAiVehicleController vehicleController;
    [SerializeField] CarSO carSO;
    [SerializeField] private bool setStart;
    private void Start()
    {
        vehicleController = GetComponent<ArcadeAiVehicleController>();
        vehicleController.MaxSpeed = carSO.MaxSpeed;
        vehicleController.accelaration = carSO.Accelaration;
        vehicleController.turn = carSO.TurnSpeed;
    }
    private void Update()
    {
        vehicleController.IsStart = setStart;
    }
}
