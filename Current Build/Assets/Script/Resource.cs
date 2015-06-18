using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour
{
	public enum Type { Iron, Copper, Tin };

	[SerializeField] protected Type _type;
	public Type type
	{
		get { return _type; }
		set { _type = value; }
	}

	[SerializeField] protected int _quantity;
	public int quantity
	{
		get { return _quantity; }
		set { _quantity = value; }
	}
}
