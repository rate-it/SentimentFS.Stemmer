namespace SentimentFS.Stemmer

module Rules =
    open System.Text.RegularExpressions
    open SentimentFS.TextUtilities.Regex
    open SentimentFS.TextUtilities.Text

    [<Literal>]
    let Vowels = "aeiouy"
    let vowels = sprintf "[%s]" Vowels
    let consonant  = sprintf "[^%s]" Vowels
    let nonVowelWXY = sprintf "[^%swxY]" Vowels
    let doubles = [|"bb"; "dd"; "ff"; "gg"; "mm"; "nn"; "pp"; "rr"; "tt"|]
    let shortSyllable = sprintf "((%s%s%s)|(^%s%s))" consonant vowels nonVowelWXY vowels consonant
    let rVc = sprintf "^%s*%s+%s" consonant vowels consonant

    [<CompiledName("R1")>]
    let r1(word: string) =
        match word with
        | FirstMatch "^(gener|commun|arsen)" matched ->
            word |> replacePrefix matched ""
        | FirstMatch rVc matched  ->
            word |> replacePrefix matched ""
        | _ -> ""

    [<CompiledName("IsShort")>]
    let isShort(word: string) =
        r1(word) = "" && Regex.IsMatch(word, shortSyllable)
