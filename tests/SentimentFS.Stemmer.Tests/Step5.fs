namespace SentimentFS.Stemmer.Tests.Steps

module Step4 =
    open Expecto
    open SentimentFS.Stemmer.Steps
    open SentimentFS.Stemmer

    [<Tests>]
    let tests =
        testList "Step5" [
            testCase "conceive" <| fun _ ->
                let subject = Step5.apply "conceive"
                Expect.equal subject "conceiv" "should equal conceiv"
            testCase "move" <| fun _ ->
                let subject = Step5.apply "move"
                Expect.equal subject "move" "should equal move"
            testCase "momoie" <| fun _ ->
                let subject = Step5.apply "momoie"
                Expect.equal subject "momoi" "should equal momoi"
            testCase "moe" <| fun _ ->
                let subject = Step5.apply "moe"
                Expect.equal subject "moe" "should equal moe"
            testCase "daniell" <| fun _ ->
                let subject = Step5.apply "daniell"
                Expect.equal subject "daniel" "should equal daniel"
            testCase "doll" <| fun _ ->
                let subject = Step5.apply "doll"
                Expect.equal subject "doll" "should equal doll"
            testCase "mail" <| fun _ ->
                let subject = Step5.apply "mail"
                Expect.equal subject "mail" "should equal mail"
        ]
