namespace SentimentFS.Stemmer.Tests.Steps

module Step1a =
    open Expecto
    open SentimentFS.Stemmer.Steps
    open SentimentFS.Stemmer

    [<Tests>]
    let tests =
        testList "Step1a" [
            testList "removeS" [
                testCase "gas" <| fun _ ->
                    let subject = Step1a.removeS "gas"
                    Expect.equal subject (Next("gas")) "should equal gas"
                testCase "this" <| fun _ ->
                    let subject = Step1a.removeS "this"
                    Expect.equal subject (Next("this")) "should equal this"
                testCase "gaps" <| fun _ ->
                    let subject = Step1a.removeS "gaps"
                    Expect.equal subject (Found("gap")) "should equal gap"
                testCase "kiwis" <| fun _ ->
                    let subject = Step1a.removeS "kiwis"
                    Expect.equal subject (Found("kiwi")) "should equal kiwi"
            ]
            testList "leaveUSandSS" [
                testCase "abyss" <| fun _ ->
                    let subject = Step1a.leaveUSandSS "abyss"
                    Expect.equal subject (Found("abyss")) "should equal abyss"
                testCase "us" <| fun _ ->
                    let subject = Step1a.leaveUSandSS "us"
                    Expect.equal subject (Found("us")) "should equal us"
                testCase "gaps" <| fun _ ->
                    let subject = Step1a.leaveUSandSS "gap"
                    Expect.equal subject (Next("gap")) "should equal gap"
            ]
            testList "replaceIedAndIes" [
                testCase "tied" <| fun _ ->
                    let subject = Step1a.replaceIedAndIes "tied"
                    Expect.equal subject (Found("tie")) "should equal tie"
                testCase "ties" <| fun _ ->
                    let subject = Step1a.replaceIedAndIes "ties"
                    Expect.equal subject (Found("tie")) "should equal tie"
                testCase "cries" <| fun _ ->
                    let subject = Step1a.replaceIedAndIes "cries"
                    Expect.equal subject (Found("cri")) "should equal cri"
                testCase "test" <| fun _ ->
                    let subject = Step1a.replaceIedAndIes "test"
                    Expect.equal subject (Next("test")) "should equal test"
            ]
            testList "replaceSses" [
                testCase "actresses" <| fun _ ->
                    let subject = Step1a.replaceSses "actresses"
                    Expect.equal subject (Found("actress")) "should equal actress"
                testCase "test" <| fun _ ->
                    let subject = Step1a.replaceSses "test"
                    Expect.equal subject (Next("test")) "should equal test"
            ]
            testList "replaceSuffix" [
                testCase "abyss" <| fun _ ->
                    let subject = Step1a.replaceSuffix "abyss"
                    Expect.equal subject "abyss" "should equal abyss"
            ]
        ]
