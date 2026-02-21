namespace SentimentFS.Stemmer.Steps

module Step4 =
    open System.Text.RegularExpressions
    open SentimentFS.TextUtilities.Text
    open SentimentFS.TextUtilities.Regex
    open SentimentFS.Stemmer.Rules
    open SentimentFS.Stemmer

    let regex = Regex("(al|ance|ence|er|ic|able|ible|ant|ement|ment|ent|ism|ate|iti|ous|ive|ize)$")
    let private removeSuffixIon(word:string) =
        if endsWith(Rules.r2(word))([|"ion"|]) && endsWith(word)([|"sion"; "tion"|]) then
            Found(word |> replaceSuffix "ion" "")
        else
            Next(word)

    let private removeSuffixinR2(word: string)(suffix: string) =
        if endsWith(Rules.r2(word))([|suffix|]) then
            Found(word |> replaceSuffix suffix "")
        else
            Next(word)

    let private removeSuffix(word: string) =
        match word with
        | SuffixRegexMatch regex result ->
            removeSuffixinR2 word result
        | _ -> Next(word)

    [<CompiledName("Apply")>]
    let apply word =
        let result = Word.word {
            return! removeSuffix word
            return! removeSuffixIon word
        }
        match result with Found x -> x | Next x -> x
