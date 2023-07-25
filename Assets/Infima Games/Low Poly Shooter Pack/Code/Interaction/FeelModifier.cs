// //Copyright 2022, Infima Games. All Rights Reserved.
//
// using UnityEngine;
//
// namespace InfimaGames.LowPolyShooterPack
// {
//     public class FeelModifier : Interactable
//     {
//         [SerializeField]
//         private FeelPreset feelPreset;
//         
//         [SerializeField]
//         private Animator pivotAnimator;
//         
//         /// <summary>
//         /// Interact.
//         /// </summary>
//         public override void Interact(GameObject actor = null)
//         {
//             //TODO: Clean this entire component.
//             if(pivotAnimator != null)
//                 pivotAnimator.Play("Press");
//
//             //We need an actor so we can parent this to that.
//             if (actor != null)
//             {
//                 //Grab Character Behaviour. This makes sure that a proper character is trying to pick up this weapon.
//                 var characterBehaviour = actor.GetComponent<CharacterBehaviour>();
//                 if (characterBehaviour == null)
//                     return;
//
//                 var feelManager = actor.GetComponent<FeelManager>();
//                 if (feelManager != null)
//                 {
//                     feelManager.Preset = feelPreset;
//                 }
//             }
//         }
//     }
// }