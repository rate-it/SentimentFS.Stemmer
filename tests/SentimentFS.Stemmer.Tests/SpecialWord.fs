namespace SentimentFS.Stemmer.Tests.Steps

module SpecialWord =
    open Expecto
    open SentimentFS.Stemmer.Steps
    open SentimentFS.Stemmer

    [<Tests>]
    let specialWordTests =
        testList "SpecialWord.specialWord" [
            testCase "when map contains word" <| fun  _ ->
                let subject = "skis" |> SpecialWord.specialWord
                Expect.isSome subject "should be Some"
                Expect.equal (Option.get(subject)) "ski" "should equal ski"
            testCase "when map does not contain word" <| fun  _ ->
                let subject = "buying" |> SpecialWord.specialWord
                Expect.isNone subject "should be None"
        ]

    [<Tests>]
    let apply =
        testList "SpecialWord.specialWord" [
            testCase "when map contains word" <| fun  _ ->
                let subject = "skis" |> SpecialWord.apply
                Expect.equal subject (Found("ski")) "should equal ski"
            testCase "when map does not contain word" <| fun  _ ->
                let subject = "buying" |> SpecialWord.apply
                Expect.equal subject (Next("buying")) "should equal buying"
        ]
