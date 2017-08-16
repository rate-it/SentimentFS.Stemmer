namespace SentimentFS.Stemmer.Steps

module Step2 =
    open System.Text.RegularExpressions
    open SentimentFS.TextUtilities.Text
    open SentimentFS.Stemmer.Rules
    open SentimentFS.Stemmer

    [<CompiledName("postRemoveEdEdlyIngIngly")>]
    let postRemoveEdEdlyIngIngly(word: string) =
        if Text.endsWith (word) ([|"at"; "bi"; "iz"|]) then
            word + "e"
        elif Text.endsWith (word) (doubles) then
            word.Substring(0, word.Length - 1)
        elif Rules.isShort(word) then
            word + "e"
        else
            word

    [<CompiledName("RemoveEdEdlyIngIngly")>]
    let removeEdEdlyIngIngly(word: string) =
        let rule = sprintf "(%s.*)(ingly|edly|ing|ed)$" Rules.vowels;
        if Regex.IsMatch(word, rule) then
            Found(Regex.Replace(word, rule,"$1") |> postRemoveEdEdlyIngIngly)
        else
            Next(word)

    [<CompiledName("ReplaceEedEddlyInR1")>]
    let replaceEedEddlyInR1(word: string) =
        if Text.endsWith(Rules.r1(word))([|"eedly"; "eed"|]) then
            Found((word |> Text.replaceSuffix ("eedly", "ee") |> Text.replaceSuffix ("eed", "ee")))
        else
            Found(word)

    [<CompiledName("ReplaceEedEedly")>]
    let replaceEedEedly(word: string) =
        if Text.endsWith(word)([|"eedly"; "eed"|]) then
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
    let apply(word: string) =
        let result = word |> replaceSuffix |> replaceSuffixY
        log "Step 2: %s" result
        result
