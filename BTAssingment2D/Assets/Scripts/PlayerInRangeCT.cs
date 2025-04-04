using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class PlayerInRange : ConditionTask<Transform> {

		public float radius;
		public LayerMask playerLayer;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
            Collider2D hit = Physics2D.OverlapCircle(agent.position, radius, playerLayer);
            return hit != null && hit.CompareTag("Player");
        }

        void OnGizmosSelected() // Select the monkey/bird to check the OverlapCircle // Why dosent this show?
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(agent.position, radius);
        }
    }
}