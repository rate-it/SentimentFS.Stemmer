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
        ]
