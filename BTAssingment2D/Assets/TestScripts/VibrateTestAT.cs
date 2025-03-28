using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections;
using Unity.IO.LowLevel.Unsafe;


namespace NodeCanvas.Tasks.Actions {

    public class VibrateTestAT : ActionTask<Transform> {

        public float duration;
        public float magnitude;

        private Vector3 originalPos; // storeing og position

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            originalPos = agent.localPosition; // saving position
            StartCoroutine(Vibrate()); // vibrating courutine all this should be in execute cus it breaks if things are in update (last assingment)
        }

        private IEnumerator Vibrate()
        {
            float elapsed = 0f;

            while (elapsed < duration) // keep shaking until duration reached
            {
                float offsetX = Random.Range(-1f, 1f) * magnitude; // random offsets to vibrate
                float offsetY = Random.Range(-1f, 1f) * magnitude;

                agent.localPosition = originalPos + new Vector3(offsetX, offsetY, 0f); // applying it
                elapsed += Time.deltaTime;

                yield return null;
            }

            agent.localPosition = originalPos; // Set position back to 0,0 when done
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