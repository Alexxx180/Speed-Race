using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationChanging : MonoBehaviour
{
    public RandomAppearing apperance;
    public Image background;
    
    public DoubleList obstacles;
    public List<Sprite> sprites;

    public int minTime = 2500;
    public int maxTime = 5000;

    private int _currentSelection = 0;
    public int _current = 0;
    private int _delay = 3750;

    // Here we change location with random set
    // of time between range of two values
    public void FixedUpdate()
    {
        _current++;
        if (_current >= _delay)
        {
            _current = 0;
            _delay = Random.Range(minTime, maxTime);

            _currentSelection += 1;
            _currentSelection %= sprites.Count;

            apperance.obstacles = obstacles.objects[_currentSelection].objects;
            background.sprite = sprites[_currentSelection];
        }
    }
}
