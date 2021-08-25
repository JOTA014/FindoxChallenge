using System;
using System.Collections.Generic;
using System.Text;

namespace CallCenter.Logic.DTO
{
    public class Agent
    {
        public int Id { get; set; }
        public int Call { get; set; }
        public bool IsBusy = false;
    }
}
