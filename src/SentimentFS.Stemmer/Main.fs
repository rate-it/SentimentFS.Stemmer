namespace SentimentFS.Stemmer

module Stemmer =
    open SentimentFS.TextUtilities.Text

    [<CompiledName("Stem")>]
    let rec stem =
        let localstem = fun (word: string) ->
            if word.Length <= 2 then
                word
            else
                word |> toLower |> SpecialWord.apply |> PostSpecialWord.apply
        localstem
