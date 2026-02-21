namespace SentimentFS.Stemmer.Steps

module Step0 =
    open System.Text.RegularExpressions
    open SentimentFS.TextUtilities.Text
    open SentimentFS.Stemmer.Rules

    let yRegex = Regex($"^y|([%s{Vowels}])y", RegexOptions.Compiled)

    [<CompiledName("TrimEndApostrophe")>]
    let trimEndApostrophe = removeSuffix "'"

    [<CompiledName("TrimStartApostrophe")>]
    let trimStartApostrophe = skipPrefix "'"

    [<CompiledName("RemoveSApostrophe")>]
    let removeSApostrophe = removeSuffix "'s"

    [<CompiledName("MarkConsonantY")>]
    let markConsonantY(word: string) =
        if word.Contains("y") then
            yRegex.Replace(word, "$1Y")
        else
            word

    [<CompiledName("Apply")>]
    let inline apply word = word |> trimStartApostrophe |> trimEndApostrophe |> removeSApostrophe |> markConsonantY
