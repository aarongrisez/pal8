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

    public string ReportAccessibleLocations()
    {
        List<string> output = new List<string>();
        for (int i = 0; i < currentLocation.accessibleLocations.Count; i++)
        {
            output.Add(currentLocation.accessibleLocations[i].name);
        }
        return string.Join("\n", output.ToArray());
    }

    public string ReportObjectsInRoom()
    {
        List<string> output = new List<string>();
        for (int i = 0; i < currentLocation.objectsInRoom.Count; i++)
        {
            output.Add(currentLocation.objectsInRoom[i].name);
        }
        return string.Join("\n", output.ToArray());
    }

    public Location GetAccessibleLocationByName(string name)
    {
        for (int i = 0; i < currentLocation.accessibleLocations.Count; i++)
        {
            if (name == currentLocation.accessibleLocations[i].name)
            {
                return currentLocation.accessibleLocations[i];
            }
        }
        return null;
    }

    public InteractableObject GetObjectInRoomByName(string name)
    {
        for (int i = 0; i < currentLocation.objectsInRoom.Count; i++)
        {
            if (name == currentLocation.objectsInRoom[i].name)
            {
                return currentLocation.objectsInRoom[i];
            }
        }
        return null;
    }

}
