using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftDemo_A
{
	internal interface ILiftState
	{
		void MovingUp(Lift lift);
		void MovingDown(Lift lift);
	}
}
