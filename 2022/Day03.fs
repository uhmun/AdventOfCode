module AoC2022Day03

//┌───────┬────────┬──────────┬──────────────┐
//│ Day   │ Part   │ Solution │ Elapsed time │
//├───────┼────────┼──────────┼──────────────┤
//│ Day 3 │ Part 1 │ 8018     │ 13 ms        │
//│ Day 3 │ Part 2 │ 2518     │ 3 ms         │
//└───────┴────────┴──────────┴──────────────┘

open AoCHelper
open System.IO
open System.Threading.Tasks

module common =
    let getPrioValues = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray()

    let getPriority (charArray: char array) =
        let mutable count = 0
        for c in charArray do
            let value = getPrioValues |> Array.findIndex ((=) c)
            count <- count + (value + 1)
        count

module solve_1 =
    open common

    let mutable result = 0

    let intersect (rucksack:string) =
        let compartments = rucksack.ToCharArray() |> Array.splitInto 2
        Set.intersect (set compartments[0]) (set compartments[1]) |> Array.ofSeq

    let solution (input: string array) = 
        for rucksack in input do
            result <- result + (intersect rucksack |> getPriority)

        result.ToString()

module solve_2 =
    open common

    let solution (input: string array) = 
        let mutable result = 0

        let thirds = input |> Array.chunkBySize 3
        
        for groupOfRucksacks in thirds do
            let intersection = Set.intersect (set (groupOfRucksacks[0].ToCharArray())) (set (groupOfRucksacks[1].ToCharArray())) |> Set.intersect (set (groupOfRucksacks[2].ToCharArray())) |> Array.ofSeq
            result <- result + getPriority intersection

        result.ToString()

type Day03() = 
    inherit BaseDay()
    let inputFile = File.ReadAllLines(base.InputFilePath)
    override  this.Solve_1() = solve_1.solution inputFile |> ValueTask<string>
    override  this.Solve_2() = solve_2.solution inputFile |> ValueTask<string>