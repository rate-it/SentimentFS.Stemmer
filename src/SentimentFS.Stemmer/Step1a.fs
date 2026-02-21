namespace SentimentFS.Stemmer.Steps

module Step1a =
    open System.Text.RegularExpressions
    open SentimentFS.TextUtilities.Text
    open SentimentFS.Stemmer.Rules
    open SentimentFS.Stemmer

    let private sRegex = Regex( $"([%s{Vowels}]).+s$", RegexOptions.Compiled)

    [<CompiledName("ReplaceSses")>]
    let replaceSses(word: string) =
        if word.EndsWith("sses") then
            Found(word |> replaceSuffix "sses" "ss")
        else
            Next(word)

    [<CompiledName("ReplaceIedAndIes")>]
    let replaceIedAndIes(word: string) =
        if word.EndsWith("ied") || word.EndsWith("ies") then
            let result = if word.Length > 4 then
                            word |> replaceSuffix "ied" "i" |> replaceSuffix "ies" "i"
                         else
                            word |> replaceSuffix "ied" "ie" |> replaceSuffix "ies" "ie"
            Found(result)
        else
            Next(word)

    [<CompiledName("RemoveS")>]
    let removeS(word: string) =
        if sRegex.IsMatch(word) then
            Found(word |> replaceSuffix "s" "")
        else
            Next(word)

    [<CompiledName("LeaveUSandSS")>]
    let leaveUSandSS(word: string) =
        if word.EndsWith("ss") || word.EndsWith("us") then
            Found(word)
        else
            Next(word)

    [<CompiledName("ReplaceSuffix")>]
    let replaceSuffix(word: string) =
        let result = Word.word {
            return! replaceSses word
            return! replaceIedAndIes word
            return! leaveUSandSS word
            return! removeS word
        }
        match result with Found x -> x | Next x -> x

    [<CompiledName("Apply")>]
    let apply = replaceSuffix
