namespace SentimentFS.Stemmer.Tests

module Rules =
    open Expecto
    open SentimentFS.Stemmer

    [<Tests>]
    let tests =
        testList "Rules" [
            testList "r1" [
                testCase "beautiful" <| fun _ ->
                    let subject = Rules.r1 "beautiful"
                    Expect.equal subject "iful" "should equal iful"
                testCase "beauty" <| fun _ ->
                    let subject = Rules.r1 "beauty"
                    Expect.equal subject "y" "should equal y"
                testCase "beaut" <| fun _ ->
                    let subject = Rules.r1 "beaut"
                    Expect.equal subject "" "should equal iful"
                testCase "beau" <| fun _ ->
                    let subject = Rules.r1 "beau"
                    Expect.equal subject "" "should equal iful"
                testCase "animadversion" <| fun _ ->
                    let subject = Rules.r1 "animadversion"
                    Expect.equal subject "imadversion" "should equal imadversion"
                testCase "arsenal" <| fun _ ->
                    let subject = Rules.r1 "arsenal"
                    Expect.equal subject "al" "should equal al"
                testCase "communication" <| fun _ ->
                    let subject = Rules.r1 "communication"
                    Expect.equal subject "ication" "should equal ication"
                testCase "generation" <| fun _ ->
                    let subject = Rules.r1 "generation"
                    Expect.equal subject "ation" "should equal ation"

            ]
            testList "isShort" [
                testCase "rap" <| fun _ ->
                    let subject = Rules.isShort "rap"
                    Expect.isTrue subject "isShort"
                testCase "trap" <| fun _ ->
                    let subject = Rules.isShort "trap"
                    Expect.isTrue subject "isShort"
                testCase "ow" <| fun _ ->
                    let subject = Rules.isShort "ow"
                    Expect.isTrue subject "isShort"
                testCase "on" <| fun _ ->
                    let subject = Rules.isShort "on"
                    Expect.isTrue subject "isShort"
                testCase "uproot" <| fun _ ->
                    let subject = Rules.isShort "uproot"
                    Expect.isFalse subject "is not Short"
                testCase "disturb" <| fun _ ->
                    let subject = Rules.isShort "disturb"
                    Expect.isFalse subject "is not Short"
                ]
            testList "replaceR1Suffix" [
                testCase """("sensational", "ational", "ate")""" <| fun _ ->
                    let subject = ("sensational" |> Rules.replaceR1Suffix "ational" "ate")
                    Expect.equal subject (Found("sensate")) "should be Found and equal sensate"
                testCase """("nationalism", "alism", "al")""" <| fun _ ->
                    let subject = ("nationalism" |> Rules.replaceR1Suffix "alism" "al")
                    Expect.equal subject (Found("national")) "should be Found and equal national"
                testCase """("nationalizer", "izer", "ize")""" <| fun _ ->
                    let subject = ("nationalizer" |> Rules.replaceR1Suffix "izer" "ize")
                    Expect.equal subject (Found("nationalize")) "should be Found and equal nationalize"
                testCase """("nationalli", "alli", "al")""" <| fun _ ->
                    let subject = ("nationalli" |> Rules.replaceR1Suffix "alli" "al")
                    Expect.equal subject (Found("national")) "should be Found and equal national"
            ]
        ]
