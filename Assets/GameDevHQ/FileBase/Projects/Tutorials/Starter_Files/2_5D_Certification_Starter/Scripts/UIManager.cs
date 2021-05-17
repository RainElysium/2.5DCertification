using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int _points;
    [SerializeField]
    private Text _pointsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _pointsText.text = "Collected: " + _points;
    }

    public void addPoint()
    {
        ++_points;
    }

}
