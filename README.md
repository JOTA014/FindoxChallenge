
# Automation challenge

This repo contains my take on asked automation challenge



## Pre-requirements

I assume you do, but just in case you don't, you need to have installed:

- Visual studio 2019/Visual studio code
- .Net core 3.1
  
## Instructions

- Clone this repo
- Open/Build solution (under ./CallCenter)
- Run tests

## Implemented tests
- AddNewCall: Adds a new call which should be assigned to an agent
- AddTwoNewCall: Add 2 new calls which should be assigned to 2 agents
- AddCallToManager: Add enough (6) calls to be necessary to assign a call to a manager
- AddCallToBothManager: Add enough (7) calls to be necessary to assign a call to both managers
- SendCallToQueue: Add enough (8) calls to be necessary to send a call to the call queue
- AssignCallFromQueue: Add 10 calls (5 agents, 2 managers, 3 to the queue), then free up an agent and verify that we have now one call out of the queue and assigned to the previously freed agent (5 agents, 2 managers, 2 to the queue)
## Tech Stack

- C#
- .NET core
- XUNIT

## NOTE:

App code needs some refactors to make some generic code (reuse code and not repeat it) but since the objective of this challenge is (i think) evaluate the test automation I didn't took much time on it

  