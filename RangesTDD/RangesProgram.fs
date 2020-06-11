// Learn more about F# at http://fsharp.org

open System

type Range(rangeExpression:string) =
    class
        let mutable expression = rangeExpression.Trim().Split(',');
        let mutable startVal = Int32.Parse(expression.[0].Substring(1));
        let mutable endVal = Int32.Parse(expression.[1].Substring(0,expression.[1].Length - 1));
        do
            if (expression.[0].StartsWith('(')) then
                startVal <- startVal + 1
            elif not(expression.[0].StartsWith('[')) then
                eprintfn "Rango Invalido"

            if (expression.[1].EndsWith(')')) then
                endVal <- endVal - 1
            elif not(expression.[1].EndsWith(']')) then
                eprintfn "Rango Invalido"
        
        do printfn "Rango: %s %d %d" rangeExpression startVal endVal

        member this.Contains(inputRange:int[]):bool =
            let mutable isContained = true
            for value in inputRange do
                if value < startVal || endVal < value then
                    isContained <- false
            isContained

        member this.GetAllPoints():int[] =
            [| for i in startVal .. endVal -> i |]

        member this.GetEndPoints():int[] =
            [| startVal; endVal |]

        member this.ContainsRange(inputRange:Range):bool =
            let inputValues = inputRange.GetEndPoints()
            (startVal <= inputValues.[0] && inputValues.[1] <= endVal)
        
        member this.OverlapsRange(inputRange:Range):bool =
            let inputValues = inputRange.GetEndPoints()
            (startVal <= inputValues.[0] && inputValues.[0] <= endVal) || 
            (startVal <= inputValues.[1] && inputValues.[1] <= endVal)

        member this.Equals(inputRange:Range):bool =
            let inputValues = inputRange.GetEndPoints()
            (startVal = inputValues.[0] && inputValues.[1] = endVal)
    end

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code
