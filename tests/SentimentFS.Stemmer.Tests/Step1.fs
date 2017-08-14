namespace SentimentFS.Stemmer.Tests.Steps

module Step1 =
    open Expecto
    open SentimentFS.Stemmer.Steps
    open SentimentFS.Stemmer

    [<Tests>]
    let tests =
        testList "Step1" [
            testList "removeS" [
                testCase "gas" <| fun _ ->
                    let subject = Step1.removeS "gas"
                    Expect.equal subject (Next("gas")) "should equal gas"
                testCase "this" <| fun _ ->
                    let subject = Step1.removeS "this"
                    Expect.equal subject (Next("this")) "should equal this"
                testCase "gaps" <| fun _ ->
                    let subject = Step1.removeS "gaps"
                    Expect.equal subject (Found("gap")) "should equal gap"
                testCase "kiwis" <| fun _ ->
                    let subject = Step1.removeS "kiwis"
                    Expect.equal subject (Found("kiwi")) "should equal kiwi"
            ]
            testList "leaveUSandSS" [
                testCase "abyss" <| fun _ ->
                    let subject = Step1.leaveUSandSS "abyss"
                    Expect.equal subject (Found("abyss")) "should equal abyss"
                testCase "us" <| fun _ ->
                    let subject = Step1.leaveUSandSS "us"
                    Expect.equal subject (Found("us")) "should equal us"
                testCase "gaps" <| fun _ ->
                    let subject = Step1.leaveUSandSS "gap"
                    Expect.equal subject (Next("gap")) "should equal gap"
            ]
            testList "replaceIedAndIes" [
                testCase "tied" <| fun _ ->
                    let subject = Step1.replaceIedAndIes "tied"
                    Expect.equal subject (Found("tie")) "should equal tie"
                testCase "ties" <| fun _ ->
                    let subject = Step1.replaceIedAndIes "ties"
                    Expect.equal subject (Found("tie")) "should equal tie"
                testCase "cries" <| fun _ ->
                    let subject = Step1.replaceIedAndIes "cries"
                    Expect.equal subject (Found("cri")) "should equal cri"
                testCase "test" <| fun _ ->
                    let subject = Step1.replaceIedAndIes "test"
                    Expect.equal subject (Next("test")) "should equal test"
            ]
            testList "replaceSses" [
                testCase "actresses" <| fun _ ->
                    let subject = Step1.replaceSses "actresses"
                    Expect.equal subject (Found("actress")) "should equal actress"
                testCase "test" <| fun _ ->
                    let subject = Step1.replaceSses "test"
                    Expect.equal subject (Next("test")) "should equal test"
            ]
            testList "replaceSuffix" [
                testCase "abyss" <| fun _ ->
                    let subject = Step1.replaceSuffix "abyss"
                    Expect.equal subject "abyss" "should equal abyss"
            ]
        ]
