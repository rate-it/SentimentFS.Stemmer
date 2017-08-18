namespace SentimentFS.Stemmer.Tests.Steps

module Step4 =
    open Expecto
    open SentimentFS.Stemmer.Steps
    open SentimentFS.Stemmer

    [<Tests>]
    let tests =
        testList "Step4" [
            testCase "national" <| fun _ ->
                let subject = Step4.apply "national"
                Expect.equal subject "nation" "should equal nation"
            testCase "association" <| fun _ ->
                let subject = Step4.apply "association"
                Expect.equal subject "associat" "should equal associat"
            testCase "apprehension" <| fun _ ->
                let subject = Step4.apply "apprehension"
                Expect.equal subject "apprehens" "should equal apprehens"
            testCase "concepcion" <| fun _ ->
                let subject = Step4.apply "concepcion"
                Expect.equal subject "concepcion" "should equal concepcion"
            testCase "addition" <| fun _ ->
                let subject = Step4.apply "addition"
                Expect.equal subject "addit" "should equal addit"
            testCase "agreement" <| fun _ ->
                let subject = Step4.apply "agreement"
                Expect.equal subject "agreement" "should equal agreement"
        ]
