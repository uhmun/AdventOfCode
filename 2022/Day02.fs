module AoC2022Day02

//┌───────┬────────┬──────────┬──────────────┐
//│ Day   │ Part   │ Solution │ Elapsed time │
//├───────┼────────┼──────────┼──────────────┤
//│ Day 2 │ Part 1 │ 15691    │ 12 ms        │
//│ Day 2 │ Part 2 │ 12989    │ 0.81 ms      │
//└───────┴────────┴──────────┴──────────────┘

open AoCHelper
open System.IO
open System.Threading.Tasks

type Rps =
   | Rock = 1
   | Paper = 2
   | Scissors = 3

type outcomeScore =
    | lost = 0
    | draw = 3
    | win = 6

//this beats that
let gameRules = Map[Rps.Rock, Rps.Scissors; Rps.Paper, Rps.Rock; Rps.Scissors, Rps.Paper ]

module solve_1 =
    let parseRps = function
    | 'A' -> Rps.Rock
    | 'B' -> Rps.Paper
    | 'C' -> Rps.Scissors
    | 'X' -> Rps.Rock
    | 'Y' -> Rps.Paper
    | 'Z' -> Rps.Scissors

    let getOutcomeScore (myChoice:Rps) (opponentChoice:Rps) =
        if myChoice = opponentChoice then 3
        elif gameRules[myChoice] = opponentChoice then 6
        else 0

    let solution input =
        let mutable overallScore = 0

        for game:string in input do
            let opponentChoice = parseRps game[0]
            let myChoice = parseRps game[2]
            overallScore <- overallScore + getOutcomeScore myChoice opponentChoice
            overallScore <- overallScore + (int)myChoice
            
        let result = overallScore
        result.ToString()
        

module solve_2 =
    let parseRps = function
    | 'A' -> Rps.Rock
    | 'B' -> Rps.Paper
    | 'C' -> Rps.Scissors

    let parseOutcome = function
    | 'X' -> outcomeScore.lost
    | 'Y' -> outcomeScore.draw
    | 'Z' -> outcomeScore.win

    let rev map: Map<Rps,Rps> = 
      Map.fold (fun m key value -> m.Add(value,key)) Map.empty map

    let howToWin = rev gameRules

    let solution input =
        let mutable overallScore = 0

        for game:string in input do
            let opponentChoice = parseRps game[0]
            let outcome = parseOutcome game[2]
            
            if outcome = outcomeScore.draw then overallScore <- overallScore + (int)opponentChoice + (int)outcomeScore.draw
            elif outcome = outcomeScore.lost then
                overallScore <- overallScore + (int)gameRules[opponentChoice]
            else
                overallScore <- overallScore + (int)outcomeScore.win
                overallScore <- overallScore + (int)howToWin[opponentChoice]
            
        let result = overallScore
        result.ToString()

type Day02() = 
    inherit BaseDay()
    let inputFile = File.ReadAllLines(base.InputFilePath)
    override  this.Solve_1() = solve_1.solution inputFile |> ValueTask<string>
    override  this.Solve_2() = solve_2.solution inputFile |> ValueTask<string>