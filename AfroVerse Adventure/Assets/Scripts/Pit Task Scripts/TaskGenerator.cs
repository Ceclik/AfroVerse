using UnityEngine;

public class TaskGenerator : MonoBehaviour
{ 
    public int FirstTerm { get; private set; }
    public int SecondTerm { get; private set; }
    public int CorrectAnswer { get; private set; }
    public int NumberOfCorrectDoor { get; private set; }

    private void Awake()
    {
        NumberOfCorrectDoor = Random.Range(1, 4);
        FirstTerm = Random.Range(1, 9);
        SecondTerm = Random.Range(1, 9);
        CorrectAnswer = FirstTerm + SecondTerm;
    }
}

