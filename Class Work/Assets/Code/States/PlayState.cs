using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class PlayState : IStateBase
	{
		private StateManager manager;

		public PlayState(StateManager managerRef)  
		{
			manager = managerRef; //testing some stuff
			Debug.Log("Constructing PlayState");
		}
		public void StateUpdate()		{
				if (Input.GetKeyUp (KeyCode.Space))
			{
				manager.SwitchState (new WonState (manager));
			}
		}

		public void ShowIt()
		{
			
		}
	}
}
