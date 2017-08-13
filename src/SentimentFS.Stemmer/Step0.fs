namespace SentimentFS.Stemmer.Steps

module Step0 =
    open System.Text.RegularExpressions
    open SentimentFS.TextUtilities.Text
    open SentimentFS.Stemmer.Rules

    [<CompiledName("TrimEndApostrophe")>]
    let trimEndApostrophe = removeSuffix "'"

    [<CompiledName("TrimStartApostrophe")>]
    let trimStartApostrophe = skipPrefix "'"


    [<CompiledName("RemoveSApostrophe")>]
    let removeSApostrophe = removeSuffix "'s"

    [<CompiledName("MarkConsonantY")>]
    let markConsonantY(word: string) =
        if word.Contains("y") then
            Regex.Replace(word, (sprintf "^y|([%s])y" Vowels), "$1Y")
        else
            word

    [<CompiledName("Apply")>]
    let inline apply word = word |> trimStartApostrophe |> trimEndApostrophe |> removeSApostrophe |> markConsonantY
