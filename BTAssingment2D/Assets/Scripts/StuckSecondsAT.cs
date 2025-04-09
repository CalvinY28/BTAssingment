using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class StuckSecondsAT : ActionTask<Transform> {

        public BBParameter<float> stuckDuration;
        public BBParameter<float> movementThreshold; // How much it can be moving

        private Vector3 lastPosition;
        private float timer = 0f;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            lastPosition = agent.position;
            timer = 0f;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            float distanceMoved = Vector3.Distance(agent.position, lastPosition);

            if (distanceMoved < movementThreshold.value)
            {
                timer += Time.deltaTime;

                if (timer >= stuckDuration.value)
                {
                    EndAction(true); // End action here means it is in fact stuck
                }
            }
            else
            {
                lastPosition = agent.position; // Reset timer and position if moved
                timer = 0f;
            }

        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}