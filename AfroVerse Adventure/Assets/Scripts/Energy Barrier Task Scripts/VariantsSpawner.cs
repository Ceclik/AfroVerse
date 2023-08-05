using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariantsSpawner : MonoBehaviour
{
    [SerializeField] private List<Element> _elements;

    [SerializeField] private List<GameObject> _plates;
    private void Awake()
    {
        for(int i = 0; i < 4; i++)
            _plates[i].GetComponent<Image>().sprite = _elements[i].Icon;
    }
}
