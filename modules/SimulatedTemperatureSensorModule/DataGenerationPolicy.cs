// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace SimulatedFlowSensorModule
{
    public class DataGenerationPolicy
    {
        private static readonly Random rnd = new Random();
        private double _normal;

        public DataGenerationPolicy()
        {
            MachineFlowMin = 21;
            MachineFlowMax = 100;
            MachinePressureMin = 1;
            MachinePressureMax = 10;
            AmbientFlow = 21;
            HumidityPercentMin = 24;
            HumidityPercentMax = 27;
            _normal = (MachinePressureMax - MachinePressureMin) / (MachineFlowMax - MachineFlowMin);
        }

        public double MachineFlowMin { get; private set; }
        public double MachineFlowMax { get; private set; }
        public double MachinePressureMin { get; private set; }
        public double MachinePressureMax { get; private set; }
        public double AmbientFlow { get; private set; }
        public int HumidityPercentMin { get; private set; }
        public int HumidityPercentMax { get; set; }

        public double CalculateMachineFlow(double? currentFlow = null)
        {
            var current = currentFlow ?? MachineFlowMin;
            if(current > MachineFlowMax)
            {
                current += rnd.NextDouble() - 0.5; // add value between [-0.5..0.5]
            }
            else
            {
                current += -0.25 + (rnd.NextDouble() * 1.5); // add value between [-0.25..1.25] - avg +0.5
            }
            return current;
        }

        public double CalculatePressure(double currentFlow)
        {
            return MachinePressureMin + ((currentFlow - MachineFlowMin) * _normal);
        }

        public double CalculateAmbientFlow()
        {
            return AmbientFlow + rnd.NextDouble() -0.5;
        }

        public int CalculateHumidity()
        {
            return rnd.Next(HumidityPercentMin, HumidityPercentMax);
        }
    }
}
