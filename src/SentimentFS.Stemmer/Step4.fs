namespace SentimentFS.Stemmer.Steps

module Step4 =
    open System.Text.RegularExpressions
    open SentimentFS.TextUtilities.Text
    open SentimentFS.TextUtilities.Regex
    open SentimentFS.Stemmer.Rules
    open SentimentFS.Stemmer

    let private replaceSuffixAtiveInR2(word: string) =
        if (endsWith (Rules.r2(word)) ([|"ative"|])) then
            Found((word |> replaceSuffix "ative" ""))
        else
            Next(word)

    [<CompiledName("Apply")>]
    let apply word =
        let result = Word.word {
            return! Rules.replaceR1Suffix "ational" "ate" word
            return! Rules.replaceR1Suffix "tional" "tion" word
            return! Rules.replaceR1Suffix "alize" "al" word
            return! Rules.replaceR1Suffix "icate" "ic" word
            return! Rules.replaceR1Suffix "iciti" "ic" word
            return! Rules.replaceR1Suffix "ical" "ic" word
            return! Rules.replaceR1Suffix "ness" "" word
            return! Rules.replaceR1Suffix "ful" "" word
            return! replaceSuffixAtiveInR2 word
        }
        match result with Found x -> x | Next x -> x
