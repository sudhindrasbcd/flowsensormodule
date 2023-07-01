// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace SimulatedFlowSensorModule
{
    public class FlowDataFactory
    {
        private static readonly Random rand = new Random();
        private static double CurrentMachineFlow;

        public static MessageBody CreateFlowData(int counter, int instanceId, DataGenerationPolicy policy, bool reset = false)
        {
            if (reset)
            {
                FlowDataFactory.CurrentMachineFlow = policy.CalculateMachineFlow();
            }
            else
            {
                FlowDataFactory.CurrentMachineFlow =
                    policy.CalculateMachineFlow(FlowDataFactory.CurrentMachineFlow);
            }

            var machinePressure = policy.CalculatePressure(FlowDataFactory.CurrentMachineFlow);
            var ambientFlow = policy.CalculateAmbientFlow();
            var ambientHumidity = policy.CalculateHumidity();

            var messageBody = new MessageBody
            {
                InstanceId = instanceId,
                Machine = new Machine
                {
                    Flow = FlowDataFactory.CurrentMachineFlow,
                    Pressure = machinePressure
                },
                Ambient = new Ambient
                {
                    Flow = ambientFlow,
                    Humidity = ambientHumidity
                },
                TimeCreated = string.Format("{0:O}", DateTime.Now)
            };

            return messageBody;
        }
    }
}
