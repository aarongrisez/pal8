using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Maintains current state and state transitions of player location
public class LocationManager : BaseManager 
{
    private Location currentLocation;

    public Location GetCurrentLocation()
    {
        return currentLocation;
    }

    public void SetCurrentLocation(Location location)
    {
        currentLocation = location;
    }

    public override void ClearAllCollections()
    {
        accessibleLocations.Clear();
    }

}
