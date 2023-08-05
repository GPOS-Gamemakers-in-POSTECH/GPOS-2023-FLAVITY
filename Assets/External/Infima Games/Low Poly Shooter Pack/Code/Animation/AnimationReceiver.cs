//Copyright 2022, Infima Games. All Rights Reserved.

using System;
using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
	/// <summary>
	/// This class is helpful when adding weapons alone in the scene that are playing animations.
	/// As, without it, the animation events would not have a receiver, and thus create errors!
	/// </summary>
	public class AnimationReceiver : MonoBehaviour
	{
		/// <summary>
		/// Demonstration Component Reference.
		/// </summary>
		private CharacterDemonstration characterDemonstration;

		#region UNITY

		private void Awake()
		{
			//Cache the demonstration component.
			characterDemonstration = GetComponent<CharacterDemonstration>();
		}

		#endregion
		
		#region ANIMATION

		private void OnAmmunitionFill(int amount = 0)
		{
		}

		private void OnGrenade()
		{
		}
		private void OnSetActiveMagazine(int active)
		{
		}
		
		private void OnAnimationEndedBolt()
		{
		}
		private void OnAnimationEndedReload()
		{
		}

		private void OnAnimationEndedGrenadeThrow()
		{
		}
		private void OnAnimationEndedMelee()
		{
		}

		private void OnAnimationEndedInspect()
		{
		}
		private void OnAnimationEndedHolster()
		{
		}
		
		private void OnEjectCasing()
		{
		}

		private void OnSlideBack()
		{
		}

		private void OnSetActiveKnife()
		{
		}

		/// <summary>
		/// Spawns a magazine! This function is called from an Animation Event.
		/// </summary>
		private void OnDropMagazine(int drop = 0)
		{
			//Drop the magazine.
			if(characterDemonstration != null)
				characterDemonstration.DropMagazine(drop == 0);
		}

		#endregion
	}   
}