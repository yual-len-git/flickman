using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathCreation.Examples {
    // Example of creating a path at runtime from a set of points.

    [RequireComponent(typeof(PathCreator))]
    public class GeneratePathExample : MonoBehaviour {

        public bool closedLoop = true;
        Vector3[] waypoints;

        void Start () {
            List<Vector3> l = new List<Vector3>();
            foreach (Transform child in transform)
            {
                l.Add(child.position);
            }

            waypoints = l.ToArray();

            if (waypoints.Length > 0) {
                print("here!");
                // Create a new bezier path from the waypoints.
                BezierPath bezierPath = new BezierPath (waypoints, closedLoop, PathSpace.xyz);
                GetComponent<PathCreator>().bezierPath = bezierPath;
            }
        }
    }
}