using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {
	// I shoulda made this more modular
	public class IsHit2CT : ConditionTask<Transform> {

        private BirdHitBox birdHitbox;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
            birdHitbox = agent.GetComponent<BirdHitBox>();
        }

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

            if (birdHitbox.hitByBanana)
            {
                birdHitbox.hitByBanana = false;
                return true;
            }

            return false;
        }
	}
}