namespace LiftDemo_A
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.liftTimerUp = new System.Windows.Forms.Timer(this.components);
            this.doorTimer_down = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewLogs = new System.Windows.Forms.DataGridView();
            this.liftTimerDown = new System.Windows.Forms.Timer(this.components);
            this.ExitButton = new System.Windows.Forms.Button();
            //this.DeleteButton = new System.Windows.Forms.Button();
            this.UpArrow = new System.Windows.Forms.Button();
            this.DownArrow = new System.Windows.Forms.Button();
            this.AlarmButton = new System.Windows.Forms.Button();
            this.doorRight_1 = new System.Windows.Forms.PictureBox();
            this.doorLeft_1 = new System.Windows.Forms.PictureBox();
            this.GRightDoor = new System.Windows.Forms.PictureBox();
            this.GLeftDoor = new System.Windows.Forms.PictureBox();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.ButtonG = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.ElevatorPanel = new System.Windows.Forms.PictureBox();
            this.MyElevator = new System.Windows.Forms.PictureBox();
            this.doorTimer_up = new System.Windows.Forms.Timer(this.components);
            this.automatic_door = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doorRight_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doorLeft_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRightDoor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GLeftDoor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElevatorPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyElevator)).BeginInit();
            this.SuspendLayout();
            // 
            // liftTimerUp
            // 
            this.liftTimerUp.Interval = 50;
            this.liftTimerUp.Tick += new System.EventHandler(this.liftTimerUp_Tick);
            // 
            // dataGridViewLogs
            // 
            this.dataGridViewLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLogs.Location = new System.Drawing.Point(1001, 61);
            this.dataGridViewLogs.Name = "dataGridViewLogs";
            this.dataGridViewLogs.RowHeadersWidth = 51;
            this.dataGridViewLogs.RowTemplate.Height = 24;
            this.dataGridViewLogs.Size = new System.Drawing.Size(338, 561);
            this.dataGridViewLogs.TabIndex = 10;
            // 
            // liftTimerDown
            // 
            this.liftTimerDown.Tick += new System.EventHandler(this.liftTimerDown_Tick);
            // 
            // ExitButton
            // 
            this.ExitButton.BackgroundImage = global::LiftDemo_A.Properties.Resources.ExitButtonFinal;
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExitButton.Location = new System.Drawing.Point(1264, 23);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 40);
            this.ExitButton.TabIndex = 15;
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            //this.DeleteButton.BackgroundImage = global::LiftDemo_A.Properties.Resources.DeleteIcon;
            //this.DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //this.DeleteButton.Location = new System.Drawing.Point(1227, 23);
            //this.DeleteButton.Name = "DeleteButton";
            //this.DeleteButton.Size = new System.Drawing.Size(41, 40);
            //this.DeleteButton.TabIndex = 14;
            //this.DeleteButton.UseVisualStyleBackColor = true;
            //// 
            // UpArrow
            // 
            this.UpArrow.BackgroundImage = global::LiftDemo_A.Properties.Resources.DownButton;
            this.UpArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpArrow.Location = new System.Drawing.Point(347, 172);
            this.UpArrow.Name = "UpArrow";
            this.UpArrow.Size = new System.Drawing.Size(39, 34);
            this.UpArrow.TabIndex = 13;
            this.UpArrow.UseVisualStyleBackColor = true;
            this.UpArrow.Click += new System.EventHandler(this.btn_1_click);
            // 
            // DownArrow
            // 
            this.DownArrow.BackgroundImage = global::LiftDemo_A.Properties.Resources.UpGButton;
            this.DownArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DownArrow.Location = new System.Drawing.Point(347, 510);
            this.DownArrow.Name = "DownArrow";
            this.DownArrow.Size = new System.Drawing.Size(39, 34);
            this.DownArrow.TabIndex = 12;
            this.DownArrow.UseVisualStyleBackColor = true;
            this.DownArrow.Click += new System.EventHandler(this.btn_G_click);
            // 
            // AlarmButton
            // 
            this.AlarmButton.BackgroundImage = global::LiftDemo_A.Properties.Resources.AlarmButtonF;
            this.AlarmButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AlarmButton.Location = new System.Drawing.Point(595, 243);
            this.AlarmButton.Name = "AlarmButton";
            this.AlarmButton.Size = new System.Drawing.Size(51, 50);
            this.AlarmButton.TabIndex = 11;
            this.AlarmButton.UseVisualStyleBackColor = true;
            this.AlarmButton.Click += new System.EventHandler(this.buttonAlarm_Click);
            // 
            // doorRight_1
            // 
            this.doorRight_1.BackgroundImage = global::LiftDemo_A.Properties.Resources.GoldRightDoor;
            this.doorRight_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.doorRight_1.Location = new System.Drawing.Point(174, 61);
            this.doorRight_1.Name = "doorRight_1";
            this.doorRight_1.Size = new System.Drawing.Size(81, 208);
            this.doorRight_1.TabIndex = 9;
            this.doorRight_1.TabStop = false;
            // 
            // doorLeft_1
            // 
            this.doorLeft_1.BackgroundImage = global::LiftDemo_A.Properties.Resources.GoldLeftDoor;
            this.doorLeft_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.doorLeft_1.Location = new System.Drawing.Point(93, 61);
            this.doorLeft_1.Name = "doorLeft_1";
            this.doorLeft_1.Size = new System.Drawing.Size(83, 208);
            this.doorLeft_1.TabIndex = 8;
            this.doorLeft_1.TabStop = false;
            // 
            // GRightDoor
            // 
            this.GRightDoor.BackgroundImage = global::LiftDemo_A.Properties.Resources.GoldRightDoor;
            this.GRightDoor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GRightDoor.Location = new System.Drawing.Point(174, 414);
            this.GRightDoor.Name = "GRightDoor";
            this.GRightDoor.Size = new System.Drawing.Size(81, 208);
            this.GRightDoor.TabIndex = 7;
            this.GRightDoor.TabStop = false;
            // 
            // GLeftDoor
            // 
            this.GLeftDoor.BackgroundImage = global::LiftDemo_A.Properties.Resources.GoldLeftDoor;
            this.GLeftDoor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GLeftDoor.Location = new System.Drawing.Point(93, 414);
            this.GLeftDoor.Name = "GLeftDoor";
            this.GLeftDoor.Size = new System.Drawing.Size(83, 208);
            this.GLeftDoor.TabIndex = 6;
            this.GLeftDoor.TabStop = false;
            // 
            // ButtonClose
            // 
            this.ButtonClose.BackgroundImage = global::LiftDemo_A.Properties.Resources.CloseDoor2;
            this.ButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonClose.Location = new System.Drawing.Point(626, 313);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(64, 56);
            this.ButtonClose.TabIndex = 5;
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.BackgroundImage = global::LiftDemo_A.Properties.Resources.Opendoor3;
            this.ButtonOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonOpen.Location = new System.Drawing.Point(556, 313);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(64, 56);
            this.ButtonOpen.TabIndex = 4;
            this.ButtonOpen.UseVisualStyleBackColor = true;
            this.ButtonOpen.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // ButtonG
            // 
            this.ButtonG.BackgroundImage = global::LiftDemo_A.Properties.Resources.ButtonGGold;
            this.ButtonG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonG.Location = new System.Drawing.Point(595, 184);
            this.ButtonG.Name = "ButtonG";
            this.ButtonG.Size = new System.Drawing.Size(51, 53);
            this.ButtonG.TabIndex = 3;
            this.ButtonG.UseVisualStyleBackColor = true;
            this.ButtonG.Click += new System.EventHandler(this.btn_G_click);
            // 
            // Button1
            // 
            this.Button1.BackgroundImage = global::LiftDemo_A.Properties.Resources.Button1Gold;
            this.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button1.Location = new System.Drawing.Point(595, 125);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(51, 53);
            this.Button1.TabIndex = 2;
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.btn_1_click);
            // 
            // ElevatorPanel
            // 
            this.ElevatorPanel.BackgroundImage = global::LiftDemo_A.Properties.Resources.GoldSlatefinal;
            this.ElevatorPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ElevatorPanel.Location = new System.Drawing.Point(513, 36);
            this.ElevatorPanel.Name = "ElevatorPanel";
            this.ElevatorPanel.Size = new System.Drawing.Size(218, 383);
            this.ElevatorPanel.TabIndex = 1;
            this.ElevatorPanel.TabStop = false;
            // 
            // MyElevator
            // 
            this.MyElevator.BackgroundImage = global::LiftDemo_A.Properties.Resources.GoldOpen;
            this.MyElevator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MyElevator.Location = new System.Drawing.Point(93, 414);
            this.MyElevator.Name = "MyElevator";
            this.MyElevator.Size = new System.Drawing.Size(162, 208);
            this.MyElevator.TabIndex = 0;
            this.MyElevator.TabStop = false;
            // 
            // doorTimer_up
            // 
            this.doorTimer_up.Tick += new System.EventHandler(this.door_Timer_up_Tick);
            // 
            // automatic_door
            // 
            this.automatic_door.Tick += new System.EventHandler(this.automaticDoor_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 623);
            this.Controls.Add(this.ExitButton);
            //this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.UpArrow);
            this.Controls.Add(this.DownArrow);
            this.Controls.Add(this.AlarmButton);
            this.Controls.Add(this.dataGridViewLogs);
            this.Controls.Add(this.doorRight_1);
            this.Controls.Add(this.doorLeft_1);
            this.Controls.Add(this.GRightDoor);
            this.Controls.Add(this.GLeftDoor);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ButtonOpen);
            this.Controls.Add(this.ButtonG);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.ElevatorPanel);
            this.Controls.Add(this.MyElevator);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doorRight_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doorLeft_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRightDoor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GLeftDoor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElevatorPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyElevator)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox MyElevator;
		private System.Windows.Forms.PictureBox ElevatorPanel;
		private System.Windows.Forms.Button Button1;
		private System.Windows.Forms.Button ButtonG;
		private System.Windows.Forms.Button ButtonOpen;
		private System.Windows.Forms.Button ButtonClose;
		private System.Windows.Forms.Timer liftTimerUp;
		private System.Windows.Forms.PictureBox GLeftDoor;
		private System.Windows.Forms.PictureBox GRightDoor;
		private System.Windows.Forms.PictureBox doorRight_1;
		private System.Windows.Forms.PictureBox doorLeft_1;
		private System.Windows.Forms.Timer doorTimer_down;
		private System.Windows.Forms.DataGridView dataGridViewLogs;
		private System.Windows.Forms.Timer liftTimerDown;
        private System.Windows.Forms.Button AlarmButton;
        private System.Windows.Forms.Button DownArrow;
        private System.Windows.Forms.Button UpArrow;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Timer doorTimer_up;
        private System.Windows.Forms.Timer automatic_door;
    }
}

