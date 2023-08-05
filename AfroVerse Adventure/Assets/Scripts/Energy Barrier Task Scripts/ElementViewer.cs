using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementViewer : MonoBehaviour
{
    [SerializeField] private List<Image> _sourceImages;
    [SerializeField] private List<Element> _elements;

    private int _randomElementNumber;

    private void Awake()
    {
        
        for (int i = 0; i < 3; i++)
        {
            _randomElementNumber = Random.Range(0, 4);
            for(int j = 0; j < 3; j++)
                if (_sourceImages[j].sprite == _elements[_randomElementNumber].Icon)
                {
                    _randomElementNumber = Random.Range(0, 4);
                    j = -1;
                }     
            _sourceImages[i].sprite = _elements[_randomElementNumber].Icon;
        }
    }
}
