namespace SentimentFS.Stemmer.Tests.Steps

module Stemmer =
    open Expecto
    open SentimentFS.Stemmer.Steps
    open SentimentFS.Stemmer
    open System.IO
    let testsFromOfficialDiffs =
        seq {
            let reader = new StreamReader("diffs.txt")
            let mutable line = reader.ReadLine()
            while not (isNull line) do
                let split = line.Split([| ' ' |], System.StringSplitOptions.RemoveEmptyEntries)
                let word = split.[0]
                let expected = split.[1]

                let test = testCase word <| fun _ ->
                    let actual = Stemmer.stem(word)
                    Expect.equal actual (expected) (sprintf "expected %s; got %s" expected actual)

                yield test
                line <- reader.ReadLine()
        }
    let officialTests = Seq.toList testsFromOfficialDiffs

    [<Tests>]
    let tests =
        testList "stem" [
            testCase "Hello" <| fun _ ->
                let subject = Stemmer.stem("Hello")
                Expect.equal subject ("hello") "should equal hello"
            testCase "hElLo" <| fun _ ->
                let subject = Stemmer.stem("hElLo")
                Expect.equal subject ("hello") "should equal hello"
            testCase "capabilities" <| fun _ ->
                let subject = Stemmer.stem("capabilities")
                Expect.equal subject ("capabl") "should equal capabl"
            testCase "expressive" <| fun _ ->
                let subject = Stemmer.stem("expressive")
                Expect.equal subject ("express") "should equal express"

            testList "official" officialTests
        ]
