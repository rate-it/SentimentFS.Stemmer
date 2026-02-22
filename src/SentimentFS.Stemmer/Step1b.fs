namespace SentimentFS.Stemmer.Steps

module Step1b =
    open System.Text.RegularExpressions
    open SentimentFS.TextUtilities.Text
    open SentimentFS.TextUtilities.Regex
    open SentimentFS.Stemmer.Rules
    open SentimentFS.Stemmer
    let private edly = [|"eedly"; "eed"|]
    let private rule = Regex($"(%s{Rules.vowels}.*)(ingly|edly|ing|ed)$")

    [<CompiledName("postRemoveEdEdlyIngIngly")>]
    let postRemoveEdEdlyIngIngly(word: string) =
        if endsWith (word) ([|"at"; "bi"; "iz"|]) then
            word + "e"
        elif endsWith (word) (doubles) then
            word.Substring(0, word.Length - 1)
        elif Rules.isShort(word) then
            word + "e"
        else
            word

    [<CompiledName("RemoveEdEdlyIngIngly")>]
    let removeEdEdlyIngIngly(word: string) =
        if rule.IsMatch(word) then
            Found(rule.Replace(word,"$1") |> postRemoveEdEdlyIngIngly)
        else
            Next(word)

    [<CompiledName("ReplaceEedEddlyInR1")>]
    let replaceEedEddlyInR1(word: string) =
        if endsWith(Rules.r1(word))(edly) then
            Found((word |> replaceSuffix "eedly" "ee" |> replaceSuffix "eed" "ee"))
        else
            Found(word)

    [<CompiledName("ReplaceEedEedly")>]
    let replaceEedEedly(word: string) =
        if endsWith(word)(edly) then
            word |> replaceEedEddlyInR1
        else
            Next(word)

    [<CompiledName("ReplaceSuffix")>]
    let replaceSuffix(word: string) =
        match word |> replaceEedEedly with
        | Next(word) ->
            match word |> removeEdEdlyIngIngly with
            | Next(word) -> word
            | Found(word) -> word
        | Found(word) -> word

    [<CompiledName("ReplaceSuffixY")>]
    let replaceSuffixY(word: string) =
        match word.ToLower() with
        | SuffixMatch (sprintf ".+%sy" Rules.consonant) _ ->
            word.Substring(0, word.Length - 1) + "i"
        | _ -> word

    [<CompiledName("Apply")>]
    let apply = replaceSuffix >> replaceSuffixY
