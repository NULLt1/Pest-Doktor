using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mapbox.Examples
{
	public class PlayerMovement : MonoBehaviour
	{
		public Material[] Materials;
		public Transform Target;
		public Animator CharacterAnimator;
		public float Speed;
		void Start()
		{
			
		}

		void Update()
		{
			foreach (var item in Materials)
			{
				item.SetVector("_CharacterPosition", transform.position);
			}

			var distance = Vector3.Distance(transform.position, Target.position);
			if (distance > 0.1f)
			{
				transform.LookAt(Target.position);
				transform.Translate(Vector3.forward * Speed);
				CharacterAnimator.SetBool("IsWalking", true);
			}
			else
			{
				CharacterAnimator.SetBool("IsWalking", false);
			}
		}
	}
}