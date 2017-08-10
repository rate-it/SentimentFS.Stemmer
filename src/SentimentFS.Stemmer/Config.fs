namespace SentimentFS.Stemmer

type Alghorithm =
    | Porter

type Config = { alghorithm: Alghorithm }
