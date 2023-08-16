using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CarSO")]
public class CarSO : ScriptableObject
{
    public string CarName;
    public CarClass CarClass;
    public GameObject Prefab;
    public float MaxSpeed;
    public float Accelaration;
    public float TurnSpeed;
}

[System.Serializable]
public enum CarClass
{
    A, B, R, S, X
}