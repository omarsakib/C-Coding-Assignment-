using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace DAQ_Simulation_Application
{
    public partial class Form1 : Form
    {
        DateTime timedate = DateTime.Now;
        List<string> ListValue = new List<string>();
        string[] AnalogValue = new string[3];
        string[] DigitalValue = new string[1];
        string AnalogText;
        string DigitalText;
        int maximumSensorID = 4;
        int ctr;


        Sensor[] SensorObject = new Sensor[4];

        public Form1()
        {
            InitializeComponent();

            for (ctr = 0; ctr < maximumSensorID; ctr++)
            {
                SensorObject[ctr] = new Sensor(ctr);
            }
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSampling_Click(object sender, EventArgs e)
        {
            
            tmrSampling.Start();
            txtSamplingTime.Text = time + "seconds";



        }
        double time = 0;

        private void tmrSampling_Tick(object sender, EventArgs e)
        {
            if (time > 55)
            {
                time = time + 1;
                txtSamplingTime.Text = time/10 + "seconds";
            }
            else
            {
                tmrSampling.Stop();

                txtSamplingTime.Text = "Sampled After 5.4 Sec";
                txtFinalValue.AppendText("Analog Sensor Value: ");

                for (ctr = 0; ctr < 3; ctr++)
                {
                    AnalogText = SensorObject[ctr].GetValueAnalog().ToString("F10");
                    txtFinalValue.AppendText(AnalogText + ",");

                    AnalogValue[ctr] = AnalogText;
                }
                string ListStringValues = string.Join(",", AnalogValue);

                ListValue.Add(ListStringValues);
                txtFinalValue.AppendText("Digital Sensors Value: ");


                for (ctr = 3; ctr < maximumSensorID; ctr++)
                {

                    DigitalText = SensorObject[ctr].GetValueDigital().ToString();
                    txtFinalValue.AppendText(DigitalText + ", ");

                    DigitalValue[ctr - 3] = DigitalText;
                }
                string DigitalListValues = string.Join(",", DigitalValue);
                string DateTime = string.Join("", timedate);
                ListValue.Add(DateTime);
                ListValue.Add(DigitalListValues);
                

            }
        }
        

        

        private void btnLogging_Click(object sender, EventArgs e)
        {

            tmrLogging.Start();
            circle_time = 0;
            txtLogging.Text=circle_time + " seconds";


        }
        int circle_time = 0;
        private void tmrLogging_Tick(object sender, EventArgs e)
        {
            if (circle_time > 61)
            {
                circle_time = circle_time + 1;
                txtLogging.Text = circle_time/10 + " seconds";
            }
            else
            {
                tmrLogging.Stop();
                txtLogging.Text = "Logged After 6 Sec";
                string filepath = @"D:\Assignment\Assignment_Result.csv";
                File.AppendAllLines(filepath, ListValue);
                txtFinalValue.Text = "Assignment Result SAVED!  ";

            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
