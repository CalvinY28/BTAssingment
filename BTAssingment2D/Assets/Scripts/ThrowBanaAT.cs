using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ThrowBanaAT : ActionTask<Transform> {

		public BBParameter<GameObject> bananaPrefab;
		public float force;
		public string playerTag = "Player";

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            GameObject player = GameObject.FindGameObjectWithTag(playerTag);

            if (player == null)
            {
                Debug.LogWarning("No player");
                EndAction(false);
                return;
            }

            GameObject projectile = GameObject.Instantiate(bananaPrefab.value, agent.position, Quaternion.identity); // Instantiate projectile

            //Destroy(projectile, 5f);
            UnityEngine.Object.Destroy(projectile, 5f); // Destroy after 5 seconds // cant use destory becasue not monobehavoir or smth

            Vector2 directionToPlayer = (player.transform.position - agent.position).normalized; // Calculate direction

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(directionToPlayer * force, ForceMode2D.Impulse); // Applying force
            }

            EndAction(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}