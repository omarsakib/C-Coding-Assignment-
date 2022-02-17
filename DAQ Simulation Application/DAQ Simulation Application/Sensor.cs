using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAQ_Simulation_Application
{
    public class Sensor
    {
        double dVal;
        int sVal;
        int sId;
        Random rSensorValue;

        public Sensor(int id)
        {

            sVal = id;
            rSensorValue = new Random(id);
            sVal = 0;
            dVal = 0.0F;
             

        }

        public int getSensorID ()
        {
            return sVal;
        }
        public double GetValueAnalog()
        {

            dVal += rSensorValue.NextDouble() * 10;
            return dVal;
        }

        public double GetValueDigital()
        {

            sId += rSensorValue.Next(0,1);
            return sId;
        }


        
    }
}
