using UnityEngine;

namespace Balloon
{
	public interface WindTarget
	{
		float fMaxSpeed { get; }
		Rigidbody rigid { get; }
	}
}