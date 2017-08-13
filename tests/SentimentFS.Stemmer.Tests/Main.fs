namespace SentimentFS.Stemmer.Tests

module Program =

    open Expecto

    [<EntryPoint>]
    let main argv =
        Tests.runTestsInAssembly defaultConfig argv
