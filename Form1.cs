//Version 1.3.2
//Updated 12/28/2023

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EditingRates
{
    public partial class timeCalculatorForm : Form
    {
        public timeCalculatorForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //TIMEFRAME CALCULATOR
        private void timeCalculateButton_Click(object sender, EventArgs e)
        {
            int parsedValue;

            int startingDaysNum = 0;
            int startingHoursNum = 0;
            int startingMinutesNum = 0;
            int startingSecondsNum = 0;

            if (startingDays.Text != "")
            {
                if (Int32.TryParse(startingDays.Text, out parsedValue))
                {
                    startingDaysNum = Int32.Parse(startingDays.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the initial days textbox.", "Days Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                startingDays.Text = "0";
            }

            if (startingHours.Text != "")
            {
                if (Int32.TryParse(startingHours.Text, out parsedValue))
                {
                    startingHoursNum = Int32.Parse(startingHours.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the initial hours textbox.", "Hours Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                startingHours.Text = "0";
            }

            if (startingMinutes.Text != "")
            {
                if (Int32.TryParse(startingMinutes.Text, out parsedValue))
                {
                    startingMinutesNum = Int32.Parse(startingMinutes.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the initial minutes textbox.", "Minutes Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                startingMinutes.Text = "0";
            }

            if (startingSeconds.Text != "")
            {
                if (Int32.TryParse(startingSeconds.Text, out parsedValue))
                {
                    startingSecondsNum = Int32.Parse(startingSeconds.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the initial seconds textbox.", "Seconds Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                startingSeconds.Text = "0";
            }

            int endingDaysNum = 0;
            int endingHoursNum = 0;
            int endingMinutesNum = 0;
            int endingSecondsNum = 0;

            if (endingDays.Text != "")
            {
                if (Int32.TryParse(endingDays.Text, out parsedValue))
                {
                    endingDaysNum = Int32.Parse(endingDays.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the ending days textbox.", "Days Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                endingDays.Text = "0";
            }

            if (endingHours.Text != "")
            {
                if (Int32.TryParse(endingHours.Text, out parsedValue))
                {
                    endingHoursNum = Int32.Parse(endingHours.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the ending hours textbox.", "Hours Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                endingHours.Text = "0";
            }

            if (endingMinutes.Text != "")
            {
                if (Int32.TryParse(endingMinutes.Text, out parsedValue))
                {
                    endingMinutesNum = Int32.Parse(endingMinutes.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the ending minutes textbox.", "Minutes Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                endingMinutes.Text = "0";
            }

            if (endingSeconds.Text != "")
            {
                if (Int32.TryParse(endingSeconds.Text, out parsedValue))
                {
                    endingSecondsNum = Int32.Parse(endingSeconds.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the ending seconds textbox.", "Seconds Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                endingSeconds.Text = "0";
            }

            int timeResultDays = 0;
            int timeResultHours = 0;
            int timeResultMinutes = 0;
            int timeResultSeconds = 0;

            int timeSecondsCheck = 0;
            int timeMinutesCheck = 0;
            int timeHoursCheck = 0;

            if (addRadio.Checked)
            {
                timeResultSeconds = startingSecondsNum + endingSecondsNum;
                timeResultMinutes = startingMinutesNum + endingMinutesNum;
                timeResultHours = startingHoursNum + endingHoursNum;
                timeResultDays = startingDaysNum + endingDaysNum;

                while (timeSecondsCheck == 0 || timeMinutesCheck == 0 || timeHoursCheck == 0)
                {
                    if (timeResultSeconds < 0)
                    {
                        timeResultSeconds += 60;
                        timeResultMinutes -= 1;
                    }
                    else if (timeResultSeconds > 60)
                    {
                        timeResultSeconds -= 60;
                        timeResultMinutes += 1;
                    }
                    else
                    {
                        timeSecondsCheck = 1;
                    }

                    if (timeResultMinutes < 0)
                    {
                        timeResultMinutes += 60;
                        timeResultHours -= 1;
                    }
                    else if (timeResultMinutes > 60)
                    {
                        timeResultMinutes -= 60;
                        timeResultHours += 1;
                    }
                    else
                    {
                        timeMinutesCheck = 1;
                    }

                    if (timeResultHours < 0)
                    {
                        timeResultHours += 24;
                        timeResultDays -= 1;
                    }
                    else if (timeResultHours > 24)
                    {
                        timeResultHours -= 24;
                        timeResultDays += 1;
                    }
                    else
                    {
                        timeHoursCheck = 1;
                    }
                }

            }
            else if (subtractRadio.Checked)
            {
                timeResultSeconds = Math.Abs(startingSecondsNum - endingSecondsNum);
                timeResultMinutes = Math.Abs(startingMinutesNum - endingMinutesNum);
                timeResultHours = Math.Abs(startingHoursNum - endingHoursNum);
                timeResultDays = Math.Abs(startingDaysNum - endingDaysNum);

                while (timeSecondsCheck == 0 || timeMinutesCheck == 0 || timeHoursCheck == 0)
                {
                    if (timeResultSeconds < 0)
                    {
                        timeResultSeconds += 60;
                        timeResultMinutes -= 1;
                    } else if (timeResultSeconds > 60)
                    {
                        timeResultSeconds -= 60;
                        timeResultMinutes -= 1;
                    } else
                    {
                        timeSecondsCheck = 1;
                    }

                    if (timeResultMinutes < 0)
                    {
                        timeResultMinutes += 60;
                        timeResultHours -= 1;
                    } else if (timeResultMinutes < 0)
                    {
                        timeResultMinutes += 60;
                        timeResultHours -= 1;
                    } else 
                    { 
                        timeMinutesCheck = 1; 
                    }

                    if (timeResultHours < 0)
                    {
                        timeResultHours += 24;
                        timeResultDays -= 1;
                    } else if (timeResultHours < 0)
                    {
                        timeResultHours += 24;
                        timeResultDays -= 1;
                    } else
                    {
                        timeHoursCheck = 1;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select the appropriate radio button for adding or subtracting.", "No Operand Selected",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            resultDays.Text = timeResultDays.ToString();
            resultHours.Text = timeResultHours.ToString();
            resultMinutes.Text = timeResultMinutes.ToString();
            resultSeconds.Text = timeResultSeconds.ToString();
        }

        private void timeRotateButton_Click(object sender, EventArgs e)
        {
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




        //HOURLY RATE CALCULATOR
        private void rateCalculateButton_Click(object sender, EventArgs e)
        {
            double parsedDouble;
            int parsedInt;

            int rateHoursNum = 0;
            double rateMinutesNum = 0;
            double rateSecondsNum = 0;

            double rateResult = 0;

            double rate = 0;

            if (hourlyRate.Text != "")
            {
                if (double.TryParse(hourlyRate.Text, out parsedDouble))
                {
                    rate = double.Parse(hourlyRate.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the hourly rate textbox.", "Hourly Rate Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                hourlyRate.Text = "0";
            }

            if (rateHours.Text != "")
            {
                if (Int32.TryParse(rateHours.Text, out parsedInt))
                {
                    rateHoursNum = Int32.Parse(rateHours.Text);
                    if (rateHoursNum != 0)
                    {
                        rateResult = rateResult + (rate * rateHoursNum);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the rate hours textbox.", "Rate Hours Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                rateHours.Text = "0";
            }

            if (rateMinutes.Text != "")
            {
                if (Int32.TryParse(rateMinutes.Text, out parsedInt))
                {
                    rateMinutesNum = Int32.Parse(rateMinutes.Text);
                    if (rateMinutesNum != 0)
                    {
                        rateResult = rateResult + (rate * (rateMinutesNum / 60));
                        double test = rate * (rateMinutesNum / 60);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the rate minutes textbox.", "Rate Minutes Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                rateMinutes.Text = "0";
            }

            if (rateSeconds.Text != "")
            {
                if (Int32.TryParse(rateSeconds.Text, out parsedInt))
                {
                    rateSecondsNum = Int32.Parse(rateSeconds.Text);
                    if (rateSecondsNum != 0)
                    {
                        rateResult = rateResult + (rate * (rateSecondsNum / 3600));
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the rate seconds textbox.", "Rate Seconds Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                rateSeconds.Text = "0";
            }
            payNum.Text = "$" + rateResult.ToString("F2");
        }

        private void timeframeResultMinute_Click(object sender, EventArgs e)
        {

        }





        //DURATION CALCULATOR
        private void timeframeCalculateButton_Click(object sender, EventArgs e)
        {
            int parsedValue;

            int startingTimeHoursNum = 0;
            int startingTimeMinutesNum = 0;
            int startingTimeSecondsNum = 0;
            string selectedEndingAMPM = null;
            string selectedStartingAMPM = null;
            if (startingAMPM.SelectedItem == null)
            {
                MessageBox.Show("Please select AM or PM in the dropdown.", "AM/PM Not Specified",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                selectedStartingAMPM = startingAMPM.SelectedItem.ToString();
            }
            if (endingAMPM.SelectedItem == null)
            {
                MessageBox.Show("Please select AM or PM in the dropdown.", "AM/PM Not Specified",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                selectedEndingAMPM = endingAMPM.SelectedItem.ToString();
            }
            if (startingTimeHour.Text != "")
            {
                if (Int32.TryParse(startingTimeHour.Text, out parsedValue))
                {
                    startingTimeHoursNum = Int32.Parse(startingTimeHour.Text);
                    if (selectedStartingAMPM != "")
                    {
                        if (selectedStartingAMPM == "AM")
                        {
                            //Do nothing
                        }
                        else if (selectedStartingAMPM == "PM")
                        {
                            if (startingTimeHoursNum < 11)
                            {
                                startingTimeHoursNum = 12 + startingTimeHoursNum;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select AM or PM in the dropdown.", "AM/PM Not Specified",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the initial timeframe hour textbox.", "Hour Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                startingTimeHour.Text = "0";
            }

            if (startingTimeMinute.Text != "")
            {
                if (Int32.TryParse(startingTimeMinute.Text, out parsedValue))
                {
                    startingTimeMinutesNum = Int32.Parse(startingTimeMinute.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the initial timeframe minute textbox.", "Minute Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                startingTimeMinute.Text = "0";
            }

            if (startingTimeSecond.Text != "")
            {
                if (Int32.TryParse(startingTimeSecond.Text, out parsedValue))
                {
                    startingTimeSecondsNum = Int32.Parse(startingTimeSecond.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the initial timeframe seconds textbox.", "Second Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                startingTimeSecond.Text = "0";
            }

            int endingTimeHoursNum = 0;
            int endingTimeMinutesNum = 0;
            int endingTimeSecondsNum = 0;

            if (endingTimeHour.Text != "")
            {
                if (Int32.TryParse(endingTimeHour.Text, out parsedValue))
                {
                    endingTimeHoursNum = Int32.Parse(endingTimeHour.Text);
                    if (selectedEndingAMPM != "")
                    {
                        if (selectedEndingAMPM == "AM")
                        {
                            //Do nothing
                        }
                        else if (selectedEndingAMPM == "PM")
                        {
                            if (endingTimeHoursNum < 11)
                            {
                                endingTimeHoursNum = 12 + endingTimeHoursNum;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select AM or PM in the dropdown.", "AM/PM Not Specified",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the ending timeframe hour textbox.", "Hour Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                endingTimeHour.Text = "0";
            }

            if (endingTimeMinute.Text != "")
            {
                if (Int32.TryParse(endingTimeMinute.Text, out parsedValue))
                {
                    endingTimeMinutesNum = Int32.Parse(endingTimeMinute.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the ending timeframe minute textbox.", "Minute Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                endingTimeMinute.Text = "0";
            }

            if (endingTimeSecond.Text != "")
            {
                if (Int32.TryParse(endingTimeSecond.Text, out parsedValue))
                {
                    endingTimeSecondsNum = Int32.Parse(endingTimeSecond.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the ending timeframe seconds textbox.", "Second Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                endingTimeSecond.Text = "0";
            }

            int timeframeCalcHours = 0;
            int timeframeCalcMinutes = 0;
            int timeframeCalcSeconds = 0;

            if (addTimeframeRadio.Checked)
            {
                timeframeCalcSeconds = startingTimeSecondsNum + endingTimeSecondsNum;
                timeframeCalcMinutes = startingTimeMinutesNum + endingTimeMinutesNum;
                timeframeCalcHours = startingTimeHoursNum + endingTimeHoursNum;

                while (timeframeCalcSeconds >= 60)
                {
                    timeframeCalcSeconds -= 60;
                    timeframeCalcMinutes += 1;
                }
                while (timeframeCalcSeconds < 0)
                {
                    timeframeCalcSeconds += 60;
                    timeframeCalcMinutes -= 1;
                }
                while (timeframeCalcMinutes >= 60)
                {
                    timeframeCalcMinutes -= 60;
                    timeframeCalcHours += 1;
                }
                while (timeframeCalcMinutes < 0)
                {
                    timeframeCalcMinutes += 60;
                    timeframeCalcHours -= 1;
                }
            }
            else if (subtractTimeframeRadio.Checked)
            {
                timeframeCalcSeconds = Math.Abs(startingTimeSecondsNum - endingTimeSecondsNum);
                timeframeCalcMinutes = Math.Abs(startingTimeMinutesNum - endingTimeMinutesNum);
                timeframeCalcHours = Math.Abs(startingTimeHoursNum - endingTimeHoursNum);

                while (timeframeCalcSeconds >= 60)
                {
                    timeframeCalcSeconds -= 60;
                    timeframeCalcMinutes += 1;
                }
                while (timeframeCalcSeconds < 0)
                {
                    timeframeCalcSeconds += 60;
                    timeframeCalcMinutes -= 1;
                }
                while (timeframeCalcMinutes >= 60)
                {
                    timeframeCalcMinutes -= 60;
                    timeframeCalcHours += 1;
                }
                while (timeframeCalcMinutes < 0)
                {
                    timeframeCalcMinutes += 60;
                    timeframeCalcHours -= 1;
                }

            }
            else
            {
                MessageBox.Show("Please select the appropriate radio button for adding or subtracting.", "No Operand Selected",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            timeframeResultHour.Text = timeframeCalcHours.ToString();
            timeframeResultMinute.Text = timeframeCalcMinutes.ToString();
            timeframeResultSecond.Text = timeframeCalcSeconds.ToString();
            timeframeResultAMPM.Text = "N/A";
        }






        private void resultingTimeCalculate_Click(object sender, EventArgs e)
        {
            int parsedValue;

            int startingTimeHoursNum = 0;
            int startingTimeMinutesNum = 0;
            int startingTimeSecondsNum = 0;
            string selectedEndingAMPM = null;
            string selectedStartingAMPM = null;
            if (startingAMPM.SelectedItem == null)
            {
                MessageBox.Show("Please select AM or PM in the dropdown.", "AM/PM Not Specified",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                selectedStartingAMPM = startingAMPM.SelectedItem.ToString();
            }
            if (endingAMPM.SelectedItem == null)
            {
                //Do nothing.
                //MessageBox.Show("Please select AM or PM in the dropdown.", "AM/PM Not Specified",
                 //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                selectedEndingAMPM = endingAMPM.SelectedItem.ToString();
            }

            if (startingTimeHour.Text != "")
            {
                if (Int32.TryParse(startingTimeHour.Text, out parsedValue))
                {
                    startingTimeHoursNum = Int32.Parse(startingTimeHour.Text);
                    if (selectedStartingAMPM != "")
                    {
                        if (selectedStartingAMPM == "AM")
                        {
                            //Do nothing
                        }
                        else if (selectedStartingAMPM == "PM")
                        {
                            if (startingTimeHoursNum < 11)
                            {
                                startingTimeHoursNum = 12 + startingTimeHoursNum;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select AM or PM in the dropdown.", "AM/PM Not Specified",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the initial timeframe hour textbox.", "Hour Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                startingTimeHour.Text = "0";
            }

            if (startingTimeMinute.Text != "")
            {
                if (Int32.TryParse(startingTimeMinute.Text, out parsedValue))
                {
                    startingTimeMinutesNum = Int32.Parse(startingTimeMinute.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the initial timeframe minute textbox.", "Minute Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                startingTimeMinute.Text = "0";
            }

            if (startingTimeSecond.Text != "")
            {
                if (Int32.TryParse(startingTimeSecond.Text, out parsedValue))
                {
                    startingTimeSecondsNum = Int32.Parse(startingTimeSecond.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the initial timeframe seconds textbox.", "Second Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                startingTimeSecond.Text = "0";
            }

            int endingTimeHoursNum = 0;
            int endingTimeMinutesNum = 0;
            int endingTimeSecondsNum = 0;

            if (endingTimeHour.Text != "")
            {
                if (Int32.TryParse(endingTimeHour.Text, out parsedValue))
                {
                    endingTimeHoursNum = Int32.Parse(endingTimeHour.Text);
                    if (selectedEndingAMPM != "")
                    {
                        if (selectedEndingAMPM == "AM")
                        {
                            //Do nothing
                        }
                        else if (selectedEndingAMPM == "PM")
                        {
                            if (endingTimeHoursNum < 11)
                            {
                                endingTimeHoursNum = 12 + endingTimeHoursNum;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select AM or PM in the dropdown.", "AM/PM Not Specified",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the ending timeframe hour textbox.", "Hour Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                endingTimeHour.Text = "0";
            }

            if (endingTimeMinute.Text != "")
            {
                if (Int32.TryParse(endingTimeMinute.Text, out parsedValue))
                {
                    endingTimeMinutesNum = Int32.Parse(endingTimeMinute.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the ending timeframe minute textbox.", "Minute Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                endingTimeMinute.Text = "0";
            }

            if (endingTimeSecond.Text != "")
            {
                if (Int32.TryParse(endingTimeSecond.Text, out parsedValue))
                {
                    endingTimeSecondsNum = Int32.Parse(endingTimeSecond.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the ending timeframe seconds textbox.", "Second Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                endingTimeSecond.Text = "0";
            }

            int timeframeCalcHours = 0;
            int timeframeCalcMinutes = 0;
            int timeframeCalcSeconds = 0;

            string AMPM = selectedStartingAMPM;

            if (addTimeframeRadio.Checked)
            {
                timeframeCalcSeconds = startingTimeSecondsNum + endingTimeSecondsNum;
                timeframeCalcMinutes = startingTimeMinutesNum + endingTimeMinutesNum;
                timeframeCalcHours = startingTimeHoursNum + endingTimeHoursNum;

                while (timeframeCalcSeconds >= 60)
                {
                    timeframeCalcSeconds -= 60;
                    timeframeCalcMinutes += 1;
                }
                while (timeframeCalcSeconds < 0)
                {
                    timeframeCalcSeconds += 60;
                    timeframeCalcMinutes -= 1;
                }
                while (timeframeCalcMinutes >= 60)
                {
                    timeframeCalcMinutes -= 60;
                    timeframeCalcHours += 1;
                }
                while (timeframeCalcMinutes < 0)
                {
                    timeframeCalcMinutes += 60;
                    timeframeCalcHours -= 1;
                }
                while (timeframeCalcHours >= 12)
                {
                    if (AMPM == "AM")
                    {
                        AMPM = "PM";
                    }
                    else
                    {
                        AMPM = "AM";
                    }
                    timeframeCalcHours -= 12;
                }
                if (timeframeCalcHours == 0)
                {
                    timeframeCalcHours = 12;
                }

                
            }
            else if (subtractTimeframeRadio.Checked)
            {
                timeframeCalcSeconds = Math.Abs(startingTimeSecondsNum - endingTimeSecondsNum);
                timeframeCalcMinutes = Math.Abs(startingTimeMinutesNum - endingTimeMinutesNum);
                timeframeCalcHours = Math.Abs(startingTimeHoursNum - endingTimeHoursNum);

                while (timeframeCalcSeconds >= 60)
                {
                    timeframeCalcSeconds -= 60;
                    timeframeCalcMinutes += 1;
                }
                while (timeframeCalcSeconds < 0)
                {
                    timeframeCalcSeconds += 60;
                    timeframeCalcMinutes -= 1;
                }
                while (timeframeCalcMinutes >= 60)
                {
                    timeframeCalcMinutes -= 60;
                    timeframeCalcHours += 1;
                }
                while (timeframeCalcMinutes < 0)
                {
                    timeframeCalcMinutes += 60;
                    timeframeCalcHours -= 1;
                }
                while (timeframeCalcHours >= 12)
                {
                    if (AMPM == "AM")
                    {
                        AMPM = "PM";
                    }
                    else
                    {
                        AMPM = "AM";
                    }
                    timeframeCalcHours -= 12;
                }
                if (timeframeCalcHours == 0)
                {
                    timeframeCalcHours = 12;
                }

            }
            else
            {
                MessageBox.Show("Please select the appropriate radio button for adding or subtracting.", "No Operand Selected",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            timeframeResultHour.Text = timeframeCalcHours.ToString();
            timeframeResultMinute.Text = timeframeCalcMinutes.ToString();
            timeframeResultSecond.Text = timeframeCalcSeconds.ToString();
            timeframeResultAMPM.Text = AMPM;
        }



        //DATE CALCULATOR
        private void dateCalculateButton_Click(object sender, EventArgs e)
        {
            int parsedValue;

            int startingMonthNum = 0;
            int startingDayNum = 0;
            int startingYearNum = 0;

            int endingMonthNum = 0;
            int endingDayNum = 0;
            int endingYearNum = 0;

            if (startingMonth.Text != "")
            {
                if (Int32.TryParse(startingMonth.Text, out parsedValue))
                {
                    startingMonthNum = Int32.Parse(startingMonth.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the starting month textbox.", "Month Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                startingMonth.Text = "0";
            }

            if (startingDay.Text != "")
            {
                if (Int32.TryParse(startingDay.Text, out parsedValue))
                {
                    startingDayNum = Int32.Parse(startingDay.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the starting day textbox.", "Day Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                startingDay.Text = "0";
            }

            if (startingYear.Text != "")
            {
                if (Int32.TryParse(startingYear.Text, out parsedValue))
                {
                    startingYearNum = Int32.Parse(startingYear.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the starting year textbox.", "Year Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                startingYear.Text = "0";
            }

            // Parse ending date components
            if (endingMonth.Text != "")
            {
                if (Int32.TryParse(endingMonth.Text, out parsedValue))
                {
                    endingMonthNum = Int32.Parse(endingMonth.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the ending month textbox.", "Month Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                endingMonth.Text = "0";
            }

            if (endingDay.Text != "")
            {
                if (Int32.TryParse(endingDay.Text, out parsedValue))
                {
                    endingDayNum = Int32.Parse(endingDay.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the ending day textbox.", "Day Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                endingDay.Text = "0";
            }

            if (endingYear.Text != "")
            {
                if (Int32.TryParse(endingYear.Text, out parsedValue))
                {
                    endingYearNum = Int32.Parse(endingYear.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a numeric value in the ending year textbox.", "Year Textbox is Not Numeric",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                endingYear.Text = "0";
            }

            int dateCalcMonth = 0;
            int dateCalcDay = 0;
            int dateCalcYear = 0;

            int dateMonthCheck = 0;
            int dateDayCheck = 0;

            int check28 = 0;
            int check30 = 0;
            int check31 = 0;

            if (addDate.Checked)
            {
                dateCalcMonth = Math.Abs(startingMonthNum + endingMonthNum);
                dateCalcDay = Math.Abs(startingDayNum + endingDayNum);
                dateCalcYear = Math.Abs(startingYearNum + endingYearNum);

                while (dateDayCheck == 0 || dateMonthCheck == 0)
                {
                    if (dateCalcMonth > 12)
                    {
                        dateCalcMonth -= 12;
                        dateCalcYear += 1;
                    } else if (dateCalcMonth < 0)
                    {
                        dateCalcMonth += 12;
                        dateCalcYear -= 1;
                    }
                    else
                    {
                        dateMonthCheck = 1;
                    }

                    if (dateCalcDay > 31)
                    {
                        dateCalcDay -= 31;
                        dateCalcMonth += 1;
                    } else if (dateCalcDay < 0)
                    {
                        dateCalcDay += 31;
                        dateCalcMonth -= 1;
                    } else
                    {
                        dateDayCheck = 1;
                    }
                }

                while (check28 == 0 || check30 == 0 || check31 == 0)
                {
                    if (dateCalcMonth == 2)
                    {
                        if (dateCalcDay > 28)
                        {
                            dateCalcDay -= 28;
                            dateCalcMonth++;
                            check28 = 0;
                        }
                        else
                        {
                            check28 = 1;
                        }
                    } else
                    {
                        check28 = 1;
                    }
                    if (dateCalcMonth == 4 || dateCalcMonth == 6 || dateCalcMonth == 8 || dateCalcMonth == 11)
                    {
                        if (dateCalcDay > 30)
                        {
                            dateCalcDay -= 30;
                            dateCalcMonth++;
                            check30 = 0;
                        }
                        else
                        {
                            check30 = 1;
                        }
                    }
                    else
                    {
                        check30 = 1;
                    }
                    if (dateCalcMonth == 1 || dateCalcMonth == 3 || dateCalcMonth == 5 || dateCalcMonth == 7 || dateCalcMonth == 9 || dateCalcMonth == 10 || dateCalcMonth == 12)
                    {
                        if (dateCalcDay > 31)
                        {
                            dateCalcDay -= 31;
                            dateCalcMonth++;
                            check31 = 0;
                        }
                        else
                        {
                            check31 = 1;
                        }
                    }
                    else
                    {
                        check31 = 1;
                    }
                }

                while (dateCalcMonth > 12)
                {
                    dateCalcMonth -= 12;
                    dateCalcYear += 1;
                }
            } else if (subtractDate.Checked)
            {
                dateCalcMonth = startingMonthNum - endingMonthNum;
                dateCalcDay = startingDayNum - endingDayNum;
                dateCalcYear = startingYearNum - endingYearNum;

                while (dateDayCheck == 0 || dateMonthCheck == 0)
                {
                    if (dateCalcMonth > 12)
                    {
                        dateCalcMonth -= 12;
                        dateCalcYear += 1;
                    }
                    else if (dateCalcMonth < 0)
                    {
                        dateCalcMonth += 12;
                        dateCalcYear -= 1;
                    }
                    else
                    {
                        dateMonthCheck = 1;
                    }

                    if (dateCalcDay > 31)
                    {
                        dateCalcDay -= 31;
                        dateCalcMonth += 1;
                    }
                    else if (dateCalcDay < 0)
                    {
                        dateCalcDay += 31;
                        dateCalcMonth -= 1;
                    }
                    else
                    {
                        dateDayCheck = 1;
                    }
                }

                while (check28 == 0 || check30 == 0 || check31 == 0)
                {
                    if (dateCalcMonth == 2)
                    {
                        if (dateCalcDay < 0)
                        {
                            dateCalcDay += 28;
                            dateCalcMonth--;
                            check28 = 0;
                        }
                        else
                        {
                            check28 = 1;
                        }
                    } else
                    {
                        check28 = 1;
                    }
                    if (dateCalcMonth == 4 || dateCalcMonth == 6 || dateCalcMonth == 8 || dateCalcMonth == 11)
                    {
                        if (dateCalcDay < 0)
                        {
                            dateCalcDay += 30;
                            dateCalcMonth--;
                            check30 = 0;
                        }
                        else
                        {
                            check30 = 1;
                        }
                    } else
                    {
                        check30 = 1;
                    }
                    if (dateCalcMonth == 1 || dateCalcMonth == 3 || dateCalcMonth == 5 || dateCalcMonth == 7 || dateCalcMonth == 9 || dateCalcMonth == 10 || dateCalcMonth == 12)
                    {
                        if (dateCalcDay < 0)
                        {
                            dateCalcDay += 31;
                            dateCalcMonth--;
                            check31 = 0;
                        }
                        else
                        {
                            check31 = 1;
                        }
                    } else
                    {
                        check31 = 1;
                    }
                }

                while (dateCalcMonth < 0)
                {
                    dateCalcMonth += 12;
                    dateCalcYear--;
                }
            } else
            {
                MessageBox.Show("Please select the appropriate radio button for adding or subtracting.", "No Operand Selected",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dateResultMonth.Text = dateCalcMonth.ToString();
            dateResultDay.Text = dateCalcDay.ToString();
            dateResultYear.Text = dateCalcYear.ToString();
        }

        private void startingTimeHour_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
