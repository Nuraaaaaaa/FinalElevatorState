using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LiftDemo_A
{
	public partial class Form1 : Form
	{
		bool isClosing = false;
		bool isOpening = false;


        int doorMaxOpenWidth;
		int doorSpeed = 5;
		int liftSpeed = 5;



        private SoundPlayer alarmSound;
		private bool isAlarmActive = false;

		private Lift lift;
		DataTable dt = new DataTable();
		DBContext dbContext = new DBContext();

		public Form1()
		{
			InitializeComponent();

			lift = new Lift(MyElevator, Button1, ButtonG, this.ClientSize.Height, liftSpeed, liftTimerUp, liftTimerDown, doorLeft_1, GLeftDoor);

            alarmSound = new SoundPlayer(@"C:\Users\Aino\Downloads\alarm.wav");



            doorMaxOpenWidth = MyElevator.Width / 2 - 30;

			dataGridViewLogs.ColumnCount = 2;
			dataGridViewLogs.Columns[0].Name = "Time";
			dataGridViewLogs.Columns[1].Name = "Events";

			dt.Columns.Add("LogTime");
			dt.Columns.Add("EventDescription");

		}

		private void logEvents(string message)
		{
			string currentTime = DateTime.Now.ToString("hh:mm:ss");

			dt.Rows.Add(currentTime, message);
			dataGridViewLogs.Rows.Add(currentTime, message);

			dbContext.InsertLogsIntoDB(dt);
		}


		private void Form1_Load(object sender, EventArgs e)
		{
			dbContext.loadLogsFromDB(dt, dataGridViewLogs);
		}


		public void btn_1_click(object sender, EventArgs e)
		{

			// Your logic for handling Button 1 click
			if (isOpening || doorTimer.Enabled)  // If doors are open or currently opening
			{
				CloseDoors();  // Start door-closing process
				lift.SetState(new MovingUpState());  // Set the elevator's next state

				lift.LiftTimerUp.Tag = "Start"; // Flag to start moving after doors close
			}
			else
			{
				// Start moving the elevator directly
				lift.SetState(new MovingUpState());
				lift.LiftTimerUp.Start();
				logEvents("Lift is coming up.");
			}
			//lift.LiftTimerDown.Start();

			ButtonG.Enabled = false; // Disable the ground button



		}

		public void btn_G_click(object sender, EventArgs e)
		{
			if (isOpening)  // If doors are open or currently opening // || doorTimer.Enabled
			{
				CloseDoors();  // Start door-closing process

				lift.SetState(new MovingDownState());  // Set the elevator's next state

				lift.LiftTimerDown.Tag = "Start"; // Flag to start moving after doors close
			}
			else
			{
				// Start moving the elevator directly
				lift.SetState(new MovingDownState());
				lift.LiftTimerDown.Start();
				logEvents("Lift is coming down.");
			}

			this.ButtonOpen.Click += new System.EventHandler(this.btn_Open_Click);


		}

		public void liftTimerUp_Tick(object sender, EventArgs e)
		{
			lift.MovingUp();
		}

		public void liftTimerDown_Tick(object sender, EventArgs e)
		{
			lift.MovingDown();
		}

		private void btn_Open_Click(object sender, EventArgs e)
		{

			if (lift._CurrentState is IdleState)
			{
				isOpening = true;
				isClosing = false;
				doorTimer.Start();
				ButtonClose.Enabled = false;


				logEvents("Lift door is Opening!!!");

			}
		}

		private void btn_Close_Click(object sender, EventArgs e)
		{
			isOpening =false;
			isClosing=true;
			doorTimer.Start();
			logEvents("Lift door is Closing");
		}




       
        private void buttonAlarm_Click(object sender, EventArgs e)
        {
            if (isAlarmActive)
            {
                ResetAlarm();
            }
            else
            {
                // Log the alarm event
                logEvents("Alarm Activated!");

                // Stop all elevator and door timers
                lift.LiftTimerUp.Stop();
                lift.LiftTimerDown.Stop();
                doorTimer.Stop();

                // Disable buttons to prevent actions during the alarm
                Button1.Enabled = false;
                ButtonG.Enabled = false;
                ButtonOpen.Enabled = false;
                ButtonClose.Enabled = false;
                DownArrow.Enabled = false;
                UpArrow.Enabled = false;

                // Play the alarm sound
                try
                {
                    // Initializing the SoundPlayer with the full path to the sound file
                    alarmSound = new SoundPlayer(@"C:\Users\Aino\Downloads\alarm-6786.wav");

                    alarmSound.PlayLooping(); // Loop the alarm sound until reset
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not play alarm sound: " + ex.Message);
                }

                // button appearance to indicate the alarm is active
                AlarmButton.BackColor = Color.Red;
                AlarmButton.Text = "Alarm Activated";
                isAlarmActive = true; // Set alarm state to active
            }
        }

        private void ResetAlarm()
        {
            logEvents("Alarm Reset");

            // Stop the alarm sound
            if (alarmSound != null && isAlarmActive) // Check if alarmSound is initialized
            {
                alarmSound.Stop();
            }

            // Re-enable buttons for lift functionality
            Button1.Enabled = true;
            ButtonG.Enabled = true;
            ButtonOpen.Enabled = true;
            ButtonClose.Enabled = true;
            DownArrow.Enabled = true;
            UpArrow.Enabled = true;


            // Reset alarm button appearance
            AlarmButton.BackColor = SystemColors.Control;
            AlarmButton.Text = "Alarm";
            isAlarmActive = false; // Set the alarm state to inactive
        }


        private void DeleteButton(object sender, EventArgs e)
        {
            dbContext.DeleteLogs();
            dbContext.loadLogsFromDB(dt, dataGridViewLogs);

        }


		public void OpenDoors()
		{
			if (lift.MainElevator.Top == doorLeft_1.Location.Y) // Top floor
			{
				isOpening = true;
				isClosing = false;
				doorTimer.Start();  // Start door timer to open doors on the top floor
				ButtonClose.Enabled = false;
				logEvents("Doors are opening at the top floor!");
			}
			else if (lift.MainElevator.Location.Y == GLeftDoor.Location.Y) // Ground floor
			{
				isOpening = true;
				isClosing = false;
				doorTimer.Start();  // Start door timer to open doors on the ground floor
				ButtonClose.Enabled = false;
				logEvents("Doors are opening at the ground floor!");
			}
		}

		private void CloseDoors()
		{
			isOpening = false;
			isClosing = true;
			doorTimer.Start();
			logEvents("Doors are closing!");
		}


		private void door_Timer_Tick(object sender, EventArgs e)
		{
			if (isOpening)
			{
				// Open the doors
				if (MyElevator.Top == doorLeft_1.Location.Y) // Assuming the ground floor is Top = 0
				{
					if (doorLeft_1.Left > doorMaxOpenWidth / 2)
					{
						doorLeft_1.Left -= doorSpeed;
						doorRight_1.Left += doorSpeed;
					}
					else
					{
						doorTimer.Stop();
						ButtonClose.Enabled = true; // Enable close button

					}
				}
				else // When at floor 1
				{
					if (GLeftDoor.Left > doorMaxOpenWidth / 2)
					{
						GLeftDoor.Left -= doorSpeed;
						GRightDoor.Left += doorSpeed;
					}
					else
					{
						doorTimer.Stop();
						ButtonClose.Enabled = true; // Enable close button

					}
				}
			}
			else if (isClosing)
			{
				// Close the doors
				if (MyElevator.Top == doorLeft_1.Location.Y) // Assuming the ground floor is Top = 0
				{
					if (doorLeft_1.Right < MyElevator.Width + doorMaxOpenWidth / 2 - 5)
					{
						doorLeft_1.Left += doorSpeed;
						doorRight_1.Left -= doorSpeed;
					}
					else
					{
						doorTimer.Stop();
						liftTimerDown.Start();
					}
				}
				else // When at floor 1
				{
					if (GLeftDoor.Right < MyElevator.Width + doorMaxOpenWidth / 2 - 5)
					{
						GLeftDoor.Left += doorSpeed;
						GRightDoor.Left -= doorSpeed;
					}
					else
					{
						doorTimer.Stop();
						liftTimerUp.Start();

					}
				}
			}
		}

	}
}
