namespace SentimentFS.Stemmer.Tests.Steps

module Step4 =
    open Expecto
    open SentimentFS.Stemmer.Steps
    open SentimentFS.Stemmer

    [<Tests>]
    let tests =
        testList "Step4" [
            testCase "proportional" <| fun _ ->
                let subject = Step4.apply "proportional"
                Expect.equal subject "proportion" "should equal proportion"
            testCase "duplicate" <| fun _ ->
                let subject = Step4.apply "duplicate"
                Expect.equal subject "duplic" "should equal duplic"
            testCase "dupliciti" <| fun _ ->
                let subject = Step4.apply "dupliciti"
                Expect.equal subject "duplic" "should equal duplic"
            testCase "duplical" <| fun _ ->
                let subject = Step4.apply "duplical"
                Expect.equal subject "duplic" "should equal duplic"
            testCase "colourful" <| fun _ ->
                let subject = Step4.apply "colourful"
                Expect.equal subject "colour" "should equal colour"
            testCase "eagerness" <| fun _ ->
                let subject = Step4.apply "eagerness"
                Expect.equal subject "eager" "should equal eager"
            testCase "negative" <| fun _ ->
                let subject = Step4.apply "negative"
                Expect.equal subject "negative" "should equal negative"
            testCase "imaginative" <| fun _ ->
                let subject = Step4.apply "imaginative"
                Expect.equal subject "imagin" "should equal imagin"
        ]
