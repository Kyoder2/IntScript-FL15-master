using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class LostState : IStateBase
	{
		private StateManager manager;

		public LostState(StateManager managerRef)  
		{
			manager = managerRef; //testing some stuff
			Debug.Log("Constructing LostState");
		}

		public void StateUpdate()
		{
				if (Input.GetKeyUp (KeyCode.Space))
			{
				manager.SwitchState (new BeginState (manager));
				Application.LoadLevel("BeginningState");
			}
		}

		public void ShowIt()
		{
			
		}
	}
}
