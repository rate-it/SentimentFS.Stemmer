namespace SentimentFS.Stemmer.Steps

module Step5 =
    open System.Text.RegularExpressions
    open SentimentFS.TextUtilities.Text
    open SentimentFS.TextUtilities.Regex
    open SentimentFS.Stemmer.Rules
    open SentimentFS.Stemmer

    // TODO: should be refactored
    let private removeSuffixInR2(word: string) =
        let r2 = Rules.r2 word
        if (endsWith(r2)([|"e"|])) then
            word |> replaceSuffix "e" ""
        elif (endsWith(Rules.r1 word)([|"e"|])) && not (Regex.IsMatch(word, (sprintf "%se$" Rules.shortSyllable))) then
            word |> replaceSuffix "e" ""
        elif (endsWith(r2)([|"l"|])) && (endsWith(word)([|"ll"|])) then
            word |> replaceSuffix "l" ""
        else
            word

    [<CompiledName("Apply")>]
    let apply = removeSuffixInR2
