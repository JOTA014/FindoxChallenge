using System;
using Xunit;

namespace CallCenter.Test
{
    public class CallCenterTest
    {
        [Fact]
        public void AddNewCall()
        {
            var callCenter = new Logic.Logic.CallCenter();
            callCenter.NewCall(1);
            Assert.Equal(1, callCenter.GetNumberOfBusyAgents());
        }

        [Fact]
        public void AddTwoNewCall()
        {
            var callCenter = new Logic.Logic.CallCenter();
            for (var i = 1; i <= 2; i++)
            {
                callCenter.NewCall(i);
            }
            Assert.Equal(2, callCenter.GetNumberOfBusyAgents());
        }

        [Fact]
        public void AddCallToManager()
        {
            var callCenter = new Logic.Logic.CallCenter();
            for (var i = 1; i <= 6; i++)
            {
                callCenter.NewCall(i);
            }
            Assert.Equal(5, callCenter.GetNumberOfBusyAgents());
            Assert.Equal(1, callCenter.GetNumberOfBusyManagers());
        }

        [Fact]
        public void AddCallToBothManager()
        {
            var callCenter = new Logic.Logic.CallCenter();
            for (var i = 1; i <= 7; i++)
            {
                callCenter.NewCall(i);
            }
            Assert.Equal(5, callCenter.GetNumberOfBusyAgents());
            Assert.Equal(2, callCenter.GetNumberOfBusyManagers());
        }

        [Fact]
        public void SendCallToQueue()
        {
            var callCenter = new Logic.Logic.CallCenter();
            for (var i = 1; i <= 8; i++)
            {
                callCenter.NewCall(i);
            }
            Assert.Equal(5, callCenter.GetNumberOfBusyAgents());
            Assert.Equal(2, callCenter.GetNumberOfBusyManagers());
            Assert.Equal(1, callCenter.GetCallsInQueue());
        }

        [Fact]
        public void AssignCallFromQueue()
        {
            var callCenter = new Logic.Logic.CallCenter();
            for (var i = 1; i <= 10; i++)
            {
                callCenter.NewCall(i);
            }
            Assert.Equal(5, callCenter.GetNumberOfBusyAgents());
            Assert.Equal(2, callCenter.GetNumberOfBusyManagers());
            Assert.Equal(3, callCenter.GetCallsInQueue()); //Here we have 3 calls on queue

            callCenter.FreeUpAgent(); //Here w free an agent and call assignment from queue shoud automatically assign a call to that agent

            Assert.Equal(5, callCenter.GetNumberOfBusyAgents());
            Assert.Equal(2, callCenter.GetNumberOfBusyManagers());
            Assert.Equal(2, callCenter.GetCallsInQueue()); //now we must have 2 calls on queue
        }
    }
}
