using UnityEngine;
using System.Collections;

public class LiftPathFollower : MonoBehaviour {

	public float speed = 3f;
    public float smooth = 5f;
	public Transform pathParent;
    public int startingIndex;
    double[] angles = {424.979, 386.536, 56.49, 86.49, 116.49, 147.293, 177.293, 207.293, 235.305, 265.961, 295.961, 244.955, 244.955, 244.955, 248.219, 260.741, 253.59, 258.093, 249.666, 234.705, 240.993, 240.993, 243.538, 251.286, 246.678, 240.973, 234.695, 230.397, 227.106, 230.787, 226.677, 232.754, 162.86, 192.86, 222.86, 252.86, 282.86, 312.86, 342.86, 372.86, 402.86, 432.86, 400.762, 405.631, 410.415, 407.309, 411.367, 415.431, 421.044, 425.984, 430.689, 424.32, 417.855, 422.061, 415.317, 430.516, 437.239, 432.722, 441.442, 428.24, 421.602, 424.582};
	Transform targetPoint;
	int index;

	void OnDrawGizmos()
	{
		Vector3 from;
		Vector3 to;
		for (int a=0; a<pathParent.childCount; a++)
		{
			from = pathParent.GetChild(a).position;
			to = pathParent.GetChild((a+1) % pathParent.childCount).position;
			Gizmos.color = new Color (1, 0, 0);
			Gizmos.DrawLine (from, to);
		}
	}

	void Start () {
		index = startingIndex;
		targetPoint = pathParent.GetChild(index);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, targetPoint.position, speed * Time.deltaTime);
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, (float) angles[index] + transform.parent.eulerAngles.y, 0), smooth * Time.deltaTime);
        if (Vector3.Distance (transform.position, targetPoint.position) < 0.1f) 
		{
			if (index < pathParent.childCount - 1) {
                index++;
            }
            else {
                index = 0;
            }
			targetPoint = pathParent.GetChild(index);
		}
	}
}