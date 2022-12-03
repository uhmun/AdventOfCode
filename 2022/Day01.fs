module AoC2022Day01

//┌───────┬────────┬──────────┬──────────────┐
//│ Day   │ Part   │ Solution │ Elapsed time │
//├───────┼────────┼──────────┼──────────────┤
//│ Day 1 │ Part 1 │ 69912    │ 4 ms         │
//│ Day 1 │ Part 2 │ 208180   │ 4 ms         │
//└───────┴────────┴──────────┴──────────────┘

open AoCHelper
open System.IO
open System.Threading.Tasks

//module attempt2 =
//    let getCaloriesArray input = 
//        let divide pred input =
//            let f x (acc,buf) =
//                match pred x,buf with
//                | true,buf -> (acc,(int)x::buf)
//                | false,[] -> (acc,[])
//                | false,buf -> (buf::acc,[])

//            let rest,remainingBuffer = Array.foldBack f input ([],[])
//            match remainingBuffer with
//            | [] -> rest
//            | buf -> buf :: rest

//        let pred (s:string) = (System.String.IsNullOrWhiteSpace s = false)
//        let caloriesArray = divide pred input
//        caloriesArray

module common = 
    let getCaloriesArray input = 
        let caloriesArray = ResizeArray<int>()
        let mutable currentCalories = 0

        for calories:string in input do
            if (System.String.IsNullOrWhiteSpace calories) then
                caloriesArray.Add currentCalories
                currentCalories <- 0
            else currentCalories <- currentCalories + int calories

        caloriesArray.Sort()
        caloriesArray.Reverse()
        caloriesArray

module solve_1 =
    let solution input = 
        let caloriesArray = common.getCaloriesArray input |> Seq.head

        let result = caloriesArray
        result.ToString()
        

module solve_2 =
    let solution input = 
        let caloriesArray = common.getCaloriesArray input |> Seq.take(3) |> Seq.sum
        
        let result = caloriesArray
        result.ToString()

type Day01() = 
    inherit BaseDay()
    let inputFile = File.ReadAllLines(base.InputFilePath)
    override  this.Solve_1() = solve_1.solution inputFile |> ValueTask<string>
    override  this.Solve_2() = solve_2.solution inputFile |> ValueTask<string>