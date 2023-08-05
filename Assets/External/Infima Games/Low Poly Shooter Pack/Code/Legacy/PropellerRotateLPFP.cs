//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack.Legacy
{
	public class PropellerRotateLPFP : MonoBehaviour
	{

		[Tooltip("How fast the propellers rotate on the Z axis")]
		public float rotationSpeed = 2500.0f;

		private void Update()
		{
			transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
		}
	}
}