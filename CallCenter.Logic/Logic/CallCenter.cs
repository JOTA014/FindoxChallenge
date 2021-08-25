using CallCenter.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CallCenter.Logic.Logic
{
    public class CallCenter
    {
        //List<Agent> Agents = new List<Agent>();
        //List<Manager> Managers = new List<Manager>();

        ObservableCollection<Agent> Agents = new ObservableCollection<Agent>();
        ObservableCollection<Manager> Managers = new ObservableCollection<Manager>();
        Queue<int> callQueue = new Queue<int>();

        public CallCenter()
        {
            InitializeCallCenter();
        }

        public void NewCall(int callId)
        {
            if(Agents.Any(x => x.IsBusy == false))
            {
                AssignCallToAgent(callId);
            }
            else if(Managers.Any(x => x.IsBusy == false))
            {
                AssignCallToManager(callId);
            }
            else
            {
                callQueue.Enqueue(callId);
            }
        }

        private void AssignCallToManager(int callId)
        {
            var availableManager = Managers.First(x => x.IsBusy == false);
            var newManagers = Managers.Where(c => c.Id == availableManager.Id).Select(c => { c.Call = callId; c.IsBusy = true; return c; }).ToList();
            Managers[Managers.IndexOf(availableManager)] = newManagers.First();
        }

        private void AssignCallToAgent(int callId)
        {
            var availableAgent = Agents.First(x => x.IsBusy == false);
            var newAgents = Agents.Where(c => c.Id == availableAgent.Id).Select(c => { c.Call = callId; c.IsBusy = true; return c; }).ToList();
            Agents[Agents.IndexOf(availableAgent)] = newAgents.First();
        }

        public int GetNumberOfBusyAgents()
        {
            return Agents.Count(x => x.IsBusy == true);
        }

        public int GetNumberOfBusyManagers()
        {
            return Managers.Count(x => x.IsBusy == true);
        }

        public int GetCallsInQueue()
        {
            return callQueue.Count;
        }

        private void InitializeCallCenter()
        {
            InitializeAgents();
            Initializemanagers();
        }

        private void InitializeAgents()
        {
            for (var i = 1; i <= 5; i++)
            {
                Agents.Add(new Agent { Id = i, Call = 0 });
            }

            Agents.CollectionChanged += AgentChanged;
        }

        private void Initializemanagers()
        {
            for (var i = 1; i <= 2; i++)
            {
                Managers.Add(new Manager { Id = i, Call = 0 });
            }

            Managers.CollectionChanged += ManagerChanged;
        }

        private void AgentChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(Agents.Any(x => x.IsBusy == false) && e.Action != NotifyCollectionChangedAction.Replace)
            {
                AssignCallToAgent(callQueue.Dequeue());
            }
        }

        private void ManagerChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (Managers.Any(x => x.IsBusy == false) && e.Action != NotifyCollectionChangedAction.Replace)
            {
                AssignCallToManager(callQueue.Dequeue());
            }
        }

        public void FreeUpAgent()
        {
            var availableAgent = Agents.First();
            var newAgents = Agents.Where(c => c.Id == availableAgent.Id).Select(c => { c.Call = 0; c.IsBusy = false; return c; }).ToList();
            Agents.Remove(availableAgent);
            Agents.Add(newAgents.First());
        }

        public void FreeUpManager()
        {
            var availableManager = Managers.First();
            var newManagers = Managers.Where(c => c.Id == availableManager.Id).Select(c => { c.Call = 0; c.IsBusy = false; return c; }).ToList();
            Managers.Remove(availableManager);
            Managers.Add(newManagers.First());
        }
    }
}
