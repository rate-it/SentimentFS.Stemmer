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
    let liEndings = [|"cli"; "dli"; "eli"; "gli"; "hli"; "kli"; "mli"; "nli"; "rli"; "tli"|]

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

    let private foundSuffixInR1(suffix: string) (replacement: string) (word: string) =
        match word |> r1 with
        | SuffixMatch suffix _ ->
            Found(word |> replaceSuffix suffix replacement)
        | _ ->  Found(word)

    [<CompiledName("ReplaceR1Suffix")>]
    let replaceR1Suffix (suffix: string) (replacement: string) (word: string) =
        match word with
        | SuffixMatch suffix _ ->
            word |> foundSuffixInR1 suffix replacement
        | _ -> Next(word)

    [<CompiledName("Invariant")>]
    let invariant(word:string) =
        (word, [| "inning"; "outing"; "canning"; "herring"; "earring"; "proceed"; "exceed"; "succeed" |] |> Array.exists(fun x -> x = word))

    let private normalR1(word: string) =
        match word with
        | FirstMatch rVc result ->
            word |> replacePrefix result ""
        | _ -> ""

    [<CompiledName("R2")>]
    let r2 = r1 >> normalR1
