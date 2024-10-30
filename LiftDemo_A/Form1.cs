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

		bool liftAtGround = false;
		bool liftAtTop = false;


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
            

            if (liftAtGround)
            {
                lift.SetState(new MovingUpState());

                lift.LiftTimerUp.Start();
                isClosing = true;
                doorAuto();

            }
            else
            {
                lift.SetState(new MovingUpState());

                liftAtTop = true;

                lift.LiftTimerUp.Start();

                doorAuto();
            }

            ButtonG.Enabled = false;
			logEvents("Lift is moving Up");
		}

		public void btn_G_click(object sender, EventArgs e)
		{
			lift.SetState(new MovingDownState());
            //doorAuto();

            lift.LiftTimerDown.Start();
			liftAtGround = true;
			//liftAtTop = false;
			if (liftAtTop)
			{


				isOpening = true;

                doorAuto();

			}
			else
			{
				isClosing = true;
				doorAuto();
			}

            logEvents("Lift is moving Down");
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
			isOpening=true;
			isClosing=false;
			doorTimer_down.Start();
			ButtonClose.Enabled = false;

			logEvents("Lift door is Opening!!!");
		}

		private void btn_Close_Click(object sender, EventArgs e)
		{
			isOpening =false;
			isClosing=true;
			doorTimer_up.Start();
			logEvents("Lift door is Closing");
		}

		public void doorAuto()
		{
			automatic_door.Start();
		}

		private void automaticDoor_Tick(object sender, EventArgs e)

		{
			if (MyElevator.Top == GLeftDoor.Location.Y)
			{
				if (liftAtGround)
				{
					if (GLeftDoor.Left > doorMaxOpenWidth / 2)
					{
						GLeftDoor.Left -= doorSpeed;
						GRightDoor.Left += doorSpeed;
					}
					else
					{
						doorTimer_down.Stop();
						liftAtGround = true;
						liftAtTop = false;
                        ButtonClose.Enabled = true;
					}
				}

				if (isClosing)
				{
					if (GLeftDoor.Right < MyElevator.Width + doorMaxOpenWidth / 2 - 5)
					{
						GLeftDoor.Left += doorSpeed;
						GRightDoor.Left -= doorSpeed;
					}
					else
					{
						doorTimer_down.Stop();
						liftAtTop = true;
						liftAtGround= false;

					}
				}
			}

			else if (MyElevator.Top == doorLeft_1.Location.Y)
            {
				if (liftAtTop)
				{
					if (doorLeft_1.Left > doorMaxOpenWidth / 2)
					{
						doorLeft_1.Left -= doorSpeed;
						doorRight_1.Left += doorSpeed;
					}
					else
					{
						doorTimer_down.Stop();
						ButtonClose.Enabled = true;
					}
				}

				if (isClosing)
				{
					if (doorLeft_1.Right < MyElevator.Width + doorMaxOpenWidth / 2 - 5)
					{
						doorLeft_1.Left += doorSpeed;
						doorRight_1.Left -= doorSpeed;
					}
					else
					{
						doorTimer_down.Stop();

					}
				}
			}
		}

        private void door_Timer_down_Tick(object sender, EventArgs e)

        {
            if (MyElevator.Top == GLeftDoor.Location.Y)
            {
                if (isOpening)
                {
                    if (GLeftDoor.Left > doorMaxOpenWidth / 2)
                    {
                        GLeftDoor.Left -= doorSpeed;
                        GRightDoor.Left += doorSpeed;
                    }
                    else
                    {
                        doorTimer_down.Stop();
                        ButtonClose.Enabled = true;
                    }
                }

                if (isClosing)
                {
                    if (GLeftDoor.Right < MyElevator.Width + doorMaxOpenWidth / 2 - 5)
                    {
                        GLeftDoor.Left += doorSpeed;
                        GRightDoor.Left -= doorSpeed;
                    }
                    else
                    {
                        doorTimer_down.Stop();

                    }
                }
            }

            else if (MyElevator.Top == doorLeft_1.Location.Y)
            {
                if (isOpening)
                {
                    if (doorLeft_1.Left > doorMaxOpenWidth / 2)
                    {
                        doorLeft_1.Left -= doorSpeed;
                        doorRight_1.Left += doorSpeed;
                    }
                    else
                    {
                        doorTimer_down.Stop();
                        ButtonClose.Enabled = true;
                    }
                }

                if (isClosing)
                {
                    if (doorLeft_1.Right < MyElevator.Width + doorMaxOpenWidth / 2 - 5)
                    {
                        doorLeft_1.Left += doorSpeed;
                        doorRight_1.Left -= doorSpeed;
                    }
                    else
                    {
                        doorTimer_down.Stop();

                    }
                }
            }
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
                automatic_door.Stop();
                doorTimer_down.Stop();
                doorTimer_up.Stop();

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

            // Restart lift timers based on current lift state
            if (liftAtGround)
            {
                lift.LiftTimerUp.Start();
            }
            else if (liftAtTop)
            {
                lift.LiftTimerDown.Start();
            }

            // Re-enable automatic door operations
            automatic_door.Start();

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


        private void door_Timer_up_Tick(object sender, EventArgs e)

        {


            if(MyElevator.Top == doorLeft_1.Location.Y)
            {
                if (isOpening)
                {
                    if (doorLeft_1.Left > doorMaxOpenWidth / 2)
                    {
                        doorLeft_1.Left -= doorSpeed;
                        doorRight_1.Left += doorSpeed;
                    }
                    else
                    {
                        doorTimer_down.Stop();
                        ButtonClose.Enabled = true;
                    }
                }

                if (isClosing)
                {
                    if (doorLeft_1.Right < MyElevator.Width + doorMaxOpenWidth / 2 - 5)
                    {
                        doorLeft_1.Left += doorSpeed;
                        doorRight_1.Left -= doorSpeed;
                    }
                    else
                    {
                        doorTimer_down.Stop();

                    }
                }
            }


        }

    }
}
