namespace SentimentFS.Stemmer.Steps

module Step3 =
    open System.Text.RegularExpressions
    open SentimentFS.TextUtilities.Text
    open SentimentFS.TextUtilities.Regex
    open SentimentFS.Stemmer.Rules
    open SentimentFS.Stemmer

    let private replaceSuffixOgi(word: string) =
        if (endsWith word [|(Rules.r1(word))|]) && (endsWith word [|"logi"|]) then
            Found(word |> replaceSuffix "ogi" "og")
        else
            Next(word)

    let private replaceSuffixLi(word: string) =
        if (endsWith (Rules.r1(word)) [|"li"|]) && (endsWith word (Rules.liEndings)) then
            Found(word |> replaceSuffix "li" "")
        else
            Next(word)

    [<CompiledName("ReplaceSuffixInR1")>]
    let replaceSuffixInR1 word =
        let result = Word.word {
            return! Rules.replaceR1Suffix ("ization") ("ize") word
            return! Rules.replaceR1Suffix ("ational") ("ate") word
            return! Rules.replaceR1Suffix ("fulness") ("ful") word
            return! Rules.replaceR1Suffix ("ousness") ("ous") word
            return! Rules.replaceR1Suffix ("iveness") ("ive") word
            return! Rules.replaceR1Suffix ("tional") ("tion") word
            return! Rules.replaceR1Suffix ("biliti") ("ble") word
            return! Rules.replaceR1Suffix ("lessli") ("less") word
            return! Rules.replaceR1Suffix ("entli") ("ent") word
            return! Rules.replaceR1Suffix ("ation") ("ate") word
            return! Rules.replaceR1Suffix ("alism") ("al") word
            return! Rules.replaceR1Suffix ("aliti") ("al") word
            return! Rules.replaceR1Suffix ("ousli") ("ous") word
            return! Rules.replaceR1Suffix ("iviti") ("ive") word
            return! Rules.replaceR1Suffix ("fulli") ("ful") word
            return! Rules.replaceR1Suffix ("enci") ("ence") word
            return! Rules.replaceR1Suffix ("anci") ("ance") word
            return! Rules.replaceR1Suffix ("abli") ("able") word
            return! Rules.replaceR1Suffix ("izer") ("ize") word
            return! Rules.replaceR1Suffix ("ator") ("ate") word
            return! Rules.replaceR1Suffix ("alli") ("al") word
            return! Rules.replaceR1Suffix ("bli") ("ble") word
            return! replaceSuffixOgi word
            return! replaceSuffixLi word
        }
        match result with Found x -> x | Next x -> x

    [<CompiledName("Apply")>]
    let apply = replaceSuffixInR1
