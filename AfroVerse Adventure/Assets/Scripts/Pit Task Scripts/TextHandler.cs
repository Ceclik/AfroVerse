using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    [SerializeField] private Text _taskText;

    [SerializeField] private Text _firstDoorText;
    [SerializeField] private Text _secondDoorText;
    [SerializeField] private Text _thirdDoorText;

    [SerializeField] private TaskGenerator _taskGenerator;

    private int _randomRange;

    private void Start()
    {
        _taskGenerator = GetComponent<TaskGenerator>();
        SetTaskText();
        SetFirstDoorText();
        SetSecondDoorText();
        SetThirdDoorText();
    }

    private void SetTaskText()
    {
        _taskText.text = $"{_taskGenerator.FirstTerm} + {_taskGenerator.SecondTerm} = Exit\n\nWhere is the exit?";
    }

    private void SetFirstDoorText()
    {
        if (_taskGenerator.NumberOfCorrectDoor == 1)
            _firstDoorText.text = _taskGenerator.CorrectAnswer.ToString();
        else
            RandomRangeGenerator(_firstDoorText);

    }

    private void SetSecondDoorText()
    {
        if (_taskGenerator.NumberOfCorrectDoor == 2)
            _secondDoorText.text = _taskGenerator.CorrectAnswer.ToString();
        else
            RandomRangeGenerator(_secondDoorText);
    }

    private void SetThirdDoorText()
    {
        if (_taskGenerator.NumberOfCorrectDoor == 3)
            _thirdDoorText.text = _taskGenerator.CorrectAnswer.ToString();
        else
            RandomRangeGenerator(_thirdDoorText);
    }

    private void RandomRangeGenerator(Text doorText)
    {
        _randomRange = Random.Range(1, 15);
        while(_randomRange == _taskGenerator.CorrectAnswer)
            _randomRange = Random.Range(1, 15);
        doorText.text = _randomRange.ToString();
    }
}
