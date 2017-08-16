namespace SentimentFS.Stemmer.Tests.Steps

module Step3 =
    open Expecto
    open SentimentFS.Stemmer.Steps
    open SentimentFS.Stemmer

    [<Tests>]
    let tests =
        testList "Step2" [
            testList "postRemoveEdEdlyIngIngly" [
                testCase "when word end with at or bi or iz" <| fun _ ->
                    let subject = Step2.postRemoveEdEdlyIngIngly "plat"
                    Expect.equal subject ("plate") "should equal plate"
                testCase "when word has doubles" <| fun _ ->
                    let subject = Step2.postRemoveEdEdlyIngIngly "add"
                    Expect.equal subject ("ad") "should equal ad"
                testCase "when word is short" <| fun _ ->
                    let subject = Step2.postRemoveEdEdlyIngIngly "on"
                    Expect.equal subject "one" "should equal one"
                testCase "when word is other" <| fun _ ->
                    let subject = Step2.postRemoveEdEdlyIngIngly "awesome"
                    Expect.equal subject "awesome" "should equal awesome"
            ]
            testList "removeEdEdlyIngIngly" [
                testCase "luxuriating" <| fun _ ->
                    let subject = Step2.removeEdEdlyIngIngly "luxuriating"
                    Expect.equal subject (Found("luxuriate")) "should be Found and equal luxuriate"
                testCase "hopping" <| fun _ ->
                    let subject = Step2.removeEdEdlyIngIngly "hopping"
                    Expect.equal subject (Found("hop")) "should be Found and equal hop"
                testCase "hoping" <| fun _ ->
                    let subject = Step2.removeEdEdlyIngIngly "hoping"
                    Expect.equal subject (Found("hope")) "should be Found and equal hope"
                testCase "add" <| fun _ ->
                    let subject = Step2.removeEdEdlyIngIngly "add"
                    Expect.equal subject (Next("add")) "should be Next and equal add"
                testCase "on" <| fun _ ->
                    let subject = Step2.removeEdEdlyIngIngly "on"
                    Expect.equal subject (Next("on")) "should be Next and equal on"
            ]
            testList "replaceEedEddlyInR1" [
                testCase "proceed" <| fun _ ->
                    let subject = Step2.replaceEedEddlyInR1 "proceed"
                    Expect.equal subject (Found("procee")) "should be Found and equal procee"
                testCase "proceedly" <| fun _ ->
                    let subject = Step2.replaceEedEddlyInR1 "proceedly"
                    Expect.equal subject (Found("procee")) "should be Found and equal procee"
                testCase "need" <| fun _ ->
                    let subject = Step2.replaceEedEddlyInR1 "need"
                    Expect.equal subject (Found("need")) "should be Found and equal need"
            ]
            testList "replaceEedEedly" [
                testCase "proceed" <| fun _ ->
                    let subject = Step2.replaceEedEedly "proceed"
                    Expect.equal subject (Found("procee")) "should be Found and equal procee"
                testCase "proceedly" <| fun _ ->
                    let subject = Step2.replaceEedEedly "proceedly"
                    Expect.equal subject (Found("procee")) "should be Found and equal procee"
                testCase "need" <| fun _ ->
                    let subject = Step2.replaceEedEedly "need"
                    Expect.equal subject (Found("need")) "should be Found and equal need"
            ]
            testList "replaceSuffix" [
                testCase "bleed" <| fun _ ->
                    let subject = Step2.replaceSuffix "bleed"
                    Expect.equal subject "bleed" "should be bleed"
                testCase "proceedly" <| fun _ ->
                    let subject = Step2.replaceSuffix "proceedly"
                    Expect.equal subject "procee" "should be procee"
            ]
            testList "replaceSuffixY" [
                testCase "cry" <| fun _ ->
                    let subject = Step2.replaceSuffixY "cry"
                    Expect.equal subject "cri" "should equal cri"
                testCase "say" <| fun _ ->
                    let subject = Step2.replaceSuffixY "say"
                    Expect.equal subject "say" "should equal say"
                testCase "by" <| fun _ ->
                    let subject = Step2.replaceSuffixY "by"
                    Expect.equal subject "by" "should equal by"
            ]
        ]
