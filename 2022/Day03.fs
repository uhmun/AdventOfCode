module AoC2022Day03

//┌───────┬────────┬──────────┬──────────────┐
//│ Day   │ Part   │ Solution │ Elapsed time │
//├───────┼────────┼──────────┼──────────────┤
//└───────┴────────┴──────────┴──────────────┘

open AoCHelper
open System.IO
open System.Threading.Tasks

module solve_1 =
    let solution input = 
        let result = ""
        result.ToString()

module solve_2 =
    let solution input = 
        let result = ""
        result.ToString()

type Day03() = 
    inherit BaseDay()
    let inputFile = File.ReadAllLines(base.InputFilePath)
    override  this.Solve_1() = solve_1.solution inputFile |> ValueTask<string>
    override  this.Solve_2() = solve_2.solution inputFile |> ValueTask<string>