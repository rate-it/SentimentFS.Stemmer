namespace SentimentFS.Stemmer


module SpecialWord =
    let map =  [("skis", "ski"); ("skies" ,"sky"); ("dying" ,"die"); ("lying" ,"lie"); ("tying" ,"tie"); ("idly"  ,"idl"); ("gently","gentl"); ("ugly"  ,"ugli"); ("early" ,"earli"); ("only"  ,"onli"); ("singly","singl"); ("sky"   ,"sky"); ("news"  ,"news"); ("howe"  ,"howe"); ("atlas" ,"atlas"); ("cosmos","cosmos"); ("bias"  ,"bias"); ("andes" ,"andes")] |> dict
    let specialWord(word: string) =
        match map.TryGetValue(word) with
        | true, v -> Some(v)
        | _ -> None

    [<CompiledName("Appy")>]
    let apply(word: string) =
        match (word |> specialWord) with
        | Some w -> Found(w)
        | None -> Next(word)


module PostSpecialWord =
    open SentimentFS.Stemmer.Steps
    open SentimentFS.Stemmer

    let private postInvariant(invariant: (string * bool)) =

        let capitalYbackToLowercase (str:string) =
            str.Replace("Y", "y")

        match invariant with
        | (word, true) -> word
        | (word, false) ->
            word |> Step1b.apply |> Step2.apply |> Step3.apply |> Step4.apply |> Step5.apply |> capitalYbackToLowercase

    let apply(word: ReplaceResult) =
        match word with
        | Found(word) -> word
        | Next(word) -> word |> Step0.apply |> Step1a.apply |> Rules.invariant |> postInvariant
