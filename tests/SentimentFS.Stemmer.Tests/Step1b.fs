namespace SentimentFS.Stemmer.Tests.Steps

module Step1b =
    open Expecto
    open SentimentFS.Stemmer.Steps
    open SentimentFS.Stemmer

    [<Tests>]
    let tests =
        testList "Step1b" [
            testList "postRemoveEdEdlyIngIngly" [
                testCase "when word end with at or bi or iz" <| fun _ ->
                    let subject = Step1b.postRemoveEdEdlyIngIngly "plat"
                    Expect.equal subject ("plate") "should equal plate"
                testCase "when word has doubles" <| fun _ ->
                    let subject = Step1b.postRemoveEdEdlyIngIngly "add"
                    Expect.equal subject ("ad") "should equal ad"
                testCase "when word is short" <| fun _ ->
                    let subject = Step1b.postRemoveEdEdlyIngIngly "on"
                    Expect.equal subject "one" "should equal one"
                testCase "when word is other" <| fun _ ->
                    let subject = Step1b.postRemoveEdEdlyIngIngly "awesome"
                    Expect.equal subject "awesome" "should equal awesome"
            ]
            testList "removeEdEdlyIngIngly" [
                testCase "luxuriating" <| fun _ ->
                    let subject = Step1b.removeEdEdlyIngIngly "luxuriating"
                    Expect.equal subject (Found("luxuriate")) "should be Found and equal luxuriate"
                testCase "hopping" <| fun _ ->
                    let subject = Step1b.removeEdEdlyIngIngly "hopping"
                    Expect.equal subject (Found("hop")) "should be Found and equal hop"
                testCase "hoping" <| fun _ ->
                    let subject = Step1b.removeEdEdlyIngIngly "hoping"
                    Expect.equal subject (Found("hope")) "should be Found and equal hope"
                testCase "add" <| fun _ ->
                    let subject = Step1b.removeEdEdlyIngIngly "add"
                    Expect.equal subject (Next("add")) "should be Next and equal add"
                testCase "on" <| fun _ ->
                    let subject = Step1b.removeEdEdlyIngIngly "on"
                    Expect.equal subject (Next("on")) "should be Next and equal on"
            ]
            testList "replaceEedEddlyInR1" [
                testCase "proceed" <| fun _ ->
                    let subject = Step1b.replaceEedEddlyInR1 "proceed"
                    Expect.equal subject (Found("procee")) "should be Found and equal procee"
                testCase "proceedly" <| fun _ ->
                    let subject = Step1b.replaceEedEddlyInR1 "proceedly"
                    Expect.equal subject (Found("procee")) "should be Found and equal procee"
                testCase "need" <| fun _ ->
                    let subject = Step1b.replaceEedEddlyInR1 "need"
                    Expect.equal subject (Found("need")) "should be Found and equal need"
            ]
            testList "replaceEedEedly" [
                testCase "proceed" <| fun _ ->
                    let subject = Step1b.replaceEedEedly "proceed"
                    Expect.equal subject (Found("procee")) "should be Found and equal procee"
                testCase "proceedly" <| fun _ ->
                    let subject = Step1b.replaceEedEedly "proceedly"
                    Expect.equal subject (Found("procee")) "should be Found and equal procee"
                testCase "need" <| fun _ ->
                    let subject = Step1b.replaceEedEedly "need"
                    Expect.equal subject (Found("need")) "should be Found and equal need"
            ]
            testList "replaceSuffix" [
                testCase "bleed" <| fun _ ->
                    let subject = Step1b.replaceSuffix "bleed"
                    Expect.equal subject "bleed" "should be bleed"
                testCase "proceedly" <| fun _ ->
                    let subject = Step1b.replaceSuffix "proceedly"
                    Expect.equal subject "procee" "should be procee"
            ]
            testList "replaceSuffixY" [
                testCase "cry" <| fun _ ->
                    let subject = Step1b.replaceSuffixY "cry"
                    Expect.equal subject "cri" "should equal cri"
                testCase "say" <| fun _ ->
                    let subject = Step1b.replaceSuffixY "say"
                    Expect.equal subject "say" "should equal say"
                testCase "by" <| fun _ ->
                    let subject = Step1b.replaceSuffixY "by"
                    Expect.equal subject "by" "should equal by"
            ]
        ]
