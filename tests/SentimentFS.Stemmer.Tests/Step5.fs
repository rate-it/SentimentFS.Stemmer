namespace SentimentFS.Stemmer.Tests.Steps

module Step5 =
    open Expecto
    open SentimentFS.Stemmer.Steps
    open SentimentFS.Stemmer

    [<Tests>]
    let tests =
        testList "Step5" [
            testCase "national" <| fun _ ->
                let subject = Step5.apply "national"
                Expect.equal subject "nation" "should equal nation"
            testCase "association" <| fun _ ->
                let subject = Step5.apply "association"
                Expect.equal subject "associat" "should equal associat"
            testCase "apprehension" <| fun _ ->
                let subject = Step5.apply "apprehension"
                Expect.equal subject "apprehens" "should equal apprehens"
            testCase "concepcion" <| fun _ ->
                let subject = Step5.apply "concepcion"
                Expect.equal subject "concepcion" "should equal concepcion"
            testCase "addition" <| fun _ ->
                let subject = Step5.apply "addition"
                Expect.equal subject "addit" "should equal addit"
            testCase "agreement" <| fun _ ->
                let subject = Step5.apply "agreement"
                Expect.equal subject "agreement" "should equal agreement"
        ]
