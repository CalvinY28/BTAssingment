using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ThrowBananaTestAT : ActionTask<Transform> {

        public BBParameter<GameObject> projectilePrefab;
        public float shootForce;
        public Vector2 shootDirection = Vector2.up; // shooting it upwards

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            GameObject projectile = GameObject.Instantiate(projectilePrefab.value, agent.position, Quaternion.identity); // instantiate at agent position
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>(); // get rigidbodyt from projectile

            if (rb != null)
            {
                Vector2 force = shootDirection.normalized * shootForce; // make sure to normalize and apply the correct forces.
                rb.AddForce(force, ForceMode2D.Impulse);
            }
            else
            {
                Debug.Log("a");
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