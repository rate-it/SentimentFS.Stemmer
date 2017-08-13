module SentimentFS.Stemmer.Tests.Steps


module Step0 =
    open Expecto
    open SentimentFS.Stemmer.Steps

    [<Tests>]
    let test =
        testList "Step0" [
            testList "markConsonantY" [
                testCase "when word has y at first position" <| fun _ ->
                    let subject = Step0.markConsonantY "youth"
                    Expect.equal subject "Youth" "should equal Youth"
                testCase "when word has y after vowel" <| fun _ ->
                    let subject = Step0.markConsonantY "boyish"
                    Expect.equal subject "boYish" "should equal boYish"
                testCase "when word has no y after vowel" <| fun _ ->
                    let subject = Step0.markConsonantY "flying"
                    Expect.equal subject "flying" "should equal flying"
                testCase "when word has no y" <| fun _ ->
                    let subject = Step0.markConsonantY "test"
                    Expect.equal subject "test" "should equal test"
            ]
            testList "removeSApostrophe" [
                testCase "when word end with 's" <| fun _ ->
                    let subject = Step0.removeSApostrophe "test's"
                    Expect.equal subject "test" "should equal test"
                testCase "when word no end with 's" <| fun _ ->
                    let subject = Step0.removeSApostrophe "test"
                    Expect.equal subject "test" "should equal test"
            ]
            testList "TrimApostrophes" [
                testCase "when word has no Apostrophes at middle position" <| fun _ ->
                    let subject = "te'st" |> Step0.trimEndApostrophe |> Step0.trimStartApostrophe
                    Expect.equal subject "te'st" "should equal te'st"
            ]
            testList "Apply" [
                testCase "youth's'" <| fun _ ->
                    let subject = Step0.apply "youth's'"
                    Expect.equal subject "Youth" "should equal Youth"
            ]
        ]
