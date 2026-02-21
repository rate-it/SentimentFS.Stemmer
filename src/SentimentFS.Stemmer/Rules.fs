namespace SentimentFS.Stemmer

open System.Collections.Generic

module Rules =
    open System.Text.RegularExpressions
    open SentimentFS.TextUtilities.Regex
    open SentimentFS.TextUtilities.Text

    let private invariants = HashSet[| "inning"; "outing"; "canning"; "herring"; "earring"; "proceed"; "exceed"; "succeed" |];
    [<Literal>]
    let Vowels = "aeiouy"
    let vowels = $"[%s{Vowels}]"
    let consonant  = $"[^%s{Vowels}]"
    let nonVowelWXY = $"[^%s{Vowels}wxY]"
    let doubles = [|"bb"; "dd"; "ff"; "gg"; "mm"; "nn"; "pp"; "rr"; "tt"|]
    let shortSyllable = $"((%s{consonant}%s{vowels}%s{nonVowelWXY})|(^%s{vowels}%s{consonant}))"
    let rVc = $"^%s{consonant}*%s{vowels}+%s{consonant}"
    let liEndings = [|"cli"; "dli"; "eli"; "gli"; "hli"; "kli"; "mli"; "nli"; "rli"; "tli"|]

    let private r1Regex = Regex("^(gener|commun|arsen)", RegexOptions.Compiled)
    let private r1RvcRegex = Regex(rVc, RegexOptions.Compiled)
    let private shortSyllableRegex = Regex(shortSyllable, RegexOptions.Compiled)

    [<CompiledName("R1")>]
    let r1(word: string) =
        match word with
        | FirstRegexMatch r1Regex matched ->
            word |> replacePrefix matched ""
        | FirstRegexMatch r1RvcRegex matched  ->
            word |> replacePrefix matched ""
        | _ -> ""

    [<CompiledName("IsShort")>]
    let isShort(word: string) =
        r1(word) = "" && shortSyllableRegex.IsMatch(word)

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
        (word, invariants.Contains(word))

    let private normalR1(word: string) =
        match word with
        | FirstMatch rVc result ->
            word |> replacePrefix result ""
        | _ -> ""

    [<CompiledName("R2")>]
    let r2 = r1 >> normalR1
