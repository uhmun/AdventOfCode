module AoC2022_Day01

open AoCHelper
open System.IO
open System.Threading.Tasks

module solve_1 =
    let solution input = 
        task{
            let result = ""
            return result
        }
        

module solve_2 =
    let solution input = 
        task{
            let result = ""
            return result
        }

type Day01() = 
    inherit BaseDay()
    let inputFile = File.ReadAllLines(base.InputFilePath)
    override  this.Solve_1() = solve_1.solution inputFile |> ValueTask<string>
    override  this.Solve_2() = solve_2.solution inputFile |> ValueTask<string>