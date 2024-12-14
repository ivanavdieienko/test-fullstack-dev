using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig", order = 1)]

public class GameConfig : ScriptableObject
{
    [SerializeField]
    private float longPressTimeInSeconds = 1f;

    [SerializeField]
    private float liftAltitude = 1f;

    [SerializeField]
    private float snapRange = 0.5f;

    public float LongPressTimeInSeconds => longPressTimeInSeconds;
    public float LiftAltitude => liftAltitude;
    public float SnapRange => snapRange;
}
