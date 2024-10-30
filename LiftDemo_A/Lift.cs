using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiftDemo_A
{
	internal class Lift
	{
		public ILiftState _CurrentState;

		public PictureBox MainElevator;
		public Button Btn_1;
		public Button Btn_G;
		public int FormSize;
		public int LiftSpeed;
		public Timer LiftTimerUp;
		public Timer LiftTimerDown;
		public PictureBox DoorLeft1;
		public PictureBox DoorLeft;

        public Lift(PictureBox mainElevator, Button btn_1, Button btn_G, int formSize, int liftSpeed, Timer liftTimerUp, Timer liftTimerDown, PictureBox doorLeft1, PictureBox doorLeft)
		{
			MainElevator = mainElevator;
			Btn_1 = btn_1;
			Btn_G = btn_G;
			FormSize = formSize;
			LiftSpeed = liftSpeed;
			LiftTimerUp = liftTimerUp;
			LiftTimerDown = liftTimerDown;
			DoorLeft1 = doorLeft1;
			DoorLeft = doorLeft;
            _CurrentState = new IdleState();
		}

		public void SetState(ILiftState state)
		{
			_CurrentState = state;
		}

		public void MovingUp()
		{
			_CurrentState.MovingUp(this);
		}

		public void MovingDown()
		{
			_CurrentState.MovingDown(this);
		}


	}
}
