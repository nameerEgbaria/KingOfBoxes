using System.Collections.Generic;
using UnityEngine;

public class BoxMazeManager : MonoBehaviour
{
    public Transform player;
    public LayerMask boxLayer;
    public LayerMask targetLayer;
    public LayerMask obstacleLayer;
    public float gridSize = 1.0f;

    private List<Transform> grayBoxes = new List<Transform>();
    private List<Transform> targets = new List<Transform>();

    private void Update()
    {
        // Check if the "U" key is pressed.
        if (Input.GetKeyDown(KeyCode.U))
        {
            // Find all gray boxes and targets in the scene.
            FindGrayBoxesAndTargets();

            // Find the number of gray boxes, path to the closest gray box, and path to the closest target.
            int numberOfGrayBoxes = grayBoxes.Count;
            List<Vector3> pathToClosestGrayBox = FindPathToClosestObject(player.position, grayBoxes);
            List<Vector3> pathToClosestTarget = FindPathToClosestObject(player.position, targets);

            // Print the results.
            Debug.Log("Number of boxes that still gray: " + numberOfGrayBoxes);
            Debug.Log("Path to closest gray box: " + PathToString(pathToClosestGrayBox));
            Debug.Log("Path to closest target: " + PathToString(pathToClosestTarget));
        }
    }

    private void FindGrayBoxesAndTargets()
    {
        // Clear previous lists of gray boxes and targets.
        grayBoxes.Clear();
        targets.Clear();

        // Find all objects with the boxLayer and targetLayer.
        Collider[] colliders = Physics.OverlapSphere(player.position, 100f, boxLayer | targetLayer);

        foreach (var collider in colliders)
        {
            if (((1 << collider.gameObject.layer) & boxLayer) != 0)
            {
                // This is a gray box.
                grayBoxes.Add(collider.transform);
            }
            else if (((1 << collider.gameObject.layer) & targetLayer) != 0)
            {
                // This is a target.
                targets.Add(collider.transform);
            }
        }
    }

    private List<Vector3> FindPathToClosestObject(Vector3 start, List<Transform> objects)
    {
        List<Vector3> path = new List<Vector3>();
        float closestDistance = Mathf.Infinity;
        Transform closestObject = null;

        foreach (var obj in objects)
        {
            float distance = Vector3.Distance(start, obj.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = obj;
            }
        }

        if (closestObject != null)
        {
            // Implement A* pathfinding to find the path from 'start' to 'closestObject'.
            path = AStarPathfinding(start, closestObject.position);
        }

        return path;
    }

    private List<Vector3> AStarPathfinding(Vector3 start, Vector3 target)
    {
        // Implement your A* pathfinding algorithm here.
        // This code will depend on your specific maze and navigation setup.
        // You can use a third-party A* pathfinding library or write your own implementation.
        // A* will return the path as a list of waypoints.

        // For simplicity, this example just returns a straight path.
        List<Vector3> path = new List<Vector3>();
        path.Add(start);
        path.Add(target);

        return path;
    }

    private string PathToString(List<Vector3> path)
    {
        string pathString = "";
        for (int i = 0; i < path.Count - 1; i++)
        {
            Vector3 direction = path[i + 1] - path[i];
            pathString += GetDirectionString(direction) + " ";
        }
        return pathString;
    }

    private string GetDirectionString(Vector3 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
        {
            if (direction.x > 0)
                return "move to the right";
            else
                return "move to the left";
        }
        else
        {
            if (direction.z > 0)
                return "move forward";
            else
                return "move backward";
        }
    }
}
