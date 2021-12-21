using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationChanging : MonoBehaviour
{
    public RandomAppearing apperance;
    public Image background;
    
    public DoubleList obstacles;
    public List<Sprite> sprites;

    private readonly int _minTime = 500;
    private readonly int _maxTime = 1500;

    private int _currentSelection = 0;

    private readonly TimeSystem _changeTime = new TimeSystem(0, 750);
    
    public void FixedUpdate()
    {
        if (_changeTime.FullTimeBeat())
            return;
        ChangeLocation();
    }

    // Here we change location with random set
    // of time between range of two values
    private void ChangeLocation()
    {
        int delayRange = Random.Range(_minTime, _maxTime);
        _changeTime.SetDelay(delayRange);

        _currentSelection += 1;
        _currentSelection %= sprites.Count;

        apperance.obstacles = obstacles.objects[_currentSelection].objects;
        background.sprite = sprites[_currentSelection];
    }
}