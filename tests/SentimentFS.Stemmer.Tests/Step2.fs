namespace SentimentFS.Stemmer.Tests.Steps

module Step2 =
    open Expecto
    open SentimentFS.Stemmer.Steps
    open SentimentFS.Stemmer

    [<Tests>]
    let tests =
        testList "Step2" [
            testList "replaceSuffixInR1" [
                testCase "sensational" <| fun _ ->
                    let subject = Step2.replaceSuffixInR1 "sensational"
                    Expect.equal subject "sensate" "should equal sensate"
                testCase "sentenci" <| fun _ ->
                    let subject = Step2.replaceSuffixInR1 "sentenci"
                    Expect.equal subject "sentence" "should equal sentence"
                testCase "entranci" <| fun _ ->
                    let subject = Step2.replaceSuffixInR1 "entranci"
                    Expect.equal subject "entrance" "should equal entrance"
                testCase "pocketabli" <| fun _ ->
                    let subject = Step2.replaceSuffixInR1 "pocketabli"
                    Expect.equal subject "pocketable" "should equal pocketable"
                testCase "momentli" <| fun _ ->
                    let subject = Step2.replaceSuffixInR1 "momentli"
                    Expect.equal subject "moment" "should equal moment"
                testCase "nationalization" <| fun _ ->
                    let subject = Step2.replaceSuffixInR1 "nationalization"
                    Expect.equal subject "nationalize" "should equal nationalize"
                testCase "acceleration" <| fun _ ->
                    let subject = Step2.replaceSuffixInR1 "acceleration"
                    Expect.equal subject "accelerate" "should equal accelerate"
                testCase "accelerator" <| fun _ ->
                    let subject = Step2.replaceSuffixInR1 "accelerator"
                    Expect.equal subject "accelerate" "should equal accelerate"
                testCase "usefulness" <| fun _ ->
                    let subject = Step2.replaceSuffixInR1 "usefulness"
                    Expect.equal subject "useful" "should equal useful"
                testCase "mopli" <| fun _ ->
                    let subject = Step2.replaceSuffixInR1 "mopli"
                    Expect.equal subject "mopli" "should equal mopli"
                testCase "geologi" <| fun _ ->
                    let subject = Step2.replaceSuffixInR1 "geologi"
                    Expect.equal subject "geolog" "should equal geologi"
                testCase "greatli" <| fun _ ->
                    let subject = Step2.replaceSuffixInR1 "greatli"
                    Expect.equal subject "great" "should equal great"
                testCase "masterfulli" <| fun _ ->
                    let subject = Step2.replaceSuffixInR1 "masterfulli"
                    Expect.equal subject "masterful" "should equal masterful"
                testCase "generousli" <| fun _ ->
                    let subject = Step2.replaceSuffixInR1 "generousli"
                    Expect.equal subject "generous" "should equal generous"
            ]
        ]
