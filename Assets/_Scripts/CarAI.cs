using ArcadeVP;
using UnityEngine;

public class CarAI : MonoBehaviour, ICar
{
    public static CarAI CreateCar(CarSO carSO, Vector3 spawnPosition)
    {
        GameObject go = Instantiate(carSO.Prefab, spawnPosition, Quaternion.Euler(Vector3.up * 120f));
        CarAI carAI = go.GetComponent<CarAI>();
        carAI.carSO = carSO;
        return carAI;
    }

    ArcadeAiVehicleController vehicleController;
    [SerializeField] CarSO carSO;
    private bool setStart;

    public string CarName { get => carSO.CarName; }

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
    public void SetStart(bool set)
    {
        setStart = set;
    }
}
