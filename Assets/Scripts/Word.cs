
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Word")]
public class Word : ScriptableObject
{
    [SerializeField] public string word;
    [SerializeField] public string def;
}
