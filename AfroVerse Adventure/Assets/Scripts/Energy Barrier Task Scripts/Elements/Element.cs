using UnityEngine;

[CreateAssetMenu(fileName = "New Element", menuName = "Element/Create New Element", order = 51)]
public class Element : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] public Sprite Icon;
}
