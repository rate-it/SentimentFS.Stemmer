namespace SentimentFS.Stemmer.Steps

module Step0 =
    open System.Text.RegularExpressions
    open SentimentFS.Stemmer.Rules

    [<CompiledName("TrimEndApostrophe")>]
    let trimEndApostrophe(word:string) =
        if word.EndsWith("'") then
            word.Substring(0, word.Length - 1)
        else
            word

    [<CompiledName("TrimStartApostrophe")>]
    let trimStartApostrophe(word:string) =
        if word.StartsWith("'") then
            word.Substring(1)
        else
            word


    [<CompiledName("RemoveSApostrophe")>]
    let removeSApostrophe(word: string) =
        if word.EndsWith("'s") then
            word.Substring(0, word.Length - 2)
        else
            word

    [<CompiledName("MarkConsonantY")>]
    let markConsonantY(word: string) =
        if word.Contains("y") then
            Regex.Replace(word, (sprintf "^y|([%s])y" Vowels), "$1Y")
        else
            word

    [<CompiledName("Apply")>]
    let inline apply word = word |> trimStartApostrophe |> trimEndApostrophe |> removeSApostrophe |> markConsonantY
