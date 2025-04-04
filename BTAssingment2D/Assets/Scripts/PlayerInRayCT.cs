using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{

	public class PlayerInRayCT : ConditionTask<Transform>
	{

		public float Length;
		public LayerMask PlayerLayer;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit()
		{
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable()
		{

		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable()
		{

		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck()
		{

			RaycastHit2D hit = Physics2D.Raycast(agent.position, Vector2.down, Length, PlayerLayer); // If hit the RAYCAST return

			if (hit.collider != null && hit.collider.CompareTag("Player"))
			{
				return true;
			}
			return false;

		}
		void OnGizmosSelected() // idk why this aint working just gonna eyeball it now
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine(agent.position, agent.position + Vector3.down * Length);
		}
	}
}