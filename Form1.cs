// Version 1.4 by Treverse
// Last Updated: 11/5/2024
using System;
using System.Windows.Forms;

namespace TimeCalculator
{
    public partial class timeCalculatorForm : Form
    {
        public timeCalculatorForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Nothing lol
        }

        // TIMEFRAME CALCULATOR
        private void timeCalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Parse inputs for starting time
                TimeSpan startTime = new TimeSpan(
                    int.Parse(startingDays.Text) * 24 + int.Parse(startingHours.Text),
                    int.Parse(startingMinutes.Text),
                    int.Parse(startingSeconds.Text));

                // Parse inputs for ending time
                TimeSpan endTime = new TimeSpan(
                    int.Parse(endingDays.Text) * 24 + int.Parse(endingHours.Text),
                    int.Parse(endingMinutes.Text),
                    int.Parse(endingSeconds.Text));

                // Calculate result based on add or subtract operation
                TimeSpan resultTime = addRadio.Checked ? startTime + endTime : startTime - endTime;

                // Display results
                resultDays.Text = resultTime.Days.ToString();
                resultHours.Text = resultTime.Hours.ToString();
                resultMinutes.Text = resultTime.Minutes.ToString();
                resultSeconds.Text = resultTime.Seconds.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid numeric values for time.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ROTATE TIMEFRAME VALUES
        private void timeRotateButton_Click(object sender, EventArgs e)
        {
            // Transfer result values to starting values and reset result values
            startingDays.Text = resultDays.Text;
            startingHours.Text = resultHours.Text;
            startingMinutes.Text = resultMinutes.Text;
            startingSeconds.Text = resultSeconds.Text;

            endingDays.Text = "";
            endingHours.Text = "";
            endingMinutes.Text = "";
            endingSeconds.Text = "";

            resultDays.Text = "0";
            resultHours.Text = "0";
            resultMinutes.Text = "0";
            resultSeconds.Text = "0";
        }

        // HOURLY RATE CALCULATOR
        private void rateCalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Parse contents of text boxes
                int hours = int.Parse(rateHours.Text);
                int minutes = int.Parse(rateMinutes.Text);
                int seconds = int.Parse(rateSeconds.Text);
                double hourlyRateValue = double.Parse(hourlyRate.Text);

                double totalHours = hours + (minutes / 60.0) + (seconds / 3600.0);
                double pay = totalHours * hourlyRateValue;

                // Format and display the resulting pay
                payNum.Text = "$" + pay.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid numeric values for hours, minutes, seconds, and rate.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // DATE CALCULATOR
        private void dateCalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Parse starting date
                DateTime startDate = new DateTime(
                    int.Parse(startingYear.Text),
                    int.Parse(startingMonth.Text),
                    int.Parse(startingDay.Text));

                // Convert ending date input into total days
                int daysToAdd = (int.Parse(endingYear.Text) * 365) + (int.Parse(endingMonth.Text) * 30) + int.Parse(endingDay.Text);

                // Calculate result date based on add or subtract operation
                DateTime resultDate = addDate.Checked ? startDate.AddDays(daysToAdd) : startDate.AddDays(-daysToAdd);

                // Display results
                dateResultMonth.Text = resultDate.Month.ToString();
                dateResultDay.Text = resultDate.Day.ToString();
                dateResultYear.Text = resultDate.Year.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid numeric values for dates.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

        // DURATION CALCULATOR
        private void calculateDurationButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure AM/PM selection for both start and end times
                if (startingAMPM.SelectedItem == null || endingAMPM.SelectedItem == null)
                {
                    MessageBox.Show("Please select AM or PM for both start and end times.", "AM/PM Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parse and convert start time to 24-hour format
                int startHour = int.Parse(startingTimeHour.Text);
                int startMinute = int.Parse(startingTimeMinute.Text);
                int startSecond = int.Parse(startingTimeSecond.Text);
                string startAMPM = startingAMPM.SelectedItem.ToString();
                if (startAMPM == "PM" && startHour < 12) startHour += 12;
                if (startAMPM == "AM" && startHour == 12) startHour = 0;

                DateTime startTime = new DateTime(1, 1, 1, startHour, startMinute, startSecond);

                // Parse and convert end time to 24-hour format
                int endHour = int.Parse(endingTimeHour.Text);
                int endMinute = int.Parse(endingTimeMinute.Text);
                int endSecond = int.Parse(endingTimeSecond.Text);
                string endAMPM = endingAMPM.SelectedItem.ToString();
                if (endAMPM == "PM" && endHour < 12) endHour += 12;
                if (endAMPM == "AM" && endHour == 12) endHour = 0;

                DateTime endTime = new DateTime(1, 1, 1, endHour, endMinute, endSecond);

                // Calculate the duration between the two times
                TimeSpan duration;
                if (endTime >= startTime)
                {
                    duration = endTime - startTime;
                }
                else
                {
                    // Wrap-around by adding a day if endTime is earlier than startTime
                    duration = (endTime - startTime) + TimeSpan.FromDays(1);
                }

                // Display the calculated duration
                timeframeResultHour.Text = duration.Hours.ToString();
                timeframeResultMinute.Text = duration.Minutes.ToString();
                timeframeResultSecond.Text = duration.Seconds.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for time in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treverseHyperlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // The URL to open
            string url = "https://treverse.live/socials";

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // For .NET Core 3.0 and above
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Any other future additions would go here!
    }
}
