using UnityEngine;
using System.Collections;

public class BoundingBox : MonoBehaviour
{
	[SerializeField] private bool DEBUG = true;

	[SerializeField] private Vector3 _start;
	public Vector3 start
	{
		get { return _start; }
		set { _start = value; }
	}

	[SerializeField] private Vector3 _end;
	public Vector3 end
	{
		get { return _end; }
		set { _end = value; }
	}

	// Use this for initialization
	void Start ()
	{
		//	Check that all end values are greater than start values
		//	Swap if they're not
		float temp;
		
		if (_start.x > _end.x)
		{
			temp = _start.x;
			_start.x = _end.x;
			_end.x = temp;
		}
		
		if (_start.y > _end.y)
		{
			temp = _start.y;
			_start.y = _end.y;
			_end.y = temp;
		}
		
		if (_start.z > _end.z)
		{
			temp = _start.z;
			_start.z = _end.z;
			_end.z = temp;
		}

		if (DEBUG == true)
		{
			//	Create LineRenderer
			LineRenderer lr = this.gameObject.AddComponent<LineRenderer>();
			lr.SetVertexCount(5);

			//	Top "face"
			lr.SetPosition(0, _start);
			lr.SetPosition(1, new Vector3(_end.x, _start.y, _start.z));
			lr.SetPosition(2, new Vector3(_end.x, _end.y, _start.z));
			lr.SetPosition(3, new Vector3(_start.x, _end.y, _start.z));
			lr.SetPosition(4, _start);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		//	If object is out of range, move to opposite edge
		Vector3 newPosition = this.transform.position;
		
		if (this.transform.position.x < _start.x)
		{
			newPosition.x = _end.x;
		}
		else if (this.transform.position.x > _end.x)
		{
			newPosition.x = _start.x;
		}

		if (this.transform.position.y < _start.y)
		{
			newPosition.y = _end.y;
		}
		else if (this.transform.position.y > _end.y)
		{
			newPosition.y = _start.y;
		}
		
		if (this.transform.position.z < _start.z)
		{
			newPosition.z = _end.z;
		}
		else if (this.transform.position.z > _end.z)
		{
			newPosition.z = _start.z;
		}

		this.transform.position = newPosition;
	}
}
