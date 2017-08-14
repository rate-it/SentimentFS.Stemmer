namespace SentimentFS.Stemmer

type Alghorithm =
    | Porter

type Config = { alghorithm: Alghorithm }

type ReplaceResult =
    | Found of string
    | Next of string

module Word =
    type WordBuilder() =
        member this.ReturnFrom x = x
        member this.Combine(a, b) =
            match a with
            | Next _ -> b
            | Found w -> a

        member this.Delay(f) = f()

    let word = WordBuilder()
